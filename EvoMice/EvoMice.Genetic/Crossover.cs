using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Вероятностный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public abstract class Crossover<TChromosome, TParentsPair>
        : ICrossover<TChromosome, TParentsPair>
    {
        /// <summary>
        /// Вероятность кроссовера
        /// </summary>
        public double Probability { get; protected set; }

        /// <summary>
        /// Вероятностный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        protected Crossover(double probability)
        {
            Probability = probability;
        }

        /// <summary>
        /// Операция кроссовера
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        protected abstract IReadOnlyList<TChromosome> DoCrossover(TParentsPair parentsPair);


        #region ICrossover<TChromosome,TIndividual,TParentsPair> Members

        IReadOnlyList<TChromosome> ICrossover<TChromosome, TParentsPair>.Crossover(TParentsPair parentsPair)
        {
            if (Util.Random.NextDouble() <= Probability)
                return DoCrossover(parentsPair);
            
            return new List<TChromosome>();
        }

        #endregion
    }
}
