using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Скрещивание особей
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public interface ICrossover<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
    {
        /// <summary>
        /// Производит скрещивание особей
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        IList<TChromosome> Crossover(TParentsPair parentsPair);
    }
}
