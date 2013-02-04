using System.Collections.Generic;

namespace EvoMice.Neuro
{
    public class Network<TNeuron, TSynapse> : INetwork<TNeuron, TSynapse>
        where TNeuron : INeuron
        where TSynapse : ISynapse
    {
        protected IReadOnlyList<TNeuron> neurons;
        protected IReadOnlyList<TSynapse> synapses;

        public Network(IReadOnlyList<TNeuron> neurons, IReadOnlyList<TSynapse> synapses)
        {
            this.neurons = neurons;
            this.synapses = synapses;
        }

        #region INetwork<TNeuron,TSynapse> Members

        public IReadOnlyList<TNeuron> Neurons
        {
            get { return neurons; }
        }

        public IReadOnlyList<TSynapse> Synapses
        {
            get { return synapses; }
        }

        void INetwork<TNeuron, TSynapse>.Update()
        {
            foreach (var synapse in synapses)
                synapse.Update();
            foreach (var neuron in neurons)
                neuron.Update();
        }

        #endregion
    }
}
