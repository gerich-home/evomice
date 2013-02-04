using System.Collections.Generic;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Ранговая селекция
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TSelector">Тип алгоритма отбора особей</typeparam>
    public class RankSelection<TChromosome, TIndividual, TSelector> :
        Selection<TChromosome, TIndividual, TSelector>
        where TIndividual : IIndividual<TChromosome>
        where TSelector : ISelector<TChromosome, TIndividual>
    {
        /// <summary>
        /// Верхняя граница ожидаемого числа копий самой приспособленной особи
        /// </summary>
        public double R { get; protected set; }

        /// <summary>
        /// Ранговая селекция
        /// </summary>
        /// <param name="r">Верхняя граница ожидаемого числа копий самой приспособленной особи</param>
        /// <param name="selector">Алгоритм отбора особей</param>
        public RankSelection(double r, TSelector selector) :
            base(selector)
        {
            R = r;
        }

        /// <summary>
        /// Произвести селекцию
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        protected override IReadOnlyList<TIndividual> DoSelection(IReadOnlyList<TIndividual> reproductionGroup, int count)
        {
            int rCount = reproductionGroup.Count;
            var ranks = new List<double>(rCount);

            var sortedPopulation = Util.PopulationSorter.SortPopulation<TChromosome, TIndividual>(reproductionGroup);

            double b = 2 - R;
            double a = 2 * (R - 1);
            double c = 1 / (rCount - 1.0);
            for (int i = 0; i < rCount; i++)
                ranks.Add(a * (1 - i * c) + b);

            return Selector.Select(sortedPopulation, ranks, count);
        }
    }
}
