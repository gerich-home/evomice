using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Стратегия формирования следующего поколения
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IReproductionStrategy<TIndividual>
    {
        /// <summary>
        /// Сформировать следующее поколение
        /// </summary>
        /// <param name="population">Текущее поколение</param>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <returns>Новое поколение</returns>
        IReadOnlyList<TIndividual> NextGeneration(IReadOnlyList<TIndividual> population, IReadOnlyList<TIndividual> reproductionGroup);
    }
}
