using System;
using System.Collections;
using System.Linq;
using System.Text;
//using Sanford.Multimedia;
//using Sanford.Multimedia.Midi;

using Midi;

namespace BioMusic.Code.Utility
{
	[Serializable()]
	public class MusicScale
	{
		#region Fields

		private Scale scale;
		Random rand = new Random();

		#endregion

		#region Construction

		public MusicScale()
		{
			Build(Pitch.C4.NotePreferringSharps(), Scale.Major);
		}

		public MusicScale(Note tonic, ScalePattern pattern)
		{
			Build(tonic, pattern);
		}

		public MusicScale(Sanford.Multimedia.Note tonic, ScalePattern pattern)
		{
			Build(ConvertNote(tonic), pattern);
		}

		#endregion

		#region Methods

		public void Randomize()
		{
			this.Pattern = RandomPattern();
			this.Tonic = RandomTonic();
		}

		private ScalePattern RandomPattern()
		{
			return Scale.Patterns[rand.Next(Scale.Patterns.Length)];
		}

		private Note RandomTonic()
		{
			Sanford.Multimedia.Note note = (Sanford.Multimedia.Note)rand.Next(12);
			return ConvertNote(note);
		}

		public Note ConvertNote(Sanford.Multimedia.Note n)
		{
			string noteName = n.ToString();
			int acc = 0;
			if (noteName.Contains("Flat")) acc--;
			if (noteName.Contains("Sharp")) acc++;
			return new Note(noteName[0], acc);
		}

		public void Build(Note tonic, ScalePattern pattern)
		{
			scale = new Scale(tonic, pattern);
		}

		public Note GetNoteAtIndex(int index)
		{
			return scale.NoteSequence[index];
		}

		#endregion

		#region Properties

		public ScalePattern Pattern
		{
			get { return scale.Pattern; }
			set { Build(scale.Tonic, value); }
		}

		public Note Tonic
		{
			get { return scale.Tonic; }
			set { Build(value, scale.Pattern); }
		}

		public Note[] Notes
		{
		    get { return scale.NoteSequence; }
		}

		public string Name
		{
			get { return this.scale.Name; }
		}

		//public Key Key
		//{
		//    get { return key; }
		//    set { key = value; }
		//}

		public int NoteCount
		{
			get { return this.Notes.Length; }
		}

		public Note this[int index]
		{
			get { return GetNoteAtIndex(index); }
		}

		#endregion


		#region Static

		public static MusicScale CMajor = new MusicScale();
		//public static MusicScale 

		/*
		public static string[] GetFormattedKeyNames()
		{
			string[] tempNames = Enum.GetNames(typeof(Sanford.Multimedia.Key));
			int numKeys = tempNames.Length;

			ArrayList names = new ArrayList(tempNames.Length);

			names.AddRange(tempNames);
			names.Sort();

			string[] formattedNames = new string[numKeys];

			int nameIndex = 0;
			char currentLetter = '\0';

			foreach (string name in names)
			{
				formattedNames[nameIndex] = "";

				int letterPos = 0;
				bool bSkipFirstLetter = true;

				foreach (char letter in name)
				{
					formattedNames[nameIndex] += letter;

					letterPos++;

					if (bSkipFirstLetter)
					{
						bSkipFirstLetter = false;
						continue;
					}

					if (char.IsUpper(letter))
						formattedNames[nameIndex] = formattedNames[nameIndex].Insert(++letterPos - 2, " ");
				}

				nameIndex++;
			}

			return formattedNames;
		}

		public static Key GetKeyByName(string name)
		{
			string[] arrTemp = name.Split(' ');
			string newName = "";

			foreach (string s in arrTemp)
				newName += s;

			return (Key)Enum.Parse(typeof(Key), newName);
		}
		*/

		#endregion
	
	}

