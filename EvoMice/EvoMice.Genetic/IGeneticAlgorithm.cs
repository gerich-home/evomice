
namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IGeneticAlgorithm<out TChromosome, out TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Запуск генетического алгоритма
        /// </summary>
        /// <param name="fitnessFunction">Функция приспосбленности</param>
        /// <returns>Лучшее решение, найденное генетическим алгоритмом</returns>
        TIndividual Run(IFitnessFunction<TChromosome> fitnessFunction);
    }
}
