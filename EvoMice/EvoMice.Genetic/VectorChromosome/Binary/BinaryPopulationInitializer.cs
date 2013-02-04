using System.Collections.Generic;

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
        public int PopulationSize { get; protected set; }

        /// <summary>
        /// Длина хромосомы индивидов
        /// </summary>
        public int ChromosomeLength { get; protected set; }

        /// <summary>
        /// Инициализатор первого поколения из бинарных хромосом
        /// </summary>
        /// <param name="populationSize">Размер популяции</param>
        /// <param name="chromosomeLength">Длина хромосомы индивидов</param>
        public BinaryPopulationInitializer(int populationSize, int chromosomeLength)
        {
            PopulationSize = populationSize;
            ChromosomeLength = chromosomeLength;
        }

        #region IPopulationInitializer<BinaryChromosome> Members

        IReadOnlyList<BinaryChromosome> IPopulationInitializer<BinaryChromosome>.Initialize()
        {
            var population = new List<BinaryChromosome>(PopulationSize);

            for (int i = 0; i < PopulationSize; i++)
                population.Add(new BinaryChromosome(ChromosomeLength));

            return population;
        }

        #endregion
    }
}
