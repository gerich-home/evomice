
namespace EvoMice.Genetic
{
    /// <summary>
    /// Родительская пара
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    /// <typeparam name="TIndividual"></typeparam>
    public class ParentsPair<TChromosome, TIndividual> : IParentsPair<TChromosome, TIndividual>
        where TIndividual : IIndividual<TChromosome>
    {

        /// <summary>
        /// Родительская пара
        /// </summary>
        /// <param name="mother">1-ая особь родительской пары</param>
        /// <param name="father">2-ая особь родительской пары</param>
        public ParentsPair(TIndividual mother, TIndividual father)
        {
            Mother = mother;
            Father = father;
        }

        #region IParentsPair<TChromosome, TIndividual> Members

        /// <summary>
        /// 1-ая особь родительской пары
        /// </summary>
        public TIndividual Mother { get; protected set; }

        /// <summary>
        /// 2-ая особь родительской пары
        /// </summary>
        public TIndividual Father { get; protected set; }

        #endregion
    }
}