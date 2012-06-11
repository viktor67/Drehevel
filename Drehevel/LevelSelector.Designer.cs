namespace Drehevel
{
	partial class LevelSelectorForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LevelSelectorForm));
			this.btnOK = new System.Windows.Forms.Button();
			this.btnNone = new System.Windows.Forms.Button();
			this.btnAll = new System.Windows.Forms.Button();
			this.lbLevels = new System.Windows.Forms.CheckedListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.Name = "btnOK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnNone
			// 
			resources.ApplyResources(this.btnNone, "btnNone");
			this.btnNone.Name = "btnNone";
			this.btnNone.UseVisualStyleBackColor = true;
			// 
			// btnAll
			// 
			resources.ApplyResources(this.btnAll, "btnAll");
			this.btnAll.Name = "btnAll";
			this.btnAll.UseVisualStyleBackColor = true;
			// 
			// lbLevels
			// 
			resources.ApplyResources(this.lbLevels, "lbLevels");
			this.lbLevels.CheckOnClick = true;
			this.lbLevels.FormattingEnabled = true;
			this.lbLevels.Name = "lbLevels";
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// LevelSelectorForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lbLevels);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LevelSelectorForm";
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