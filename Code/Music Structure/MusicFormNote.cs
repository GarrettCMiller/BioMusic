using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Sanford.Multimedia;
//using Sanford.Multimedia.Midi;

using Midi;

using BioMusic.Code.Forms;
using BioMusic.Code.FSM;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class NoteArray : MusicFormList<MusicFormNote>
	{
		public NoteArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormNote this[int index]
		{
			get { return (MusicFormNote)base[index]; }
		}

		public MusicFormNote this[string name]
		{
			get { return (MusicFormNote)base[name]; }
		}
	}

	[Serializable()]
	public class NoteChord
	{
		#region Fields

		private Note note;
		private Chord chord;

		#endregion

		#region Construction

		public NoteChord()
		{
			this.Note = new Note('C');
		}

		public NoteChord(Note note)
		{
			this.Note = note;
		}

		public NoteChord(Chord chord)
		{
			this.Chord = chord;
		}

		#endregion

		#region Conversion

		public static implicit operator Note(NoteChord nc)
		{
			return nc.Note;
		}

		public static implicit operator Chord(NoteChord nc)
		{
			return nc.Chord;
		}

		public static implicit operator NoteChord(Note nc)
		{
			return new NoteChord(nc);
		}

		public static implicit operator NoteChord(Chord nc)
		{
			return new NoteChord(nc);
		}

		#endregion

		#region Properties

		public bool IsNote
		{
			get { return (note != null); }
		}

		public bool IsChord
		{
			get { return (chord != null); }			
		}

		public Note Note
		{
			get { return this.note; }
			set { this.note = value; }
		}

		public Chord Chord
		{
			get { return this.chord; }
			set { this.chord = value; }
		}

		#endregion
	}

	[Serializable()]
	public class MusicFormNote : MusicFormBase
	{
		#region Fields

		protected bool bIsRestNote = false;
		
		protected NoteChord notePitch;
		protected NoteLength noteLength = NoteLength.Quarter;
		protected COctave noteOctave = COctave.C3;
		protected byte noteVelocity = 0;

		private double msTime = -1;

		protected System.Timers.Timer timer;

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Note; }
		}

		public override int NumSections
		{
			get { return 0; }
		}

		public override int NumPhrases
		{
			get { return 0; }
		}

		public override int NumMeasures
		{
			get { return 0; }
		}

		public override int NumMotifs
		{
			get { return 0; }
		}

		public override int NumCells
		{
			get { return 0; }
		}

		public override int NumNotes
		{
			get { return 0; }
		}

		public bool IsRestNote
		{
			get { return bIsRestNote; }
			protected set { bIsRestNote = value; }
		}

		public MusicFormCell Parent
		{
			get { return (MusicFormCell)parent; }
			protected set { parent = value; }
		}

		public NoteLength Length
		{
			get { return noteLength; }
			set { noteLength = value; }
		}

		public Note Pitch
		{
			get { return notePitch; }
			set { notePitch = value; }
		}

		public Chord Chord
		{
			get { return notePitch; }
			set { notePitch = value; }
		}

		public COctave Octave
		{
			get { return noteOctave; }
			protected set { noteOctave = value; }
		}

		public System.Timers.Timer Timer
		{
			get { return timer; }
			protected set { timer = value; }
		}

		public override double MsLength
		{
			get { return msTime; }
			protected set { msTime = value; }
		}

		#endregion

		#region Construction

		public MusicFormNote(MusicFormCell parentCell, bool bRestNote, NoteLength length, string name)
			: base(parentCell, name)
		{
			this.Parent = parentCell;
			this.Length = length;
			this.IsRestNote = bRestNote;

			this.Octave = this.Properties.RootOctave;

			InitTimer();
		}

		#region Rest Notes

		/// <summary>
		/// Creates a quarter rest note.
		/// </summary>
		/// <param name="parentCell"></param>
		/// <param name="name"></param>
		public MusicFormNote(MusicFormCell parentCell, string name)
			: base(parentCell, name)
		{
			this.Parent = parentCell;
			this.Length = NoteLength.Quarter;
			this.IsRestNote = true;

			InitTimer();
		}

		#endregion

		#region Regular Notes

		/// <summary>
		/// Create a quarter note of the specified pitch.
		/// </summary>
		/// <param name="parentCell"></param>
		/// <param name="pitch"></param>
		/// <param name="name"></param>
		public MusicFormNote(MusicFormCell parentCell, Note pitch, string name)
			: base(parentCell, name)
		{
			this.Parent = parentCell;
			this.Length = NoteLength.Quarter;
			this.Pitch = pitch;

			InitTimer();
		}

		/// <summary>
		/// Create a note of the specified pitch and length.
		/// </summary>
		/// <param name="parentCell"></param>
		/// <param name="length"></param>
		/// <param name="pitch"></param>
		/// <param name="name"></param>
		public MusicFormNote(MusicFormCell parentCell, NoteLength length, Note pitch, string name)
			: base(parentCell, name)
		{
			this.Parent = parentCell;
			this.Length = length;
			this.Pitch = pitch;

			InitTimer();
		}

		/// <summary>
		/// Creates a note of the specified pitch and length, in
		/// the specified octave.
		/// </summary>
		/// <param name="parentCell"></param>
		/// <param name="length"></param>
		/// <param name="pitch"></param>
		/// <param name="octave"></param>
		/// <param name="name"></param>
		public MusicFormNote(MusicFormCell parentCell, NoteLength length, Note pitch, COctave octave, string name)
			: base(parentCell, name)
		{
			this.Parent = parentCell;
			this.Length = length;
			this.Pitch = pitch;
			this.Octave = octave;

			InitTimer();
		}

		#endregion

		#region Utility

		private void InitTimer()
		{
			this.MsLength = GetMSTime();

			this.Timer = new System.Timers.Timer(this.MsLength);
			this.Timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
		}

		public double GetMSTime()
		{
			return GetMSTime(this.Length);
		}

		public double GetMSTime(NoteLength note)
		{
			double noteToBeat = ((float)this.Properties.Denominator / (int)note);
			noteToBeat /= (this.Properties.Tempo / 60.0);			

			return (1000 * noteToBeat);
		}

		void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			Stop();
		}

		#endregion

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormNote note)
		{
			return new MusicListEntry(note);
		}

		#region MusicFormBase implementation

		public override void Create()
		{
			Randomize();
		}

		public override void Randomize()
		{
			//Plus 1 for the octave note
			int noteIndex = this.Random.Next(this.Properties.RootScale.NoteCount + 1);

			if (noteIndex == this.Properties.RootScale.NoteCount)
			{
				this.Pitch = this.Properties.RootScale.Tonic;
				this.Octave++;
			}
			else
			{
				this.Pitch = this.Properties.RootScale[noteIndex];

				if (noteIndex > 0)
				{
					if (this.Pitch.PositionInOctave <= this.Properties.RootScale.Tonic.PositionInOctave)
						this.Octave++;
				}
			}

			if (this.Random.NextDouble() < this.Properties.ChordChance)
			{
				ChordPattern pattern = this.Properties.ChordPattern;
				int inversion = this.Properties.ChordInversion;

				//switch (this.Random.Next(4))
				//{
				//    case 0: pattern = Chord.Augmented; break;
				//    case 1: pattern = Chord.Diminished; break;
				//    case 2: pattern = Chord.Major; break;
				//    case 3: pattern = Chord.Minor; break;
				//    default: throw new ApplicationException("NO!");
				//}

				//inversion = Random.Next(3);

				this.Chord = new Chord(this.Pitch, pattern, inversion);
			}
		}

		private int PianoKey()
		{
			int octAdjust = (int)this.Octave;

			int key = 0;
			
			if (this.notePitch.IsChord)
				key = (int)this.Chord.Root.PitchAtOrBelow(this.Chord.Root.PitchInOctave(octAdjust) - 1);
			else
				key = (int)this.Pitch.PitchInOctave(octAdjust);

			if (key > PianoForm.MainInstance.Piano.HighNoteID ||
				key < PianoForm.MainInstance.Piano.LowNoteID)
				throw new ArgumentOutOfRangeException("Piano key out of range!");
			
			return key;
		}

		public override void Play()
		{
			if (!this.IsRestNote)
			{
				int root = this.PianoKey();

				if (this.notePitch.IsChord)
				{					
					if (this.Chord.Pattern.Ascent.Length < 3)
						throw new ApplicationException();

					foreach (int note in this.Chord.Pattern.Ascent)
						PressPianoKey(root + note);
				}
				else
					PressPianoKey(root);
			}

			this.Timer.Start();
			this.Playing = true;
		}

		private static void PressPianoKey(int root)
		{
			if (root > PianoForm.MainInstance.Piano.HighNoteID ||
				root < PianoForm.MainInstance.Piano.LowNoteID)
				return;

			PianoForm.MainInstance.Piano.PressPianoKey(root);
		}

		public override void Stop()
		{
			this.Playing = false;
			this.Timer.Stop();

			//MIDIInterface.THIS.DefaultOutputDevice.SendNoteOff(Midi.Channel.Channel1, (Midi.Pitch)this.PianoKey(), 127);

			if (!this.IsRestNote)
			{
				int root = this.PianoKey();

				if (this.notePitch.IsChord)
				{
					foreach (int note in this.Chord.Pattern.Ascent)
						ReleasePianoKey(root + note);
				}
				else
					ReleasePianoKey(root);
			}
		}

		private static void ReleasePianoKey(int root)
		{
			if (root > PianoForm.MainInstance.Piano.HighNoteID ||
				root < PianoForm.MainInstance.Piano.LowNoteID)
				return;

			PianoForm.MainInstance.Piano.ReleasePianoKey(root);
		}

		#endregion

		#endregion

		#region FractalStateMachine overrides

		public override FSMResult SMS_Update(object[] arrArgs)
		{
			return this.Playing ? FSMResult.Success : FSMResult.Fail;
		}

		#endregion
	}
}
