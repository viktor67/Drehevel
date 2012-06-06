namespace Drehevel.Builder
{
	partial class LevelSelector
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnNone = new System.Windows.Forms.Button();
			this.btnAll = new System.Windows.Forms.Button();
			this.lbLevels = new System.Windows.Forms.CheckedListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(207, 185);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "Start Build";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnNone
			// 
			this.btnNone.Location = new System.Drawing.Point(93, 185);
			this.btnNone.Name = "btnNone";
			this.btnNone.Size = new System.Drawing.Size(75, 23);
			this.btnNone.TabIndex = 2;
			this.btnNone.Text = "Select None";
			this.btnNone.UseVisualStyleBackColor = true;
			// 
			// btnAll
			// 
			this.btnAll.Location = new System.Drawing.Point(12, 185);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(75, 23);
			this.btnAll.TabIndex = 3;
			this.btnAll.Text = "Select All";
			this.btnAll.UseVisualStyleBackColor = true;
			// 
			// lbLevels
			// 
			this.lbLevels.CheckOnClick = true;
			this.lbLevels.FormattingEnabled = true;
			this.lbLevels.Location = new System.Drawing.Point(12, 12);
			this.lbLevels.Name = "lbLevels";
			this.lbLevels.Size = new System.Drawing.Size(351, 154);
			this.lbLevels.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(288, 185);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// LevelSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 220);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lbLevels);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LevelSelector";
			this.Text = "Select Levels";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnNone;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.CheckedListBox lbLevels;
		private System.Windows.Forms.Button btnCancel;
	}
}