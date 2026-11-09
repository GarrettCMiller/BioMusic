using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

using BioMusic.Code;
using BioMusic.Code.Utility;
using BioMusic.Code.Forms;
using BioMusic.Code.FSM;

//using Sanford.Multimedia;
//using Sanford.Multimedia.Midi;

namespace BioMusic.Code.MusicForms
{
	/////////////////////////////////////////////////////////////////////////
	#region MusicForm enums

	public enum MusicForm
	{
		Song,
		Section,
		Phrase,
		Measure,
		Motif,
		Cell,
		Note
	}

	public enum COctave
	{
		C0,

		C1,
		C2,
		C3,
		C4,
		C5,
		C6,
		C7,

		C8,
	}
	public enum AOctave
	{
		A0,
		A1,
		A2,
		A3,
		A4,
		A5,
		A6,
		A7,
	}

	public enum NoteLength
	{
		Whole = 1 << 0,
		Half = 1 << 1,
		Quarter = 1 << 2,
		Eighth = 1 << 3,
		Sixteenth = 1 << 4,
		ThirtySecond = 1 << 5,
		SixtyFourth = 1 << 6
	}

	#endregion
	/////////////////////////////////////////////////////////////////////////

	/////////////////////////////////////////////////////////////////////////
	#region Music List

	/// <summary>
	/// An empty (for now) interface to describe a list of music
	/// forms (only) that can be interfaced with like a
	/// SortedList at least.
	/// </summary>
	public interface IMusicFormList
	{
	}

	/// <summary>
	/// A wrapper class to a dictionary entry (mostly to shorten the name).
	/// </summary>
	[Serializable()]
	public class MusicListEntry
	{
		#region Fields

		private System.Collections.DictionaryEntry de;

		#endregion

		#region Properties

		public System.Collections.DictionaryEntry Entry
		{
			get { return de; }
			set { de = value; }
		}

		public string Key
		{
			get { return (string)this.Entry.Key; }
			set { this.de.Key = value; }
		}

		public string Name
		{
			get { return this.Key; }
			set { this.Key = value; }
		}

		public MusicFormBase Object
		{
			get { return (MusicFormBase)this.de.Value; }
			set { this.de.Value = value; }
		}

		#endregion

		#region Construction

		public MusicListEntry(System.Collections.DictionaryEntry de)
		{
			Create(de);
		}

		//public MusicListEntry(

		public MusicListEntry(string name, MusicFormBase form)
		{
			Create(name, form);
		}

		public MusicListEntry(MusicFormBase form) : this(form.Name, form)
		{
		}

		#endregion

		#region Methods

		public void Create(System.Collections.DictionaryEntry de)
		{
			Create((string)de.Key, (MusicFormBase)de.Value);
		}

		public void Create(MusicFormBase form)
		{
			Create(form.Name, form);
		}

		public void Create(string name, MusicFormBase form)
		{
			this.Entry = new System.Collections.DictionaryEntry(name, form);
		}

		#endregion

		#region Conversions

		public static implicit operator System.Collections.DictionaryEntry(MusicListEntry m)
		{
			return m.Entry;
		}

		public static implicit operator MusicListEntry(System.Collections.DictionaryEntry de)
		{
			return new MusicListEntry(de);
		}

		public static implicit operator MusicFormBase(MusicListEntry m)
		{
			return m.Object;
		}

		public static implicit operator string(MusicListEntry m)
		{
			return m.Name;
		}

		#endregion
	}

	public class MusicListEnumerator : IDictionaryEnumerator
	{
		#region Fields

		private MusicListEntry entry;
		private int pos = -1;
		private BaseMusicFormList list;

		#endregion

		#region Construction

		public MusicListEnumerator(BaseMusicFormList l)
		{
			this.list = l;
		}

		#endregion

		#region IDictionaryEnumerator Members

		public DictionaryEntry Entry
		{
			get { return this.entry.Entry; }
			protected set { this.entry.Entry = value; }
		}

		public object Key
		{
			get { return this.entry.Key; }
			protected set { this.entry.Key = (string)value; }
		}

		public object Value
		{
			get { return this.entry.Object; }
			protected set { this.entry.Object = (MusicFormBase)value; }
		}

		#endregion

		#region IEnumerator Members

		object IEnumerator.Current
		{
			get { return this.entry.Object; }
		}

		public MusicFormBase Current
		{
			get { return entry; }
		}

