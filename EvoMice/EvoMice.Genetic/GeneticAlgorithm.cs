using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class GeneticAlgorithm<TChromosome> :
        IGeneticAlgorithm<TChromosome, IIndividual<TChromosome>>
    {
        /// <summary>
        /// Лучшее решение, найденное генетическим алгоритмом
        /// </summary>
        IIndividual<TChromosome> bestSolution;

        /// <summary>
        /// Функция приспособленности
        /// </summary>
        IFitnessFunction<TChromosome> fitnessFunction;

        /// <summary>
        /// Стратегия формирования следующей популяции
        /// </summary>
        IReproductionStrategy<TChromosome, Individual<TChromosome>> strategy;

        /// <summary>
        /// Инициализатор первой популяции
        /// </summary>
        IPopulationInitializer<TChromosome> populationInitializer;

        /// <summary>
        /// Условие продолжения генетического алгоритма
        /// </summary>
        IContinueCondition<TChromosome, Individual<TChromosome>> continueCondition;

        /// <summary>
        /// Система подбора родительских пар
        /// </summary>
        IBreeding<TChromosome, Individual<TChromosome>, ParentsPair<TChromosome, Individual<TChromosome>>> breeding;

        /// <summary>
        /// Кроссовер
        /// </summary>
        ICrossover<TChromosome, Individual<TChromosome>, ParentsPair<TChromosome, Individual<TChromosome>>> crossover;

        /// <summary>
        /// Мутация
        /// </summary>
        IMutation<TChromosome> mutation;

        /// <summary>
        /// Генетический алгоритм
        /// </summary>
        /// <param name="fitnessFunction">Функция приспособленности</param>
        /// <param name="strategy">Стратегия формирования следующей популяции</param>
        /// <param name="populationInitializer">Инициализатор первой популяции</param>
        /// <param name="continueCondition">Условие продолжения генетического алгоритма</param>
        /// <param name="breeding">Система подбора родительских пар</param>
        /// <param name="crossover">Кроссовер</param>
        /// <param name="mutation">Мутация</param>
        public GeneticAlgorithm(
            IFitnessFunction<TChromosome> fitnessFunction,
            IReproductionStrategy<TChromosome, Individual<TChromosome>> strategy,
            IPopulationInitializer<TChromosome> populationInitializer,
            IContinueCondition<TChromosome, Individual<TChromosome>> continueCondition,
            IBreeding<TChromosome, Individual<TChromosome>, ParentsPair<TChromosome, Individual<TChromosome>>> breeding,
            ICrossover<TChromosome, Individual<TChromosome>, ParentsPair<TChromosome, Individual<TChromosome>>> crossover,
            IMutation<TChromosome> mutation
            )
        {
            this.fitnessFunction = fitnessFunction;
            this.strategy = strategy;
            this.populationInitializer = populationInitializer;
            this.continueCondition = continueCondition;
            this.breeding = breeding;
            this.crossover = crossover;
            this.mutation = mutation;
            bestSolution = null;
        }

        #region IGeneticAlgorithm<TChromosome> Members

        /// <summary>
        /// Работа генетического алгоритма
        /// </summary>
        public void Run()
        {
            int generation = 0;

            IList<TChromosome> currentPopulationsChromosomes;
            IList<Individual<TChromosome>> currentPopulation;

            IList<ParentsPair<TChromosome, Individual<TChromosome>>> pairs;

            IList<TChromosome> children;

            TChromosome mutant;

            List<Individual<TChromosome>> reproductionGroup =
                new List<Individual<TChromosome>>();

            currentPopulationsChromosomes = populationInitializer.Intialize();

            currentPopulation = new List<Individual<TChromosome>>();
            foreach (TChromosome chromosome in currentPopulationsChromosomes)
                currentPopulation.Add(
                    new Individual<TChromosome>(chromosome, fitnessFunction)
                    );

            bestSolution = currentPopulation[0];

            foreach (Individual<TChromosome> individual in currentPopulation)
                if (individual.Fitness > bestSolution.Fitness)
                    bestSolution = individual;

            while (continueCondition.ShouldContinue(currentPopulation, generation))
            {
                reproductionGroup.Clear();

                pairs = breeding.Select(currentPopulation);

                foreach (ParentsPair<TChromosome, Individual<TChromosome>>
                    pair in pairs)
                {
                    children = crossover.Crossover(pair);

                    foreach (TChromosome chromosome in children)
                    {
                        mutant = mutation.Mutate(chromosome);

                        reproductionGroup.Add(
                            new Individual<TChromosome>(mutant, fitnessFunction)
                            );
                    }
                }

                foreach (Individual<TChromosome> individual in reproductionGroup)
                    if (individual.Fitness > bestSolution.Fitness)
                        bestSolution = individual;

                currentPopulation = strategy.NextGeneration(
                    currentPopulation,
                    reproductionGroup
                    );
                generation++;
            }
        }

        /// <summary>
        /// Лучшее решение, найденное генетическим алгоритмом
        /// </summary>
        public IIndividual<TChromosome> BestSolution
        {
            get { return BestSolution; }
        }

        #endregion
    }
}
