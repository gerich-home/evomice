﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Инбридинг
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TChromosomeDistance">Тип вычислителя расстояния между хромосомами</typeparam>
    public class Inbreeding<TChromosome, TIndividual, TChromosomeDistance> :
        IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>
        where TIndividual : IIndividual<TChromosome>
        where TChromosomeDistance : IChromosomeDistance<TChromosome>
    {
        /// <summary>
        /// Вычислитель расстояния между хромосомами
        /// </summary>
        protected TChromosomeDistance сhromosomeDistance;

        /// <summary>
        /// Максимальная дистанция между скрещиваемыми хромосомами
        /// </summary>
        protected double maxDistance;

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        protected int numTests;

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Инбридинг
        /// </summary>
        /// <param name="сhromosomeDistance">Вычислитель расстояния между хромосомами</param>
        /// <param name="maxDistance">Максимальная дистанция между скрещиваемыми хромосомами</param>
        /// <param name="numTests">Число попыток найти хорошую пару</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public Inbreeding(TChromosomeDistance сhromosomeDistance, double maxDistance, int numTests, int pairCount)
        {
            this.сhromosomeDistance = сhromosomeDistance;
            this.maxDistance = maxDistance;
            this.numTests = numTests;
            this.pairCount = pairCount;
        }

        /// <summary>
        /// Вычислитель расстояния между хромосомами
        /// </summary>
        public TChromosomeDistance ChromosomeDistance
        {
            get { return сhromosomeDistance; }
            set { сhromosomeDistance = value; }
        }

        /// <summary>
        /// Максимальная дистанция между скрещиваемыми хромосомами
        /// </summary>
        public double MaxDistance
        {
            get { return maxDistance; }
            set { maxDistance = value; }
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

        #region IBreeding<TChromosome,TIndividual,ParentsPair<TChromosome,TIndividual>> Members

        IList<ParentsPair<TChromosome, TIndividual>> IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>.Select(IList<TIndividual> population)
        {
            int pCount = population.Count;
            List<ParentsPair<TChromosome, TIndividual>> pairs = new List<ParentsPair<TChromosome, TIndividual>>(pairCount);
            for (int i = 0; i < pairCount; i++)
            {
                int firstInd = Util.Random.Next(pCount);
                TIndividual first = population[firstInd];

                int secondInd = Util.Random.Next(pCount - 1);
                if (secondInd >= firstInd)
                    secondInd++;

                TIndividual best = population[secondInd];
                double bestDistance = сhromosomeDistance.Distance(
                    first.Chromosome, best.Chromosome);

                for (int j = 0; j < numTests && bestDistance > maxDistance; j++)
                {
                    secondInd = Util.Random.Next(pCount - 1);
                    if (secondInd >= firstInd)
                        secondInd++;

                    TIndividual second = population[secondInd];
                    double distance = сhromosomeDistance.Distance(
                        first.Chromosome, second.Chromosome);
                    if (distance < bestDistance)
                    {
                        bestDistance = distance;
                        best = second;
                    }
                }

                pairs.Add(new ParentsPair<TChromosome, TIndividual>(first, best));
            }
            return pairs;
        }

        #endregion
    }
}