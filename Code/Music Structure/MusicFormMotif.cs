using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class MotifArray : MusicFormList<MusicFormMotif>
	{
		public MotifArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormMotif this[int index]
		{
			get { return (MusicFormMotif)base[index]; }
		}

		public MusicFormMotif this[string name]
		{
			get { return (MusicFormMotif)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormMotif : MusicFormBase
	{
		#region Fields

		public static readonly NoteLength MaxLength = NoteLength.Whole;
		public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected int nTotalLength = 0;
		protected NoteLength officialLength;
		protected float fTotalLength = 0.0f;

		#endregion

		#region Construction

		public MusicFormMotif(MusicFormMeasure parent, string name)
			: base(parent, name)
		{
			this.children = new CellArray(true);
		}

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Motif; }
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
			get { return this.Cells.Count; }
		}

		public override int NumNotes
		{
			get { return this.Notes.Count; }
		}

		public CellArray Cells
		{
			get { return (CellArray)children; }

			protected set { children = value; }
		}

		public NoteArray Notes
		{
			get { return (this.noteArray == null ? CreateNoteArray() : this.noteArray); }
		}

		public MusicFormMeasure Parent
		{
			get { return (MusicFormMeasure)parent; }
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

		public override double MsLength
		{
			get
			{
				double sum = 0.0;
				foreach (MusicFormCell cell in this.Cells)
					sum += cell.MsLength;
				return sum;
			}

			protected set { }
		}

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormMotif motif)
		{
			return new MusicListEntry(motif);
		}

		#region Create sub-child cache arrays

		private NoteArray CreateNoteArray()
		{
			noteArray = new NoteArray(false);

			foreach (MusicFormCell cell in Cells)
				noteArray.AddRange(cell.Notes);

			return noteArray;
		}

		#endregion

		#region MusicFormBase implementation

		public override void Create()
		{
			for (int i = 0; i < 2; i++)
			{
				MusicFormCell newCell = new MusicFormCell(this, "Cell " + i);
				newCell.Create(NoteLength.Quarter, (NoteLength)(1 << this.Random.Next(4)));
				Cells.Add(newCell);
			}
		}

		public void Create(NoteLength maxLength)
		{
			//Up to 3 cells per motif, but 3 should be rarer than one or
			//two, so we set the max to 9 (exclusive) and mod it by 3
			int numCells = 1;// this.Random.Next(1, 9) % 3;

			//if (maxLength > NoteLength.Quarter) 
				//numCells = this.Random.Next(1, 3);

			for (int i = 0; i < numCells; i++)
			{
				MusicFormCell newCell = new MusicFormCell(this, "Cell " + i);

				float ratio = 1;// Math.Max((int)numCells / (float)maxLength, (float)maxLength / (int)numCells);

				newCell.CreateByLength((NoteLength)ratio);
				Cells.Add(newCell);
			}
		}

		public override void Randomize()
		{
			throw new NotImplementedException();
		}

		#endregion

		#endregion
	}
}
