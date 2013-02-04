using System;
using System.Collections.Generic;
using EvoMice.Genetic;
using EvoMice.Genetic.Breeding;
using EvoMice.Genetic.ContinueCondition;
using EvoMice.Genetic.ReproductionStrategy;
using EvoMice.Genetic.Selection;
using EvoMice.Genetic.Selection.Selector;
using EvoMice.Genetic.VectorChromosome.Continuous;
using EvoMice.Genetic.VectorChromosome.Continuous.Crossover;
using EvoMice.Genetic.VectorChromosome.Mutation;
using EvoMice.Neuro;
using EvoMice.Neuro.Neurons;
using EvoMice.Neuro.Synapses;

namespace EvoMice
{
    class SquaredFunc : IFitnessFunction<ContinuousChromosome>
    {
        readonly double offset;
        public SquaredFunc(double offset)
        {
            this.offset = offset;
        }

        #region IFitnessFunction<ContinuousChromosome> Members

        public double Calculate(ContinuousChromosome chromosome)
        {
            double s = 0;
            for (int i = 0; i < chromosome.Length; i++)
            {
                double d = chromosome[i].Value - offset;
                s += d * d;
            }
            double l = Math.Sqrt(s);
            //return 200-(1- Math.Cos(l) + 0.2*l);
            return Math.Exp(-s) + Math.Cos(l) + 1;
        }

        #endregion
    }

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
            Console.WriteLine(test() ? "{0}:\t пройден" : "{0}:\t НЕ ПРОЙДЕН", description);
        }

        static bool testGeneticClasses()
        {
            var ga =
                new GeneticAlgorithm<ContinuousChromosome,
                    Individual<ContinuousChromosome>,
                    ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>
                    >(
                    new ElitistReproductionStrategy<ContinuousChromosome, Individual<ContinuousChromosome>, ISelection<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (0.2,
                //new BTournamentSelection<ContinuousChromosome,Individual<ContinuousChromosome>>(4)
                        new ScaledProportionalSelection<ContinuousChromosome, Individual<ContinuousChromosome>,ISelector<ContinuousChromosome,Individual<ContinuousChromosome>>>
                            (2,
                            new RouletteSelector<ContinuousChromosome,Individual<ContinuousChromosome>>())
                        ),
                    new ContinuousPopulationInitializer
                         (500, 2, -20, 20),
                    new GenerationContinueCondition<ContinuousChromosome, Individual<ContinuousChromosome>>
                        (20),
                    new IndividualFactory<ContinuousChromosome>(),
                    new Panmixia<ContinuousChromosome, Individual<ContinuousChromosome>, ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>, ParentsPairFactory<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (new ParentsPairFactory<ContinuousChromosome, Individual<ContinuousChromosome>>(),
                        50),
                    new BLXCrossover<Individual<ContinuousChromosome>, ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (0.8, 0.2),
                    new PointMutation<ContinuousChromosome, ContinuousLocus>
                        (0.03)
                    );

            DateTime t = DateTime.Now;
            var bestSolution = ga.Run(new SquaredFunc(10));
            Console.WriteLine((DateTime.Now - t).TotalMilliseconds);

            Console.WriteLine(bestSolution.Fitness);
            bestSolution.RecalculateFitness();
            Console.WriteLine("[{0}, {1}]", bestSolution.Chromosome[0].Value, bestSolution.Chromosome[1].Value);
            return true;
        }

        static void TestGenetic()
        {
            Console.WriteLine("\tТестируем EvoMice.Genetic");

            RunTest(testGeneticClasses, "Классы генетического алгоритма");

        }

        static bool testNeuroStruct()
        {

            LinearNeuron n1 = new LinearNeuron(1),
                         n2 = new LinearNeuron(1),
                         n3 = new LinearNeuron(1);

            ClampedSynapse s1 = new ClampedSynapse(n1, n2, 1),
                           s2 = new ClampedSynapse(n2, n3, 1),
                           s3 = new ClampedSynapse(n3, n1, 2);

            INetwork<LinearNeuron, ClampedSynapse> network = new Network<LinearNeuron, ClampedSynapse>(new List<LinearNeuron> { n1, n2, n3 }, new List<ClampedSynapse> { s1, s2, s3 });
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

        static void TestNeuro()
        {
            Console.WriteLine("\tТестируем EvoMice.Neuro");

            RunTest(testNeuroStruct, "Работа нейронной сети");

        }

        public static void RunTests()
        {
            TestNeuro();
            TestGenetic();
        }
    }
}
