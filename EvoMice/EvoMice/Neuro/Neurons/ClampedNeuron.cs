using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro.Neurons
{
    /// <summary>
    /// Нейрон, не меняющий своего возбуждения
    /// </summary>
    public class ClampedNeuron : INeuron
    {
        /// <summary>
        /// Возбужение нейрона
        /// </summary>
        protected double activation;

        /// <summary>
        /// Нейрон, не меняющий своего возбуждения
        /// </summary>
        /// <param name="activation">Уровень возбуждения</param>
        public ClampedNeuron(double activation)
        {
            this.activation = activation;
        }

        #region INeuron Members

        void INeuron.AddSignal(double weight)
        {
        }

        void INeuron.Update()
        {
        }

        /// <summary>
        /// Возбужение нейрона
        /// </summary>
        public double Activation
        {
            get { return activation; }
            set { activation = value; }
        }

        #endregion
    }
}
