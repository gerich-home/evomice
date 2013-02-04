using System.Collections.Generic;

namespace EvoMice.Genetic.VectorChromosome.Crossover
{
    /// <summary>
    /// Однородный кроссовер с учётом приспособленности
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public class HomogeneousFitnessCrossover<TChromosome, TIndividual, TParentsPair, TLocus> :
        Crossover<TChromosome, TIndividual, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TLocus : ICopyable<TLocus>
    {
        /// <summary>
        /// Однородный кроссовер с учётом приспособленности
        /// </summary>
        /// <param name="probability">Вероятность кроссовера</param>
        public HomogeneousFitnessCrossover(double probability)
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

            // TODO: Поправить:
            // Похоже алгоритм тупит при увеличении приспособленностей...
            double p = parentsPair.Father.Fitness / (parentsPair.Mother.Fitness + parentsPair.Father.Fitness);

            for (int i = 0; i < motherChromosome.Length; i++)
                if (Util.Random.NextDouble() <= p)
                    child[i] = fatherChromosome[i].Copy();

            return new List<TChromosome> {child};
        }
    }
}
