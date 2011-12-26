using System.Collections.Generic;

namespace EvoMice.Genetic.VectorChromosome.Crossover
{
    /// <summary>
    /// Двухточечный кроссовер
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class TwoPointCrossover<TChromosome, TIndividual, TParentsPair, TLocus> :
        Crossover<TChromosome, TIndividual, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TLocus : ICopyable<TLocus>
    {
        /// <summary>
        /// Двухточечный кроссовер
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public TwoPointCrossover(double probability)
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

            int point1 = Util.Random.Next(motherChromosome.Length - 1);
            int point2 = Util.Random.Next(motherChromosome.Length - 2);
            if (point2 >= point1)
                point2++;
            else
            {
                int tmp = point1;
                point1 = point2;
                point2 = tmp;
            }

            TChromosome child1 = motherChromosome.Copy();
            TChromosome child2 = fatherChromosome.Copy();

            for (int i = point1 + 1; i <= point2; i++)
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
