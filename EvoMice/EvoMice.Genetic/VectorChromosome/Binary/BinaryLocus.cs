
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
        public int Value { get; set; }

        /// <summary>
        /// Бинарный локус
        /// </summary>
        /// <remarks>Заполнен случайным значением</remarks>
        public BinaryLocus()
        {
            Value = Util.Random.Next(2);
        }

        /// <summary>
        /// Бинарный локус
        /// </summary>
        /// <param name="value">Значение локуса</param>
        public BinaryLocus(int value)
        {
            if (value == 0)
                Value = 0;
            else
                Value = 1;
        }

        #region ICopyable<BinaryLocus> Members

        /// <summary>
        /// Создать копию данного объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        public BinaryLocus Copy()
        {
            return new BinaryLocus(this.Value);
        }

        #endregion

        #region IMutateable<BinaryLocus> Members

        /// <summary>
        /// Создать мутанта данного объекта
        /// </summary>
        /// <returns>Мутант объекта</returns>
        public BinaryLocus Mutate()
        {
            return new BinaryLocus(1 - Value);
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
            return otherObject.Value == Value;
        }

        #endregion
    }
}
