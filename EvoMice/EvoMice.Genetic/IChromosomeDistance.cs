
namespace EvoMice.Genetic
{
    /// <summary>
    /// Измеритель расстояния между хромосомами
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы</typeparam>
    public interface IChromosomeDistance<in TChromosome>
    {
        /// <summary>
        /// Расстояние между двумя хромосомами
        /// </summary>
        /// <param name="first">Первая хромосома</param>
        /// <param name="second">Вторая хромосома</param>
        /// <returns>Расстояние</returns>
        double Distance(TChromosome first, TChromosome second);
    }
}
