using System;
using System.Globalization;
using System.Windows.Forms;
using Drehevel.Properties;

namespace Drehevel.Launcher
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var culture = new CultureInfo(Settings.Default.Language);
			culture.UseOnCurrentThread();

			var instance = new BuilderForm();
			instance.Show();

			Application.Run();
		}
	}
}
