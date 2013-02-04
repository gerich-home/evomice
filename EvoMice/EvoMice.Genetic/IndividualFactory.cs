
namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель индивида
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class IndividualFactory<TChromosome> :
        IIndividualFactory<TChromosome, Individual<TChromosome>>
    {
        #region IIndividualFactory<TChromosome,Individual<TChromosome>> Members

        Individual<TChromosome> IIndividualFactory<TChromosome, Individual<TChromosome>>.CreateIndividual(TChromosome chromosome, IFitnessFunction<TChromosome> fitnessFunction)
        {
            return new Individual<TChromosome>(chromosome, fitnessFunction);
        }

        #endregion
    }
}
