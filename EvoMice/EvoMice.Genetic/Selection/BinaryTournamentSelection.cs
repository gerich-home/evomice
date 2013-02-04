using System.Collections.Generic;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Бинарная турнирная селекция
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class BinaryTournamentSelection<TChromosome, TIndividual> :
        ISelection<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        #region ISelection<TChromosome,TIndividual> Members

        IReadOnlyList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IReadOnlyList<TIndividual> reproductionGroup, int count)
        {
            var selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            for (int i = 0; i < count; i++)
            {
                var first = reproductionGroup[Util.Random.Next(rCount)];
                var second = reproductionGroup[Util.Random.Next(rCount)];

                selected.Add(first.Fitness > second.Fitness ? first : second);
            }

            return selected;
        }

        #endregion
    }
}
