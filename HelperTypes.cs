using Ionic.Zlib;

namespace Drehevel
{
	public struct ProgressReport
	{
		public string Message { get; set; }
		public ProgressReportType Type { get; set; }
		public int Max { get; set; }
	}

	public enum ProgressReportType
	{
		Startup,
		FileUpdate,
		ArchiveUpdate,
		Finished,
		Aborted
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
		public static UICompressionChoice[] CompressionChoices =
		{
			new UICompressionChoice("Highest", CompressionLevel.BestCompression),
			new UICompressionChoice("Balanced", CompressionLevel.Default),
			new UICompressionChoice("Fastest", CompressionLevel.BestSpeed),
			new UICompressionChoice("None", CompressionLevel.None)
		};
	}

	public static class FileSorting
	{
		public static string[] BannedExtensions = 
		{
			".bak",
			".cry",
			".max",
			".psd",
			".log"
		};

		public static string[] BannedFolders =
		{
			"Tools",
			"Editor",
			"Code",
			"LogBackups",
			"statoscope",
			"BinTemp",
			"USER"
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
			"luac.out"
		};
	}
}