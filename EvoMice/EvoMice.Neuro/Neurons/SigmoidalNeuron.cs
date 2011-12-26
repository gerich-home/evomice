using System;

namespace EvoMice.Neuro.Neurons
{
    /// <summary>
    /// Нейрон с активационной функцией 1 / (1 - e(-b * t) ) + bias
    /// </summary>
    public class SigmoidalNeuron : BaseNeuron
    {
        /// <summary>
        /// Степень крутизны сигмоиды
        /// </summary>
        protected double slope;

        #region Конструкторы
        /// <summary>
        /// Линейный нейрон
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="bias">Начальное возбужение нейрона</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public SigmoidalNeuron(double slope, double bias, double lowBound, double highBound)
            : base(bias, lowBound, highBound)
        {
            this.slope = slope;
        }

        /// <summary>
        /// Линейный нейрон
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="bias">Начальное возбужение нейрона</param>
        public SigmoidalNeuron(double slope, double bias)
            : this(slope, bias, double.NegativeInfinity, double.PositiveInfinity)
        {
        }

        /// <summary>
        /// Линейный нейрон
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public SigmoidalNeuron(double slope, double lowBound, double highBound)
            : this(slope, 0, lowBound, highBound)
        {
        }

        /// <summary>
        /// Линейный нейрон
        /// </summary>
        /// <param name="slope">Степень крутизны активационной функции</param>
        public SigmoidalNeuron(double slope)
            : this(slope, 0, double.NegativeInfinity, double.PositiveInfinity)
        {
        }

        #endregion

        protected override double CalculateActivation()
        {
            return bias + 1 / (1 - Math.Exp(-slope * summaryInput));
        }
    }
}
