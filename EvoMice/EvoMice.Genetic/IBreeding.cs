using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Система скрещивания (система подбора родительских пар)
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public interface IBreeding<TChromosome, in TIndividual, out TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
    {
        /// <summary>
        /// Выбор родительских пар из текущего поколения популяции
        /// </summary>
        /// <param name="population">Текущее поколение</param>
        /// <returns>Образованные родительские пары</returns>  
        IReadOnlyList<TParentsPair> Select(IReadOnlyList<TIndividual> population);
    }
}
