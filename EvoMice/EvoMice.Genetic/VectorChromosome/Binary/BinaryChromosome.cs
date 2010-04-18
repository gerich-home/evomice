using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Binary
{
    /// <summary>
    /// Бинарная хромосома
    /// </summary>
    public class BinaryChromosome :
        IVectorChromosome<BinaryLocus>,
        ICopyable<BinaryChromosome>
    {
        /// <summary>
        /// Локусы хромосомы
        /// </summary>
        BinaryLocus[] locuses;

        /// <summary>
        /// Бинарная хромосома
        /// </summary>
        /// <param name="length">Длина хромосомы</param>
        public BinaryChromosome(int length)
        {
            locuses = new BinaryLocus[length];
            for (int i = 0; i < length; i++)
                locuses[i] = new BinaryLocus();
        }

        /// <summary>
        /// Бинарная хромосома
        /// </summary>
        /// <param name="original">Копируемая хромосома</param>
        public BinaryChromosome(BinaryChromosome original)
        {
            locuses = new BinaryLocus[original.Length];
            for (int i = 0; i < original.Length; i++)
                locuses[i] = original[i].Copy();
        }

        #region IVectorChromosome<BinaryLocus> Members

        /// <summary>
        /// Локус в заданной позиции
        /// </summary>
        /// <param name="index">Позиция локуса</param>
        /// <returns>Локус</returns>
        public BinaryLocus this[int index]
        {
            get
            {
                return locuses[index];
            }
            set
            {
                locuses[index] = value;
            }
        }

        /// <summary>
        /// Длина хромосомы
        /// </summary>
        public int Length
        {
            get { return locuses.Length; }
        }

        #endregion

        #region ICopyable<BinaryChromosome> Members

        public BinaryChromosome Copy()
        {
            return new BinaryChromosome(this);
        }

        #endregion
    }
}
