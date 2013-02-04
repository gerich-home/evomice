using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Селекция
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TSelector">Тип алгоритма отбора особей</typeparam>
    public abstract class Selection<TIndividual, TSelector>
        : ISelection<TIndividual>
    {
        /// <summary>
        /// Алгоритм отбора особей
        /// </summary>
        public TSelector Selector { get; protected set; }

        /// <summary>
        /// Селекция
        /// </summary>
        /// <param name="selector">Алгоритм отбора особей</param>
        protected Selection(TSelector selector)
        {
            Selector = selector;
        }

        /// <summary>
        /// Произвести селекцию
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        protected abstract IReadOnlyList<TIndividual> DoSelection(IReadOnlyList<TIndividual> reproductionGroup, int count);

        #region ISelection<TChromosome,TIndividual> Members

        IReadOnlyList<TIndividual> ISelection<TIndividual>.Select(IReadOnlyList<TIndividual> reproductionGroup, int count)
        {
            if (count == 0)
                return new List<TIndividual>(0);
            
            return DoSelection(reproductionGroup, count);
        }

        #endregion
    }
}
