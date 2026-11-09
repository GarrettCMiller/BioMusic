using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;

using BioMusic.Code.MusicForms;

namespace BioMusic.Code.Forms
{
	public partial class PianoForm : Form
	{
		#region Static

		private static PianoForm mainInstance;

		public static PianoForm MainInstance
		{
			get { return mainInstance; }
		}
		
		#endregion

		#region Fields
		
		private bool playing = false;
		private bool closing = false;

		private int outDeviceID = 0;
		private OutputDevice outDevice;

		#endregion

		#region Construction
		
		public PianoForm()
		{
			InitializeComponent();
			mainInstance = this;
		}

		#endregion

		#region Properties

		public PianoControl Piano
		{
			get { return this.pianoControl1; }
		}

		protected int OutputDeviceID
		{
			get { return this.outDeviceID; }
			set
			{
				this.outDeviceID = value;

				if (this.OutputDevice != null)
					this.OutputDevice.Dispose();

				this.OutputDevice = new OutputDevice(this.outDeviceID);
			}
		}

		protected OutputDevice OutputDevice
		{
			get { return this.outDevice; }
			private set { this.outDevice = value; }
		}

		#endregion

		#region Methods

		#region Initialization

		protected override void OnLoad(EventArgs e)
		{
			if (OutputDevice.DeviceCount == 0)
			{
				MessageBox.Show("No MIDI output devices available.", "Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Stop);

				Close();
			}
			else
			{
				sequence1.LoadProgressChanged += HandleLoadProgressChanged;
				sequence1.LoadCompleted += HandleLoadCompleted;

				//SetOutputDevice();
			}

			base.OnLoad(e);
		}

		private void SetOutputDevice()
		{
			try
			{
				this.OutputDeviceID = (int)GeneralMidiInstrument.AcousticGrandPiano;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error!",
					MessageBoxButtons.OK, MessageBoxIcon.Stop);

				Close();
			}
		}

		#endregion

		#region Sequence loading

		private void HandleLoadProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			//toolStripProgressBar1.Value = e.ProgressPercentage;
		}

		private void HandleLoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.Cursor = Cursors.Arrow;
			//toolStripProgressBar1.Value = 0;

			if (e.Error == null)
			{
				//positionHScrollBar.Value = 0;
				//positionHScrollBar.Maximum = sequence1.GetLength();
			}
			else
			{
				MessageBox.Show(e.Error.Message);
			}
		}
		
		#endregion

		

		#region Events

		#region Key presses

		protected override void OnKeyDown(KeyEventArgs e)
		{
			pianoControl1.PressPianoKey(e.KeyCode);

			base.OnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			pianoControl1.ReleasePianoKey(e.KeyCode);

			base.OnKeyUp(e);
		}
		
		#endregion

		#region Form stuff

		protected override void OnClosing(CancelEventArgs e)
		{
			closing = true;

			base.OnClosing(e);
		}

		protected override void OnClosed(EventArgs e)
		{
			sequence1.Dispose();

			if (outDevice != null)
			{
				outDevice.Dispose();
			}

			base.OnClosed(e);
		}		

		#endregion

		#region MIDI messages

		private void HandleChannelMessagePlayed(object sender, ChannelMessageEventArgs e)
		{
			if (closing)
			{
				return;
			}

			outDevice.Send(e.Message);
			pianoControl1.Send(e.Message);
		}

		private void HandleChased(object sender, ChasedEventArgs e)
		{
			foreach (ChannelMessage message in e.Messages)
			{
				outDevice.Send(message);
			}
		}

		private void HandleSysExMessagePlayed(object sender, SysExMessageEventArgs e)
		{
			//outDevice.Send(e.Message); Sometimes causes an exception to be thrown because the output device is overloaded.
		}

		private void HandleStopped(object sender, StoppedEventArgs e)
		{
			foreach (ChannelMessage message in e.Messages)
			{
				outDevice.Send(message);
				pianoControl1.Send(message);
			}
		}

		private void HandlePlayingCompleted(object sender, EventArgs e)
		{
			timer1.Stop();
		}

		private void pianoControl1_PianoKeyDown(object sender, PianoKeyEventArgs e)
		{
			#region Guard

			if (playing)
			{
				return;
			}

			#endregion

			MIDIInterface.THIS.Out.SendNoteOn(Midi.Channel.Channel1, (Midi.Pitch)e.NoteID, 127);
			
			//outDevice.Send(new ChannelMessage(ChannelCommand.NoteOn, 0, e.NoteID, 127));
		}

		private void pianoControl1_PianoKeyUp(object sender, PianoKeyEventArgs e)
		{
			#region Guard

			if (playing)
			{
				return;
			}

			#endregion

			MIDIInterface.THIS.Out.SendNoteOff(Midi.Channel.Channel1, (Midi.Pitch)e.NoteID, 127);

			//outDevice.Send(new ChannelMessage(ChannelCommand.NoteOff, 0, e.NoteID, 0));
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//if (!scrolling)
			//{
			//    positionHScrollBar.Value = sequencer1.Position;
			//}
		}
		
		#endregion
		
		#endregion
		
		#endregion
	}
}
