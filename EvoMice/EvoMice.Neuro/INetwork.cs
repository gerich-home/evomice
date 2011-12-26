using System.Collections.Generic;

namespace EvoMice.Neuro
{
    /// <summary>
    /// Нейронная сеть
    /// </summary>
    public interface INetwork<TNeuron, TSynapse>
        where TNeuron : INeuron
        where TSynapse : ISynapse
    {
        /// <summary>
        /// Список нейронов
        /// </summary>
        IList<TNeuron> Neurons { get; }
        /// <summary>
        /// Список синапсов
        /// </summary>
        IList<TSynapse> Synapses { get; }

        void Update();
    }
}
