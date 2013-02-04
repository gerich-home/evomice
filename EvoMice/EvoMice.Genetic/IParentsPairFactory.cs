
namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель родительской пары
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public interface IParentsPairFactory<in TIndividual, out TParentsPair>
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
