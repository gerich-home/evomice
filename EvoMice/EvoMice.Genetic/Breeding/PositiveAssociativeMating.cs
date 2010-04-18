using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Breeding
{
    /// <summary>
    /// Позитивное ассоциативное скрещивание
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TChromosomeDistance">Тип вычислителя расстояния между хромосомами</typeparam>
    public class PositiveAssociativeMating<TChromosome, TIndividual> :
        IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// Максимальная разница между приспособленностями скрещиваемых особей
        /// </summary>
        protected double maxDelta;

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        protected int numTests;

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        protected int pairCount;

        /// <summary>
        /// Позитивное ассоциативное скрещивание
        /// </summary>
        /// <param name="maxDelta">Максимальная разница между приспособленностями скрещиваемых особей</param>
        /// <param name="numTests">Число попыток найти хорошую пару</param>
        /// <param name="pairCount">Число создаваемых пар</param>
        public PositiveAssociativeMating(double maxDelta, int numTests, int pairCount)
        {
            this.maxDelta = maxDelta;
            this.numTests = numTests;
            this.pairCount = pairCount;
        }

        /// <summary>
        /// Максимальная разница между приспособленностями скрещиваемых особей
        /// </summary>
        public double MaxDelta
        {
            get { return maxDelta; }
            set { maxDelta = value; }
        }

        /// <summary>
        /// Число попыток найти хорошую пару
        /// </summary>
        public int NumTests
        {
            get { return numTests; }
            set { numTests = value; }
        }

        /// <summary>
        /// Число создаваемых пар
        /// </summary>
        public int PairCount
        {
            get { return pairCount; }
            set { pairCount = value; }
        }

        #region IBreeding<TChromosome,TIndividual,ParentsPair<TChromosome,TIndividual>> Members

        IList<ParentsPair<TChromosome, TIndividual>> IBreeding<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>.Select(IList<TIndividual> population)
        {
            //Надо отсортировать population по приспособленности
            throw new NotImplementedException("PositiveAssociativeMating");
        }

        #endregion
    }
}
