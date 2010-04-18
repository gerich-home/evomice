using System;
using System.Collections.Generic;
using System.Text;

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
        protected double probability;

        /// <summary>
        /// Мутация
        /// </summary>
        /// <param name="probability">Вероятность мутации</param>
        public Mutation(double probability)
        {
            this.probability = probability;
        }

        /// <summary>
        /// Вероятность кроссовера
        /// </summary>
        public double Probability
        {
            get { return probability; }
            set { probability = value; }
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
            if (Util.Random.NextDouble() <= probability)
                return DoMutation(chromosome);
            else
                return chromosome;
        }

        #endregion
    }
}
