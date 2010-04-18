using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Mutation
{
    /// <summary>
    /// Отбор методом рулетки
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    public class RouletteSelection<TChromosome, TIndividual> :
        ISelection<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {
        #region ISelection<TChromosome,TIndividual> Members

        IList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, int count)
        {
            List<TIndividual> selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;
            double[] fitness = new double[rCount];

            fitness[0] = reproductionGroup[0].Fitness;
            for (int i = 1; i < rCount; i++)
                fitness[i] = fitness[i - 1] + reproductionGroup[i].Fitness;
            for (int i = 0; i < rCount; i++)
                fitness[i] /= fitness[rCount];

            for (int i = 0; i < count; i++)
            {
                double r = Util.Random.NextDouble();
                for (int j = 0; j < rCount; j++)
                    if (r < fitness[j])
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
