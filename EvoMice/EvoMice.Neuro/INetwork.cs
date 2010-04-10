using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro
{
    /// <summary>
    /// Нейронная сеть
    /// </summary>
    public interface INetwork
    {
        /// <summary>
        /// Список нейронов
        /// </summary>
        IList<INeuron> Neurons { get; }
        /// <summary>
        /// Список синапсов
        /// </summary>
        IList<ISynapse> Synapses { get; }

        void Update();
    }
}
