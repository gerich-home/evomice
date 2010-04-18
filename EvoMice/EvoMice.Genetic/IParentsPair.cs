using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Родительская пара
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public interface IParentsPair<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        /// <summary>
        /// 1-ая особь родительской пары
        /// </summary>
        TIndividual Mother { get; }

        /// <summary>
        /// 2-ая особь родительской пары
        /// </summary>
        TIndividual Father { get; }
    }
}
