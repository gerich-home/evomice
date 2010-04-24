using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Genetic
{
    /// <summary>
    /// Оцененная особь генетического алгоритма
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public class Individual<TChromosome> : IIndividual<TChromosome>
    {
        /// <summary>
        /// Значение приспособленности
        /// </summary>
        protected double fitness;

        /// <summary>
        /// Функция приспособленности
        /// </summary>
        protected IFitnessFunction<TChromosome> fitnessFunction;

        /// <summary>
        /// Особь
        /// </summary>
        protected TChromosome chromosome;

        /// <summary>
        /// Оцененная особь генетического алгоритма
        /// </summary>
        /// <param name="individual">Неоцененная особь</param>
        /// <remarks>Оценивает особь, создавая новый объект Individual</remarks>
        public Individual(TChromosome chromosome, IFitnessFunction<TChromosome> fitnessFunction)
        {
            this.chromosome = chromosome;
            this.fitnessFunction = fitnessFunction;
            RecalculateFitness();
        }

        #region IIndividual<TChromosome> Members

        /// <summary>
        /// Значение приспособленности
        /// </summary>
        public double Fitness
        {
            get { return fitness; }
        }

        /// <summary>
        /// Хромосома особи
        /// </summary>
        public TChromosome Chromosome
        {
            get { return chromosome; }
        }

        /// <summary>
        /// Пересчитывает значение приспособленности особи
        /// </summary>
        public void RecalculateFitness()
        {
            fitness = fitnessFunction.Calculate(chromosome);
        }

        #endregion
    }
}