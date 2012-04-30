using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;

namespace Drehevel
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// The currently selected compression level.
		/// </summary>
		private CompressionLevel _compression;

		public MainForm()
		{
			InitializeComponent();

			// Create a list of human-readable compression choices
			var compressionChoices = new UICompressionChoice[]
			{
			    new UICompressionChoice("Highest", CompressionLevel.BestCompression),
				new UICompressionChoice("Balanced", CompressionLevel.Default),
				new UICompressionChoice("Fastest", CompressionLevel.BestSpeed),
				new UICompressionChoice("None", CompressionLevel.None)
			};

			compressionSelector.DataSource = compressionChoices;
			_compression = compressionChoices.First().Compression;
		}

		/// <summary>
		/// Called when the user starts a build.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartBuild(object sender, EventArgs e)
		{
			zipWorker.RunWorkerAsync();
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
			var dir = new DirectoryInfo(@"C:\Dev\CryENGINE3\");

			using(var archive = new ZipFile())
			{
				archive.CompressionLevel = _compression;
				archive.SaveProgress += this.OnZipProgression;

				// This magically fixes an issue for certain files, don't question it
				archive.CodecBufferSize = 10240000;

				var dirs = dir.GetDirectories("*", SearchOption.AllDirectories).ToList();
				dirs.Add(dir);

				foreach(var subdir in dirs)
				{
					var dirName = subdir.FullName.Replace(dir.FullName, "");

					// Inner loop
					foreach(var file in subdir.GetFiles().Where(file => !Restrictions.Extensions.Contains(file.Extension)))
					{
						var tempfile = archive.AddFile(file.FullName);
						tempfile.FileName = Path.Combine(dirName, file.Name);
					}
				}

				archive.Save(@"D:\output.zip");
			}
		}

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
						zipWorker.ReportProgress(100, new ProgressReport { Message = "Build finished!", Type = ProgressReportType.Finished });
					}
					break;
			}
		}

		private void OnCompressionSelectionChange(object sender, EventArgs e)
		{
			_compression = (CompressionLevel)compressionSelector.SelectedValue;
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
	}
}
