﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro
{
    public class Network<TNeuron, TSynapse> : INetwork<TNeuron, TSynapse>
        where TNeuron : INeuron
        where TSynapse : ISynapse
    {
        protected List<TNeuron> neurons;
        protected List<TSynapse> synapses;

        public Network()
        {
            neurons = new List<TNeuron>();
            synapses = new List<TSynapse>();
        }

        #region INetwork<TNeuron,TSynapse> Members

        public IList<TNeuron> Neurons
        {
            get { return neurons; }
        }

        public IList<TSynapse> Synapses
        {
            get { return synapses; }
        }

        void INetwork<TNeuron, TSynapse>.Update()
        {
            foreach (ISynapse synapse in synapses)
                synapse.Update();
            foreach (INeuron neuron in neurons)
                neuron.Update();
        }

        #endregion
    }
}