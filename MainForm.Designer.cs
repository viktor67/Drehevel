namespace Drehevel
{
	partial class MainForm
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
			if(disposing && (components != null))
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
			this.btnStartBuild = new System.Windows.Forms.Button();
			this.overallProgress = new System.Windows.Forms.ProgressBar();
			this.zipWorker = new System.ComponentModel.BackgroundWorker();
			this.statusText = new System.Windows.Forms.Label();
			this.fileProgress = new System.Windows.Forms.ProgressBar();
			this.btnCancelBuild = new System.Windows.Forms.Button();
			this.compressionSelector = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.projectFolderSelector = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnProjectSelector = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportAnIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.projectFileSelector = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFileSelector = new System.Windows.Forms.Button();
			this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStartBuild
			// 
			this.btnStartBuild.Location = new System.Drawing.Point(12, 152);
			this.btnStartBuild.Name = "btnStartBuild";
			this.btnStartBuild.Size = new System.Drawing.Size(75, 23);
			this.btnStartBuild.TabIndex = 0;
			this.btnStartBuild.Text = "Start Build";
			this.btnStartBuild.UseVisualStyleBackColor = true;
			this.btnStartBuild.Click += new System.EventHandler(this.StartBuild);
			// 
			// overallProgress
			// 
			this.overallProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.overallProgress.Location = new System.Drawing.Point(12, 258);
			this.overallProgress.Name = "overallProgress";
			this.overallProgress.Size = new System.Drawing.Size(417, 23);
			this.overallProgress.TabIndex = 1;
			// 
			// zipWorker
			// 
			this.zipWorker.WorkerReportsProgress = true;
			this.zipWorker.WorkerSupportsCancellation = true;
			this.zipWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoWork);
			this.zipWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnWorkerProgression);
			// 
			// statusText
			// 
			this.statusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.statusText.AutoSize = true;
			this.statusText.Location = new System.Drawing.Point(12, 213);
			this.statusText.Name = "statusText";
			this.statusText.Size = new System.Drawing.Size(24, 13);
			this.statusText.TabIndex = 2;
			this.statusText.Text = "Idle";
			// 
			// fileProgress
			// 
			this.fileProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fileProgress.Location = new System.Drawing.Point(12, 229);
			this.fileProgress.Name = "fileProgress";
			this.fileProgress.Size = new System.Drawing.Size(417, 23);
			this.fileProgress.TabIndex = 3;
			// 
			// btnCancelBuild
			// 
			this.btnCancelBuild.Enabled = false;
			this.btnCancelBuild.Location = new System.Drawing.Point(93, 152);
			this.btnCancelBuild.Name = "btnCancelBuild";
			this.btnCancelBuild.Size = new System.Drawing.Size(75, 23);
			this.btnCancelBuild.TabIndex = 4;
			this.btnCancelBuild.Text = "Cancel";
			this.btnCancelBuild.UseVisualStyleBackColor = true;
			this.btnCancelBuild.Click += new System.EventHandler(this.CancelBuild);
			// 
			// compressionSelector
			// 
			this.compressionSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.compressionSelector.DisplayMember = "Name";
			this.compressionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.compressionSelector.FormattingEnabled = true;
			this.compressionSelector.Location = new System.Drawing.Point(310, 154);
			this.compressionSelector.Name = "compressionSelector";
			this.compressionSelector.Size = new System.Drawing.Size(119, 21);
			this.compressionSelector.TabIndex = 5;
			this.compressionSelector.ValueMember = "Compression";
			this.compressionSelector.SelectedIndexChanged += new System.EventHandler(this.OnCompressionSelectionChange);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(234, 157);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Compression:";
			// 
			// projectFolderSelector
			// 
			this.projectFolderSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.projectFolderSelector.Location = new System.Drawing.Point(12, 57);
			this.projectFolderSelector.Name = "projectFolderSelector";
			this.projectFolderSelector.Size = new System.Drawing.Size(309, 20);
			this.projectFolderSelector.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Project Location";
			// 
			// btnProjectSelector
			// 
			this.btnProjectSelector.Location = new System.Drawing.Point(324, 54);
			this.btnProjectSelector.Name = "btnProjectSelector";
			this.btnProjectSelector.Size = new System.Drawing.Size(105, 23);
			this.btnProjectSelector.TabIndex = 9;
			this.btnProjectSelector.Text = "Select Folder";
			this.btnProjectSelector.UseVisualStyleBackColor = true;
			this.btnProjectSelector.Click += new System.EventHandler(this.FolderSelect);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(441, 24);
			this.menuStrip1.TabIndex = 10;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.LoadBuildSettings);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveBuildSettings);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportAnIssueToolStripMenuItem,
            this.sourceCodeToolStripMenuItem,
            this.aboutToolStripMenuItem1});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.aboutToolStripMenuItem.Text = "Help";
			// 
			// reportAnIssueToolStripMenuItem
			// 
			this.reportAnIssueToolStripMenuItem.Name = "reportAnIssueToolStripMenuItem";
			this.reportAnIssueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.reportAnIssueToolStripMenuItem.Text = "Forum Thread";
			this.reportAnIssueToolStripMenuItem.Click += new System.EventHandler(this.ShowForumThread);
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.ShowAboutBox);
			// 
			// projectFileSelector
			// 
			this.projectFileSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.projectFileSelector.Location = new System.Drawing.Point(12, 98);
			this.projectFileSelector.Name = "projectFileSelector";
			this.projectFileSelector.Size = new System.Drawing.Size(309, 20);
			this.projectFileSelector.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "Output File";
			// 
			// btnFileSelector
			// 
			this.btnFileSelector.Location = new System.Drawing.Point(324, 95);
			this.btnFileSelector.Name = "btnFileSelector";
			this.btnFileSelector.Size = new System.Drawing.Size(105, 23);
			this.btnFileSelector.TabIndex = 13;
			this.btnFileSelector.Text = "Select File";
			this.btnFileSelector.UseVisualStyleBackColor = true;
			this.btnFileSelector.Click += new System.EventHandler(this.OutputFileSelect);
			// 
			// sourceCodeToolStripMenuItem
			// 
			this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
			this.sourceCodeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.sourceCodeToolStripMenuItem.Text = "Source Code";
			this.sourceCodeToolStripMenuItem.Click += new System.EventHandler(this.ShowSourceCode);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 293);
			this.Controls.Add(this.btnFileSelector);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.projectFileSelector);
			this.Controls.Add(this.btnProjectSelector);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.projectFolderSelector);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.compressionSelector);
			this.Controls.Add(this.btnCancelBuild);
			this.Controls.Add(this.fileProgress);
			this.Controls.Add(this.statusText);
			this.Controls.Add(this.overallProgress);
			this.Controls.Add(this.btnStartBuild);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Drehevel - CryENGINE3 Build Tool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStartBuild;
		private System.Windows.Forms.ProgressBar overallProgress;
		private System.ComponentModel.BackgroundWorker zipWorker;
		private System.Windows.Forms.Label statusText;
		private System.Windows.Forms.ProgressBar fileProgress;
		private System.Windows.Forms.Button btnCancelBuild;
		private System.Windows.Forms.ComboBox compressionSelector;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox projectFolderSelector;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnProjectSelector;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.TextBox projectFileSelector;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnFileSelector;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem reportAnIssueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sourceCodeToolStripMenuItem;
	}
}

