using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Панмиксия
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class Panmixia<TChromosome, TIndividual> :
        IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Панмиксия
        /// </summary>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Panmixia(int pairCount)
        {
            this.pairCount = pairCount;
        }

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount
        {
            get { return pairCount; }
            set { pairCount = value; }
        }

        #region IBreeding<TChromosome,TIndividual,ParentsPair<TChromosome,TIndividual>> Members

        IList<ParentsPair<TChromosome, TIndividual>> IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>.Select(IList<TIndividual> population)
        {
            int pCount = population.Count;
            List<ParentsPair<TChromosome, TIndividual>> pairs = new List<ParentsPair<TChromosome, TIndividual>>(pairCount);

            for (int i = 0; i < pairCount; i++)
            {
                int first = Util.Random.Next(pCount);
                int second = Util.Random.Next(pCount - 1);

                if (second >= first)
                    second++;

                pairs.Add(
                    new ParentsPair<TChromosome, TIndividual>(
                        population[first],population[second]
                        ));
            }
            return pairs;
        }

        #endregion
    }
}
