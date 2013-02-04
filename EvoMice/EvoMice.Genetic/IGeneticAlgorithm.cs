﻿
namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TFitnessFunction">Тип функции приспособленности</typeparam>
    public interface IGeneticAlgorithm<TChromosome, out TIndividual, in TFitnessFunction>
        where TIndividual : IIndividual<TChromosome>
        where TFitnessFunction : IFitnessFunction<TChromosome>
    {
        /// <summary>
        /// Запуск генетического алгоритма
        /// </summary>
        /// <param name="fitnessFunction">Функция приспосбленности</param>
        /// <returns>Лучшее решение, найденное генетическим алгоритмом</returns>
        TIndividual Run(TFitnessFunction fitnessFunction);
    }
}
