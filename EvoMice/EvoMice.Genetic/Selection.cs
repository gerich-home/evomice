using System.Collections.Generic;
using EvoMice.Genetic.Selection;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Селекция
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TSelector">Тип алгоритма отбора особей</typeparam>
    public abstract class Selection<TChromosome, TIndividual, TSelector> :
        ISelection<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
        where TSelector : ISelector<TChromosome, TIndividual>
    {
        /// <summary>
        /// Алгоритм отбора особей
        /// </summary>
        public TSelector Selector { get; protected set; }

        /// <summary>
        /// Селекция
        /// </summary>
        /// <param name="selector">Алгоритм отбора особей</param>
        public Selection(TSelector selector)
        {
            Selector = selector;
        }

        /// <summary>
        /// Произвести селекцию
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        protected abstract IList<TIndividual> DoSelection(IList<TIndividual> reproductionGroup, int count);

        #region ISelection<TChromosome,TIndividual> Members
        
        IList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, int count)
        {
            if (count == 0)
                return new List<TIndividual>(0);
            else
                return DoSelection(reproductionGroup, count);
        }

        #endregion
    }
}
