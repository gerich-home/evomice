using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Условие продолжения генетического алгоритма
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IContinueCondition<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Следует ли продолжать работу генетического алгоритма
        /// </summary>
        /// <param name="population">Текущее поколение</param>
        /// <param name="generation">Номер текущего поколения</param>
        /// <returns>true, если стоит продолжать</returns>
        bool ShouldContinue(IList<TIndividual> population, int generation);
    }
}
