namespace BioMusic.Code.Forms
{
	partial class InstrumentChooser
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
			this.comboBoxInstruments = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// comboBoxInstruments
			// 
			this.comboBoxInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxInstruments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxInstruments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxInstruments.FormattingEnabled = true;
			this.comboBoxInstruments.Location = new System.Drawing.Point(13, 13);
			this.comboBoxInstruments.MaxDropDownItems = 12;
			this.comboBoxInstruments.Name = "comboBoxInstruments";
			this.comboBoxInstruments.Size = new System.Drawing.Size(267, 21);
			this.comboBoxInstruments.TabIndex = 0;
			this.comboBoxInstruments.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstruments_SelectedIndexChanged);
			// 
			// InstrumentChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 49);
			this.Controls.Add(this.comboBoxInstruments);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InstrumentChooser";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Select an Instrument";
			this.Load += new System.EventHandler(this.InstrumentChooser_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstrumentChooser_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxInstruments;
	}
}