namespace Drehevel
{
	partial class BuilderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuilderForm));
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
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.françaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deutschToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.norskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.中文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportAnIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sourceCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.projectFileSelector = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFileSelector = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStartBuild
			// 
			resources.ApplyResources(this.btnStartBuild, "btnStartBuild");
			this.btnStartBuild.Name = "btnStartBuild";
			this.btnStartBuild.UseVisualStyleBackColor = true;
			this.btnStartBuild.Click += new System.EventHandler(this.PreBuild);
			// 
			// overallProgress
			// 
			resources.ApplyResources(this.overallProgress, "overallProgress");
			this.overallProgress.Name = "overallProgress";
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
			resources.ApplyResources(this.statusText, "statusText");
			this.statusText.Name = "statusText";
			// 
			// fileProgress
			// 
			resources.ApplyResources(this.fileProgress, "fileProgress");
			this.fileProgress.Name = "fileProgress";
			// 
			// btnCancelBuild
			// 
			resources.ApplyResources(this.btnCancelBuild, "btnCancelBuild");
			this.btnCancelBuild.Name = "btnCancelBuild";
			this.btnCancelBuild.UseVisualStyleBackColor = true;
			this.btnCancelBuild.Click += new System.EventHandler(this.CancelBuild);
			// 
			// compressionSelector
			// 
			resources.ApplyResources(this.compressionSelector, "compressionSelector");
			this.compressionSelector.DisplayMember = "Name";
			this.compressionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.compressionSelector.FormattingEnabled = true;
			this.compressionSelector.Name = "compressionSelector";
			this.compressionSelector.ValueMember = "Compression";
			this.compressionSelector.SelectedIndexChanged += new System.EventHandler(this.OnCompressionSelectionChange);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// projectFolderSelector
			// 
			resources.ApplyResources(this.projectFolderSelector, "projectFolderSelector");
			this.projectFolderSelector.Name = "projectFolderSelector";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// btnProjectSelector
			// 
			resources.ApplyResources(this.btnProjectSelector, "btnProjectSelector");
			this.btnProjectSelector.Name = "btnProjectSelector";
			this.btnProjectSelector.UseVisualStyleBackColor = true;
			this.btnProjectSelector.Click += new System.EventHandler(this.FolderSelect);
			// 
			// menuStrip1
			// 
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
			this.menuStrip1.Name = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			// 
			// openToolStripMenuItem
			// 
			resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.LoadBuildSettings);
			// 
			// saveToolStripMenuItem
			// 
			resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveBuildSettings);
			// 
			// settingsToolStripMenuItem
			// 
			resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			// 
			// languageToolStripMenuItem
			// 
			resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.françaisToolStripMenuItem,
            this.deutschToolStripMenuItem,
            this.italianoToolStripMenuItem,
            this.norskToolStripMenuItem,
            this.中文ToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			// 
			// englishToolStripMenuItem
			// 
			resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
			this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			// 
			// françaisToolStripMenuItem
			// 
			resources.ApplyResources(this.françaisToolStripMenuItem, "françaisToolStripMenuItem");
			this.françaisToolStripMenuItem.Name = "françaisToolStripMenuItem";
			// 
			// deutschToolStripMenuItem
			// 
			resources.ApplyResources(this.deutschToolStripMenuItem, "deutschToolStripMenuItem");
			this.deutschToolStripMenuItem.Name = "deutschToolStripMenuItem";
			// 
			// italianoToolStripMenuItem
			// 
			resources.ApplyResources(this.italianoToolStripMenuItem, "italianoToolStripMenuItem");
			this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
			// 
			// norskToolStripMenuItem
			// 
			resources.ApplyResources(this.norskToolStripMenuItem, "norskToolStripMenuItem");
			this.norskToolStripMenuItem.Name = "norskToolStripMenuItem";
			// 
			// 中文ToolStripMenuItem
			// 
			resources.ApplyResources(this.中文ToolStripMenuItem, "中文ToolStripMenuItem");
			this.中文ToolStripMenuItem.Name = "中文ToolStripMenuItem";
			// 
			// aboutToolStripMenuItem
			// 
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportAnIssueToolStripMenuItem,
            this.sourceCodeToolStripMenuItem,
            this.aboutToolStripMenuItem1});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			// 
			// reportAnIssueToolStripMenuItem
			// 
			resources.ApplyResources(this.reportAnIssueToolStripMenuItem, "reportAnIssueToolStripMenuItem");
			this.reportAnIssueToolStripMenuItem.Name = "reportAnIssueToolStripMenuItem";
			// 
			// sourceCodeToolStripMenuItem
			// 
			resources.ApplyResources(this.sourceCodeToolStripMenuItem, "sourceCodeToolStripMenuItem");
			this.sourceCodeToolStripMenuItem.Name = "sourceCodeToolStripMenuItem";
			// 
			// aboutToolStripMenuItem1
			// 
			resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			// 
			// projectFileSelector
			// 
			resources.ApplyResources(this.projectFileSelector, "projectFileSelector");
			this.projectFileSelector.Name = "projectFileSelector";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// btnFileSelector
			// 
			resources.ApplyResources(this.btnFileSelector, "btnFileSelector");
			this.btnFileSelector.Name = "btnFileSelector";
			this.btnFileSelector.UseVisualStyleBackColor = true;
			this.btnFileSelector.Click += new System.EventHandler(this.OutputFileSelect);
			// 
			// BuilderForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
			this.Name = "BuilderForm";
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
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem françaisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deutschToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem norskToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
	}
}

