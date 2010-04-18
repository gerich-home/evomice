using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Оцененная особь генетического алгоритма
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public interface IIndividual<TChromosome>
    {
        /// <summary>
        /// Значение приспособленности
        /// </summary>
        double Fitness { get; }

        /// <summary>
        /// Хромосома особи
        /// </summary>
        TChromosome Chromosome { get; }

        /// <summary>
        /// Пересчитывает значение приспособленности особи
        /// </summary>
        void RecalculateFitness();
    }
}
