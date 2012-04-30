using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using Ionic.Zip;
using Ionic.Zlib;
using System.Diagnostics;

namespace Drehevel
{
	public partial class MainForm : Form
	{
		private CompressionLevel _compression;
		/// <summary>
		/// The currently selected compression level.
		/// </summary>
		private CompressionLevel Compression
		{
			get
			{
				return _compression;
			}
			set
			{
				_compression = value;
				compressionSelector.SelectedIndex = BuildSettings.CompressionChoices.ToList().FindIndex(compression => compression.Compression == value);
			}
		}

		public MainForm()
		{
			InitializeComponent();

			compressionSelector.DataSource = BuildSettings.CompressionChoices;
			Compression = BuildSettings.CompressionChoices.First().Compression;
		}

		/// <summary>
		/// Called when the user starts a build.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartBuild(object sender, EventArgs e)
		{
			zipWorker.RunWorkerAsync(projectFolderSelector.Text);
		}

		/// <summary>
		/// Called when the user cancels a build.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CancelBuild(object sender, EventArgs e)
		{
			zipWorker.CancelAsync();
		}

		/// <summary>
		/// Called when the worker sends a progress report.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnWorkerProgression(object sender, ProgressChangedEventArgs e)
		{
			var progressReport = (ProgressReport)e.UserState;

			if(!string.IsNullOrEmpty(progressReport.Message))
				statusText.Text = progressReport.Message;

			switch(progressReport.Type)
			{
				case ProgressReportType.ArchiveUpdate:
					overallProgress.Value = e.ProgressPercentage;
					break;

				case ProgressReportType.FileUpdate:
					fileProgress.Value = e.ProgressPercentage;
					break;

				case ProgressReportType.Startup:
					overallProgress.Maximum = progressReport.Max;
					btnStartBuild.Enabled = false;
					btnCancelBuild.Enabled = true;
					break;

				case ProgressReportType.Aborted:
				case ProgressReportType.Finished:
					fileProgress.Value = 0;
					overallProgress.Value = 0;
					btnStartBuild.Enabled = true;
					btnCancelBuild.Enabled = false;
					break;
			}
		}

		/// <summary>
		/// Controls file sorting and archive creation.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoWork(object sender, DoWorkEventArgs e)
		{
			var dirPath = e.Argument as string;

			if(string.IsNullOrEmpty(dirPath))
			{
				e.Cancel = true;
				return;
			}

			var dir = new DirectoryInfo(dirPath);

			using(var archive = new ZipFile())
			{
				archive.CompressionLevel = Compression;
				archive.SaveProgress += this.OnZipProgression;

				// This magically fixes an issue for certain files, don't question it
				archive.CodecBufferSize = 10240000;

				var dirs = new List<DirectoryInfo>();
				dirs.Add(dir);

				foreach(var subdir in dir.GetDirectories("*", SearchOption.AllDirectories))
				{
					if(subdir.GetFiles().Any(file => FileSorting.RequiredFiles.Contains(file.Name)))
					{
						dirs.Add(subdir);
						continue;
					}
					else if(FileSorting.BannedFolders.Any(folder => subdir.FullName.Contains(folder)))
						continue;
					else
						dirs.Add(subdir);
				}

				foreach(var subdir in dirs)
				{
					var dirName = subdir.FullName.Replace(dir.FullName, "");

					// Inner loop
					foreach(var file in subdir.GetFiles().Where(file => !FileSorting.BannedExtensions.Contains(file.Extension) && !FileSorting.BannedFiles.Contains(file.Name)
						&& (!FileSorting.BannedFolders.Any(folder => subdir.FullName.Contains(folder)) || FileSorting.RequiredFiles.Contains(file.Name))))
					{
						var tempfile = archive.AddFile(file.FullName);
						tempfile.FileName = Path.Combine(dirName, file.Name);
					}
				}

				archive.Save(projectFileSelector.Text);
			}
		}

		private Stopwatch _stopwatch;

