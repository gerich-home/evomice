using System.Collections.Generic;
using System.Linq;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Генетический алгоритм
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TParentsPair">Тип родительской пары</typeparam>
    public class GeneticAlgorithm<TChromosome, TIndividual, TParentsPair> :
        IGeneticAlgorithm<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
        where TParentsPair : IParentsPair<TIndividual>
    {
        /// <summary>
        /// Стратегия формирования следующей популяции
        /// </summary>
        public IReproductionStrategy<TIndividual> Strategy { get; protected set; }

        /// <summary>
        /// Инициализатор первой популяции
        /// </summary>
        public IPopulationInitializer<TChromosome> PopulationInitializer { get; protected set; }

        /// <summary>
        /// Условие продолжения генетического алгоритма
        /// </summary>
        public IContinueCondition<TIndividual> ContinueCondition { get; protected set; }

        /// <summary>
        /// Создатель индивида
        /// </summary>
        public IIndividualFactory<TChromosome, TIndividual> IndividualFactory { get; protected set; }

        /// <summary>
        /// Система подбора родительских пар
        /// </summary>
        public IBreeding<TIndividual, TParentsPair> Breeding { get; protected set; }

        /// <summary>
        /// Кроссовер
        /// </summary>
        public ICrossover<TChromosome, TParentsPair> Crossover { get; protected set; }

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
            IReproductionStrategy<TIndividual> strategy,
            IPopulationInitializer<TChromosome> populationInitializer,
            IContinueCondition<TIndividual> continueCondition,
            IIndividualFactory<TChromosome, TIndividual> individualFactory,
            IBreeding<TIndividual, TParentsPair> breeding,
            ICrossover<TChromosome, TParentsPair> crossover,
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
        }

        #region IGeneticAlgorithm<TChromosome,TIndividual,TFitnessFunction> Members

        /// <summary>
        /// Работа генетического алгоритма
        /// </summary>
        /// <param name="fitnessFunction">Функция приспособленности</param>
        /// <returns>Лучшее решение, найденное генетическим алгоритмом</returns>
        public TIndividual Run(IFitnessFunction<TChromosome> fitnessFunction)
        {
            int generation = 0;

            var reproductionGroup = new List<TIndividual>();

            var currentPopulationsChromosomes = PopulationInitializer.Initialize();

            IReadOnlyList<TIndividual> currentPopulation = currentPopulationsChromosomes.Select(
                chromosome => IndividualFactory.CreateIndividual(chromosome, fitnessFunction)
                ).ToList();

            var bestSolution = currentPopulation[0];

            foreach (var individual in currentPopulation)
                if (individual.Fitness > bestSolution.Fitness)
                    bestSolution = individual;

            while (ContinueCondition.ShouldContinue(currentPopulation, generation))
            {

                var pairs = Breeding.Select(currentPopulation);

                reproductionGroup.Clear();

                foreach (var children in pairs.Select(pair => Crossover.Crossover(pair)))
                {
                    reproductionGroup.AddRange(
                        children
                            .Select(chromosome => Mutation.Mutate(chromosome))
                            .Select(mutant => IndividualFactory.CreateIndividual(mutant, fitnessFunction)));
                }

                foreach (var individual in reproductionGroup)
                    if (individual.Fitness > bestSolution.Fitness)
                        bestSolution = individual;

                currentPopulation = Strategy.NextGeneration(
                    currentPopulation,
                    reproductionGroup
                    );

                generation++;
            }

            return bestSolution;
        }

        #endregion
    }
}
