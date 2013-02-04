using System.Collections.Generic;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Алгоритм отбора особей на основе сопоставленных им рангам или вероятностям
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface ISelector<TIndividual>
    {
        /// <summary>
        /// Отбор особей на основе сопоставленных им рангам или вероятностям
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="ranks">Ранги, сопоставленные особям</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        /// <remarks>Ранги рассматриваются как относительные величины</remarks>
        IReadOnlyList<TIndividual> Select(IReadOnlyList<TIndividual> reproductionGroup, IReadOnlyList<double> ranks, int count);
    }
}
