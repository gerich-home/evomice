﻿using System.Collections.Generic;

namespace EvoMice.Genetic.Util
{
    public static class PopulationSorter
    {
        /// <summary>
        /// Сортирует популяцию по убыванию приспособленностей
        /// </summary>
        /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
        /// <typeparam name="TIndividual">Тип индивида</typeparam>
        /// <param name="population">Популяция</param>
        /// <returns>Отсортированная популяция</returns>
        public static IReadOnlyList<TIndividual> SortPopulation<TChromosome, TIndividual>(IReadOnlyList<TIndividual> population)
            where TIndividual : IIndividual<TChromosome>
        {
            var sortedPopulation = new List<TIndividual>(population.Count);
            sortedPopulation.AddRange(population);
            QSort<TChromosome, TIndividual>(sortedPopulation, 0, population.Count - 1);
            return sortedPopulation;
        }

        private static void QSort<TChromosome, TIndividual>(IList<TIndividual> population, int left, int right)
            where TIndividual : IIndividual<TChromosome>
        {
            int l = left;
            int r = right;
            double mFitness = population[left].Fitness;
            while (l <= r)
            {
                while (population[l].Fitness > mFitness && l < right) l++;
                while (mFitness > population[r].Fitness && r > left) r--;

                if (l > r) continue;

                var tmp = population[l];
                population[l] = population[r];
                population[r] = tmp;
                l++; r--;
            }

            if (left < r) QSort<TChromosome, TIndividual>(population, left, r);
            if (l < right) QSort<TChromosome, TIndividual>(population, l, right);
        }
    }
}
