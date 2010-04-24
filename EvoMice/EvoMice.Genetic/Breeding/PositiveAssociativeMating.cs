using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Позитивное ассоциативное скрещивание
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TParentsPairFactory">Создатель родительской пары</typeparam>
    public class PositiveAssociativeMating<TChromosome, TIndividual, TParentsPair, TParentsPairFactory> :
        IBreeding<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TParentsPairFactory : IParentsPairFactory<TChromosome, TIndividual, TParentsPair>
    {
        /// <summary>
        /// Максимальная разница между приспособленностями скрещиваемых особей
        /// </summary>
        protected double maxDelta;

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        protected TParentsPairFactory parentsPairFactory;

        /// <summary>
        /// Позитивное ассоциативное скрещивание
        /// </summary>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="maxDelta">Максимальная разница между приспособленностями скрещиваемых особей</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public PositiveAssociativeMating(TParentsPairFactory parentsPairFactory, double maxDelta, int pairCount)
        {
            this.maxDelta = maxDelta;
            this.pairCount = pairCount;
            this.parentsPairFactory = parentsPairFactory;
        }

        /// <summary>
        /// Максимальная разница между приспособленностями скрещиваемых особей
        /// </summary>
        public double MaxDelta
        {
            get { return maxDelta; }
            set { maxDelta = value; }
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
            TIndividual[] sortedPopulation =
                Util.PopulationSorter.SortPopulation<TChromosome, TIndividual>(
                    population
                );

            int pCount = population.Count;
            List<TParentsPair> pairs =
                new List<TParentsPair>(pairCount);

            int minInd;
            int maxInd;

            for (int i = 0; i < pairCount; i++)
            {
                int firstInd = Util.Random.Next(pCount);
                TIndividual first = sortedPopulation[firstInd];

                for (minInd = firstInd - 1; minInd >= 0; minInd--)
                    if ((sortedPopulation[minInd].Fitness - first.Fitness) > maxDelta)
                        break;

                for (maxInd = firstInd + 1; maxInd < pCount; maxInd++)
                    if ((first.Fitness - sortedPopulation[maxInd].Fitness) > maxDelta)
                        break;

                if (maxInd - minInd == 2)
                {
                    i--;
                    continue;
                }

                int secondInd = minInd + 1 + Util.Random.Next(maxInd - minInd - 2);
                if (secondInd >= firstInd)
                    secondInd++;

                TIndividual second = population[secondInd];

                pairs.Add(parentsPairFactory.CreatePair(first, second));
            }
            return pairs;
        }

        #endregion
    }
}
