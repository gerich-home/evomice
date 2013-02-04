using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Система отбора(селекции) особей из репродукционного множества
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface ISelection<TIndividual>
    {
        /// <summary>
        /// Отбор особей
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        /// <remarks>Число отобранных особей может не совпадать с count, если невозможно отобрать особей по данной схеме селекции</remarks>
        IReadOnlyList<TIndividual> Select(IReadOnlyList<TIndividual> reproductionGroup, int count);
    }
}
