using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.Selection
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
        /// <summary>
        /// Математичкое ожидание числа копий самой приспособленной особи
        /// </summary>
        protected double c = 2;

        /// <summary>
        /// Отбор методом рулетки
        /// </summary>
        /// <param name="c">Математичкое ожидание числа копий самой приспособленной особи</param>
        public RouletteSelection(double c)
        {
            this.c = c;
        }

        #region ISelection<TChromosome,TIndividual> Members

        IList<TIndividual> ISelection<TChromosome, TIndividual>.Select(IList<TIndividual> reproductionGroup, int count)
        {
            List<TIndividual> selected = new List<TIndividual>(count);

            int rCount = reproductionGroup.Count;

            double a;
            double b;
            double aveFitness = 0;
            double minFitness = double.MaxValue;
            double maxFitness = double.MinValue;

            for (int i = 0; i < rCount; i++)
            {
                aveFitness += reproductionGroup[i].Fitness;
                maxFitness = Math.Max(maxFitness, reproductionGroup[i].Fitness);
                minFitness = Math.Min(minFitness, reproductionGroup[i].Fitness);
            }
            aveFitness /= rCount;

            if (minFitness * (c - 1) >= (maxFitness - c * aveFitness))
            {
                a = (c - 1) * aveFitness / (aveFitness + maxFitness);
                b = aveFitness * (maxFitness - c * aveFitness) / (aveFitness - minFitness);
            }
            else
            {
                a = aveFitness / (aveFitness - minFitness);
                b = aveFitness * minFitness / (aveFitness - minFitness);
            }

            double[] probability = new double[rCount];

            probability[0] = a * reproductionGroup[0].Fitness + b;
            for (int i = 1; i < rCount; i++)
                probability[i] = probability[i - 1] + a * reproductionGroup[i].Fitness + b;

            double lastFitness = probability[rCount - 1];
            for (int i = 0; i < rCount; i++)
                probability[i] /= lastFitness;

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
