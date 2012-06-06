using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Drehevel.Builder;
using Drehevel.Properties;

namespace Drehevel
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
			Application.Run(new BuilderForm());
		}
	}
}
