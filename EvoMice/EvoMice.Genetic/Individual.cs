
namespace EvoMice.Genetic
{
    /// <summary>
    /// Оцененная особь генетического алгоритма
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class Individual<TChromosome> : IIndividual<TChromosome>
    {
        /// <summary>
        /// Функция приспособленности
        /// </summary>
        public IFitnessFunction<TChromosome> FitnessFunction { get; protected set; }

        /// <summary>
        /// Оцененная особь генетического алгоритма
        /// </summary>
        /// <param name="individual">Неоцененная особь</param>
        /// <remarks>Оценивает особь, создавая новый объект Individual</remarks>
        public Individual(
            TChromosome chromosome,
            IFitnessFunction<TChromosome> fitnessFunction)
        {
            Chromosome = chromosome;
            FitnessFunction = fitnessFunction;
            RecalculateFitness();
        }

        #region IIndividual<TChromosome> Members

        /// <summary>
        /// Значение приспособленности
        /// </summary>
        public double Fitness { get; protected set; }

        /// <summary>
        /// Хромосома особи
        /// </summary>
        public TChromosome Chromosome { get; protected set; }

        /// <summary>
        /// Пересчитывает значение приспособленности особи
        /// </summary>
        public void RecalculateFitness()
        {
            Fitness = FitnessFunction.Calculate(Chromosome);
        }

        #endregion
    }
}