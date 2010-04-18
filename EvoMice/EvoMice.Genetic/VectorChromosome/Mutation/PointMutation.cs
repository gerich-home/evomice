using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Mutation
{
    /// <summary>
    /// Одноточечная мутация
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class PointMutation<TChromosome, TLocus> :
        Mutation<TChromosome>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TLocus : IMutateable<TLocus>
    {
        /// <summary>
        /// Одноточечная мутация
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        public PointMutation(double probability)
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

            int mutationPosition = Util.Random.Next(chromosome.Length);
            mutant[mutationPosition] = mutant[mutationPosition].Mutate();

            return mutant;
        }
    }
}
