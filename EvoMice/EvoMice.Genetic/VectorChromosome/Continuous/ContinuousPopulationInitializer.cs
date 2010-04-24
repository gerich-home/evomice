using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Continuous
{
    /// <summary>
    /// Инициализатор первого поколения из непрерывных хромосом
    /// </summary>
    public class ContinuousPopulationInitializer :
        IPopulationInitializer<ContinuousChromosome>
    {
        /// <summary>
        /// Размер популяции
        /// </summary>
        protected int populationSize;

        /// <summary>
        /// Длина хромосомы индивидов
        /// </summary>
        protected int chromosomeLength;

        /// <summary>
        /// Нижние допустимые значения локусов
        /// </summary>
        protected double[] lowBounds;

        /// <summary>
        /// Верхние допустимые значения локусов
        /// </summary>
        protected double[] highBounds;

        /// <summary>
        /// Инициализатор первого поколения из непрерывных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        /// <param name="lowBound">Нижнее допустимое значение локусов</param>
        /// <param name="highBound">Верхнее допустимое значение локусов</param>
        public ContinuousPopulationInitializer(int populationSize, int chromosomeLength, double lowBound, double highBound)
        {
            this.populationSize = populationSize;
            this.chromosomeLength = chromosomeLength;

            lowBounds = new double[chromosomeLength];
            highBounds = new double[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                lowBounds[i] = lowBound;
                highBounds[i] = highBound;
            }
        }

        /// <summary>
        /// Инициализатор первого поколения из непрерывных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        /// <param name="lowBounds">Нижние допустимые значения локусов</param>
        /// <param name="highBounds">Верхние допустимые значения локусов</param>
        public ContinuousPopulationInitializer(int populationSize, int chromosomeLength, double[] lowBounds, double[] highBounds)
        {
            this.populationSize = populationSize;
            this.chromosomeLength = chromosomeLength;

            this.lowBounds = new double[chromosomeLength];
            this.highBounds = new double[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                this.lowBounds[i] = lowBounds[i];
                this.highBounds[i] = highBounds[i];
            }
        }

        /// <summary>
        /// Размер популяции
        /// </summary>
        public int PopulationSize
        {
            get { return populationSize; }
            set { populationSize = value; }
        }

        /// <summary>
        /// Длина хромосомы индивидов
        /// </summary>
        public int ChromosomeLength
        {
            get { return chromosomeLength; }
            set { chromosomeLength = value; }
        }

        #region IPopulationInitializer<ContinuousChromosome> Members

        IList<ContinuousChromosome> IPopulationInitializer<ContinuousChromosome>.Initialize()
        {
            List<ContinuousChromosome> population = new List<ContinuousChromosome>(populationSize);

            for (int i = 0; i < populationSize; i++)
                population.Add(new ContinuousChromosome(chromosomeLength, lowBounds, highBounds));

            return population;
        }

        #endregion
    }
}
