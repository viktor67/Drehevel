using System.Collections.Generic;
using System.IO;
using Ionic.Zlib;

namespace Drehevel.Builder
{
	public class WorkArguments
	{
		public DirectoryInfo RootDirectory { get; set; }
		public IEnumerable<DirectoryInfo> ExcludedLevels { get; set; }
	}

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
}