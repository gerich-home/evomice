
namespace EvoMice.Genetic
{
    /// <summary>
    /// Тип, способный к мутации
    /// </summary>
    /// <typeparam name="T">Тип, который имеют мутанты</typeparam>
    public interface IMutateable<out T>
    {
        /// <summary>
        /// Создать мутанта данного объекта
        /// </summary>
        /// <returns>Мутант объекта</returns>
        T Mutate();
    }
}
