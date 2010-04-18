using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.ReproductionStrategy
{
    /// <summary>
    /// Стратегия формирования следующего поколения
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class ReproductionStrategy<TChromosome, TIndividual> :
        IReproductionStrategy<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        #region IReproductionStrategy<TChromosome,TIndividual> Members

        IList<TIndividual> IReproductionStrategy<TChromosome, TIndividual>.NextGeneration(IList<TIndividual> population, IList<TIndividual> reproductionGroup)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
