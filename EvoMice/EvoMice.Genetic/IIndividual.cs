
namespace EvoMice.Genetic
{
    /// <summary>
    /// Оцененная особь генетического алгоритма
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public interface IIndividual<out TChromosome>
    {
        /// <summary>
        /// Значение приспособленности
        /// </summary>
        double Fitness { get; }

        /// <summary>
        /// Хромосома особи
        /// </summary>
        TChromosome Chromosome { get; }

        /// <summary>
        /// Пересчитывает значение приспособленности особи
        /// </summary>
        void RecalculateFitness();
    }
}
