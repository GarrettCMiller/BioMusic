using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class PhraseArray : MusicFormList<MusicFormPhrase>
	{
		public PhraseArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormPhrase this[int index]
		{
			get { return (MusicFormPhrase)base[index]; }
		}

		public MusicFormPhrase this[string name]
		{
			get { return (MusicFormPhrase)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormPhrase : MusicFormBase
	{
		#region Fields

		//public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected float fTotalLength = 0.0f;

		#endregion

		#region Construction

		public MusicFormPhrase(MusicFormSection parent, string name)
			: base(parent, name)
		{
			this.children = new MeasureArray(true);
		}

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Phrase; }
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
			get { return this.Measures.Count; }
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

		public MusicFormSection Parent
		{
			get { return (MusicFormSection)parent; }
			protected set { parent = value; }
		}

		public MeasureArray Measures
		{
			get { return (MeasureArray)this.children; }

			protected set { this.children = value; }
		}

		public MotifArray Motifs
		{
			get { return (this.motifArray == null ? CreateMotifArray() : this.motifArray); }
		}

		public CellArray Cells
		{
			get { return (this.cellArray == null ? CreateCellArray() : this.cellArray); }
		}

		public NoteArray Notes
		{
			get { return (this.noteArray == null ? CreateNoteArray() : this.noteArray); }
		}

		public override double MsLength
		{
			get
			{
				double sum = 0.0;
				foreach (MusicFormMeasure measure in this.Measures)
					sum += measure.MsLength;
				return sum;
			}

			protected set { }
		}

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormPhrase phrase)
		{
			return new MusicListEntry(phrase);
		}

		#region Create sub-child cache arrays

		private MotifArray CreateMotifArray()
		{
			motifArray = new MotifArray(false);

			foreach (MusicFormMeasure measure in this.Measures)
				motifArray.AddRange(measure.Motifs);

			return motifArray;
		}

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
			for (int i = 0; i < this.Properties.NumMeasuresPerPhrase; i++)
			{
				MusicFormMeasure newMeasure = new MusicFormMeasure(this, "Measure " + i);
				newMeasure.Create();
				Measures.Add(newMeasure);
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
