using System;
using System.Collections.Generic;
using System.Text;

namespace EvoMice.Neuro
{
    /// <summary>
    /// Связь между нейронами
    /// </summary>
    public interface ISynapse
    {
        /// <summary>
        /// Вычисляет взвешенный сигнал синапса на основе выхода нейрона и своего веса
        /// </summary>
        void Update();
    }
}
