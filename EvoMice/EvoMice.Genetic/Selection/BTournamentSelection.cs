using System.Collections.Generic;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Бетта-турнирная селекция
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class BTournamentSelection<TChromosome, TIndividual> :
        ISelection<TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Численность конкурирующей группы
        /// </summary>
        public int Betta { get; protected set; }

        /// <summary>
        /// Бетта-турнирная селекция
        /// </summary>
        /// <param name="betta">Численность конкурирующей группы</param>
        public BTournamentSelection(int betta)
        {
            Betta = betta;
        }

        #region ISelection<TChromosome,TIndividual> Members

        IReadOnlyList<TIndividual> ISelection<TIndividual>.Select(IReadOnlyList<TIndividual> reproductionGroup, int count)
        {
            var selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            for (int i = 0; i < count; i++)
            {
                var best = reproductionGroup[Util.Random.Next(rCount)];

                for (int j = 1; j < Betta; j++)
                {
                    var current = reproductionGroup[Util.Random.Next(rCount)];
                    if (current.Fitness > best.Fitness)
                        best = current;
                }

                selected.Add(best);
            }

            return selected;
        }

        #endregion
    }
}
