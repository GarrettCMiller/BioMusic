using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class MeasureArray : MusicFormList<MusicFormMeasure>
	{
		public MeasureArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormMeasure this[int index]
		{
			get { return (MusicFormMeasure)base[index]; }
		}

		public MusicFormMeasure this[string name]
		{
			get { return (MusicFormMeasure)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormMeasure : MusicFormBase
	{
		#region Fields

		public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected float fTotalLength = 0.0f;

		#endregion

		#region Construction

		public MusicFormMeasure(MusicFormPhrase parent, string name)
			: base(parent, name)
		{
			this.children = new MotifArray(true);
		}

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Measure; }
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
			get { return this.children.Count; }
		}

		public override int NumCells
		{
			get { return this.Cells.Count; }
		}

		public override int NumNotes
		{
			get { return this.Notes.Count; }
		}

		public MotifArray Motifs
		{
			get { return (MotifArray)this.children; }

			protected set { this.children = value; }
		}

		public CellArray Cells
		{
			get { return (this.cellArray == null ? CreateCellArray() : this.cellArray); }
		}

		public NoteArray Notes
		{
			get { return (this.noteArray == null ? CreateNoteArray() : this.noteArray); }
		}

		public MusicFormPhrase Parent
		{
			get { return (MusicFormPhrase)parent; }
			protected set { parent = value; }
		}

		public NoteLength TempLength
		{
			set
			{
				fTotalLength += 1.0f / (int)value;

				//foreach (NoteLength length in Enum.GetValues(typeof(NoteLength)))
				//{
				//    if (fTotalLength >= (int)length)
				//    {
				//        this.LengthInWholeNotes = length;
				//        return;
				//    }
				//}
			}
		}

		public override double MsLength
		{
			get 
			{
				double sum = 0.0;
				foreach (MusicFormMotif motif in this.Motifs)
					sum += motif.MsLength;
				return sum;
			}

			protected set { }
		}

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormMeasure measure)
		{
			return new MusicListEntry(measure);
		}

		#region Create sub-child cache arrays

		private CellArray CreateCellArray()
		{
			cellArray = new CellArray(false);

			foreach (MusicFormMotif motif in Motifs)
				cellArray.AddRange(motif.Cells);

			return cellArray;
		}

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
			NoteLength numMotifs = (NoteLength)(this.Random.Next(1, 3));
			
			for (int i = 0; i < (int)numMotifs; i++)
			{
				MusicFormMotif newMotif = new MusicFormMotif(this, "Motif " + i);
				newMotif.Create(numMotifs);
				Motifs.Add(newMotif);
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
