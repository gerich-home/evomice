using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro
{
    public class Network : INetwork
    {
        List<INeuron> neurons;
        List<ISynapse> synapses;

        public Network()
        {
            neurons = new List<INeuron>();
            synapses = new List<ISynapse>();
        }

        #region INetwork Members

        public IList<INeuron> Neurons
        {
            get { return neurons; }
        }

        public IList<ISynapse> Synapses
        {
            get { return synapses; }
        }

        void INetwork.Update()
        {
            foreach (ISynapse synapse in synapses)
                synapse.Update();
            foreach (INeuron neuron in neurons)
                neuron.Update();
        }

        #endregion
    }
}
