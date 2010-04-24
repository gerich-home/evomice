using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель родительской пары
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public interface IParentsPairFactory<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
    {
        /// <summary>
        /// Создаёт новую родительскую пару
        /// </summary>
        /// <param name="mother">1-ая особь родительской пары</param>
        /// <param name="father">2-ая особь родительской пары</param>
        /// <returns>Родительская пара</returns>
        TParentsPair CreatePair(TIndividual mother, TIndividual father);
    }
}
