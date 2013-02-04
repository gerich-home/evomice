using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Стратегия формирования следующего поколения
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IReproductionStrategy<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
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
