using System.Collections.Generic;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Аутбридинг
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public class Outbreeding<TChromosome, TParentsPair>
        : IBreeding<IIndividual<TChromosome>, TParentsPair>
    {
        /// <summary>
        /// Вычислитель расстояния между хромосомами
        /// </summary>
        public IChromosomeDistance<TChromosome> ChromosomeDistance { get; protected set; }

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        public IParentsPairFactory<IIndividual<TChromosome>, TParentsPair> ParentsPairFactory { get; protected set; }

        /// <summary>
        /// Минимальная дистанция между скрещиваемыми хромосомами
        /// </summary>
        public double MinDistance { get; protected set; }

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        public int NumTests { get; protected set; }

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount { get; protected set; }

        /// <summary>
        /// Аутбридинг
        /// </summary>
        /// <param name="chromosomeDistance">Вычислитель расстояния между хромосомами</param>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="minDistance">Минимальная дистанция между скрещиваемыми хромосомами</param>
        /// <param name="numTests">Число попыток найти хорошую пару</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Outbreeding(
            IChromosomeDistance<TChromosome> chromosomeDistance,
            IParentsPairFactory<IIndividual<TChromosome>, TParentsPair> parentsPairFactory,
            double minDistance,
            int numTests,
            int pairCount)
        {
            ChromosomeDistance = chromosomeDistance;
            ParentsPairFactory = parentsPairFactory;
            MinDistance = minDistance;
            NumTests = numTests;
            PairCount = pairCount;
        }

        #region IBreeding<TChromosome,IIndividual<TChromosome>,TParentsPair> Members

        IReadOnlyList<TParentsPair> IBreeding<IIndividual<TChromosome>, TParentsPair>.Select(IReadOnlyList<IIndividual<TChromosome>> population)
        {
            int pCount = population.Count;
            var pairs = new List<TParentsPair>(PairCount);
            for (int i = 0; i < PairCount; i++)
            {
                int firstInd = Util.Random.Next(pCount);
                IIndividual<TChromosome> first = population[firstInd];

                int secondInd = Util.Random.Next(pCount - 1);
                if (secondInd >= firstInd)
                    secondInd++;

                IIndividual<TChromosome> best = population[secondInd];
                double bestDistance = ChromosomeDistance.Distance(
                    first.Chromosome, best.Chromosome);

                for (int j = 0; j < NumTests && bestDistance < MinDistance; j++)
                {
                    secondInd = Util.Random.Next(pCount - 1);
                    if (secondInd >= firstInd)
                        secondInd++;

                    IIndividual<TChromosome> second = population[secondInd];
                    double distance = ChromosomeDistance.Distance(
                        first.Chromosome, second.Chromosome);
                    if (distance > bestDistance)
                    {
                        bestDistance = distance;
                        best = second;
                    }
                }

                pairs.Add(ParentsPairFactory.CreatePair(first, best));
            }
            return pairs;
        }

        #endregion
    }
}