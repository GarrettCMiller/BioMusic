using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sanford.Multimedia;
using Sanford.Multimedia.Midi;

using BioMusic.Code.Utility;

namespace BioMusic
{
	class BioSequenceGene : BaseGenotype
	{
		protected float fPlayLength = 10.0f;

		////////////////////////////////////////
		
		protected float fChanceOfHoldingNote = 0.1f;
		protected float fChanceOfRest = 0.125f;
		protected float fChanceOfRepeatingNote = 0.1f;

		protected int nAverageStep = 1;
		protected int nBPM = 180;

		protected bool bStartKeyRandom = false;
		protected bool bKeyStatic = true;			//Means the key stays the same during the song
		protected Key kStartKey = Key.CMajor;
		protected int nStartNote = 0;
		protected int nTimeSigNumerator = 4;
		protected int nTimeSigDenominator = 4;
		protected int n32ndNotesPerQuarterNote = 8;

		///////////////////////////////////////

		protected KeySignatureBuilder keySigBuilder = new KeySignatureBuilder();
		protected TempoChangeBuilder tempoChange = new TempoChangeBuilder();
		protected TimeSignatureBuilder timeSig = new TimeSignatureBuilder();

		protected float fRating = 1.0f;

		//Eventually, do probability of choosing individual notes in a scale

		/////////////////////////////////////////////

		public BioSequenceGene()
		{
			keySigBuilder.Key = kStartKey;
			tempoChange.Tempo = nBPM;
		}

		public override void SetValues(object[] arrVals)
		{
			//fPlayLength = 
			fChanceOfHoldingNote = (float)arrVals[0];
			fChanceOfRest = (float)arrVals[1];
			fChanceOfRepeatingNote = (float)arrVals[2];

			nAverageStep = (int)arrVals[3];
			nBPM = (int)arrVals[4];

			bStartKeyRandom = (bool)arrVals[5];
			bKeyStatic = (bool)arrVals[6];

			kStartKey = (Key)arrVals[7];
			nStartNote = (int)arrVals[8];

			nTimeSigNumerator = (int)arrVals[9];
			nTimeSigDenominator = (int)arrVals[10];
			n32ndNotesPerQuarterNote = (int)arrVals[11];

			foreach (object val in arrVals)
				m_arrVars.Add(val);

			CreateBitString();
		}

		public override float Evaluate()
		{
			return Rating;
		}

		public override void Randomize()
		{
			m_arrVars[0] = fChanceOfHoldingNote = (float)m_rndRand.NextDouble();
			m_arrVars[1] = fChanceOfRest = (float)m_rndRand.NextDouble();
			m_arrVars[2] = fChanceOfRepeatingNote = (float)m_rndRand.NextDouble();
			m_arrVars[3] = nAverageStep = m_rndRand.Next(7);
			m_arrVars[4] = nBPM = m_rndRand.Next(60, 240);
			m_arrVars[5] = bStartKeyRandom = m_rndRand.Next(1) == 1;
			m_arrVars[6] = bKeyStatic = m_rndRand.Next(1) == 1;
			m_arrVars[7] = kStartKey = (Key)m_rndRand.Next((int)Key.CSharpMajor);
			//m_arrVars[8] = nStartNote = (int)m_rndRand.Next(ScaleBuilder.BuildNotesFromKey(this.Key).Count);
			m_arrVars[9] = nTimeSigNumerator = m_rndRand.Next(2) + 2; //Min 2, max 4
			m_arrVars[10] = nTimeSigDenominator = (int)Math.Pow((m_rndRand.Next(2) + 1), 2.0f);
			m_arrVars[11] = n32ndNotesPerQuarterNote = 8;
		}

		public override void SetDefaults()
		{
			fChanceOfHoldingNote = 0.1f;
			fChanceOfRest = 0.125f;
			fChanceOfRepeatingNote = 0.1f;

			nAverageStep = 1;
			nBPM = 180;

			bStartKeyRandom = false;
			bKeyStatic = true;
			kStartKey = Key.CMajor;
			nStartNote = 0;
			nTimeSigNumerator = 4;
			nTimeSigDenominator = 4;
			n32ndNotesPerQuarterNote = 8;
		}

		/////////////////////////////////////////////////////////

		public bool RandomStartKey
		{
			get { return bStartKeyRandom; }
			set	{ bStartKeyRandom = value; }
		}

		public bool KeyChangesAllowed
		{
			get { return bKeyStatic; }
			set { bKeyStatic = value; }
		}

		public Key Key
		{
			get { return kStartKey; }
			set { kStartKey = value; }
		}

		public int FirstNote
		{
			get { return nStartNote; }
			set { nStartNote = value; }
		}

		public TimeSignatureBuilder TimeSignature
		{
			get { return timeSig; }
		}

		public float Rating
		{
			get { return fRating; }

			set
			{
				if (value < 0.0f || value > 1.0f) throw new ArgumentOutOfRangeException("Rating must be normalized!");
				fRating = value;
			}
		}

		public float PlayLength
		{
			get { return fPlayLength; }
			set { fPlayLength = value; }
		}

		public int BPM
		{
			get { return nBPM; }

			set
			{
				nBPM = value;
			}
		}

		public float ChanceOfHoldingNote
		{
			get { return fChanceOfHoldingNote; }
			set
			{
				if (value < 0.0f || value > 1.0f)
					throw new ArgumentOutOfRangeException("Bad chance value!");

				fChanceOfHoldingNote = value;
			}
		}

		public float ChanceOfRestNote
		{
			get { return fChanceOfRest; }
			set
			{
				if (value < 0.0f || value > 1.0f)
					throw new ArgumentOutOfRangeException("Bad chance value!");

				fChanceOfRest = value;
			}
		}

		public float ChanceOfRepeatingNote
		{
			get { return fChanceOfRepeatingNote; }
			set
			{
				if (value < 0.0f || value > 1.0f)
					throw new ArgumentOutOfRangeException("Bad chance value!");

				fChanceOfRepeatingNote = value;
			}
		}
	}
}
