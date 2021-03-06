﻿using System;
using System.Collections.Generic;

namespace EvoMice.Genetic.Selection
{
    /// <summary>
    /// Пропорциональная селекция с линейным динамическим масштабированием
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual">Тип индивида</typeparam>
    /// <typeparam name="TSelector">Тип алгоритма отбора особей</typeparam>
    public class ScaledProportionalSelection<TChromosome, TIndividual, TSelector> :
        Selection<TIndividual, TSelector>
        where TIndividual : IIndividual<TChromosome>
        where TSelector : ISelector<TIndividual>
    {
        /// <summary>
        /// Математическое ожидание числа копий самой приспособленной особи
        /// </summary>
        public double c { get; protected set; }

        /// <summary>
        /// Пропорциональная селекция с линейным динамическим масштабированием
        /// </summary>
        /// <param name="c">Математическое ожидание числа копий самой приспособленной особи</param>
        /// <param name="selector">Алгоритм отбора особей</param>
        public ScaledProportionalSelection(double c, TSelector selector) :
            base(selector)
        {
            this.c = c;
        }

        /// <summary>
        /// Произвести селекцию
        /// </summary>
        /// <param name="reproductionGroup">Репродукционное множество</param>
        /// <param name="count">Число необходимых индивидов</param>
        /// <returns>Отобранные особи</returns>
        protected override IReadOnlyList<TIndividual> DoSelection(IReadOnlyList<TIndividual> reproductionGroup, int count)
        {
            int rCount = reproductionGroup.Count;
            var ranks = new List<double>(rCount);

            double a;
            double b;
            double aveFitness = 0;
            double minFitness = double.MaxValue;
            double maxFitness = double.MinValue;

            for (int i = 0; i < rCount; i++)
            {
                aveFitness += reproductionGroup[i].Fitness;
                maxFitness = Math.Max(maxFitness, reproductionGroup[i].Fitness);
                minFitness = Math.Min(minFitness, reproductionGroup[i].Fitness);
            }
            aveFitness /= rCount;

            if (minFitness == aveFitness || aveFitness == -maxFitness)
            {
                var selected = new List<TIndividual>();
                for (int i = 0; i < rCount; i++)
                    selected.Add(reproductionGroup[Util.Random.Next(rCount)]);
                return selected;
            }
            
            if (minFitness * (c - 1) >= (maxFitness - c * aveFitness))
            {
                a = (c - 1) * aveFitness / (aveFitness + maxFitness);
                b = aveFitness * (maxFitness - c * aveFitness) / (aveFitness - minFitness);
            }
            else
            {
                a = aveFitness / (aveFitness - minFitness);
                b = aveFitness * minFitness / (aveFitness - minFitness);
            }

            for (int i = 0; i < rCount; i++)
                ranks.Add(a * reproductionGroup[i].Fitness + b);

            return Selector.Select(reproductionGroup, ranks, count);
        }
    }
}
