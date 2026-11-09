using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sanford.Multimedia.Midi.UI;
using Midi;

namespace BioMusic.Code//.MIDI_Interface
{
	public class MIDIInterface
	{
		#region STATIC

		private static MIDIInterface singletonInstance;

		public static MIDIInterface THIS
		{
			get
			{
				if (singletonInstance == null)
					singletonInstance = new MIDIInterface();
				return singletonInstance;
			}
		}

		#endregion
		
		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Enums

		#endregion

		#region Delegates

		#endregion

		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Fields

		private OutputDevice defaultOutputDevice;
		private InputDevice defaultInputDevice;

		private OutputDeviceDialog outDialog = new OutputDeviceDialog();

		#endregion

		#region Properties

		public OutputDevice Out
		{
			get { return this.DefaultOutputDevice; }
		}

		public OutputDevice DefaultOutputDevice
		{
			get { return defaultOutputDevice; }
			protected set { defaultOutputDevice = value; }
		}

		public InputDevice DefaultInputDevice
		{
			get { return defaultInputDevice; }
			protected set { defaultInputDevice = value; }
		}

		public Instrument CurrentInstrument
		{
			get { return Instrument.AcousticGrandPiano; }
		}

		public bool OutputDeviceIsOpen
		{
			get { return defaultOutputDevice.IsOpen; }
		}

		#endregion

		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Construction

		protected MIDIInterface()
		{
			CreateDefaultOutputDevice();
		}

		#endregion

		///////////////////////////////////////////////////////////////////

		#region Methods

		#region Device creation

		protected void CreateDefaultOutputDevice()
		{
			CreateDefaultOutputDevice(true);
		}

		protected void CreateDefaultOutputDevice(bool bOpenNow)
		{
			#region Safety
			
			if (OutputDevice.InstalledDevices.Count == 0)
				throw new ApplicationException("No MIDI output devices found!");

			#endregion

			this.DefaultOutputDevice = OutputDevice.InstalledDevices[0];

			if (bOpenNow)
				this.DefaultOutputDevice.Open();

			this.DefaultOutputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
		}

		#endregion

		#region Cleanup

		protected virtual void Cleanup()
		{
			outDialog.Dispose();
		}

		#endregion

		#region Output device Choice

		public void ChooseOutputDevice()
		{
			throw new NotImplementedException();
			//if (this.outDialog.ShowDialog(this) == DialogResult.OK)
				//this.outDeviceID = this.outDialog.OutputDeviceID;
		}

		#endregion

		#endregion

		///////////////////////////////////////////////////////////////////
		///////////////////////////////////////////////////////////////////

		#region Indexers

		#endregion

		#region Events

		#endregion
	}
}
