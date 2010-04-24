﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.ContinueCondition
{
    /// <summary>
    /// Условие продолжения генетического алгоритма, основанное на числе поколений
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class GenerationContinueCondition<TChromosome, TIndividual> :
        IContinueCondition<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Максимальное число поколений
        /// </summary>
        protected int maxGenerations;

        /// <summary>
        /// Условие продолжения генетического алгоритма, основанное на числе поколений
        /// </summary>
        /// <param name="maxGenerations">Максимальное число поколений</param>
        public GenerationContinueCondition(int maxGenerations)
        {
            this.maxGenerations = maxGenerations;
        }

        #region IContinueCondition<TChromosome,TIndividual> Members

        bool IContinueCondition<TChromosome, TIndividual>.ShouldContinue(IList<TIndividual> population, int generation)
        {
            return generation < maxGenerations;
        }

        #endregion
    }
}
