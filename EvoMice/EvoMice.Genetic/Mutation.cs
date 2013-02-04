
namespace EvoMice.Genetic
{
    /// <summary>
    /// Мутация
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public abstract class Mutation<TChromosome> :
        IMutation<TChromosome>
    {
        /// <summary>
        /// Вероятность кроссовера
        /// </summary>
        public double Probability { get; protected set; }

        /// <summary>
        /// Мутация
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        protected Mutation(double probability)
        {
            Probability = probability;
        }

        /// <summary>
        /// Операция мутации
        /// </summary>
        /// <param name="chromosome">Особь</param>
        /// <returns>Хромосома мутанта</returns>
        protected abstract TChromosome DoMutation(TChromosome chromosome);

        #region IMutation<TChromosome> Members

        TChromosome IMutation<TChromosome>.Mutate(TChromosome chromosome)
        {
            if (Util.Random.NextDouble() <= Probability)
                return DoMutation(chromosome);
            
            return chromosome;
        }

        #endregion
    }
}
