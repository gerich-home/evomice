using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro.Synapses
{
    /// <summary>
    /// Синапс, не меняющий своего веса
    /// </summary>
    public class HebbianSynapse : BaseSynapse
    {
        /// <summary>
        /// Вес синапса
        /// </summary>
        protected double weight;

        /// <summary>
        /// Скорость изменения веса
        /// </summary>
        protected double learningRate;

        #region Конструкторы
        /// <summary>
        /// Синапс Хэбба
        /// </summary>
        /// <param name="outNeuron">Нейрон, посылающий сигнал</param>
        /// <param name="inNeuron">Нейрон, принимающий сигнал</param>
        /// <param name="weight">Вес синапса</param>
        /// <param name="learningRate">Скорость изменения веса</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public HebbianSynapse(INeuron outNeuron, INeuron inNeuron, double weight, double learningRate, double lowBound, double highBound)
            : base(outNeuron, inNeuron, lowBound, highBound)
        {
            this.weight = weight;
            this.learningRate=learningRate;
        }

        /// <summary>
        /// Синапс Хэбба
        /// </summary>
        /// <param name="outNeuron">Нейрон, посылающий сигнал</param>
        /// <param name="inNeuron">Нейрон, принимающий сигнал</param>
        /// <param name="weight">Вес синапса</param>
        /// <param name="learningRate">Скорость изменения веса</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public HebbianSynapse(INeuron outNeuron, INeuron inNeuron, double weight, double learningRate)
            : this(outNeuron, inNeuron, weight, learningRate, double.NegativeInfinity, double.PositiveInfinity)
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

        /// <summary>
        /// Скорость изменения веса
        /// </summary>
        public double LearningRate
        {
            get { return learningRate; }
            set { learningRate = value; }
        }

        protected override void Update()
        {
            weight += inNeuron.Activation * outNeuron.Activation * learningRate;
            CalculateSignal();
        }

        protected override double CalculateSignal()
        {
            return outNeuron.Activation * weight;
        }
    }
}
