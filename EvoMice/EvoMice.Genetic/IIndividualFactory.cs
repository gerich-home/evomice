
namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель индивида
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IIndividualFactory<TChromosome, out TIndividual>
    {
        /// <summary>
        /// Создаёт нового индивида
        /// </summary>
        /// <param name="chromosome">Хромосома индивида</param>
        /// <param name="fitnessFunction">Функция приспособленности для оценки индивида</param>
        /// <returns>Индивид</returns>
        TIndividual CreateIndividual(
            TChromosome chromosome,
            IFitnessFunction<TChromosome> fitnessFunction);
    }
}
