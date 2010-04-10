using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro.Synapses
{
    /// <summary>
    /// Синапс, не меняющий своего веса
    /// </summary>
    public class ClampedSynapse : BaseSynapse
    {
        /// <summary>
        /// Вес синапса
        /// </summary>
        protected double weight;

        #region Конструкторы
        /// <summary>
        /// Синапс, не меняющий своего веса
        /// </summary>
        /// <param name="outNeuron">Нейрон, посылающий сигнал</param>
        /// <param name="inNeuron">Нейрон, принимающий сигнал</param>
        /// <param name="weight">Вес синапса</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public ClampedSynapse(INeuron outNeuron, INeuron inNeuron, double weight, double lowBound, double highBound)
            : base(outNeuron, inNeuron, lowBound, highBound)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Синапс, не меняющий своего веса
        /// </summary>
        /// <param name="outNeuron">Нейрон, посылающий сигнал</param>
        /// <param name="inNeuron">Нейрон, принимающий сигнал</param>
        /// <param name="weight">Вес синапса</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public ClampedSynapse(INeuron outNeuron, INeuron inNeuron, double weight)
            : this(outNeuron, inNeuron, weight, double.NegativeInfinity, double.PositiveInfinity)
        {
        }

        #endregion

        /// <summary>
        /// Вес синапса
        /// </summary>
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        protected override double CalculateSignal()
        {
            return outNeuron.Activation * weight;
        }
    }
}
