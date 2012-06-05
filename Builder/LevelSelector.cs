using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Drehevel.Builder
{
	public partial class LevelSelector : Form
	{
		private BuilderForm _owner;

		public LevelSelector(BuilderForm owner)
		{
			InitializeComponent();

			_owner = owner;

			btnAll.Click += (sender, args) =>
			{
				for(int i = 0; i < lbLevels.Items.Count; i++)
					lbLevels.SetItemChecked(i, true);
			};

			btnNone.Click += (sender, args) =>
			{
				for(int i = 0; i < lbLevels.Items.Count; i++)
					lbLevels.SetItemChecked(i, false);
			};

			btnOK.Click += (sender, args) =>
			{
				var uncheckedItems = from level in lbLevels.Items.Cast<DirectoryInfo>()
									 where !lbLevels.CheckedItems.Contains(level)
									 select level;

				var uncheckedWithSubdirs = uncheckedItems.ToList();

				foreach(var item in uncheckedItems)
					uncheckedWithSubdirs.AddRange(item.GetDirectories("*", SearchOption.AllDirectories));

				_owner.StartBuild(uncheckedWithSubdirs);
				Close();
			};
		}

		public void DisplayLevels(IEnumerable<DirectoryInfo> levels)
		{
			lbLevels.Items.Clear();
			lbLevels.Items.AddRange(levels.ToArray());
		}
	}
}
