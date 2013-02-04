
namespace EvoMice.Genetic
{
    /// <summary>
    /// Родительская пара
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IParentsPair<out TIndividual>
    {
        /// <summary>
        /// 1-ая особь родительской пары
        /// </summary>
        TIndividual Mother { get; }

        /// <summary>
        /// 2-ая особь родительской пары
        /// </summary>
        TIndividual Father { get; }
    }
}
