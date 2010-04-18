using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Continuous
{
    /// <summary>
    /// Расстояние для непрерывных хромосом
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class ChromosomeDistance<TChromosome> :
        IChromosomeDistance<TChromosome>
        where TChromosome : IVectorChromosome<ContinuousLocus>
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
            double s = 0;
            double d;
            for (int i = 0; i < first.Length; i++)
            {
                d = first[i].Value - second[i].Value;
                s += d * d;
            }
            return Math.Sqrt(s);
        }

        #endregion
    }
}
