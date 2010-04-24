using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель индивида
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TFitnessFunction">Тип функции приспособленности</typeparam>
    public class IndividualFactory<TChromosome, TFitnessFunction> :
        IIndividualFactory<TChromosome, Individual<TChromosome>, TFitnessFunction>
        where TFitnessFunction : IFitnessFunction<TChromosome>
    {
        #region IIndividualFactory<TChromosome,Individual<TChromosome>,TFitnessFunction> Members

        Individual<TChromosome> IIndividualFactory<TChromosome, Individual<TChromosome>, TFitnessFunction>.CreateIndividual(TChromosome chromosome, TFitnessFunction fitnessFunction)
        {
            return new Individual<TChromosome>(chromosome, fitnessFunction);
        }

        #endregion
    }
}
