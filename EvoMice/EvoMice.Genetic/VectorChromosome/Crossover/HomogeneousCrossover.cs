using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Crossover
{
    /// <summary>
    /// Однородный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class HomogeneousCrossover<TChromosome, TIndividual, TParentsPair, TLocus> :
        Crossover<TChromosome, TIndividual, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TLocus : ICopyable<TLocus>
    {
        /// <summary>
        /// Однородный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public HomogeneousCrossover(double probability)
            : base(probability)
        { }

        /// <summary>
        /// Операция кроссовера
        /// </summary>
        /// <param name="parentsPair">Родительская пара</param>
        /// <returns>Потомки</returns>
        protected override IList<TChromosome> DoCrossover(TParentsPair parentsPair)
        {
            TChromosome motherChromosome = parentsPair.Mother.Chromosome;
            TChromosome fatherChromosome = parentsPair.Father.Chromosome;

            TChromosome child = motherChromosome.Copy();

            for (int i = 0; i < motherChromosome.Length; i++)
                if (Util.Random.NextDouble() <= 0.5)
                    child[i] = fatherChromosome[i].Copy();

            List<TChromosome> result = new List<TChromosome>(1);
            result.Add(child);

            return result;
        }
    }
}
