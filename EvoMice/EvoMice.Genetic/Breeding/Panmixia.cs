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
        public int PairCount { get; protected set; }

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        public TParentsPairFactory ParentsPairFactory { get; protected set; }

        /// <summary>
        /// Панмиксия
        /// </summary>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Panmixia(TParentsPairFactory parentsPairFactory, int pairCount)
        {
            PairCount = pairCount;
            ParentsPairFactory = parentsPairFactory;
        }

        #region IBreeding<TChromosome,TIndividual,TParentsPair> Members

        IList<TParentsPair> IBreeding<TChromosome, TIndividual, TParentsPair>.Select(IList<TIndividual> population)
        {
            int pCount = population.Count;
            List<TParentsPair> pairs = new List<TParentsPair>(PairCount);

            for (int i = 0; i < PairCount; i++)
            {
                int first = Util.Random.Next(pCount);
                int second = Util.Random.Next(pCount - 1);

                if (second >= first)
                    second++;

                pairs.Add(ParentsPairFactory.CreatePair(
                        population[first], population[second]
                        ));
            }
            return pairs;
        }

        #endregion
    }
}
