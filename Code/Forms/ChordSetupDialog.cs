using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BioMusic.Code.Forms
{
	public partial class ChordSetupDialog : Form
	{
		#region Fields

		#endregion

		#region Properties

		public Midi.ChordPattern Pattern
		{
			get
			{
				if (this.comboBoxChordPattern.SelectedIndex == this.comboBoxChordPattern.Items.Count)
					return new Midi.ChordPattern(this.textBoxPatternName.Text, "Cstm", this.Ascent, this.LetterAscent);
				else
					return Midi.Chord.Patterns[this.comboBoxChordPattern.SelectedIndex];
			}
		}

		public int[] Ascent
		{
			get
			{
				return new int[]
				{
					int.Parse(this.textBoxAscent0.Text),
					int.Parse(this.textBoxAscent1.Text),
					int.Parse(this.textBoxAscent2.Text),
					int.Parse(this.textBoxAscent3.Text)
				};
			}
		}

		public int[] LetterAscent
		{
			get { return new int[] { 0 }; }
		}

		public int Inversion
		{
			get { return (int)this.chordInversion.Value; }
		}

		#endregion

		#region Construction

		public ChordSetupDialog()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods

		private void ChordSetupDialog_Load(object sender, EventArgs e)
		{
			int patternIndex = 0;

			this.comboBoxChordPattern.SelectedIndex = 0;

			SetupPreExistingChordPattern();
		}

		private void SetupPreExistingChordPattern()
		{
			int patternIndex = this.comboBoxChordPattern.SelectedIndex;

			if (patternIndex < Midi.Chord.Patterns.Length)
			{
				Midi.ChordPattern tempPattern = Midi.Chord.Patterns[patternIndex];

				this.textBoxPatternName.Text = tempPattern.Name;

				this.textBoxAscent0.Text = tempPattern.Ascent[0].ToString();
				this.textBoxAscent1.Text = tempPattern.Ascent[1].ToString();

				if (tempPattern.Ascent.Length > 2)
				{
					this.textBoxAscent2.Text = tempPattern.Ascent[2].ToString();

					if (tempPattern.Ascent.Length > 3)
						this.textBoxAscent3.Text = tempPattern.Ascent[3].ToString();
					else
						this.textBoxAscent3.Text = "";
				}
				else
					this.textBoxAscent2.Text = "";
			}
			else
			{
				this.textBoxPatternName.Text = "Custom";
			}
		}

		private void ChordSetupDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		private void comboBoxChordPattern_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.groupBoxCustomPattern.Enabled = (this.comboBoxChordPattern.SelectedIndex == this.comboBoxChordPattern.Items.Count - 1);
			SetupPreExistingChordPattern();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Hide();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			SetMusicBaseProperties();

			Hide();
		}

		private void SetMusicBaseProperties()
		{
			MusicForms.MusicFormBase.ClassDefaults.ChordPattern = this.Pattern;
			MusicForms.MusicFormBase.ClassDefaults.ChordInversion = this.Inversion;
		}

		#endregion
	}
}
