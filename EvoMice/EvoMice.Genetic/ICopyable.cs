
namespace EvoMice.Genetic
{
    /// <summary>
    /// Копируемый тип к данному типу
    /// </summary>
    /// <typeparam name="T">Тип, который имеют копии</typeparam>
    public interface ICopyable<T>
    {
        /// <summary>
        /// Создать копию данного объекта
        /// </summary>
        /// <returns>Копия объекта</returns>
        T Copy();
    }
}
