using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome.Binary
{
    /// <summary>
    /// Бинарный локус
    /// </summary>
    public class BinaryLocus :
        ICopyable<BinaryLocus>,
        IMutateable<BinaryLocus>,
        IEqualityComparable<BinaryLocus>
    {
        /// <summary>
        /// Значение локуса
        /// </summary>
        protected int value;

        /// <summary>
        /// Бинарный локус
        /// </summary>
        /// <remarks>Заполнен случайным значением</remarks>
        public BinaryLocus()
        {
            value = Util.Random.Next(2);
        }

        /// <summary>
        /// Бинарный локус
        /// </summary>
        /// <param name="value">Значение локуса</param>
        public BinaryLocus(int value)
        {
            if (value == 0)
                this.value = 0;
            else
                this.value = 1;
        }

        /// <summary>
        /// Значение локуса
        /// </summary>
        public int Value
        {
            get { return value; }
        }

        #region ICopyable<BinaryLocus> Members

        /// <summary>
        /// Создать копию данного объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        public BinaryLocus Copy()
        {
            return new BinaryLocus(this.value);
        }

        #endregion

        #region IMutateable<BinaryLocus> Members

        /// <summary>
        /// Создать мутанта данного объекта
        /// </summary>
        /// <returns>Мутант объекта</returns>
        public BinaryLocus Mutate()
        {
            return new BinaryLocus(1 - value);
        }

        #endregion

        #region IEqualityComparable<BinaryLocus> Members

        /// <summary>
        /// Сравнивает на равенство объекты
        /// </summary>
        /// <param name="otherObject">Второй объект</param>
        /// <returns>true, если равны</returns>
        public bool EqualsTo(BinaryLocus otherObject)
        {
            return otherObject.value == value;
        }

        #endregion
    }
}
