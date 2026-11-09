namespace BioMusic.Code.Forms
{
	partial class StructureChooser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureChooser));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.treeViewStructures = new System.Windows.Forms.TreeView();
			this.imageListMusicIcons = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.buttonOK, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.buttonCancel, 1, 0);
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 194);
			this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(1);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(282, 27);
			this.tableLayoutPanel.TabIndex = 1;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOK.Location = new System.Drawing.Point(1, 1);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(1);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(139, 25);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonCancel.Location = new System.Drawing.Point(142, 1);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(1);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(139, 25);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// treeViewStructures
			// 
			this.treeViewStructures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeViewStructures.CheckBoxes = true;
			this.treeViewStructures.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
			this.treeViewStructures.HideSelection = false;
			this.treeViewStructures.HotTracking = true;
			this.treeViewStructures.Location = new System.Drawing.Point(1, 1);
			this.treeViewStructures.Name = "treeViewStructures";
			this.treeViewStructures.Size = new System.Drawing.Size(280, 193);
			this.treeViewStructures.TabIndex = 2;
			this.treeViewStructures.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewStructures_NodeMouseDoubleClick);
			this.treeViewStructures.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewStructures_AfterCheck);
			this.treeViewStructures.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewStructures_DrawNode);
			this.treeViewStructures.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeViewStructures_NodeMouseHover);
			this.treeViewStructures.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewStructures_NodeMouseClick);
			this.treeViewStructures.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewStructures_BeforeCheck);
			// 
			// imageListMusicIcons
			// 
			this.imageListMusicIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMusicIcons.ImageStream")));
			this.imageListMusicIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListMusicIcons.Images.SetKeyName(0, "WholeNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(1, "HalfNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(2, "QuarterNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(3, "EighthNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(4, "SixteenthNote.jpg");
			this.imageListMusicIcons.Images.SetKeyName(5, "Sharp.jpg");
			this.imageListMusicIcons.Images.SetKeyName(6, "Flat.jpg");
			this.imageListMusicIcons.Images.SetKeyName(7, "TrebleClef.jpg");
			this.imageListMusicIcons.Images.SetKeyName(8, "BassClef.jpg");
			this.imageListMusicIcons.Images.SetKeyName(9, "KeySignature.jpg");
			this.imageListMusicIcons.Images.SetKeyName(10, "BarLine.jpg");
			this.imageListMusicIcons.Images.SetKeyName(11, "DoubleBar.jpg");
			this.imageListMusicIcons.Images.SetKeyName(12, "BoldDoubleBar.jpg");
			this.imageListMusicIcons.Images.SetKeyName(13, "BlankStaffWithTrebleClef.jpg");
			// 
			// StructureChooser
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(282, 220);
			this.Controls.Add(this.treeViewStructures);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StructureChooser";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "StructureChooser";
			this.tableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TreeView treeViewStructures;
		private System.Windows.Forms.ImageList imageListMusicIcons;
	}
}