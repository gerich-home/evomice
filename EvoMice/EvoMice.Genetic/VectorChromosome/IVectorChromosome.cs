using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic.VectorChromosome
{
    /// <summary>
    /// Хромосома, закодированная в виде вектора
    /// </summary>
    /// <typeparam name="TLocus">Тип локусов</typeparam>
    public interface IVectorChromosome<TLocus>
    {
        /// <summary>
        /// Локус в заданной позиции
        /// </summary>
        /// <param name="index">Позиция локуса</param>
        /// <returns>Локус</returns>
        TLocus this[int index] { get; set; }

        /// <summary>
        /// Длина хромосомы
        /// </summary>
        int Length { get; }
    }
}
