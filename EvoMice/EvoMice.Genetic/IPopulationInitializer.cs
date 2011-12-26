using System.Collections.Generic;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Инициализатор первого поколения
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public interface IPopulationInitializer<TChromosome>
    {
        /// <summary>
        /// Сгенерировать первое поколение популяции
        /// </summary>
        /// <returns>Генофонд первого поколения</returns>
        IList<TChromosome> Initialize();
    }
}
