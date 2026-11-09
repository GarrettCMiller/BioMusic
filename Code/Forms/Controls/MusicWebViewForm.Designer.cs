namespace BioMusic.Code.Forms.Controls
{
	partial class MusicWebViewForm
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
			this.listView = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.AllowColumnReorder = true;
			this.listView.AllowDrop = true;
			this.listView.CheckBoxes = true;
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.LabelEdit = true;
			this.listView.Location = new System.Drawing.Point(12, 12);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(40, 33);
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			// 
			// MusicWebViewForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(404, 386);
			this.Controls.Add(this.listView);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.KeyPreview = true;
			this.Name = "MusicWebViewForm";
			this.ShowInTaskbar = false;
			this.Text = "MusicWebViewForm";
			this.Load += new System.EventHandler(this.MusicWebViewForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView;
	}
}