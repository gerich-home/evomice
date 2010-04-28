using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Система отбора(селекции) особей из репродукционного множества
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface ISelection<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Отбор особей
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        /// <remarks>Число отобранных особей может не совпадать с count, если невозможно отобрать особей по данной схеме селекции</remarks>
        IList<TIndividual> Select(IList<TIndividual> reproductionGroup, int count);
    }
}
