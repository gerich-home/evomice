using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Аутбридинг
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TChromosomeDistance">Тип вычислителя расстояния между хромосомами</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TParentsPairFactory">Создатель родительской пары</typeparam>
    public class Outbreeding<TChromosome, TIndividual, TChromosomeDistance, TParentsPair, TParentsPairFactory> :
        IBreeding<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TChromosomeDistance : IChromosomeDistance<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TParentsPairFactory : IParentsPairFactory<TChromosome, TIndividual, TParentsPair>
    {
        /// <summary>
        /// Вычислитель расстояния между хромосомами
        /// </summary>
        protected TChromosomeDistance chromosomeDistance;

        /// <summary>
        /// Создатель родительской пары
        /// </summary>
        protected TParentsPairFactory parentsPairFactory;

        /// <summary>
        /// Минимальная дистанция между скрещиваемыми хромосомами
        /// </summary>
        protected double minDistance;

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        protected int numTests;

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Аутбридинг
        /// </summary>
        /// <param name="chromosomeDistance">Вычислитель расстояния между хромосомами</param>
        /// <param name="parentsPairFactory">Создатель родительской пары</param>
        /// <param name="minDistance">Минимальная дистанция между скрещиваемыми хромосомами</param>
        /// <param name="numTests">Число попыток найти хорошую пару</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Outbreeding(TChromosomeDistance chromosomeDistance, TParentsPairFactory parentsPairFactory, double minDistance, int numTests, int pairCount)
        {
            this.chromosomeDistance = chromosomeDistance;
            this.parentsPairFactory = parentsPairFactory;
            this.minDistance = minDistance;
            this.numTests = numTests;
            this.pairCount = pairCount;
        }

        /// <summary>
        /// Вычислитель расстояния между хромосомами
        /// </summary>
        public TChromosomeDistance ChromosomeDistance
        {
            get { return chromosomeDistance; }
            set { chromosomeDistance = value; }
        }

        /// <summary>
        /// Минимальная дистанция между скрещиваемыми хромосомами
        /// </summary>
        public double MinDistance
        {
            get { return minDistance; }
            set { minDistance = value; }
        }

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        public int NumTests
        {
            get { return numTests; }
            set { numTests = value; }
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
                int firstInd = Util.Random.Next(pCount);
                TIndividual first = population[firstInd];

                int secondInd = Util.Random.Next(pCount - 1);
                if (secondInd >= firstInd)
                    secondInd++;

                TIndividual best = population[secondInd];
                double bestDistance = chromosomeDistance.Distance(
                    first.Chromosome, best.Chromosome);

                for (int j = 0; j < numTests && bestDistance < minDistance; j++)
                {
                    secondInd = Util.Random.Next(pCount - 1);
                    if (secondInd >= firstInd)
                        secondInd++;

                    TIndividual second = population[secondInd];
                    double distance = chromosomeDistance.Distance(
                        first.Chromosome, second.Chromosome);
                    if (distance > bestDistance)
                    {
                        bestDistance = distance;
                        best = second;
                    }
                }

                pairs.Add(parentsPairFactory.CreatePair(first, best));
            }
            return pairs;
        }

        #endregion
    }
}