using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Continuous
{
    /// <summary>
    /// Непрерывный локус
    /// </summary>
    public class ContinuousLocus :
        ICopyable<ContinuousLocus>,
        IMutateable<ContinuousLocus>,
        IEqualityComparable<ContinuousLocus>
    {
        /// <summary>
        /// Значение локуса
        /// </summary>
        protected double value;

        /// <summary>
        /// Нижнее допустимое значение
        /// </summary>
        protected double lowBound;

        /// <summary>
        /// Верхнее допустимое значение
        /// </summary>
        protected double highBound;

        /// <summary>
        /// Непрерывный локус
        /// </summary>
        /// <param name="lowBound">Нижнее допустимое значение</param>
        /// <param name="highBound">Верхнее допустимое значение</param>
        /// <remarks>Заполнен случайным значением</remarks>
        public ContinuousLocus(double lowBound, double highBound)
        {
            value = Util.Random.NextDouble() * (highBound - lowBound) + lowBound;
            this.lowBound = lowBound;
            this.highBound = highBound;
        }

        /// <summary>
        /// Непрерывный локус
        /// </summary>
        /// <param name="lowBound">Нижнее допустимое значение</param>
        /// <param name="highBound">Верхнее допустимое значение</param>
        /// <param name="value">Значение локуса</param>
        public ContinuousLocus(double lowBound, double highBound, double value)
        {
            this.value = value;
            this.lowBound = lowBound;
            this.highBound = highBound;
        }

        /// <summary>
        /// Значение локуса
        /// </summary>
        public double Value
        {
            get { return value; }
            set { this.value=value; }
        }

        /// <summary>
        /// Нижнее допустимое значение
        /// </summary>
        public double LowBound
        {
            get { return lowBound; }
        }

        /// <summary>
        /// Верхнее допустимое значение
        /// </summary>
        public double HighBound
        {
            get { return highBound; }
        }

        #region ICopyable<ContinuousLocus> Members

        /// <summary>
        /// Создать копию данного объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        public ContinuousLocus Copy()
        {
            return new ContinuousLocus(lowBound, highBound, value);
        }

        #endregion

        #region IMutateable<ContinuousLocus> Members

        /// <summary>
        /// Создать мутанта данного объекта
        /// </summary>
        /// <returns>Мутант объекта</returns>
        public ContinuousLocus Mutate()
        {
            return new ContinuousLocus(lowBound, highBound);
        }

        #endregion

        #region IEqualityComparable<ContinuousLocus> Members

        /// <summary>
        /// Сравнивает на равенство объекты
        /// </summary>
        /// <param name="otherObject">Второй объект</param>
        /// <returns>true, если равны</returns>
        public bool EqualsTo(ContinuousLocus otherObject)
        {
            return otherObject.value == value;
        }

        #endregion
    }
}
