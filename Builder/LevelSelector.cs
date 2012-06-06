using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Drehevel.Builder
{
	public partial class LevelSelector : Form
	{
		private BuilderForm _owner;

		/// <summary>
		/// Initialises a new LevelSelector instance with the specified owner.
		/// </summary>
		/// <param name="owner"></param>
		public LevelSelector(BuilderForm owner, IEnumerable<DirectoryInfo> levels)
		{
			InitializeComponent();
			_owner = owner;

			lbLevels.Items.Clear();
			lbLevels.Items.AddRange(levels.ToArray());

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
				// We send across items which aren't checked to be excluded
				var uncheckedItems = from level in lbLevels.Items.Cast<DirectoryInfo>()
									 where !lbLevels.CheckedItems.Contains(level)
									 select level;

				var uncheckedWithSubdirs = uncheckedItems.ToList();

				// Fixes an issue where excluded dirs still had subdirs included
				foreach(var item in uncheckedItems)
					uncheckedWithSubdirs.AddRange(item.GetDirectories("*", SearchOption.AllDirectories));

				// Return control to the owner form
				_owner.StartBuild(uncheckedWithSubdirs);
				Close();
			};

			btnCancel.Click += (sender, args) =>
			{
				Close();
			};
		}
	}
}
