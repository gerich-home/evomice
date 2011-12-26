
namespace EvoMice.Neuro
{
    /// <summary>
    /// Нейрон
    /// </summary>
    public interface INeuron
    {
        /// <summary>
        /// Прибавляет выход синапса с суммарному входу нейрона
        /// </summary>
        /// <param name="signal">Взвешенный выход синапса</param>
        void AddSignal(double signal);

        /// <summary>
        /// Вычисляет новое значение нейрона по своему текущему состоянию и суммарному входу с синапсов
        /// </summary>
        void Update();

        /// <summary>
        /// Возбуждение нейрона
        /// </summary>
        double Activation { get; }
    }
}
