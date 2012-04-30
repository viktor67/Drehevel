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
			this.components = new System.ComponentModel.Container();
			this.btnStartBuild = new System.Windows.Forms.Button();
			this.overallProgress = new System.Windows.Forms.ProgressBar();
			this.zipWorker = new System.ComponentModel.BackgroundWorker();
			this.statusText = new System.Windows.Forms.Label();
			this.fileProgress = new System.Windows.Forms.ProgressBar();
			this.btnCancelBuild = new System.Windows.Forms.Button();
			this.compressionSelector = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.uICompressionChoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.uICompressionChoiceBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStartBuild
			// 
			this.btnStartBuild.Location = new System.Drawing.Point(12, 12);
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
			this.overallProgress.Location = new System.Drawing.Point(12, 242);
			this.overallProgress.Name = "overallProgress";
			this.overallProgress.Size = new System.Drawing.Size(416, 23);
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
			this.statusText.Location = new System.Drawing.Point(12, 197);
			this.statusText.Name = "statusText";
			this.statusText.Size = new System.Drawing.Size(24, 13);
			this.statusText.TabIndex = 2;
			this.statusText.Text = "Idle";
			// 
			// fileProgress
			// 
			this.fileProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.fileProgress.Location = new System.Drawing.Point(12, 213);
			this.fileProgress.Name = "fileProgress";
			this.fileProgress.Size = new System.Drawing.Size(416, 23);
			this.fileProgress.TabIndex = 3;
			// 
			// btnCancelBuild
			// 
			this.btnCancelBuild.Enabled = false;
			this.btnCancelBuild.Location = new System.Drawing.Point(93, 12);
			this.btnCancelBuild.Name = "btnCancelBuild";
			this.btnCancelBuild.Size = new System.Drawing.Size(75, 23);
			this.btnCancelBuild.TabIndex = 4;
			this.btnCancelBuild.Text = "Cancel";
			this.btnCancelBuild.UseVisualStyleBackColor = true;
			this.btnCancelBuild.Click += new System.EventHandler(this.CancelBuild);
			// 
			// compressionSelector
			// 
			this.compressionSelector.DisplayMember = "Name";
			this.compressionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.compressionSelector.FormattingEnabled = true;
			this.compressionSelector.Location = new System.Drawing.Point(319, 14);
			this.compressionSelector.Name = "compressionSelector";
			this.compressionSelector.Size = new System.Drawing.Size(109, 21);
			this.compressionSelector.TabIndex = 5;
			this.compressionSelector.ValueMember = "Compression";
			this.compressionSelector.SelectedIndexChanged += new System.EventHandler(this.OnCompressionSelectionChange);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(246, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Compression";
			// 
			// uICompressionChoiceBindingSource
			// 
			this.uICompressionChoiceBindingSource.DataSource = typeof(Drehevel.UICompressionChoice);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 277);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.compressionSelector);
			this.Controls.Add(this.btnCancelBuild);
			this.Controls.Add(this.fileProgress);
			this.Controls.Add(this.statusText);
			this.Controls.Add(this.overallProgress);
			this.Controls.Add(this.btnStartBuild);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "MainForm";
			this.Text = "Drehevel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
			((System.ComponentModel.ISupportInitialize)(this.uICompressionChoiceBindingSource)).EndInit();
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
		private System.Windows.Forms.BindingSource uICompressionChoiceBindingSource;
		private System.Windows.Forms.Label label1;
	}
}

