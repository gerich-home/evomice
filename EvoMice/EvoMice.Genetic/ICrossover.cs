using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Скрещивание особей
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public interface ICrossover<TChromosome, in TParentsPair>
    {
        /// <summary>
        /// Производит скрещивание особей
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        IReadOnlyList<TChromosome> Crossover(TParentsPair parentsPair);
    }
}
