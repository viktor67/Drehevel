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

	public static class Restrictions
	{
		public static string[] Extensions
		{
			get
			{
				return new string[]
				{
					".bak",
					".cry"
				};
			}
		}

		public static string[] Folders
		{
			get
			{
				return new string[]
				{
					"Tools"
				};
			}
		}
	}
}