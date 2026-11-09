using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace BioMusic
{
	class GeneticAlgorithm<GeneType> where GeneType : BaseGenotype, new()
	{
		//public delegate Eval func

		protected Random m_rndRand = new Random();

		protected ArrayList/*<GeneType>*/ m_CurrentPopulation = new ArrayList();
		protected ArrayList/*<GeneType>*/ m_CurrentSurvivors = new ArrayList();

		protected float m_fCurrentTotalFitness = 0.0f;
		protected float m_fSurvivalFitness = 0.5f;

		protected ArrayList/*<ArrayList<GeneType>>*/ m_PopulationHistory = new ArrayList();

		///////////////////////////////////////////////
		///////////////////////////////////////////////

		public virtual void CreateInitialPopulation(int popSize)
		{
			for (int i = 0; i < popSize; i++)
			{
				GeneType newGene = new GeneType();
				newGene.Randomize();
				m_CurrentPopulation.Add(newGene);
			}
		}

		public virtual void CheckFitness()
		{
			m_fCurrentTotalFitness = 0.0f;

			//Compute total fitness
			foreach (GeneType gene in m_CurrentPopulation)
				m_fCurrentTotalFitness += gene.Evaluate();

			m_PopulationHistory.Add(m_CurrentPopulation);
			m_CurrentSurvivors.Clear();

			//Normalize all fitness values and kill off those that don't meet min fitness
			foreach (GeneType gene in m_CurrentPopulation)
			{
				float fFitness = gene.Evaluate() / m_fCurrentTotalFitness;

				//We have a survivor
				if (fFitness >= m_fSurvivalFitness)
				{
					gene.SetNormalizedFitness(fFitness);
					gene.Mutate();
					m_CurrentSurvivors.Add(gene);
				}
			}

			if (m_CurrentSurvivors.Count >= 2)
			{
				for (int i = 0; i < m_CurrentSurvivors.Count / 2; i++)
				{
					int index1 = m_rndRand.Next(m_CurrentSurvivors.Count - 1),
						index2 = m_rndRand.Next(m_CurrentSurvivors.Count - 1);

					while (index1 == index2)
						index2 = m_rndRand.Next(m_CurrentSurvivors.Count - 1);

					GeneType parent1 = (GeneType)m_CurrentSurvivors[index1],
							 parent2 = (GeneType)m_CurrentSurvivors[index2];

					BaseGenotype child1 = new GeneType(),
								 child2 = new GeneType();

					child1.CopyFrom(parent1);
					child2.CopyFrom(parent2);

					m_CurrentSurvivors.Remove(parent1);
					m_CurrentSurvivors.Remove(parent2);

					switch (m_rndRand.Next(2))
					{
						case 0: child1.CrossoverBinary(ref child2); break;
						case 1: child1.CrossoverUnary(ref child2); break;
						case 2: child1.CrossoverDisruption(ref child2); break;
					}

					m_CurrentPopulation.Add(parent1);
					m_CurrentPopulation.Add(parent2);
					m_CurrentPopulation.Add(child1);
					m_CurrentPopulation.Add(child2);
				}
			}

			if (m_CurrentSurvivors.Count > 1)
				throw new Exception("Population left over that didn't reproduce!");
		}

	}
}
