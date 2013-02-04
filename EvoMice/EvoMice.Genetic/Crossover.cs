using System.Collections.Generic;

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
        protected abstract IList<TChromosome> DoCrossover(TParentsPair parentsPair);


        #region ICrossover<TChromosome,TIndividual,TParentsPair> Members

        IList<TChromosome> ICrossover<TChromosome, TIndividual, TParentsPair>.Crossover(TParentsPair parentsPair)
        {
            if (Util.Random.NextDouble() <= Probability)
                return DoCrossover(parentsPair);
            
            return new List<TChromosome>();
        }

        #endregion
    }
}
