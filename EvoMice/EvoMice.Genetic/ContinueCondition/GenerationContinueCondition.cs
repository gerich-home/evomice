using System.Collections.Generic;

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
        public int MaxGenerations { get; protected set; }

        /// <summary>
        /// Условие продолжения генетического алгоритма, основанное на числе поколений
        /// </summary>
        /// <param name="maxGenerations">Максимальное число поколений</param>
        public GenerationContinueCondition(int maxGenerations)
        {
            MaxGenerations = maxGenerations;
        }

        #region IContinueCondition<TChromosome,TIndividual> Members

        bool IContinueCondition<TChromosome, TIndividual>.ShouldContinue(IList<TIndividual> population, int generation)
        {
            return generation < MaxGenerations;
        }

        #endregion
    }
}
