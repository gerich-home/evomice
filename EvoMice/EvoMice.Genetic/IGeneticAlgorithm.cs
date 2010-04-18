using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IGeneticAlgorithm<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Запуск генетического алгоритма
        /// </summary>
        void Run();

        /// <summary>
        /// Лучшее решение, найденное генетическим алгоритмом
        /// </summary>
        TIndividual BestSolution { get; }
    }
}
