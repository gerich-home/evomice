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
        public double Value { get; set; }

        /// <summary>
        /// Нижнее допустимое значение
        /// </summary>
        public double LowBound { get; protected set; }

        /// <summary>
        /// Верхнее допустимое значение
        /// </summary>
        public double HighBound { get; protected set; }

        /// <summary>
        /// Непрерывный локус
        /// </summary>
        /// <param name="lowBound">Нижнее допустимое значение</param>
        /// <param name="highBound">Верхнее допустимое значение</param>
        /// <remarks>Заполнен случайным значением</remarks>
        public ContinuousLocus(double lowBound, double highBound)
        {
            Value = Util.Random.NextDouble() * (highBound - lowBound) + lowBound;
            LowBound = lowBound;
            HighBound = highBound;
        }

        /// <summary>
        /// Непрерывный локус
        /// </summary>
        /// <param name="lowBound">Нижнее допустимое значение</param>
        /// <param name="highBound">Верхнее допустимое значение</param>
        /// <param name="value">Значение локуса</param>
        public ContinuousLocus(double lowBound, double highBound, double value)
        {
            Value = value;
            LowBound = lowBound;
            HighBound = highBound;
        }

        #region ICopyable<ContinuousLocus> Members

        /// <summary>
        /// Создать копию данного объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        public ContinuousLocus Copy()
        {
            return new ContinuousLocus(LowBound, HighBound, Value);
        }

        #endregion

        #region IMutateable<ContinuousLocus> Members

        /// <summary>
        /// Создать мутанта данного объекта
        /// </summary>
        /// <returns>Мутант объекта</returns>
        public ContinuousLocus Mutate()
        {
            return new ContinuousLocus(LowBound, HighBound);
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
            return otherObject.Value == Value;
        }

        #endregion
    }
}
