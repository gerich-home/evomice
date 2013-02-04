using System.Collections.Generic;

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
        public double MaxDelta { get; protected set; }

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount { get; protected set; }

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        public TParentsPairFactory ParentsPairFactory { get; protected set; }

        /// <summary>
        /// Позитивное ассоциативное скрещивание
        /// </summary>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="maxDelta">Максимальная разница между приспособленностями скрещиваемых особей</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public PositiveAssociativeMating(
            TParentsPairFactory parentsPairFactory,
            double maxDelta,
            int pairCount)
        {
            MaxDelta = maxDelta;
            PairCount = pairCount;
            ParentsPairFactory = parentsPairFactory;
        }

        #region IBreeding<TChromosome,TIndividual,TParentsPair> Members

        IList<TParentsPair> IBreeding<TChromosome, TIndividual, TParentsPair>.Select(IList<TIndividual> population)
        {
            IList<TIndividual> sortedPopulation =
                Util.PopulationSorter.SortPopulation<TChromosome, TIndividual>(
                    population
                );

            int pCount = population.Count;
            var pairs = new List<TParentsPair>(PairCount);

            for (int i = 0; i < PairCount; i++)
            {
                int firstInd = Util.Random.Next(pCount);
                TIndividual first = sortedPopulation[firstInd];

                int minInd;
                for (minInd = firstInd - 1; minInd >= 0; minInd--)
                    if ((sortedPopulation[minInd].Fitness - first.Fitness) > MaxDelta)
                        break;

                int maxInd;
                for (maxInd = firstInd + 1; maxInd < pCount; maxInd++)
                    if ((first.Fitness - sortedPopulation[maxInd].Fitness) > MaxDelta)
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

                pairs.Add(ParentsPairFactory.CreatePair(first, second));
            }
            return pairs;
        }

        #endregion
    }
}
