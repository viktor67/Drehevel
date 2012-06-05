using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Drehevel.Builder
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			Process.Start("mailto:ruan@crytek.com");
		}
	}
}
