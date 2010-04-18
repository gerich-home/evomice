using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Родительская пара
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class ParentsPair<TChromosome, TIndividual> : IParentsPair<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// 1-ая особь родительской пары
        /// </summary>
        protected TIndividual mother;

        /// <summary>
        /// 2-ая особь родительской пары
        /// </summary>
        protected TIndividual father;

        /// <summary>
        /// Родительская пара
        /// </summary>
        /// <param name="mother">1-ая особь родительской пары</param>
        /// <param name="father">2-ая особь родительской пары</param>
        public ParentsPair(TIndividual mother, TIndividual father)
        {
            this.mother = mother;
            this.father = father;
        }

        #region IParentsPair<TChromosome, TIndividual> Members

        public TIndividual Mother
        {
            get { return mother; }
        }

        public TIndividual Father
        {
            get { return father; }
        }

        #endregion
    }
}