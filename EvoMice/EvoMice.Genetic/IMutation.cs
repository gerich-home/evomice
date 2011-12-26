
namespace EvoMice.Genetic
{
    /// <summary>
    /// Мутация выбранной особи
    /// </summary>
    /// <typeparam name="TChromosome">Тип хромосомы индивида</typeparam>
    public interface IMutation<TChromosome>
    {
        /// <summary>
        /// Производит мутацию хромосомы особи
        /// </summary>
        /// <param name="chromosome">Исходная хромосома</param>
        /// <returns>Мутированная хромосома или исходная, если мутация не произошла</returns>
        TChromosome Mutate(TChromosome chromosome);
    }
}
