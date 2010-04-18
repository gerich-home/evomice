using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro.Neurons
{
    /// <summary>
    /// Общая функциональность нейронов
    /// </summary>
    public abstract class BaseNeuron : INeuron
    {
        /// <summary>
        /// Начальное возбужение нейрона
        /// </summary>
        protected double bias;

        /// <summary>
        /// Минимальное принимаемое значение
        /// </summary>
        protected double lowBound;

        /// <summary>
        /// Максимальное принимаемое значение
        /// </summary>
        protected double highBound;

        /// <summary>
        /// Суммарный вход нейрона
        /// </summary>
        protected double summaryInput;

        /// <summary>
        /// Возбужение нейрона
        /// </summary>
        protected double activation;

        /// <summary>
        /// Нейрон с начальным возбужением с ограниченным возбужением
        /// </summary>
        /// <param name="bias">Начальное возбужение нейрона</param>
        /// <param name="lowBound">Минимальное принимаемое значение</param>
        /// <param name="highBound">Максимальное принимаемое значение</param>
        public BaseNeuron(double bias, double lowBound, double highBound)
        {
            this.bias = bias;
            this.lowBound = lowBound;
            this.highBound = highBound;
        }

        /// <summary>
        /// Вычислить возбуждение нейрона на основе суммарного входа
        /// </summary>
        /// <returns>Возбуждение нейрона</returns>
        protected virtual double CalculateActivation()
        {
            return 0;
        }

        protected virtual void AddSignal(double weight)
        {
            summaryInput += weight;
        }

        protected virtual void Update()
        {
            activation = Math.Min(highBound, Math.Max(lowBound, CalculateActivation()));
            summaryInput = 0;
        }

        #region INeuron Members

        void INeuron.AddSignal(double weight)
        {
            AddSignal(weight);
        }

        void INeuron.Update()
        {
            Update();
        }

        /// <summary>
        /// Возбуждение нейрона
        /// </summary>
        public double Activation
        {
            get { return activation; }
        }

        #endregion
    }
}
