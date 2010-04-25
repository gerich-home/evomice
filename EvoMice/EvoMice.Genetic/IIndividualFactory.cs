using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель индивида
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TFitnessFunction">Тип функции приспособленности</typeparam>
    public interface IIndividualFactory<TChromosome, TIndividual, TFitnessFunction>
        where TIndividual : IIndividual<TChromosome>
        where TFitnessFunction : IFitnessFunction<TChromosome>
    {
        /// <summary>
        /// Создаёт нового индивида
        /// </summary>
        /// <param name="chromosome">Хромосома индивида</param>
        /// <param name="fitnessFunction">Функция приспособленности для оценки индивида</param>
        /// <returns>Индивид</returns>
        TIndividual CreateIndividual(
            TChromosome chromosome,
            TFitnessFunction fitnessFunction);
    }
}
