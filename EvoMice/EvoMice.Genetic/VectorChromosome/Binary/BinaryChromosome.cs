
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
        protected BinaryLocus[] Locuses { get; set; }

        /// <summary>
        /// Бинарная хромосома
        /// </summary>
        /// <param name="length">Длина хромосомы</param>
        public BinaryChromosome(int length)
        {
            Locuses = new BinaryLocus[length];
            for (int i = 0; i < length; i++)
                Locuses[i] = new BinaryLocus();
        }

        /// <summary>
        /// Бинарная хромосома
        /// </summary>
        /// <param name="original">Копируемая хромосома</param>
        public BinaryChromosome(BinaryChromosome original)
        {
            Locuses = new BinaryLocus[original.Length];
            for (int i = 0; i < original.Length; i++)
                Locuses[i] = original[i].Copy();
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

        #region ICopyable<BinaryChromosome> Members

        /// <summary>
        /// Создаёт копию хромосомы
        /// </summary>
        /// <returns>Копия хромосомы</returns>
        public BinaryChromosome Copy()
        {
            return new BinaryChromosome(this);
        }

        #endregion
    }
}
