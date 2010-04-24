using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Continuous
{
    /// <summary>
    /// Хромосома с непрерывными значениями
    /// </summary>
    public class ContinuousChromosome :
        IVectorChromosome<ContinuousLocus>,
        ICopyable<ContinuousChromosome>
    {
        /// <summary>
        /// Локусы хромосомы
        /// </summary>
        protected ContinuousLocus[] Locuses { get; set; }

        /// <summary>
        /// Хромосома с непрерывными значениями
        /// </summary>
        /// <param name="length">Длина хромосомы</param>
        /// <param name="lowBound">Нижнее допустимое значение локусов</param>
        /// <param name="highBound">Верхнее допустимое значение локусов</param>
        public ContinuousChromosome(int length, double lowBound, double highBound)
        {
            Locuses = new ContinuousLocus[length];
            for (int i = 0; i < length; i++)
                Locuses[i] = new ContinuousLocus(lowBound, highBound);
        }

        /// <summary>
        /// Хромосома с непрерывными значениями
        /// </summary>
        /// <param name="length">Длина хромосомы</param>
        /// <param name="lowBounds">Нижние допустимые значения локусов</param>
        /// <param name="highBounds">Верхние допустимые значения локусов</param>
        public ContinuousChromosome(int length, double[] lowBounds, double[] highBounds)
        {
            Locuses = new ContinuousLocus[length];
            for (int i = 0; i < length; i++)
                Locuses[i] = new ContinuousLocus(lowBounds[i], highBounds[i]);
        }

        /// <summary>
        /// Хромосома с непрерывными значениями
        /// </summary>
        /// <param name="original">Копируемая хромосома</param>
        public ContinuousChromosome(ContinuousChromosome original)
        {
            Locuses = new ContinuousLocus[original.Length];
            for (int i = 0; i < original.Length; i++)
                Locuses[i] = original[i].Copy();
        }

        #region IVectorChromosome<ContinuousLocus> Members

        /// <summary>
        /// Локус в заданной позиции
        /// </summary>
        /// <param name="index">Позиция локуса</param>
        /// <returns>Локус</returns>
        public ContinuousLocus this[int index]
        {
            get
            {
                return Locuses[index];
            }
            set
            {
                Locuses[index] = value;
            }
        }

        /// <summary>
        /// Длина хромосомы
        /// </summary>
        public int Length
        {
            get { return Locuses.Length; }
        }

        #endregion

        #region ICopyable<ContinuousChromosome> Members

        public ContinuousChromosome Copy()
        {
            return new ContinuousChromosome(this);
        }

        #endregion
    }
}
