namespace BioMusic.Code.Forms.Controls
{
	partial class MusicStructureViewer
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

		#region Component Designer generated code

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
			this.listView.Location = new System.Drawing.Point(3, 574);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(23, 23);
			this.listView.TabIndex = 0;
			this.listView.UseCompatibleStateImageBehavior = false;
			// 
			// MusicStructureViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoScrollMargin = new System.Drawing.Size(20, 20);
			this.Controls.Add(this.listView);
			this.DoubleBuffered = true;
			this.Name = "MusicStructureViewer";
			this.Size = new System.Drawing.Size(566, 600);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.MusicStructureViewer_Paint);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listView;
	}
}
