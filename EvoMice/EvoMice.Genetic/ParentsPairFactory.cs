using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель родительской пары
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class ParentsPairFactory<TChromosome, TIndividual> :
        IParentsPairFactory<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>
        where TIndividual : IIndividual<TChromosome>
    {
        #region IParentsPairFactory<TChromosome,TIndividual,ParentsPair<TChromosome,TIndividual>> Members

        ParentsPair<TChromosome, TIndividual> IParentsPairFactory<TChromosome, TIndividual, ParentsPair<TChromosome, TIndividual>>.CreatePair(TIndividual mother, TIndividual father)
        {
            return new ParentsPair<TChromosome, TIndividual>(mother, father);
        }

        #endregion
    }
}
