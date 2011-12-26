
namespace EvoMice.Neuro.Neurons
{
    /// <summary>
    /// Линейный нейрон
    /// </summary>
    public class LinearNeuron : BaseNeuron
    {
        /// <summary>
        /// Степень крутизны активационной функции
        /// </summary>
        protected double slope;

        #region Конструкторы
        /// <summary>
        /// Нейрон с начальным возбужением с ограниченным возбужением
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="bias">Начальное возбужение нейрона</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public LinearNeuron(double slope, double bias, double lowBound, double highBound)
            : base(bias, lowBound, highBound)
        {
            this.slope = slope;
        }

        /// <summary>
        /// Нейрон с начальным возбужением с неограниченным возбужением
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="bias">Начальное возбужение нейрона</param>
        public LinearNeuron(double slope, double bias)
            : this(slope, bias, double.NegativeInfinity, double.PositiveInfinity)
        {
        }

        /// <summary>
        /// Нейрон с нулевым начальным возбужением с ограниченным возбужением
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public LinearNeuron(double slope, double lowBound, double highBound)
            : this(slope, 0, lowBound, highBound)
        {
        }

        /// <summary>
        /// Нейрон с нулевым начальным возбужением с неограниченным возбужением
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        public LinearNeuron(double slope)
            : this(slope, 0, double.NegativeInfinity, double.PositiveInfinity)
        {
        }

        #endregion

        protected override double CalculateActivation()
        {
            return (summaryInput + bias) * slope;
        }
    }
}
