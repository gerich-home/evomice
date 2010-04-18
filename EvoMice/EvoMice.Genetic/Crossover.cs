using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Вероятностный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public abstract class Crossover<TChromosome, TIndividual, TParentsPair> :
        ICrossover<TChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
    {
        /// <summary>
        /// Вероятность кроссовера
        /// </summary>
        protected double probability;

        /// <summary>
        /// Вероятностный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public Crossover(double probability)
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
        /// Операция кроссовера
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        protected abstract IList<TChromosome> DoCrossover(TParentsPair parentsPair);


        #region ICrossover<TChromosome,TIndividual,TParentsPair> Members

        IList<TChromosome> ICrossover<TChromosome, TIndividual, TParentsPair>.Crossover(TParentsPair parentsPair)
        {
            if (Util.Random.NextDouble() <= probability)
                return DoCrossover(parentsPair);
            else
                return new List<TChromosome>();
        }

        #endregion
    }
}
