using System;
using System.Collections.Generic;

namespace EvoMice.Genetic.VectorChromosome.Continuous.Crossover
{
    /// <summary>
    /// BLX кроссовер с параметром alpha
    /// </summary>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public class BLXCrossover<TIndividual, TParentsPair> :
        Crossover<ContinuousChromosome, TIndividual, TParentsPair>
        where TIndividual : IIndividual<ContinuousChromosome>
        where TParentsPair : IParentsPair<ContinuousChromosome, TIndividual>
    {
        /// <summary>
        /// Величина разброса значений
        /// </summary>
        public double Alpha { get; protected set; }

        /// <summary>
        /// BLX кроссовер с параметром alpha
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        /// <param name="alpha">Величина разброса значений</param>
        public BLXCrossover(double probability, double alpha)
            : base(probability)
        {
            Alpha = alpha;
        }

        /// <summary>
        /// Операция кроссовера
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        protected override IList<ContinuousChromosome> DoCrossover(TParentsPair parentsPair)
        {
            ContinuousChromosome motherChromosome = parentsPair.Mother.Chromosome;
            ContinuousChromosome fatherChromosome = parentsPair.Father.Chromosome;

            int point = Util.Random.Next(motherChromosome.Length - 1);
            ContinuousChromosome child = motherChromosome.Copy();

            double c = 1 + 2 * Alpha;
            for (int i = 0; i < child.Length; i++)
            {
                double min = Math.Min(motherChromosome[i].Value, fatherChromosome[i].Value);
                double max = Math.Max(motherChromosome[i].Value, fatherChromosome[i].Value);
                child[i].Value = min + (max - min) * (Util.Random.NextDouble() * c - Alpha);
            }

            List<ContinuousChromosome> result = new List<ContinuousChromosome>(1);
            result.Add(child);

            return result;
        }
    }
}
