namespace Drehevel
{
    partial class FileList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileList));
			this.lvFiles = new System.Windows.Forms.ListView();
			this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbQuickFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvFiles
			// 
			resources.ApplyResources(this.lvFiles, "lvFiles");
			this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Path});
			this.lvFiles.ContextMenuStrip = this.contextMenuStrip1;
			this.lvFiles.Name = "lvFiles";
			this.lvFiles.UseCompatibleStateImageBehavior = false;
			this.lvFiles.View = System.Windows.Forms.View.Details;
			// 
			// Path
			// 
			resources.ApplyResources(this.Path, "Path");
			// 
			// contextMenuStrip1
			// 
			resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInExplorerToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			// 
			// showInExplorerToolStripMenuItem
			// 
			resources.ApplyResources(this.showInExplorerToolStripMenuItem, "showInExplorerToolStripMenuItem");
			this.showInExplorerToolStripMenuItem.Name = "showInExplorerToolStripMenuItem";
			this.showInExplorerToolStripMenuItem.Click += new System.EventHandler(this.ShowInExplorer);
			// 
			// tbQuickFilter
			// 
			resources.ApplyResources(this.tbQuickFilter, "tbQuickFilter");
			this.tbQuickFilter.Name = "tbQuickFilter";
			this.tbQuickFilter.TextChanged += new System.EventHandler(this.OnFilterChange);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// FileList
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbQuickFilter);
			this.Controls.Add(this.lvFiles);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileList";
			this.Resize += new System.EventHandler(this.OnResize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.TextBox tbQuickFilter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showInExplorerToolStripMenuItem;
		private System.Windows.Forms.Label label1;
    }
}