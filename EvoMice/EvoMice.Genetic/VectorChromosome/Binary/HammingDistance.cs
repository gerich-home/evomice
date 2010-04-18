using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Binary
{
    /// <summary>
    /// Расстояние хэмминга для бинарных хромосом
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class HammingDistance<TChromosome> :
        IChromosomeDistance<TChromosome>
        where TChromosome : IVectorChromosome<BinaryLocus>
    {

        #region IChromosomeDistance<TChromosome> Members

        /// <summary>
        /// Расстояние между двумя хромосомами
        /// </summary>
        /// <param name="first">Первая хромосома</param>
        /// <param name="second">Вторая хромосома</param>
        /// <returns>Расстояние</returns>
        public double Distance(TChromosome first, TChromosome second)
        {
            double d = 0;
            for (int i = 0; i < first.Length; i++)
                if (first[i].Value != second[i].Value)
                    d++;
            return d;
        }

        #endregion
    }
}
