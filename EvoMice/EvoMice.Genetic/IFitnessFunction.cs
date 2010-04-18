using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Функция приспособленности
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public interface IFitnessFunction<TChromosome>
    {
        /// <summary>
        /// Вычислить приспособленность особи с данной хромосомой
        /// </summary>
        /// <returns>Приспособленность</returns>
        /// <remarks>Два разных вызова Calculate могут вернуть различные значения приспособленности</remarks>
        double Calculate(TChromosome chromosome);
    }
}
