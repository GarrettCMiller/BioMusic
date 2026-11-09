using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioMusic
{
	abstract class BaseGenotype
	{
		protected static int m_nNumElements = 1;
		protected static int m_nNumTotalBits = sizeof(float) * m_nNumElements;

		protected string m_strBitString;
		protected ArrayList m_arrVars = new ArrayList();

		protected float m_fNormFitness = -1.0f;

		protected int m_nDefaultOneInChance = 1000;
		protected Random m_rndRand = new Random();

		///////////////////////////////
		///////////////////////////////

		public BaseGenotype()
		{
		}

		public BaseGenotype(BaseGenotype other)
		{
			CopyFrom(other);
		}

		public int NumElements
		{
			get	{ return m_nNumElements; }
		}

		public int NumTotalBits
		{
			get	{ return m_nNumTotalBits; }
		}

		public int OneInChance
		{
			get { return m_nDefaultOneInChance; }

			set
			{
				if (value <= 0)	throw new ArgumentOutOfRangeException("OneInChance value must be greater than or equal to one!");
				m_nDefaultOneInChance = value;
			}
		}

		public string BitString
		{
			get { return m_strBitString; }
			protected set { m_strBitString = value; }
		}

		public float NormalizedFitness
		{
			get { return m_fNormFitness; }
			protected set { m_fNormFitness = value; }
		}

		public abstract void SetValues(object[] arrVals);
		public abstract float Evaluate();
		public abstract void Randomize();
		public abstract void SetDefaults();

		/////////////////////////////////////////////////////////
		/////////////////////////////////////////////////////////

		public void CopyFrom(BaseGenotype other)
		{
			this.BitString = other.BitString;
			this.m_arrVars = other.m_arrVars;
			this.NormalizedFitness = other.NormalizedFitness;
			this.OneInChance = other.OneInChance;
		}

		public virtual void CrossoverUnary(ref BaseGenotype mother)
		{
			int swapIndex = m_rndRand.Next(NumTotalBits);

			string str1 = mother.BitString;
			string str2 = BitString;

			mother.BitString = str1.Substring(0, swapIndex);
			mother.BitString += str2.Substring(swapIndex + 1);

			BitString = str2.Substring(0, swapIndex);
			BitString += str1.Substring(swapIndex + 1);
		}

		public virtual void CrossoverBinary(ref BaseGenotype mother)
		{
			int	swapIndex1 = m_rndRand.Next(NumTotalBits),
				swapIndex2 = m_rndRand.Next(NumTotalBits);

			if (swapIndex1 > swapIndex2)
				Swap(swapIndex1, swapIndex2);

			string str1 = mother.BitString;
			string str2 = BitString;

			mother.BitString = str1.Substring(0, swapIndex1);
			mother.BitString += str2.Substring(swapIndex1 + 1, swapIndex2);
			mother.BitString += str1.Substring(swapIndex2 + 1);

			BitString = str2.Substring(0, swapIndex1);
			BitString += str1.Substring(swapIndex1 + 1, swapIndex2);
			BitString += str2.Substring(swapIndex2 + 1);
		}

		private void Swap(int swapIndex1,int swapIndex2)
		{
 			int temp = swapIndex1;
			swapIndex1 = swapIndex2;
			swapIndex2 = temp;
		}

		public virtual void CrossoverDisruption(ref BaseGenotype mother)
		{
			string str1 = mother.BitString;
			string str2 = BitString;

			mother.BitString = "";
			BitString = "";

			for (int v = 0; v < NumElements; v++)
			{
				int	swapIndex = sizeof(float) * (v + 1);

				if (m_rndRand.Next(1) == 1)
				{
					mother.BitString += str1.Substring(v * swapIndex, (v + 1) * swapIndex);
					BitString += str2.Substring(v * swapIndex, (v + 1) * swapIndex);
				}
				else
				{
					mother.BitString += str2.Substring(v * swapIndex, (v + 1) * swapIndex);
					BitString += str1.Substring(v * swapIndex, (v + 1) * swapIndex);
				}
			}
		}

		public virtual void Mutate(int oneInChance)
		{
			string temp = "";

			for (int i = 0; i < BitString.Length; i++)
			{
				if (m_rndRand.Next(oneInChance) == 0)
				{
					if (m_strBitString[i] == '1')
						temp += '0';
					else
						temp += '1';
				}
			}
		}

		public virtual void Mutate()
		{
			string temp = "";

			for (int i = 0; i < m_strBitString.Length; i++)
			{
				if (m_rndRand.Next(OneInChance) == 0)
				{
					if (BitString[i] == '1')
						temp += '0';
					else
						temp += '1';
				}
			}
		}

		public void SetNormalizedFitness(float fFitness)
		{
			m_fNormFitness = fFitness;
		}

		public int ConvertFloatToInt(float f)
		{
			return (int)(f * (float)(int.MaxValue));
		}

		///////////////////////////////////////////////

		protected virtual void CreateBitString()
		{
			BitString.Remove(0);

			for (int v = 0; v < NumElements; v++)
			{
				float fVal = (float)(m_arrVars[v * 3]);
				int val = 0;
				
				//if (fVal != 0.0f)
					val = ConvertFloatToInt(fVal);	//FloatToInt(fVal);
				/*else
					val = 0;*/

				for (int bit = 1; bit <= sizeof(int) * 8; bit++)
				{
					int bitVal = (int)Math.Pow(2.0f, (float)(bit - 1));

					if ((val & bitVal) == bitVal)
						BitString += "1";
					else
						BitString += "0";
				}
			}
		}
	}
}
