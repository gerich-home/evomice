
namespace EvoMice.Genetic.VectorChromosome.Mutation
{
    /// <summary>
    /// Дополнение
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class Addition<TChromosome, TLocus> :
        Mutation<TChromosome>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TLocus : IMutateable<TLocus>
    {
        /// <summary>
        /// Дополнение
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        public Addition(double probability)
            : base(probability)
        { }

        /// <summary>
        /// Операция мутации
        /// </summary>
        /// <param name="chromosome">Особь</param>
        /// <returns>Хромосома мутанта</returns>
        protected override TChromosome DoMutation(TChromosome chromosome)
        {
            TChromosome mutant = chromosome.Copy();

            for (int i = 0; i < chromosome.Length; i++)
                mutant[i] = mutant[i].Mutate();

            return mutant;
        }
    }
}
