using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Crossover
{
    /// <summary>
    /// Ограниченный одноточечный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class RestrictedPointCrossover<TChromosome, TIndividual, TParentsPair, TLocus> :
        Crossover<TChromosome, TIndividual, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TLocus : ICopyable<TLocus>, IEqualityComparable<TLocus>
    {
        /// <summary>
        /// Ограниченный одноточечный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public RestrictedPointCrossover(double probability)
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

            int left = 0;
            int right = 0;

            for (int i = 0; i < motherChromosome.Length; i++)
                if (motherChromosome[i].EqualsTo(fatherChromosome[i]))
                {
                    left = i;
                    break;
                }

            for (int i = motherChromosome.Length - 1; i >= left; i--)
                if (motherChromosome[i].EqualsTo(fatherChromosome[i]))
                {
                    right = i;
                    break;
                }

            if (left == right)
                return new List<TChromosome>();
            else
            {
                int point = left + Util.Random.Next(right - left);
                TChromosome child1 = motherChromosome.Copy();
                TChromosome child2 = fatherChromosome.Copy();

                for (int i = 0; i <= point; i++)
                {
                    child1[i] = fatherChromosome[i].Copy();
                    child2[i] = motherChromosome[i].Copy();
                }

                List<TChromosome> result = new List<TChromosome>(2);
                result.Add(child1);
                result.Add(child2);

                return result;
            }
        }
    }
}
