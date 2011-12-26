using System.Collections.Generic;

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
        public int PopulationSize { get; protected set; }

        /// <summary>
        /// Длина хромосомы индивидов
        /// </summary>
        public int ChromosomeLength { get; protected set; }

        /// <summary>
        /// Нижние допустимые значения локусов
        /// </summary>
        protected double[] LowBounds { get; set; }

        /// <summary>
        /// Верхние допустимые значения локусов
        /// </summary>
        protected double[] HighBounds { get; set; }

        /// <summary>
        /// Инициализатор первого поколения из непрерывных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        /// <param name="lowBound">Нижнее допустимое значение локусов</param>
        /// <param name="highBound">Верхнее допустимое значение локусов</param>
        public ContinuousPopulationInitializer(
            int populationSize,
            int chromosomeLength,
            double lowBound,
            double highBound)
        {
            PopulationSize = populationSize;
            ChromosomeLength = chromosomeLength;

            LowBounds = new double[chromosomeLength];
            HighBounds = new double[chromosomeLength];

            for (int i = 0; i < chromosomeLength; i++)
            {
                LowBounds[i] = lowBound;
                HighBounds[i] = highBound;
            }
        }

        /// <summary>
        /// Инициализатор первого поколения из непрерывных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        /// <param name="lowBounds">Нижние допустимые значения локусов</param>
        /// <param name="highBounds">Верхние допустимые значения локусов</param>
        public ContinuousPopulationInitializer(
            int populationSize,
            int chromosomeLength,
            double[] lowBounds,
            double[] highBounds)
        {
            PopulationSize = populationSize;
            ChromosomeLength = chromosomeLength;

            lowBounds = new double[ChromosomeLength];
            highBounds = new double[ChromosomeLength];

            lowBounds.CopyTo(LowBounds, 0);
            highBounds.CopyTo(HighBounds, 0);
        }

        #region IPopulationInitializer<ContinuousChromosome> Members

        IList<ContinuousChromosome> IPopulationInitializer<ContinuousChromosome>.Initialize()
        {
            List<ContinuousChromosome> population = new List<ContinuousChromosome>(PopulationSize);

            for (int i = 0; i < PopulationSize; i++)
                population.Add(new ContinuousChromosome(ChromosomeLength, LowBounds, HighBounds));

            return population;
        }

        #endregion
    }
}
