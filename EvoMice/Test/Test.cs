using System;
using System.Collections.Generic;
using System.Text;
using EvoMice.Neuro;
using EvoMice.Neuro.Neurons;
using EvoMice.Neuro.Synapses;

namespace EvoMice
{
    class Test
    {
        delegate bool TestDelegate();

        /// <summary>
        /// Запуск теста
        /// </summary>
        /// <param name="test">Запускаемый тест</param>
        /// <param name="description">Описание</param>
        static void RunTest(TestDelegate test, string description)
        {
            if (test())
                Console.WriteLine("{0}:\t пройден", description);
            else
                Console.WriteLine("{0}:\t НЕ ПРОЙДЕН", description);

        }

        static bool testNeuroStruct()
        {
            INetwork<LinearNeuron, ClampedSynapse> network = new Network<LinearNeuron, ClampedSynapse>();

            LinearNeuron n1 = new LinearNeuron(1),
                         n2 = new LinearNeuron(1),
                         n3 = new LinearNeuron(1);

            IList<LinearNeuron> neurons = network.Neurons;
            neurons.Add(n1);
            neurons.Add(n2);
            neurons.Add(n3);

            IList<ClampedSynapse> synapses = network.Synapses;
            ClampedSynapse s1 = new ClampedSynapse(n1, n2, 1),
                           s2 = new ClampedSynapse(n2, n3, 1),
                           s3 = new ClampedSynapse(n3, n1, 2);
            synapses.Add(s1);
            synapses.Add(s2);
            synapses.Add(s3);

            (n1 as INeuron).AddSignal(1);

            network.Update(); if (n1.Activation != 1 || n2.Activation != 0 || n3.Activation != 0) return false;
            network.Update(); if (n1.Activation != 0 || n2.Activation != 1 || n3.Activation != 0) return false;
            network.Update(); if (n1.Activation != 0 || n2.Activation != 0 || n3.Activation != 1) return false;
            network.Update(); if (n1.Activation != 2 || n2.Activation != 0 || n3.Activation != 0) return false;
            network.Update(); if (n1.Activation != 0 || n2.Activation != 2 || n3.Activation != 0) return false;
            network.Update(); if (n1.Activation != 0 || n2.Activation != 0 || n3.Activation != 2) return false;
            network.Update(); if (n1.Activation != 4 || n2.Activation != 0 || n3.Activation != 0) return false;


            return true;
        }

        static bool testGeneticClasses()
        {


            return true;
        }

        static void TestNeuro()
        {
            Console.WriteLine("\tТестируем EvoMice.Neuro");

            RunTest(new TestDelegate(testNeuroStruct), "Работа нейронной сети");

        }

        static void TestGenetic()
        {
            Console.WriteLine("\tТестируем EvoMice.Genetic");

            RunTest(new TestDelegate(testGeneticClasses), "Классы генетического алгоритма");

        }

        public static void RunTests()
        {
            TestNeuro();
            TestGenetic();
        }
    }
}
