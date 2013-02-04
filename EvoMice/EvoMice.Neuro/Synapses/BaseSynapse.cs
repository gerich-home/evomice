using System;

namespace EvoMice.Neuro.Synapses
{
    /// <summary>
    /// Синапс, не меняющий своего веса
    /// </summary>
    abstract public class BaseSynapse : ISynapse
    {
        /// <summary>
        /// Входной нейрон
        /// </summary>
        protected INeuron inNeuron;

        /// <summary>
        /// Выходной нейрон
        /// </summary>
        protected INeuron outNeuron;

        /// <summary>
        /// Минимальное принимаемое значение
        /// </summary>
        protected double lowBound;

        /// <summary>
        /// Максимальное принимаемое значение
        /// </summary>
        protected double highBound;

        /// <summary>
        /// Синапс
        /// </summary>
        /// <param name="outNeuron">Нейрон, посылающий сигнал</param>
        /// <param name="inNeuron">Нейрон, принимающий сигнал</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        protected BaseSynapse(INeuron outNeuron, INeuron inNeuron, double lowBound, double highBound)
        {
            this.outNeuron = outNeuron;
            this.inNeuron = inNeuron;
            this.lowBound = lowBound;
            this.highBound = highBound;
        }

        /// <summary>
        /// Вычислить сигнал синапса
        /// </summary>
        /// <returns>Сигнал синапса</returns>
        protected virtual double CalculateSignal()
        {
            return 0;
        }

        protected virtual void Update()
        {
            inNeuron.AddSignal(Math.Min(highBound, Math.Max(lowBound, CalculateSignal())));
        }

        #region ISynapse Members

        void ISynapse.Update()
        {
            Update();
        }

        #endregion
    }
}
