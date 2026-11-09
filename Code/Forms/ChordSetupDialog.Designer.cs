namespace BioMusic.Code.Forms
{
	partial class ChordSetupDialog
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBoxChordPattern = new System.Windows.Forms.ComboBox();
			this.groupBoxCustomPattern = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanelChordPattern = new System.Windows.Forms.TableLayoutPanel();
			this.labelPatternName = new System.Windows.Forms.Label();
			this.textBoxPatternName = new System.Windows.Forms.TextBox();
			this.labelPatternAscent = new System.Windows.Forms.Label();
			this.tableLayoutPanelPatternAscent = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxAscent0 = new System.Windows.Forms.MaskedTextBox();
			this.textBoxAscent1 = new System.Windows.Forms.MaskedTextBox();
			this.textBoxAscent2 = new System.Windows.Forms.MaskedTextBox();
			this.textBoxAscent3 = new System.Windows.Forms.MaskedTextBox();
			this.chordInversion = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBoxCustomPattern.SuspendLayout();
			this.tableLayoutPanelChordPattern.SuspendLayout();
			this.tableLayoutPanelPatternAscent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chordInversion)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.63158F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.36842F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(277, 183);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBoxCustomPattern);
			this.groupBox1.Controls.Add(this.comboBoxChordPattern);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(271, 126);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Pattern";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chordInversion);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(3, 135);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(271, 45);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Inversion";
			// 
			// comboBoxChordPattern
			// 
			this.comboBoxChordPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxChordPattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxChordPattern.FormattingEnabled = true;
			this.comboBoxChordPattern.Items.AddRange(new object[] {
            "Major",
            "Minor",
            "Seventh",
            "Augmented",
            "Diminished",
            "Custom..."});
			this.comboBoxChordPattern.Location = new System.Drawing.Point(7, 17);
			this.comboBoxChordPattern.Name = "comboBoxChordPattern";
			this.comboBoxChordPattern.Size = new System.Drawing.Size(256, 21);
			this.comboBoxChordPattern.TabIndex = 0;
			this.comboBoxChordPattern.SelectedIndexChanged += new System.EventHandler(this.comboBoxChordPattern_SelectedIndexChanged);
			// 
			// groupBoxCustomPattern
			// 
			this.groupBoxCustomPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxCustomPattern.Controls.Add(this.tableLayoutPanelChordPattern);
			this.groupBoxCustomPattern.Location = new System.Drawing.Point(6, 45);
			this.groupBoxCustomPattern.Name = "groupBoxCustomPattern";
			this.groupBoxCustomPattern.Size = new System.Drawing.Size(259, 74);
			this.groupBoxCustomPattern.TabIndex = 1;
			this.groupBoxCustomPattern.TabStop = false;
			this.groupBoxCustomPattern.Text = "Custom";
			// 
			// tableLayoutPanelChordPattern
			// 
			this.tableLayoutPanelChordPattern.ColumnCount = 2;
			this.tableLayoutPanelChordPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.36759F));
			this.tableLayoutPanelChordPattern.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.63241F));
			this.tableLayoutPanelChordPattern.Controls.Add(this.labelPatternAscent, 0, 1);
			this.tableLayoutPanelChordPattern.Controls.Add(this.labelPatternName, 0, 0);
			this.tableLayoutPanelChordPattern.Controls.Add(this.textBoxPatternName, 1, 0);
			this.tableLayoutPanelChordPattern.Controls.Add(this.tableLayoutPanelPatternAscent, 1, 1);
			this.tableLayoutPanelChordPattern.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelChordPattern.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanelChordPattern.Name = "tableLayoutPanelChordPattern";
			this.tableLayoutPanelChordPattern.RowCount = 2;
			this.tableLayoutPanelChordPattern.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.37931F));
			this.tableLayoutPanelChordPattern.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58.62069F));
			this.tableLayoutPanelChordPattern.Size = new System.Drawing.Size(253, 55);
			this.tableLayoutPanelChordPattern.TabIndex = 0;
			// 
			// labelPatternName
			// 
			this.labelPatternName.AutoSize = true;
			this.labelPatternName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelPatternName.Location = new System.Drawing.Point(3, 0);
			this.labelPatternName.Name = "labelPatternName";
			this.labelPatternName.Size = new System.Drawing.Size(43, 22);
			this.labelPatternName.TabIndex = 0;
			this.labelPatternName.Text = "Name";
			this.labelPatternName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBoxPatternName
			// 
			this.textBoxPatternName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxPatternName.Location = new System.Drawing.Point(52, 3);
			this.textBoxPatternName.Name = "textBoxPatternName";
			this.textBoxPatternName.Size = new System.Drawing.Size(198, 20);
			this.textBoxPatternName.TabIndex = 1;
			// 
			// labelPatternAscent
			// 
			this.labelPatternAscent.AutoSize = true;
			this.labelPatternAscent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelPatternAscent.Location = new System.Drawing.Point(3, 22);
			this.labelPatternAscent.Name = "labelPatternAscent";
			this.labelPatternAscent.Size = new System.Drawing.Size(43, 33);
			this.labelPatternAscent.TabIndex = 2;
			this.labelPatternAscent.Text = "Ascent";
			this.labelPatternAscent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tableLayoutPanelPatternAscent
			// 
			this.tableLayoutPanelPatternAscent.ColumnCount = 4;
			this.tableLayoutPanelPatternAscent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelPatternAscent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelPatternAscent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelPatternAscent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanelPatternAscent.Controls.Add(this.textBoxAscent3, 3, 0);
			this.tableLayoutPanelPatternAscent.Controls.Add(this.textBoxAscent2, 2, 0);
			this.tableLayoutPanelPatternAscent.Controls.Add(this.textBoxAscent1, 1, 0);
			this.tableLayoutPanelPatternAscent.Controls.Add(this.textBoxAscent0, 0, 0);
			this.tableLayoutPanelPatternAscent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelPatternAscent.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
			this.tableLayoutPanelPatternAscent.Location = new System.Drawing.Point(52, 25);
			this.tableLayoutPanelPatternAscent.Name = "tableLayoutPanelPatternAscent";
			this.tableLayoutPanelPatternAscent.RowCount = 1;
			this.tableLayoutPanelPatternAscent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelPatternAscent.Size = new System.Drawing.Size(198, 27);
			this.tableLayoutPanelPatternAscent.TabIndex = 3;
			// 
			// textBoxAscent0
			// 
			this.textBoxAscent0.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxAscent0.Enabled = false;
			this.textBoxAscent0.Location = new System.Drawing.Point(3, 3);
			this.textBoxAscent0.Mask = "#0";
			this.textBoxAscent0.Name = "textBoxAscent0";
			this.textBoxAscent0.Size = new System.Drawing.Size(43, 20);
			this.textBoxAscent0.TabIndex = 0;
			this.textBoxAscent0.Text = "0";
			this.textBoxAscent0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxAscent1
			// 
			this.textBoxAscent1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxAscent1.Location = new System.Drawing.Point(52, 3);
			this.textBoxAscent1.Mask = "#0";
			this.textBoxAscent1.Name = "textBoxAscent1";
			this.textBoxAscent1.Size = new System.Drawing.Size(43, 20);
			this.textBoxAscent1.TabIndex = 1;
			this.textBoxAscent1.Text = "0";
			this.textBoxAscent1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxAscent2
			// 
			this.textBoxAscent2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxAscent2.Location = new System.Drawing.Point(101, 3);
			this.textBoxAscent2.Mask = "#0";
			this.textBoxAscent2.Name = "textBoxAscent2";
			this.textBoxAscent2.Size = new System.Drawing.Size(43, 20);
			this.textBoxAscent2.TabIndex = 2;
			this.textBoxAscent2.Text = "0";
			this.textBoxAscent2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBoxAscent3
			// 
			this.textBoxAscent3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxAscent3.Location = new System.Drawing.Point(150, 3);
			this.textBoxAscent3.Mask = "#0";
			this.textBoxAscent3.Name = "textBoxAscent3";
			this.textBoxAscent3.Size = new System.Drawing.Size(45, 20);
			this.textBoxAscent3.TabIndex = 3;
			this.textBoxAscent3.Text = "0";
			this.textBoxAscent3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// chordInversion
			// 
			this.chordInversion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chordInversion.Location = new System.Drawing.Point(3, 16);
			this.chordInversion.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.chordInversion.Name = "chordInversion";
			this.chordInversion.Size = new System.Drawing.Size(265, 20);
			this.chordInversion.TabIndex = 0;
			this.chordInversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.75336F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.24664F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 223);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.btnCancel, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnApply, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 192);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(278, 28);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCancel.Location = new System.Drawing.Point(3, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(133, 22);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnApply
			// 
			this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnApply.Location = new System.Drawing.Point(142, 3);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(133, 22);
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// ChordSetupDialog
			// 
			this.AcceptButton = this.btnApply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 223);
			this.Controls.Add(this.tableLayoutPanel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChordSetupDialog";
			this.ShowInTaskbar = false;
			this.Text = "Chord Setup";
			this.Load += new System.EventHandler(this.ChordSetupDialog_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChordSetupDialog_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBoxCustomPattern.ResumeLayout(false);
			this.tableLayoutPanelChordPattern.ResumeLayout(false);
			this.tableLayoutPanelChordPattern.PerformLayout();
			this.tableLayoutPanelPatternAscent.ResumeLayout(false);
			this.tableLayoutPanelPatternAscent.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chordInversion)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboBoxChordPattern;
		private System.Windows.Forms.GroupBox groupBoxCustomPattern;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChordPattern;
		private System.Windows.Forms.Label labelPatternAscent;
		private System.Windows.Forms.Label labelPatternName;
		private System.Windows.Forms.TextBox textBoxPatternName;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPatternAscent;
		private System.Windows.Forms.MaskedTextBox textBoxAscent0;
		private System.Windows.Forms.MaskedTextBox textBoxAscent3;
		private System.Windows.Forms.MaskedTextBox textBoxAscent2;
		private System.Windows.Forms.MaskedTextBox textBoxAscent1;
		private System.Windows.Forms.NumericUpDown chordInversion;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
	}
}