using System.Collections.Generic;

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
        protected override IReadOnlyList<TChromosome> DoCrossover(TParentsPair parentsPair)
        {
            var motherChromosome = parentsPair.Mother.Chromosome;
            var fatherChromosome = parentsPair.Father.Chromosome;

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
            
            int point = left + Util.Random.Next(right - left);
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
