using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class CellArray : MusicFormList<MusicFormCell>
	{
		public CellArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormCell this[int index]
		{
			get { return (MusicFormCell)base[index]; }
		}

		public MusicFormCell this[string name]
		{
			get { return (MusicFormCell)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormCell : MusicFormBase
	{
		#region Fields

		public static readonly NoteLength MaxLength = NoteLength.Whole;
		public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected int nTotalLength = 0;
		protected NoteLength officialLength;
		protected float fTotalLength = 0.0f;

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Cell; }
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

		public MusicFormMotif Parent
		{
			get { return (MusicFormMotif)parent; }
			protected set { parent = value; }
		}

		public NoteLength LengthInWholeNotes
		{
			get { return officialLength; }
			protected set { officialLength = value; }
		}

		public NoteLength TempLength
		{
			set
			{
				fTotalLength += 1.0f / (int)value;
				//this.Parent.TempLength += value;

				foreach (NoteLength length in Enum.GetValues(typeof(NoteLength)))
				{
					if (fTotalLength >= (int)length)
					{
						this.LengthInWholeNotes = length;
						return;
					}
				}
			}
		}

		public override int NumNotes
		{
			get { return this.Notes.Count; }
		}

		public NoteArray Notes
		{
			get { return (NoteArray)children; }
			protected set { children = value; }
		}

		public override double MsLength
		{
			get 
			{
				double sum = 0.0;
				foreach (MusicFormNote note in this.Notes)
					sum += note.MsLength;
				return sum;
			}

			protected set { }
		}

		#endregion

		#region Construction

		public MusicFormCell(MusicFormMotif parent, string name)
			: base(parent, name)
		{
			this.children = new NoteArray(true);
		}

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormCell cell)
		{
			return new MusicListEntry(cell);
		}

		public void AddNote(MusicFormNote note)
		{
			//if (note.LengthInWholeNotes > MaxLength)
			//    throw new ArgumentOutOfRangeException("Note cannot be longer than the cell!");//NoteValueTooLongException();

			this.Notes.Add(note);
			
			note.SMS_Initialize();

			this.LengthInWholeNotes += (int)note.Length;
		}

		public void Create(NoteLength length, NoteLength numNotes)
		{
			if (length < MaxLength)
				throw new ArgumentOutOfRangeException("Length cannot be greater than the length of the cell!");

			for (int i = 0; i < (int)numNotes; i++)
			{
				bool bRestNote = false;
				string name = "Note " + i;
				MusicFormNote newNote;

				float restChance = this.Properties.RestNoteChance;
				//Rest note
				if (restChance > 0.0f && this.Random.NextDouble() <= restChance)
				{
					bRestNote = true;
					name = "Rest " + i;
				}

				NoteLength newLength = (NoteLength)((int)(numNotes) * ((int)length));
				
				newNote = new MusicFormNote(this, bRestNote, newLength, name);

				if (!bRestNote)
					newNote.Randomize();

				AddNote(newNote);
			}
		}

		public void CreateByLength(NoteLength maxLength)
		{
			int max = (int)this.Properties.SmallestNoteValue,
				min = (int)this.Properties.LargestNoteValue;

			NoteLength numNotes = maxLength;

			if (max == min)
				numNotes = (NoteLength)(1 << min);
			else
				numNotes = (NoteLength)(1 << (this.Random.Next(min, max + 1)));

			Create(maxLength, numNotes);
		}

		public void CreateFullMeasureByNoteCount(NoteLength numNotes)
		{
			Create(NoteLength.Whole, numNotes);
		}

		#region MusicFormBase implementation

		public override void Create()
		{
			this.CreateFullMeasureByNoteCount(NoteLength.Quarter);
		}

		public override void Randomize()
		{
			throw new NotImplementedException();
		}

		#endregion

		#endregion

		#region FractalStateMachine overrides

		

		#endregion
	}
}
