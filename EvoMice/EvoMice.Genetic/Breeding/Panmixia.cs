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
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TParentsPairFactory">Создатель родительской пары</typeparam>
    public class Panmixia<TChromosome, TIndividual, TParentsPair, TParentsPairFactory> :
        IBreeding<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TParentsPairFactory : IParentsPairFactory<TChromosome, TIndividual, TParentsPair>
    {
        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        protected TParentsPairFactory parentsPairFactory;

        /// <summary>
        /// Панмиксия
        /// </summary>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Panmixia(TParentsPairFactory parentsPairFactory, int pairCount)
        {
            this.pairCount = pairCount;
            this.parentsPairFactory = parentsPairFactory;
        }

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount
        {
            get { return pairCount; }
            set { pairCount = value; }
        }

        #region IBreeding<TChromosome,TIndividual,TParentsPair> Members

        IList<TParentsPair> IBreeding<TChromosome, TIndividual, TParentsPair>.Select(IList<TIndividual> population)
        {
            int pCount = population.Count;
            List<TParentsPair> pairs = new List<TParentsPair>(pairCount);

            for (int i = 0; i < pairCount; i++)
            {
                int first = Util.Random.Next(pCount);
                int second = Util.Random.Next(pCount - 1);

                if (second >= first)
                    second++;

                pairs.Add(parentsPairFactory.CreatePair(
                        population[first], population[second]
                        ));
            }
            return pairs;
        }

        #endregion
    }
}