		/// <summary>
		/// Called when the archiver sends a progress report.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnZipProgression(object sender, SaveProgressEventArgs e)
		{
			if(_stopwatch == null)
			{
				_stopwatch = new Stopwatch();
				_stopwatch.Start();
			}

			// Cancellation is handled via request, not outright closing
			if(zipWorker.CancellationPending)
			{
				e.Cancel = true;
				zipWorker.ReportProgress(0, new ProgressReport { Type = ProgressReportType.Aborted, Message = "Build aborted!" });
				return;
			}

			switch(e.EventType)
			{
				// FIXME: This is mildly inefficient but ZipProgressEventType.Saving_Started doesn't seem to contain the total
				case ZipProgressEventType.Saving_BeforeWriteEntry:
					{
						zipWorker.ReportProgress(0, new ProgressReport { Max = e.EntriesTotal, Type = ProgressReportType.Startup });
					}
					break;

				// Update the status text and overall progress bar
				case ZipProgressEventType.Saving_AfterWriteEntry:
					{
						zipWorker.ReportProgress(e.EntriesSaved,
							new ProgressReport { Message = string.Format("Processing file {0}/{1} ({2})", e.EntriesSaved, e.EntriesTotal, e.CurrentEntry.FileName.Split('/').Last()), Type = ProgressReportType.ArchiveUpdate });
					}
					break;

				// Update the per-file progress bar
				case ZipProgressEventType.Saving_EntryBytesRead:
					{
						zipWorker.ReportProgress((int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer),
							new ProgressReport { Type = ProgressReportType.FileUpdate });
					}
					break;

				// Send a message to say that the build is complete
				case ZipProgressEventType.Saving_Completed:
					{
						zipWorker.ReportProgress(100, new ProgressReport { Message = string.Format("Build finished in {0:0.00}s!", _stopwatch.Elapsed.TotalSeconds), Type = ProgressReportType.Finished });
					}
					break;
			}
		}

		private void OnCompressionSelectionChange(object sender, EventArgs e)
		{
			Compression = (CompressionLevel)compressionSelector.SelectedValue;
		}

		/// <summary>
		/// Called when a request to close the form is made.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFormClose(object sender, FormClosingEventArgs e)
		{
			// Could leave temp files if not properly cancelled, so we force the user to cancel it
			// Better than assuming the user hasn't accidentally misclicked
			if(zipWorker.IsBusy)
			{
				MessageBox.Show("Please cancel the build before exiting the application.", "Build in progress!");
				e.Cancel = true;
			}
		}

		private string SavePath
		{
			get
			{
				var savePath = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "Builds");

				if(!Directory.Exists(savePath))
					Directory.CreateDirectory(savePath);
				
				return savePath;
			}
		}

		private void LoadBuildSettings(object sender, EventArgs e)
		{
			var fileDialog = new OpenFileDialog();
			fileDialog.InitialDirectory = SavePath;
			fileDialog.Filter = "Build settings (*.xml)|*.xml";

			var loader = new XmlSerializer(typeof(BuildSettings));

			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				using(var stream = fileDialog.OpenFile())
				{
					var settings = loader.Deserialize(stream) as BuildSettings;
					Compression = settings.Compression;
					projectFolderSelector.Text = settings.ProjectFolder;
					projectFileSelector.Text = settings.OutputName;
				}
			}
		}

		private void SaveBuildSettings(object sender, EventArgs e)
		{
			var fileDialog = new SaveFileDialog();
			fileDialog.InitialDirectory = SavePath;
			fileDialog.Filter = "Build settings (*.xml)|*.xml";

			var saver = new XmlSerializer(typeof(BuildSettings));

			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				using(var stream = fileDialog.OpenFile())
				{
					var buildfile = new BuildSettings { Compression = Compression, OutputName = projectFileSelector.Text, ProjectFolder = projectFolderSelector.Text };
					saver.Serialize(stream, buildfile);
				}
			}
		}

		private void FolderSelect(object sender, EventArgs e)
		{
			var folderDialog = new FolderBrowserDialog();

			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				projectFolderSelector.Text = folderDialog.SelectedPath;
			}
		}

		private void OutputFileSelect(object sender, EventArgs e)
		{
			var fileDialog = new SaveFileDialog();
			fileDialog.Filter = "Zip archive (*.zip)|*.zip";

			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				projectFileSelector.Text = fileDialog.FileName;
			}
		}

		private void ShowAboutBox(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void ShowForumThread(object sender, EventArgs e)
		{
			Process.Start("http://www.crydev.net/viewtopic.php?f=311&t=89643");
		}

		private void ShowSourceCode(object sender, EventArgs e)
		{
			Process.Start("https://github.com/returnString/Drehevel/");
		}
	}
}
