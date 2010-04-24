using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.ReproductionStrategy
{
    /// <summary>
    /// Стратегия формирования следующего поколения на основе перекрытия поколений
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TSelection">Тип отбора</typeparam>
    public class OverlapReproductionStrategy<TChromosome, TIndividual, TSelection> :
        IReproductionStrategy<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
        where TSelection : ISelection<TChromosome, TIndividual>
    {
        /// <summary>
        /// Параметр перекрытия
        /// </summary>
        /// <remarks>1 - неперекрывающиеся множества</remarks>
        protected double g;

        /// <summary>
        /// Метода отбора особей
        /// </summary>
        protected TSelection selection;

        /// <summary>
        /// Стратегия формирования следующего поколения на основе перекрытия поколений
        /// </summary>
        /// <param name="g">Параметр перекрытия</param>
        /// <param name="selection">Метода отбора особей</param>
        public OverlapReproductionStrategy(double g, TSelection selection)
        {
            this.g = g;
            this.selection = selection;
        }

        /// <summary>
        /// Параметр перекрытия
        /// </summary>
        /// <remarks>1 - неперекрывающиеся множества</remarks>
        public double G
        {
            get { return g; }
            set { g = value; }
        }

        /// <summary>
        /// Метода отбора особей
        /// </summary>
        public TSelection Selection
        {
            get { return selection; }
            set { selection = value; }
        }

        #region IReproductionStrategy<TChromosome,TIndividual> Members

        IList<TIndividual> IReproductionStrategy<TChromosome, TIndividual>.NextGeneration(IList<TIndividual> population, IList<TIndividual> reproductionGroup)
        {
            List<TIndividual> newPopulation = new List<TIndividual>(population.Count);

            TIndividual[] sortedPopulation = Util.PopulationSorter.SortPopulation<TChromosome, TIndividual>(population);

            int gCount = (int)(g * population.Count);
            for (int i = 0; i < gCount; i++)
                newPopulation.Add(sortedPopulation[i]);

            newPopulation.AddRange(
                selection.Select(reproductionGroup, population.Count - gCount)
                );
            return newPopulation;
        }

        #endregion
    }
}
