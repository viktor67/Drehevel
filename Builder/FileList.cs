﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Drehevel.Builder
{
	public partial class FileList : Form
	{
		private IEnumerable<FileInfo> _fileList;

		public FileList(IEnumerable<FileInfo> files)
		{
			InitializeComponent();
			_fileList = files;

			lvFiles.BeginUpdate();

			foreach(var file in _fileList)
				lvFiles.Items.Add(file.FullName);

			lvFiles.Columns[0].Width = lvFiles.Width - 32;

			lvFiles.EndUpdate();
		}

		/// <summary>
		/// Rebuilds the listview by the entered conditions. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilterChange(object sender, EventArgs e)
		{
			lvFiles.BeginUpdate();
			lvFiles.Items.Clear();

			// Specialised collections with poorly implemented AddRange funcs can fuck off
			foreach(var file in _fileList.Where(file => file.FullName.Contains(tbQuickFilter.Text)))
				lvFiles.Items.Add(file.FullName);

			lvFiles.EndUpdate();
		}
		/// <summary>
		/// Called once the User rightclicks inside the listview and selects "Show in Explorer..."
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowInExplorer(object sender, EventArgs e)
		{
			if(lvFiles.SelectedItems[0] == null)
				return;

			System.Diagnostics.Process.Start("explorer.exe", @"/select, " + lvFiles.SelectedItems[0].Text);

		}

		private void OnResize(object sender, EventArgs e)
		{
			lvFiles.Columns[0].Width = lvFiles.Width - 32;
		}
	}
}