		public bool MoveNext()
		{
			try
			{
				entry = new MusicListEntry((MusicFormBase)list.GetByIndex(++pos));
				return pos < list.Count;
			}
			catch (ArgumentOutOfRangeException e)
			{
				return false;
			}
		}

		public void Reset()
		{
			entry = (MusicListEntry)list.GetByIndex(pos);
		}

		#endregion
	}

	/// <summary>
	/// The abstract (and empty) base class representing a SortedList of music
	/// forms (only) that can be used to represent a list of songs, measures, etc
	/// </summary>
	[Serializable()]
	public abstract class BaseMusicFormList : System.Collections.SortedList, IMusicFormList
	{
	}

	/// <summary>
	/// The generic implementation of BaseMusicFormList that ensures that
	/// any MusicFormList instance represents an SortedList of items that
	/// all derive from MusicFormBase.
	/// 
	/// All functions for insertion and addition are overridden from
	/// SortedList to ensure that only MusicFormBase derivatives are added.
	/// </summary>
	/// <typeparam name="_MusicForm"></typeparam>
	[Serializable()]
	public class MusicFormList<_MusicForm> : BaseMusicFormList where _MusicForm : MusicFormBase
	{
		#region Fields

		/// <summary>
		/// Whether or not music forms are added to
		/// their parent FSM when added to this list.
		/// </summary>
		private bool bAddFormsToParentFSM = true;

		#endregion

		#region Properties

		/// <summary>
		/// Gets/Sets whether or not music forms
		/// are automatically added to their parent
		/// Finite State Machine.
		/// </summary>
		protected bool AddFormsToParent
		{
			get { return bAddFormsToParentFSM; }
			set { bAddFormsToParentFSM = value; }
		}

		#endregion

		#region Construction

		public MusicFormList(bool bAddStatesToFSM)
		{
			this.AddFormsToParent = bAddStatesToFSM;
		}

		#endregion

		#region Methods

		#region Adding form to parent FSM

		/// <summary>
		/// Adds the music form to its parent's FSM
		/// </summary>
		/// <param name="musicForm"></param>
		protected static void AddFormToParentFSM(_MusicForm musicForm)
		{
			if (musicForm.SMSParentStateMachine != null)
				musicForm.AddToParentFSM();
		}

		private static bool bAddRangeAtOnce = true;
		/// <summary>
		/// Adds the music forms in arrMusicFormArray to their parent's FSM
		/// </summary>
		/// <param name="arrMusicFormArray"></param>
		public static void AddFormsToParentFSM(_MusicForm[] arrMusicFormArray)
		{
			if (bAddRangeAtOnce)
				arrMusicFormArray[0].SMSParentStateMachine.FSM_AddStates(arrMusicFormArray);
			else
				foreach (_MusicForm musicForm in arrMusicFormArray)
					musicForm.AddToParentFSM();
		}

		#endregion

		#endregion
		
		#region  Override Methods

		#region Add

		/// <summary>
		/// Add a music form
		/// </summary>
		/// <param name="e"></param>
		public void Add(MusicListEntry e)
		{
			if (this.AddFormsToParent) AddFormToParentFSM((_MusicForm)e.Object);

			base.Add(e.Key, e.Object);
		}

		/// <summary>
		/// Add a music form
		/// </summary>
		/// <param name="musicForm"></param>
		public void Add(_MusicForm musicForm)
		{
			if (this.AddFormsToParent) AddFormToParentFSM(musicForm);

			base.Add(musicForm.Path, musicForm);
		}

		/// <summary>
		/// Add a group of music forms
		/// </summary>
		/// <param name="arrForms"></param>
		public void AddRange(_MusicForm[] arrForms)
		{
			foreach (_MusicForm form in arrForms)
				this.Add(form);
		}

		/// <summary>
		/// Add a group of music forms
		/// </summary>
		/// <param name="list"></param>
		public void AddRange(BaseMusicFormList list)
		{
			try
			{
				foreach (/*MusicListEntry*/MusicFormBase e in list)
					this.Add((_MusicForm)e);
			}
			catch (Exception ex)
			{
				//System.Windows.Forms.MessageBox.Show(ex.Message);
				//throw;
			}
		}

		#endregion

		#region Set by index

		public void SetByIndex(int index, _MusicForm musicForm)
		{
			if (this.AddFormsToParent) AddFormToParentFSM(musicForm);

			base.SetByIndex(index, musicForm);
		}

		#endregion

		#region Remove at index

		/// <summary>
		/// Removes an item by name
		/// </summary>
		/// <param name="index"></param>
		public void RemoveAt(int index)
		{
			base.RemoveAt(index);
		}

