using System.Collections.Generic;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Панмиксия
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public class Panmixia<TIndividual, TParentsPair>
        : IBreeding<TIndividual, TParentsPair>
    {
        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount { get; protected set; }

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        public IParentsPairFactory<TIndividual, TParentsPair> ParentsPairFactory { get; protected set; }

        /// <summary>
        /// Панмиксия
        /// </summary>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Panmixia(IParentsPairFactory<TIndividual, TParentsPair> parentsPairFactory, int pairCount)
        {
            PairCount = pairCount;
            ParentsPairFactory = parentsPairFactory;
        }

        #region IBreeding<TChromosome,TIndividual,TParentsPair> Members

        IReadOnlyList<TParentsPair> IBreeding<TIndividual, TParentsPair>.Select(IReadOnlyList<TIndividual> population)
        {
            int pCount = population.Count;
            var pairs = new List<TParentsPair>(PairCount);

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
