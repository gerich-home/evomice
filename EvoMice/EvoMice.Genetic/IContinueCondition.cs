using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Условие продолжения генетического алгоритма
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IContinueCondition<in TIndividual>
    {
        /// <summary>
        /// Следует ли продолжать работу генетического алгоритма
        /// </summary>
        /// <param name="population">Текущее поколение</param>
        /// <param name="generation">Номер текущего поколения</param>
        /// <returns>true, если стоит продолжать</returns>
        bool ShouldContinue(IReadOnlyList<TIndividual> population, int generation);
    }
}
