using System.Collections.Generic;

namespace EvoMice.Genetic.Selection.Selector
{
    /// <summary>
    /// Отбор методом рулетки
    /// </summary>
    public class RouletteSelector<TChromosome, TIndividual> :
        ISelector<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        #region ISelector<TChromosome,TIndividual> Members

        IList<TIndividual> ISelector<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, IList<double> ranks, int count)
        {
            var selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            var probability = new double[rCount];

            double multiplier = 0;
            for (int i = 0; i < rCount; i++)
                multiplier += ranks[i];

            multiplier = 1 / multiplier;

            probability[0] = ranks[0] * multiplier;
            for (int i = 1; i < rCount; i++)
                probability[i] = probability[i - 1] + ranks[i] * multiplier;

            for (int i = 0; i < count; i++)
            {
                double r = Util.Random.NextDouble();
                for (int j = 0; j < rCount; j++)
                    if (r < probability[j])
                    {
                        selected.Add(reproductionGroup[j]);
                        break;
                    }
            }
            return selected;
        }

        #endregion
    }
}