		#endregion

		#region Remove

		public void Remove(string name)
		{
			base.Remove(name);
		}

		#endregion

		#region Hide the bland object indexer

		protected new object this[object key]
		{
			get { throw new AccessViolationException("Shouldn't be here!"); }
		}
		
		#endregion

		#endregion

		#region Enumerator

		public override IDictionaryEnumerator  GetEnumerator()
		{
			return new MusicListEnumerator(this);
		}

		#endregion
	}

	#endregion	
	/////////////////////////////////////////////////////////////////////////

	/// <summary>
	/// Wrapper class to a musical time signature.
	/// </summary>
	[Serializable()]
	public class TimeSignature
	{
		public TimeSignature() : this(4, 4)
		{
		}

		public TimeSignature(byte num, byte den)
		{
			numerator = num;
			denominator = den;
		}

		public TimeSignature(Sanford.Multimedia.Midi.TimeSignatureBuilder t)
		{
			numerator = t.Numerator;
			denominator = t.Denominator;
		}

		public byte numerator;
		public byte denominator;
	}

	[Serializable()]
	public class MusicalProperties
	{
		#region Fields

		//protected Sanford.Multimedia.Midi.TimeSignatureBuilder timeSignature = new Sanford.Multimedia.Midi.TimeSignatureBuilder();
		private TimeSignature timeSignature = new TimeSignature();
		private int tempo = 60;

		private COctave rootOctave;
		private int octaveSpan;

		private float restNoteChance;
		private float chordChance;
		private Midi.ChordPattern chordPattern;
		private int chordInversion;

		private int largestNoteValue;
		private int smallestNoteValue;

		private uint numSectionsPerSong;
		private uint numPhrasesPerSection;
		private uint numMeasuresPerPhrase;

		private MusicScale rootScale;

		private Random random;

		#endregion

		#region Construction

		/// <summary>
		/// Default 4/4 time signature with 120 bpm and CMajor as the key.
		/// </summary>
		public MusicalProperties()
			: this(4, 4, 120, MusicScale.CMajor)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="timeSign"></param>
		/// <param name="tempo"></param>
		/// <param name="key"></param>
		public MusicalProperties(TimeSignature timeSign, int tempo, MusicScale scale)
			: this(timeSign.numerator, timeSign.denominator, tempo, scale)
		{
		}

		public MusicalProperties(byte numer, byte denom, int tempo, MusicScale scale)		
		{
			this.Numerator = numer;
			this.Denominator = denom;
			this.RootScale = scale;
			this.Tempo = tempo;
			this.RestNoteChance = 0.1f;
			this.ChordChance = 0.9f;
			this.ChordPattern = Midi.Chord.Major;
			this.ChordInversion = 0;

			this.NumSectionsPerSong = 1;
			this.NumPhrasesPerSection = 2;
			this.NumMeasuresPerPhrase = 4;

			this.Random = new Random();
		}

		#endregion		

		#region Properties

		public uint NumSectionsPerSong
		{
			get { return numSectionsPerSong; }
			set { numSectionsPerSong = value; }
		}

		public uint NumPhrasesPerSection
		{
			get { return numPhrasesPerSection; }
			set { numPhrasesPerSection = value; }
		}

		public uint NumMeasuresPerPhrase
		{
			get { return numMeasuresPerPhrase; }
			set { numMeasuresPerPhrase = value; }
		}

		public Midi.ChordPattern ChordPattern
		{
			get { return chordPattern; }
			set { chordPattern = value; }
		}

		public int ChordInversion
		{
			get { return chordInversion; }
			set { chordInversion = value; }
		}

		public float ChordChance
		{
			get { return chordChance; }
			set { chordChance = value; }
		}

		public float RestNoteChance
		{
			get { return restNoteChance; }
			set
			{
				if (value < 0.0f || value > 1.0f)
					throw new ArgumentOutOfRangeException("Probabilities cannot be outside the range [0, 1]");

				restNoteChance = value;
			}
		}

		public int LargestNoteValue
		{
			get { return largestNoteValue; }
			set { largestNoteValue = value; }
		}

		public int SmallestNoteValue
		{
			get { return smallestNoteValue; }
			set { smallestNoteValue = value; }
		}

		public COctave RootOctave
		{
			get { return this.rootOctave; }
			set { this.rootOctave = value; }
		}

		public int OctaveSpan
		{
			get { return this.octaveSpan; }
			set { this.octaveSpan = value; }
		}

		public TimeSignature TimeSignature
		{
			get { return timeSignature; }
		}

