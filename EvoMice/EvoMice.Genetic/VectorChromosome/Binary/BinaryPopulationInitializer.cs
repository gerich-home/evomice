using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Binary
{
    /// <summary>
    /// Инициализатор первого поколения из бинарных хромосом
    /// </summary>
    public class BinaryPopulationInitializer : 
        IPopulationInitializer<BinaryChromosome>
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
        /// Инициализатор первого поколения из бинарных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        public BinaryPopulationInitializer(int populationSize, int chromosomeLength)
        {
            this.populationSize = populationSize;
            this.chromosomeLength = chromosomeLength;
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

        #region IPopulationInitializer<BinaryChromosome> Members

        IList<BinaryChromosome> IPopulationInitializer<BinaryChromosome>.Intialize()
        {
            List<BinaryChromosome> population = new List<BinaryChromosome>(populationSize);

            for (int i = 0; i < populationSize; i++)
                population.Add(new BinaryChromosome(chromosomeLength));

            return population;
        }

        #endregion
    }
}
