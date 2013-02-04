
namespace EvoMice.Genetic
{
    /// <summary>
    /// Тип, который можно сравнивать на равенство с другим типом
    /// </summary>
    /// <typeparam name="T">Тип, с которым идёт сравнение</typeparam>
    public interface IEqualityComparable<in T>
    {
        /// <summary>
        /// Сравнивает на равенство объекты
        /// </summary>
        /// <param name="otherObject">Второй объект</param>
        /// <returns>true, если равны</returns>
        bool EqualsTo(T otherObject);
    }
}
