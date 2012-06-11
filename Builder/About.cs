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
			label4.Click += (sender, args) => { Process.Start("mailto:ruan@crytek.com"); };
			label13.Click += (sender, args) => { Process.Start("mailto:lavizh@gmail.com"); };
		}
	}
}
