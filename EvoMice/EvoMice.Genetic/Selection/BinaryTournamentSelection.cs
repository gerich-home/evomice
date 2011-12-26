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

        IList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, int count)
        {
            List<TIndividual> selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            TIndividual first;
            TIndividual second;

            for (int i = 0; i < count; i++)
            {
                first = reproductionGroup[Util.Random.Next(rCount)];
                second = reproductionGroup[Util.Random.Next(rCount)];

                if (first.Fitness > second.Fitness)
                    selected.Add(first);
                else
                    selected.Add(second);
            }

            return selected;
        }

        #endregion
    }
}
