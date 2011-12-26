using System;

namespace EvoMice.Genetic.VectorChromosome.Continuous.Mutation
{
    /// <summary>
    /// Мутация по произвольному направлению с фиксированной максимальной длиной
    /// </summary>
    public class DirectionalMutation<TChromosome> :
        Mutation<TChromosome>
        where TChromosome : IVectorChromosome<ContinuousLocus>, ICopyable<TChromosome>
    {
        /// <summary>
        /// Максимальное изменение хромосомы
        /// </summary>
        public double MaxMutationLength { get; protected set; }

        /// <summary>
        /// Мутация по произвольному направлению с фиксированной максимальной длиной
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        /// <param name="maxMutationLength">Максимальное изменение хромосомы</param>
        public DirectionalMutation(double probability, double maxMutationLength) :
            base(probability)
        {
            MaxMutationLength = maxMutationLength;
        }

        protected override TChromosome DoMutation(TChromosome chromosome)
        {
            TChromosome mutant = chromosome.Copy();

            double[] direction = new double[mutant.Length];
            double l = 0;

            for (int i = 0; i < mutant.Length; i++)
            {
                direction[i] = Util.Random.NextDouble();
                l += direction[i] * direction[i];
            }

            if (l == 0)
                return mutant;

            l = (2 * Util.Random.NextDouble() * MaxMutationLength - MaxMutationLength) / Math.Sqrt(l);

            for (int i = 0; i < mutant.Length; i++)
                mutant[i].Value += l * direction[i];


            return mutant;
        }
    }
}
