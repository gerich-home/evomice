using System.Collections.Generic;

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
        Crossover<TChromosome, TParentsPair>
        where TChromosome : IVectorChromosome<TLocus>, ICopyable<TChromosome>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TIndividual>
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
        protected override IReadOnlyList<TChromosome> DoCrossover(TParentsPair parentsPair)
        {
            var motherChromosome = parentsPair.Mother.Chromosome;
            var fatherChromosome = parentsPair.Father.Chromosome;

            var child = motherChromosome.Copy();

            for (int i = 0; i < motherChromosome.Length; i++)
                if (Util.Random.NextDouble() <= 0.5)
                    child[i] = fatherChromosome[i].Copy();

            return new List<TChromosome> { child };
        }
    }
}
