﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Бетта-турнирная селекция
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class BTournamentSelection<TChromosome, TIndividual> :
        ISelection<TChromosome, TIndividual>
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

        IList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, int count)
        {
            List<TIndividual> selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            TIndividual best;
            TIndividual current;

            for (int i = 0; i < count; i++)
            {
                best = reproductionGroup[Util.Random.Next(rCount)];

                for (int j = 1; j < Betta; j++)
                {
                    current = reproductionGroup[Util.Random.Next(rCount)];
                    if (current.Fitness > best.Fitness)
                        current = best;
                }

                selected.Add(best);
            }

            return selected;
        }

        #endregion
    }
}
