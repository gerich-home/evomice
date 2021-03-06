﻿using System.Collections.Generic;

namespace EvoMice.Genetic.VectorChromosome.Crossover
{
    /// <summary>
    /// Одноточечный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class PointCrossover<TChromosome, TIndividual, TParentsPair, TLocus> :
        Crossover<TChromosome, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TIndividual>
        where TLocus : ICopyable<TLocus>
    {
        /// <summary>
        /// Одноточечный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public PointCrossover(double probability)
            : base(probability)
        { }

        /// <summary>
        /// Операция кроссовера
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        protected override IReadOnlyList<TChromosome> DoCrossover(TParentsPair parentsPair)
        {
            var motherChromosome = parentsPair.Mother.Chromosome;
            var fatherChromosome = parentsPair.Father.Chromosome;

            int point = Util.Random.Next(motherChromosome.Length - 1);
            var child1 = motherChromosome.Copy();
            var child2 = fatherChromosome.Copy();

            for (int i = 0; i <= point; i++)
            {
                child1[i] = fatherChromosome[i].Copy();
                child2[i] = motherChromosome[i].Copy();
            }

            return new List<TChromosome> {child1, child2};
        }
    }
}
