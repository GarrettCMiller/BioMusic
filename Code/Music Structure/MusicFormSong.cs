using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using BioMusic.Code.FSM;

namespace BioMusic.Code.MusicForms
{
	public class SongArray : MusicFormList<MusicFormSong>
	{
		public SongArray(bool bAddStatesToFSM)
			: base(bAddStatesToFSM)
		{
		}

		public MusicFormSong this[int index]
		{
			get { return (MusicFormSong)((BaseMusicFormList)this)[index]; }
		}

		public MusicFormSong this[string name]
		{
			get { return (MusicFormSong)base[name]; }
		}
	}

	[Serializable()]
	public class MusicFormSong : MusicFormBase
	{
		#region Fields

		//public static readonly NoteLength MaxNotes = NoteLength.SixtyFourth;

		protected float fTotalLength = 0.0f;

		#endregion

		#region Construction

		public MusicFormSong(string name) : base(name)
		{
			this.children = new SectionArray(true);
		}

		#endregion

		#region Properties

		public override MusicForm Type
		{
			get { return MusicForm.Song; }
		}

		public override int NumSections
		{
			get { return this.Sections.Count; }
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

		public override int NumNotes
		{
			get { return this.Notes.Count; }
		}

		public SectionArray Sections
		{
			get { return (SectionArray)this.children; }

			protected set { this.children = value; }
		}

		public PhraseArray Phrases
		{
			get { return (this.phraseArray == null ? CreatePhraseArray() : this.phraseArray); }
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

		public new MusicFormSong Parent
		{
			get { return (MusicFormSong)parent; }
			protected set { parent = value; }
		}

		public override double MsLength
		{
			get
			{
				double sum = 0.0;

				foreach (MusicFormSection section in this.Sections)
					sum += section.MsLength;

				return sum;
			}

			protected set { }
		}

		#endregion

		#region Methods

		public static implicit operator MusicListEntry(MusicFormSong song)
		{
			return new MusicListEntry(song);
		}
		
		#region Create sub-child cache arrays

		private PhraseArray CreatePhraseArray()
		{
			phraseArray = new PhraseArray(false);

			foreach (MusicFormSection section in this.Sections)
				phraseArray.AddRange(section.Phrases);

			return phraseArray;
		}

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
			for (int i = 0; i < this.Properties.NumSectionsPerSong; i++)
			{
				MusicFormSection newSection = new MusicFormSection(this, "Section " + i);
				newSection.Create();
				Sections.Add(newSection);
			}
		}

		public override void Randomize()
		{
			throw new NotImplementedException();
		}

		#endregion

		#endregion

		#region FractalStateMachine

		public override FSMResult FSM_Update(object[] arrArgs)
		{
			FSMResult result = base.FSM_Update(arrArgs);

			if (result == FSMResult.Fail)
				this.Playing = false;

			return result;
		}

		#endregion
	}
}