	public class ScaleBuilder
	{
#if false
		public static ArrayList BuildNotesFromKey(Sanford.Multimedia.Key key)
		{
			ArrayList noteList = new ArrayList();

			switch (key)
			{
				#region Scales in A

				case Key.AMajor:
					{
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
					}
					break;

				case Key.AMinor:
					{
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
					}
					break;

				case Key.AFlatMajor:
					{
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
					}
					break;

				case Key.AFlatMinor:
					{
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.B);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.E/*FFlat*/);
						noteList.Add(Note.GFlat);
					}
					break;

				case Key.ASharpMinor:
					{
						noteList.Add(Note.ASharp);
						noteList.Add(Note.C/*BSharp*/);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.F/*ESharp*/);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
					}
					break;

				#endregion

				#region Scales in B

				case Key.BMajor:
					{
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.ASharp);
					}
					break;

				case Key.BMinor:
					{
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
					}
					break;

				case Key.BFlatMajor:
					{
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
					}
					break;

				case Key.BFlatMinor:
					{
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.GFlat);
						noteList.Add(Note.AFlat);
					}
					break;

				#endregion

				#region Scales in C

				case Key.CMajor:
					{
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
					}
					break;

				case Key.CMinor:
					{
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
					}
					break;

				case Key.CFlatMajor:
					{
						noteList.Add(Note.B/*CFlat*/);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.E/*FFlat*/);
						noteList.Add(Note.GFlat);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
					}
					break;

				case Key.CSharpMajor:
					{
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.F/*ESharp*/);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.ASharp);
						noteList.Add(Note.C/*BSharp*/);
					}
					break;

				case Key.CSharpMinor:
					{
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
					}
					break;

				#endregion

				#region Scales in D

				case Key.DMajor:
					{
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
					}
					break;

				case Key.DMinor:
					{
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
					}
					break;

				case Key.DFlatMajor:
					{
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.GFlat);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
					}
					break;

				case Key.DSharpMinor:
					{
						noteList.Add(Note.DSharp);
						noteList.Add(Note.F/*ESharp*/);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.ASharp);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
					}
					break;

				#endregion

				#region Scales in E

				case Key.EMajor:
					{
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
					}
					break;

				case Key.EMinor:
					{
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
					}
					break;

				case Key.EFlatMajor:
					{
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
					}
					break;

				case Key.EFlatMinor:
					{
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
						noteList.Add(Note.GFlat);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.B/*CFlat*/);
						noteList.Add(Note.DFlat);
					}
					break;

				#endregion

				#region Scales in F

				case Key.FMajor:
					{
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
					}
					break;

				case Key.FMinor:
					{
						noteList.Add(Note.F);
						noteList.Add(Note.G);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
					}
					break;

				case Key.FSharpMajor:
					{
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.ASharp);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.F/*ESharp*/);
					}
					break;

				case Key.FSharpMinor:
					{
						noteList.Add(Note.FSharp);
						noteList.Add(Note.GSharp);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
					}
					break;

				#endregion

				#region Scales in G

				case Key.GMajor:
					{
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.B);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
					}
					break;

				case Key.GMinor:
					{
						noteList.Add(Note.G);
						noteList.Add(Note.A);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.C);
						noteList.Add(Note.D);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
					}
					break;

				case Key.GFlatMajor:
					{
						noteList.Add(Note.GFlat);
						noteList.Add(Note.AFlat);
						noteList.Add(Note.BFlat);
						noteList.Add(Note.B/*CFlat*/);
						noteList.Add(Note.DFlat);
						noteList.Add(Note.EFlat);
						noteList.Add(Note.F);
					}
					break;

				case Key.GSharpMinor:
					{
						noteList.Add(Note.GSharp);
						noteList.Add(Note.ASharp);
						noteList.Add(Note.B);
						noteList.Add(Note.CSharp);
						noteList.Add(Note.DSharp);
						noteList.Add(Note.E);
						noteList.Add(Note.FSharp);
					}
					break;

				#endregion
			}

			return noteList;
		}
#endif
	}
}
