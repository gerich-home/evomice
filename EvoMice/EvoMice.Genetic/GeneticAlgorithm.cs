using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    /// <typeparam name="TFitnessFunction">Тип функции приспособленности</typeparam>
    public class GeneticAlgorithm<TChromosome, TIndividual, TParentsPair, TFitnessFunction> :
        IGeneticAlgorithm<TChromosome, TIndividual, TFitnessFunction>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TChromosome, TIndividual>
        where TFitnessFunction : IFitnessFunction<TChromosome>
    {
        /// <summary>
        /// Лучшее решение, найденное генетическим алгоритмом
        /// </summary>
        TIndividual bestSolution;

        /// <summary>
        /// Стратегия формирования следующей популяции
        /// </summary>
        IReproductionStrategy<TChromosome, TIndividual> strategy;

        /// <summary>
        /// Инициализатор первой популяции
        /// </summary>
        IPopulationInitializer<TChromosome> populationInitializer;

        /// <summary>
        /// Условие продолжения генетического алгоритма
        /// </summary>
        IContinueCondition<TChromosome, TIndividual> continueCondition;

        /// <summary>
        /// Создатель индивида
        /// </summary>
        IIndividualFactory<TChromosome, TIndividual, TFitnessFunction> individualFactory;

        /// <summary>
        /// Система подбора родительских пар
        /// </summary>
        IBreeding<TChromosome, TIndividual, TParentsPair> breeding;

        /// <summary>
        /// Кроссовер
        /// </summary>
        ICrossover<TChromosome, TIndividual, TParentsPair> crossover;

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
        /// <param name="individualFactory">Создатель индивида</param>
        /// <param name="breeding">Система подбора родительских пар</param>
        /// <param name="crossover">Кроссовер</param>
        /// <param name="mutation">Мутация</param>
        public GeneticAlgorithm(
            IReproductionStrategy<TChromosome, TIndividual> strategy,
            IPopulationInitializer<TChromosome> populationInitializer,
            IContinueCondition<TChromosome, TIndividual> continueCondition,
            IIndividualFactory<TChromosome,TIndividual,TFitnessFunction> individualFactory,
            IBreeding<TChromosome, TIndividual, TParentsPair> breeding,
            ICrossover<TChromosome, TIndividual, TParentsPair> crossover,
            IMutation<TChromosome> mutation
            )
        {
            this.strategy = strategy;
            this.populationInitializer = populationInitializer;
            this.continueCondition = continueCondition;
            this.individualFactory = individualFactory;
            this.breeding = breeding;
            this.crossover = crossover;
            this.mutation = mutation;
            bestSolution = default(TIndividual);
        }

        #region IGeneticAlgorithm<TChromosome,TIndividual,TFitnessFunction> Members

        /// <summary>
        /// Работа генетического алгоритма
        /// </summary>
        /// <param name="fitnessFunction">Функция приспособленности</param>
        public void Run(TFitnessFunction fitnessFunction)
        {
            int generation = 0;

            IList<TChromosome> currentPopulationsChromosomes;
            IList<TIndividual> currentPopulation;

            IList<TParentsPair> pairs;

            IList<TChromosome> children;

            TChromosome mutant;

            List<TIndividual> reproductionGroup = new List<TIndividual>();

            currentPopulationsChromosomes = populationInitializer.Initialize();

            currentPopulation = new List<TIndividual>();
            foreach (TChromosome chromosome in currentPopulationsChromosomes)
                currentPopulation.Add(
                    individualFactory.CreateIndividual(chromosome, fitnessFunction)
                    );

            bestSolution = currentPopulation[0];

            foreach (TIndividual individual in currentPopulation)
                if (individual.Fitness > bestSolution.Fitness)
                    bestSolution = individual;

            while (continueCondition.ShouldContinue(currentPopulation, generation))
            {
                reproductionGroup.Clear();

                pairs = breeding.Select(currentPopulation);

                foreach (TParentsPair pair in pairs)
                {
                    children = crossover.Crossover(pair);

                    foreach (TChromosome chromosome in children)
                    {
                        mutant = mutation.Mutate(chromosome);

                        reproductionGroup.Add(
                            individualFactory.CreateIndividual(mutant, fitnessFunction)
                            );
                    }
                }

                foreach (TIndividual individual in reproductionGroup)
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
        public TIndividual BestSolution
        {
            get { return bestSolution; }
        }

        #endregion
    }
}
