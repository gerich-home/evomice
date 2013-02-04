using System.Collections.Generic;

namespace EvoMice.Neuro
{
    /// <summary>
    /// Нейронная сеть
    /// </summary>
    public interface INetwork<out TNeuron, out TSynapse>
        where TNeuron : INeuron
        where TSynapse : ISynapse
    {
        /// <summary>
        /// Список нейронов
        /// </summary>
        IReadOnlyList<TNeuron> Neurons { get; }
        /// <summary>
        /// Список синапсов
        /// </summary>
        IReadOnlyList<TSynapse> Synapses { get; }

        void Update();
    }
}
