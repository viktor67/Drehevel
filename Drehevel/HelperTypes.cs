using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading;
using Drehevel.Properties;
using Ionic.Zlib;

namespace Drehevel
{
	/// <summary>
	/// Arguments as required by the archiver thread.
	/// </summary>
	public class WorkArguments
	{
		/// <summary>
		/// The root directory of the project.
		/// </summary>
		public DirectoryInfo RootDirectory { get; set; }

		/// <summary>
		/// The list of excluded levels as determined by the level selector form.
		/// </summary>
		public IEnumerable<DirectoryInfo> ExcludedLevels { get; set; }
	}

	/// <summary>
	/// A message sent from the archiver thread back to the GUI thread.
	/// </summary>
	public struct ProgressReport
	{
		/// <summary>
		/// The message to be displayed with the progress bar.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The type of update that has been sent.
		/// </summary>
		public ProgressReportType Type { get; set; }

		/// <summary>
		/// The total number of files found.
		/// </summary>
		public int Max { get; set; }
	}

	/// <summary>
	/// The type of message sent in a progress report.
	/// </summary>
	public enum ProgressReportType
	{
		Startup,
		FileUpdate,
		ArchiveUpdate,
		Finished,
		Aborted,
		FileListReady
	}

	public class UICompressionChoice
	{
		public CompressionLevel Compression { get; set; }
		public string Name { get; set; }

		public UICompressionChoice(string name, CompressionLevel level)
		{
			this.Compression = level;
			this.Name = name;
		}
	}

	public class BuildSettings
	{
		public string ProjectFolder { get; set; }
		public string OutputName { get; set; }
		public CompressionLevel Compression { get; set; }

		// Create a list of human-readable compression choices
		public static List<UICompressionChoice> CompressionChoices
		{
			get
			{
				return new List<UICompressionChoice>()
				{
					new UICompressionChoice(RuntimeMessages.DefaultCompression, CompressionLevel.Default),
					new UICompressionChoice(RuntimeMessages.HighCompression, CompressionLevel.BestCompression),
					new UICompressionChoice(RuntimeMessages.FastCompression, CompressionLevel.BestSpeed),
					new UICompressionChoice(RuntimeMessages.NoCompression, CompressionLevel.None),
				};
			}
		}
	}

	public static class FileSorting
	{
		public static string[] BannedExtensions = 
		{
			".bak",
			".bak2",
			".cry",
			".max",
			".psd",
			".log",
			".lib",
			".pdb",
			".exp"
		};

		public static string[] BannedFolders =
		{
			"Tools",
			"Editor",
			"Code",
			"LogBackups",
			"statoscope",
			"BinTemp",
			"USER",
			"rc"
		};

		public static string[] RequiredFiles =
		{
			"CryDevLogin.exe"
		};

		public static string[] BannedFiles =
		{
			"Editor.exe",
			"error.bmp",
			"error.dmp",
			"luac.out",
			"tags.txt"
		};
	}

	public static class CultureHelper
	{
		public static void UseOnCurrentThread(this CultureInfo culture)
		{
			Thread.CurrentThread.CurrentUICulture = culture;
			Thread.CurrentThread.CurrentCulture = culture;
		}
	}
}