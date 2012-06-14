using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using Drehevel.Properties;
using Ionic.Zip;
using Ionic.Zlib;

namespace Drehevel
{
	public partial class BuilderForm : Form
	{
		private bool falseClose;

		public BuilderForm()
		{
			InitializeComponent();

			compressionSelector.DataSource = BuildSettings.CompressionChoices;
			Compression = BuildSettings.CompressionChoices.First().Compression;

			aboutToolStripMenuItem1.Click += (sender, args) =>
				new AboutForm().ShowDialog();

			reportAnIssueToolStripMenuItem.Click += (sender, args) =>
				Process.Start("http://www.crydev.net/viewtopic.php?f=311&t=89643");

			sourceCodeToolStripMenuItem.Click += (sender, args) =>
				Process.Start("https://github.com/returnString/Drehevel/");

			var languageMenuItems = languageToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>();

			foreach(var languageMenu in languageMenuItems)
				languageMenu.Click += OnLanguageChange;
		}

		private void OnLanguageChange(object sender, EventArgs e)
		{
			var lang = (sender as ToolStripMenuItem).Text;
			var culture = CultureInfo.GetCultures(CultureTypes.AllCultures).First(
				cult => string.Equals(cult.NativeName, lang, StringComparison.InvariantCultureIgnoreCase));

			culture.UseOnCurrentThread();

			Settings.Default.Language = culture.TwoLetterISOLanguageName;
			Settings.Default.Save();

			var newForm = new BuilderForm();
			newForm.Show();
			newForm.Location = Location;

			falseClose = true;
			Close();
		}

		/// <summary>
		/// Called when the user starts a build.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PreBuild(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(projectFolderSelector.Text) || string.IsNullOrEmpty(projectFileSelector.Text))
			{
				MessageBox.Show(Resources.EmptyOptionsMessage, Resources.EmptyOptionsTitle);
				return;
			}

			var rootDir = new DirectoryInfo(projectFolderSelector.Text);
			var levelRoot = new DirectoryInfo(Path.Combine(rootDir.FullName, "Game", "Levels"));

			// Game\Levels can be optionally organised by gamerules, i.e. Singleplayer\Forest
			// To fix this, we search for the .cry file
			var filteredLevelDirs = from levelDir in levelRoot.GetDirectories("*", SearchOption.AllDirectories)
									where levelDir.GetFiles().Any(file => file.Extension == ".cry")
									select levelDir;

			var levelSelector = new LevelSelectorForm(this, filteredLevelDirs);
			levelSelector.ShowDialog();
		}

