using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic.Code.MusicForms
{
	[Serializable()]
	public class SectionArray : MusicFormList<MusicFormSection>
	{
		public SectionArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormSection this[int index]
		{
			get { return (MusicFormSection)base[index]; }
		}

		public MusicFormSection this[string name]
		{
			get { return (MusicFormSection)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormSection : MusicFormBase
	{
		#region Fields

		//public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected float fTotalLength = 0.0f;

		#endregion

		#region Construction

		public MusicFormSection(MusicFormSong parent, string name)
			: base(parent, name)
		{
			this.children = new PhraseArray(true);
		}

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Section; }
		}

		public override int NumSections
		{
			get { return 0; }
		}

		public override int NumPhrases
		{
			get { return this.Phrases.Count; }
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

		public MusicFormSong Parent
		{
			get { return (MusicFormSong)parent; }
			protected set { parent = value; }
		}

		public override int NumNotes
		{
			get { return this.Notes.Count; }
		}

		public override double MsLength
		{
			get
			{
				double sum = 0.0;
				foreach (MusicFormPhrase phrase in this.Phrases)
					sum += phrase.MsLength;
				return sum;
			}

			protected set { }
		}

		public PhraseArray Phrases
		{
			get { return (PhraseArray)this.children; }
			protected set { this.children = value; }
		}

		public MeasureArray Measures
		{
			get { return (this.measureArray == null ? CreateMeasureArray() : this.measureArray); }
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

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormSection section)
		{
			return new MusicListEntry(section);
		}

		#region Create sub-child cache arrays

		private MeasureArray CreateMeasureArray()
		{
			measureArray = new MeasureArray(false);

			foreach (MusicFormPhrase phrase in this.Phrases)
				measureArray.AddRange(phrase.Measures);

			return measureArray;
		}

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
			for (int i = 0; i < this.Properties.NumPhrasesPerSection; i++)
			{
				MusicFormPhrase newPhrase = new MusicFormPhrase(this, "Phrase " + i);
				newPhrase.Create();
				Phrases.Add(newPhrase);
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
