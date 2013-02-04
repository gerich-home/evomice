
namespace EvoMice.Genetic
{
    /// <summary>
    /// Создатель родительской пары
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class ParentsPairFactory<TIndividual>
        : IParentsPairFactory<TIndividual, ParentsPair<TIndividual>>
    {
        #region IParentsPairFactory<TChromosome,TIndividual,ParentsPair<TChromosome,TIndividual>> Members

        ParentsPair<TIndividual> IParentsPairFactory<TIndividual, ParentsPair<TIndividual>>.CreatePair(TIndividual mother, TIndividual father)
        {
            return new ParentsPair<TIndividual>(mother, father);
        }

        #endregion
    }
}
