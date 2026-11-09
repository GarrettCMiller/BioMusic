using System;
using System.Collections;
using System.Numeric;
using System.Linq;
using System.Text;

namespace BioMusic
{
	class Probability
	{
		protected double probability = 1.0;

		public Probability(double chance)
		{
			this.Chance = chance;
		}

		public double Chance
		{
			get { return probability; }
			set
			{
				if (value < 0 || value > 1.0)
					throw new ArgumentOutOfRangeException();

				probability = value;
			}
		}
	}
}