		/// <summary>
		/// Starts a build.
		/// </summary>
		/// <param name="excludedLevels">The levels to be excluded from the build.</param>
		public void StartBuild(IEnumerable<DirectoryInfo> excludedLevels)
		{
			zipWorker.RunWorkerAsync(new WorkArguments
			{
				RootDirectory = new DirectoryInfo(projectFolderSelector.Text),
				ExcludedLevels = excludedLevels
			});
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
				case ProgressReportType.FileListReady:
					var list = new FileList(_ignoredFiles);
					list.Show();
					break;

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

					if(progressReport.Type == ProgressReportType.Finished)
						Process.Start("explorer.exe", "/select, " + projectFileSelector.Text);
					break;
			}
		}

		private IEnumerable<string> _ignoredFiles;

		/// <summary>
		/// Controls file sorting and archive creation.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoWork(object sender, DoWorkEventArgs e)
		{
			var culture = new CultureInfo(Settings.Default.Language);
			Thread.CurrentThread.CurrentUICulture = culture;
			Thread.CurrentThread.CurrentCulture = culture;

			var arguments = e.Argument as WorkArguments;

			using(var archive = new ZipFile())
			{
				archive.CompressionLevel = Compression;
				archive.SaveProgress += this.OnZipProgression;

				// This magically fixes an issue for certain files, don't question it
				archive.CodecBufferSize = 10240000;

				var dirs = new List<DirectoryInfo>();
				dirs.Add(arguments.RootDirectory);

				// We always want dirs with a required file inside, so shortcircuit that
				// After that, grab folders which aren't excluded levels, editor dirs or banned folders
				var availableDirs = from subdir in arguments.RootDirectory.GetDirectories("*", SearchOption.AllDirectories)
									where subdir.GetFiles().Any(file => FileSorting.RequiredFiles.Contains(file.Name))
										|| (!arguments.ExcludedLevels.Any(level => level.FullName == subdir.FullName)
											&& !subdir.Name.Contains("_editor")
											&& !FileSorting.BannedFolders.Any(folder => subdir.FullName.Contains(folder)))
									select subdir;

				dirs.AddRange(availableDirs);

				var _usedFiles = new List<FileInfo>();
				_ignoredFiles = new List<string>();

				foreach(var subdir in dirs)
				{
					var dirName = subdir.FullName.Replace(arguments.RootDirectory.FullName, "");

					// We only want files which aren't on the banned extension or name lists
					var files = from file in subdir.GetFiles()
								where !FileSorting.BannedExtensions.Contains(file.Extension)
									&& !FileSorting.BannedFiles.Contains(file.Name)
									&& (!FileSorting.BannedFolders.Any(folder => subdir.FullName.Contains(folder))
										|| FileSorting.RequiredFiles.Contains(file.Name))
								select file;

					// Remap names for proper relative hierarchy inside the archive
					// Otherwise we get horrible full path replication
					foreach(var file in files)
					{
						var tempfile = archive.AddFile(file.FullName);
						tempfile.FileName = Path.Combine(dirName, file.Name);
						_usedFiles.Add(file);
					}
				}

				var fileNames = from file in arguments.RootDirectory.GetFiles("*", SearchOption.AllDirectories)
								select file.FullName;

				var usedNames = from file in _usedFiles
								select file.FullName;

				_ignoredFiles = fileNames.Except(usedNames);

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
			// Cancellation is handled via request, not outright closing
			if(zipWorker.CancellationPending)
			{
				e.Cancel = true;
				zipWorker.ReportProgress(0, new ProgressReport { Type = ProgressReportType.Aborted, Message = Resources.BuildAborted });
				return;
			}

			switch(e.EventType)
			{
				// Technically doesn't include the filtering time but that's a meagre ~60ms on my machine and I can't be arsed to listen for the read event
				case ZipProgressEventType.Saving_Started:
					{
						zipWorker.ReportProgress(0, new ProgressReport { Type = ProgressReportType.FileListReady });
						_stopwatch = new Stopwatch();
						_stopwatch.Start();
					}
					break;

				// FIXME: This is mildly inefficient but ZipProgressEventType.Saving_Started doesn't seem to contain the total
				case ZipProgressEventType.Saving_BeforeWriteEntry:
					{
						zipWorker.ReportProgress(0,
							new ProgressReport { Max = e.EntriesTotal, Type = ProgressReportType.Startup });
					}
					break;

				// Update the status text and overall progress bar
				case ZipProgressEventType.Saving_AfterWriteEntry:
					{
						zipWorker.ReportProgress(e.EntriesSaved,
							new ProgressReport
							{
								Message = string.Format(Resources.ProcessingFile, e.EntriesSaved, e.EntriesTotal, e.CurrentEntry.FileName.Split('/').Last()),
								Type = ProgressReportType.ArchiveUpdate
							});
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
						zipWorker.ReportProgress(100,
							new ProgressReport { Message = string.Format(Resources.BuildFinished, _stopwatch.Elapsed.TotalSeconds), Type = ProgressReportType.Finished });
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
				MessageBox.Show(Resources.CancelBeforeQuitMessage, Resources.CancelBeforeQuitTitle);
				e.Cancel = true;
			}

			// Can't distinguish between UI close calls and manual ones
			if(!falseClose)
				Application.Exit();

			Settings.Default.Save();
		}

		/// <summary>
		/// Gets the Builds folder for the application
		/// </summary>
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

		private string DialogMessage
		{
			get { return string.Format("{0} (*.xml)|*.xml", Resources.BuildSettings); }
		}

		/// <summary>
		/// Loads the build settings from an .xml file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadBuildSettings(object sender, EventArgs e)
		{
			var fileDialog = new OpenFileDialog();
			fileDialog.InitialDirectory = SavePath;
			fileDialog.Filter = DialogMessage;

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

		/// <summary>
		/// Saves the build settings to an .xml file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveBuildSettings(object sender, EventArgs e)
		{
			var fileDialog = new SaveFileDialog();
			fileDialog.InitialDirectory = SavePath;
			fileDialog.Filter = DialogMessage;

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

		/// <summary>
		/// Used to assign the project base path.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FolderSelect(object sender, EventArgs e)
		{
			var folderDialog = new FolderBrowserDialog();

			if(folderDialog.ShowDialog() == DialogResult.OK)
			{
				projectFolderSelector.Text = folderDialog.SelectedPath;
			}
		}

		/// <summary>
		/// Used to assign the output file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OutputFileSelect(object sender, EventArgs e)
		{
			var fileDialog = new SaveFileDialog();
			fileDialog.Filter = string.Format("{0} (*.zip)|*.zip", Resources.ZipArchive);

			if(fileDialog.ShowDialog() == DialogResult.OK)
			{
				projectFileSelector.Text = fileDialog.FileName;
			}
		}

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
	}
}
