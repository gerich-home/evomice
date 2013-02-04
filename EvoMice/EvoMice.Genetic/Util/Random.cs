
namespace EvoMice.Genetic.Util
{
    public static class Random
    {
        private static readonly System.Random rnd = new System.Random();

        /// <summary>
        /// Общий генератор случайных чисел
        /// </summary>
        public static System.Random Rnd
        {
            get { return rnd; }
        }

        public static int Next()
        {
            return rnd.Next();
        }

        public static int Next(int maxValue)
        {
            return rnd.Next(maxValue);
        }

        public static int Next(int minValue, int maxValue)
        {
            return rnd.Next(minValue, maxValue);
        }

        public static double NextDouble()
        {
            return rnd.NextDouble();
        }

    }
}
