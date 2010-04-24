using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Mutation
{
    /// <summary>
    /// Сальтация
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class Saltation<TChromosome, TLocus> :
        Mutation<TChromosome>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TLocus : IMutateable<TLocus>
    {
        /// <summary>
        /// Число изменяемых локусов
        /// </summary>
        public int Count { get; protected set; }

        /// <summary>
        /// Сальтация
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        /// <param name="count">Число изменяемых локусов</param>
        public Saltation(double probability, int count)
            : base(probability)
        {
            Count = count;
        }

        /// <summary>
        /// Операция мутации
        /// </summary>
        /// <param name="chromosome">Особь</param>
        /// <returns>Хромосома мутанта</returns>
        protected override TChromosome DoMutation(TChromosome chromosome)
        {
            TChromosome mutant = chromosome.Copy();

            int[] remained = new int[chromosome.Length];
            for (int i = 0; i < chromosome.Length; i++)
                remained[i] = i;

            int mutationPosition;
            for (int i = 0; i < Count; i++)
            {
                mutationPosition = Util.Random.Next(chromosome.Length - i);
                mutant[remained[mutationPosition]] = mutant[remained[mutationPosition]].Mutate();
                remained[mutationPosition] = remained[chromosome.Length - i - 1];
            }

            return mutant;
        }
    }
}
