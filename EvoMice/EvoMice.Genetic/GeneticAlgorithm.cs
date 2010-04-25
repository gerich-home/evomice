﻿using System;
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
        /// Стратегия формирования следующей популяции
        /// </summary>
        public IReproductionStrategy<TChromosome, TIndividual> Strategy { get; protected set; }

        /// <summary>
        /// Инициализатор первой популяции
        /// </summary>
        public IPopulationInitializer<TChromosome> PopulationInitializer { get; protected set; }

        /// <summary>
        /// Условие продолжения генетического алгоритма
        /// </summary>
        public IContinueCondition<TChromosome, TIndividual> ContinueCondition { get; protected set; }

        /// <summary>
        /// Создатель индивида
        /// </summary>
        public IIndividualFactory<TChromosome, TIndividual, TFitnessFunction> IndividualFactory { get; protected set; }

        /// <summary>
        /// Система подбора родительских пар
        /// </summary>
        public IBreeding<TChromosome, TIndividual, TParentsPair> Breeding { get; protected set; }

        /// <summary>
        /// Кроссовер
        /// </summary>
        public ICrossover<TChromosome, TIndividual, TParentsPair> Crossover { get; protected set; }

        /// <summary>
        /// Мутация
        /// </summary>
        public IMutation<TChromosome> Mutation { get; protected set; }

        /// <summary>
        /// Генетический алгоритм
        /// </summary>
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
            IIndividualFactory<TChromosome, TIndividual, TFitnessFunction> individualFactory,
            IBreeding<TChromosome, TIndividual, TParentsPair> breeding,
            ICrossover<TChromosome, TIndividual, TParentsPair> crossover,
            IMutation<TChromosome> mutation
            )
        {
            Strategy = strategy;
            PopulationInitializer = populationInitializer;
            ContinueCondition = continueCondition;
            IndividualFactory = individualFactory;
            Breeding = breeding;
            Crossover = crossover;
            Mutation = mutation;
            BestSolution = default(TIndividual);
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

            currentPopulationsChromosomes = PopulationInitializer.Initialize();

            currentPopulation = new List<TIndividual>();
            foreach (TChromosome chromosome in currentPopulationsChromosomes)
                currentPopulation.Add(
                    IndividualFactory.CreateIndividual(chromosome, fitnessFunction)
                    );

            BestSolution = currentPopulation[0];

            foreach (TIndividual individual in currentPopulation)
                if (individual.Fitness > BestSolution.Fitness)
                    BestSolution = individual;

            while (ContinueCondition.ShouldContinue(currentPopulation, generation))
            {

                pairs = Breeding.Select(currentPopulation);

                reproductionGroup.Clear();

                foreach (TParentsPair pair in pairs)
                {
                    children = Crossover.Crossover(pair);

                    foreach (TChromosome chromosome in children)
                    {
                        mutant = Mutation.Mutate(chromosome);

                        reproductionGroup.Add(
                            IndividualFactory.CreateIndividual(mutant, fitnessFunction)
                            );
                    }
                }

                foreach (TIndividual individual in reproductionGroup)
                    if (individual.Fitness > BestSolution.Fitness)
                        BestSolution = individual;

                currentPopulation = Strategy.NextGeneration(
                    currentPopulation,
                    reproductionGroup
                    );

                generation++;
            }
        }

        /// <summary>
        /// Лучшее решение, найденное генетическим алгоритмом
        /// </summary>
        public TIndividual BestSolution { get; protected set; }

        #endregion
    }
}