		public byte Numerator
		{
			get { return timeSignature.numerator; }
			set { timeSignature.numerator = value; }
		}

		public byte Denominator
		{
			get { return timeSignature.denominator; }
			set { timeSignature.denominator = value; }
		}

		public int Tempo
		{
			get { return tempo; }
			set { tempo = value; }
		}

		public MusicScale RootScale
		{
			get { return rootScale; }
			set { rootScale = value; }
		}

		public Random Random
		{
			get { return random; }
			protected set { random = value; }
		}

		#endregion
	}

	[Serializable()]
	public abstract class MusicFormBase : FractalStateMachine
	{
		//////////////////////////////////////////////////////
		#region Static

		#region Fields

		protected static MusicScale classScale;
		protected static Random classRandom;

		protected static string pathSeparator;

		protected static MusicalProperties classProperties;

		#endregion

		#region Properties

		public static string PathSeparator
		{
			get { return pathSeparator; }
			protected set
			{
				#region Safety

				if (value == null) throw new ArgumentNullException("Must be a valid string!");
				if (value == "") throw new ArgumentException("Must not be an empty string!");
				if (value == "\0") throw new ArgumentOutOfRangeException("Separator can't be a null terminator!");

				#endregion

				pathSeparator = value;
			}
		}

		public static MusicScale ClassRootScale
		{
			get { return classScale; }
			set { classScale = value; }
		}

		public static Random ClassRandom
		{
			get { return classRandom; }
			protected set { classRandom = value; }
		}

		public static MusicalProperties ClassDefaults
		{
			get { return classProperties; }
			set { classProperties = value; }
		}

		#endregion

		#region Construction

		static MusicFormBase()
		{
			classRandom = new Random();
			classScale = new MusicScale();
			classScale.Randomize();
			ClassDefaults = new MusicalProperties();
			pathSeparator = "/";
		}

		#endregion

		#endregion
		//////////////////////////////////////////////////////

		//////////////////////////////////////////////////////
		#region Non-Static

		#region Fields

		private MusicalProperties properties;		

		protected MusicFormBase parent;
		protected BaseMusicFormList children;

		[NonSerialized()]
		protected SectionArray sectionArray;
		[NonSerialized()]
		protected PhraseArray phraseArray;
		[NonSerialized()]
		protected MeasureArray measureArray;
		[NonSerialized()]
		protected MotifArray motifArray;
		[NonSerialized()]
		protected CellArray cellArray;
		[NonSerialized()]
		protected NoteArray noteArray;

#if _CACHE_MUSIC_FORM_PATHS_
		protected string path;
#endif

		[NonSerialized()]
		protected bool bIsPlaying = false;
		
		#endregion

		#region Methods

		#region Adding to parent object

		public virtual void AddToParentFSM()
		{
			if (this.SMSParentStateMachine != null)
				this.SMSParentStateMachine.FSM_AddState(this);
		}

		#endregion

		#region Creation

		/// <summary>
		/// Responsible for creating a default music form,
		/// creating children as well
		/// </summary>
		public abstract void Create();

		/// <summary>
		/// Randomizes the music form and its children.
		/// </summary>
		public abstract void Randomize();

		#endregion

		#region Playback

		public virtual void Play()
		{
			this.Playing = true;

			foreach (MusicFormBase child in children)
				this.FSM_QueueState(child);

			this.FSM_Initialize();
		}

		public virtual void Stop()
		{
			this.Playing = false;
		}

		#endregion

		#region Saving and Loading

		public virtual void SaveToFile(string file)
		{
			#if true

			FileStream stream = new FileStream(file, FileMode.Create);

			BinaryFormatter formatter = new BinaryFormatter();

			try
			{
				formatter.Serialize(stream, this);
			}
			catch (SerializationException ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
				throw;
			}
			finally
			{
				stream.Close();
			}
			
			#endif
		}

		public virtual void LoadFromFile(string file)
		{
			#if false

			//Opens file "data.xml" and deserializes the object from it.
			Stream stream = File.Open("data.xml", FileMode.Open);
			SoapFormatter formatter = new SoapFormatter();

			//formatter = new BinaryFormatter();

			obj = (MusicFormBase)formatter.Deserialize(stream);
			stream.Close();
			
			#endif
		}

		#endregion

		#endregion

		#region Construction

		public MusicFormBase(MusicFormBase parent, string name)
			: base(parent, name)
		{
			this.parent = parent;
			CopyParentProperties();
		}

