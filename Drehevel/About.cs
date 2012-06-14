using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Drehevel
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
			label4.Click += (sender, args) => Process.Start("mailto:ruan@crytek.com");
			label3.Click += (sender, args) => Process.Start(@"https://github.com/returnString/Drehevel#credits/");
		}
	}
}
