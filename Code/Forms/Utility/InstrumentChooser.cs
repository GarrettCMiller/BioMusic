using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BioMusic.Code.Forms
{
	public partial class InstrumentChooser : Form
	{
		#region Properties

		public int CurrentInstrumentIndex
		{
			get { return this.comboBoxInstruments.SelectedIndex; }
		}

		public Midi.Instrument CurrentInstrument
		{
			get { return (Midi.Instrument)this.CurrentInstrumentIndex; }
		}

		#endregion

		#region Construction

		public InstrumentChooser()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods
				
		private void InstrumentChooser_Load(object sender, EventArgs e)
		{
			PopulateInstrumentList();
		}

		private void PopulateInstrumentList()
		{
			this.comboBoxInstruments.Items.AddRange(Enum.GetNames(typeof(Midi.Instrument)));
			this.comboBoxInstruments.SelectedIndex = 0;
		}
		
		private void comboBoxInstruments_SelectedIndexChanged(object sender, EventArgs e)
		{
			MIDIInterface.THIS.Out.SendProgramChange(Midi.Channel.Channel1, this.CurrentInstrument);
		}

		private void InstrumentChooser_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = true;
				this.Visible = false;
			}
		}

		#endregion
	}
}