		public MusicFormBase(string name)
			: base(name)
		{
			CopyParentProperties();
		}

		private void CopyParentProperties()
		{
			if (parent != null && parent.Properties != null)
				this.Properties = parent.Properties;
			else
				this.Properties = ClassDefaults;
		}

		#endregion

		#region Properties

		public abstract MusicForm Type { get; }

		/// <summary>
		/// Gets/sets the children of the object
		/// </summary>
		public BaseMusicFormList Children
		{
			get { return this.children; }
			set { this.children = value; }
		}

		/// <summary>
		/// Recursively gets the path of the item, separated
		/// by the class separator string.
		/// </summary>
		public string Path
		{
			get
			{
				if (this.Parent != null)
					return this.Parent.Path + MusicFormBase.PathSeparator + this.Name;
				else
					return this.Name;
			}
		}

		/// <summary>
		/// Gets/Sets the parent object.
		/// </summary>
		public MusicFormBase Parent
		{
			get { return this.parent; }
			protected set { this.parent = value; }
		}

		/// <summary>
		/// Gets/sets the common musical properties of
		/// the object.
		/// </summary>
		public MusicalProperties Properties
		{
			get { return properties; }
			set { properties = value; }
		}

		/// <summary>
		/// Gets the number of sub-parts that make up this
		/// objects (sections, measures, notes, etc).
		/// </summary>
		public int NumParts
		{
			get { return children.Count; }
		}

		/// <summary>
		/// Whether or not the object is currently playing.
		/// </summary>
		public bool Playing
		{
			get { return bIsPlaying; }
			set { bIsPlaying = value; }
		}

		/// <summary>
		/// Gets the random number generator associated
		/// with this object.
		/// </summary>
		protected Random Random
		{
			get { return this.Properties.Random; }
		}

		/// <summary>
		/// Gets the length of item in ms.
		/// </summary>
		public abstract double MsLength { get; protected set; }

		/// <summary>
		/// Gets the length of the item in a TimeSpan format.
		/// </summary>
		public virtual TimeSpan Length
		{
			get { return new TimeSpan(0, 0, 0, 0, (int)Math.Round(this.MsLength)); }
		}

		#region TEMP HACK?

		public abstract int NumSections { get; }
		public abstract int NumPhrases { get; }
		public abstract int NumMeasures { get; }
		public abstract int NumMotifs { get; }
		public abstract int NumCells { get; }
		public abstract int NumNotes { get; }
	
		#endregion
		
		#endregion

		#region Indexers

		public MusicFormBase this[int i]
		{
			get { return (MusicFormBase)children.GetByIndex(i); }
			set { children.SetByIndex(i, value); }
		}

		#endregion

		#region FractalStateMachine overrides

		public override FSMResult SMS_EnterState(object[] arrArgs)
		{
			Play();

			return base.SMS_EnterState(arrArgs);
		}

		public override FSMResult SMS_ExitState(object[] arrArgs)
		{
			this.Playing = false;

			return base.SMS_ExitState(arrArgs);
		}

		public override FSMResult FSM_Initialize()
		{
			return base.FSM_Initialize();
		}

		public override FSMResult FSM_Update(object[] arrArgs)
		{
			if (base.FSM_Update(arrArgs) == FSMResult.Fail)
			{
				this.Playing = false;
				return FSMResult.Fail;
			}

			return this.Playing ? FSMResult.Success : FSMResult.Fail;
		}

		public override void Destroy()
		{
			this.children.Clear();
			base.Destroy();
		}

		public override FSMResult FSM_SendMessage(object sender, FSMMessage msg)
		{
			if (base.FSM_SendMessage(sender, msg) == FSMResult.Fail)
				return FSMResult.Fail;

			//Do message stuff here

			return FSMResult.Success;
		}

		public override FSMResult SMS_SendMessage(object sender, FSMMessage msg)
		{
			if (base.SMS_SendMessage(sender, msg) == FSMResult.Fail)
				return FSMResult.Fail;

			//Do message stuff here

			return FSMResult.Success;
		}

		public FSMResult SendMessage(object sender, FSMMessage msg)
		{
			if (SMS_SendMessage(sender, msg) == FSMResult.Fail)
				return FSMResult.Fail;

			return FSM_SendMessage(sender, msg);
		}

		protected virtual void HandleMessage(object sender, FSMMessage msg)
		{
			if (msg.ID == FSMMessageID.Stop)
				this.Playing = false;
		}

		#endregion

		#endregion
		//////////////////////////////////////////////////////
	}
}
