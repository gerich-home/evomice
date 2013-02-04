using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using EvoMice.Genetic;
using EvoMice.Genetic.Breeding;
using EvoMice.Genetic.ContinueCondition;
using EvoMice.Genetic.ReproductionStrategy;
using EvoMice.Genetic.Selection;
using EvoMice.Genetic.Selection.Selector;
using EvoMice.Genetic.VectorChromosome.Continuous;
using EvoMice.Genetic.VectorChromosome.Continuous.Crossover;
using EvoMice.Genetic.VectorChromosome.Continuous.Mutation;

namespace TestGUI
{
    public partial class TestForm : Form
    {
        public object locker = new object();

        private class TestFunc : IFitnessFunction<ContinuousChromosome>
        {
            private double[] Offset { get; set; }

            public TestFunc(params double[] offset)
            {
                Offset = new double[offset.Length];
                offset.CopyTo(Offset, 0);
            }

            #region IFitnessFunction<ContinuousChromosome> Members

            /*
            public double Calculate(ContinuousChromosome chromosome)
            {
                double s = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    double d = chromosome[i].Value - Offset[i];
                    s += d * d;
                }
                double l = Math.Sqrt(s);
                //return 60 - l;
                return 200 - (1 - Math.Cos(l) + 0.2 * l);
                //return Math.Exp(-s) + Math.Cos(l) + 1;
            }*/

            /*
            public double Calculate(ContinuousChromosome chromosome)
            {
                double s = 0;
                for (int i = 0; i < chromosome.Length; i++)
                    s += Math.Abs(chromosome[i].Value - Offset[i]);

                return 60 - s;
            }*/

            public double Calculate(ContinuousChromosome chromosome)
            {
                double s = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    double d = chromosome[i].Value - Offset[i];
                    s += d * d;
                }
                double l = Math.Sqrt(s);


                return 200 - (1 + 2 * Math.Floor(l) - l);
            }

            #endregion
        }

        private class GUIIndividualFactory :
            IIndividualFactory<ContinuousChromosome, Individual<ContinuousChromosome>>
        {
            private TestForm TestForm { get; set; }

            public GUIIndividualFactory(TestForm testForm)
            {
                TestForm = testForm;
            }

            #region IIndividualFactory<ContinuousChromosome,Individual<ContinuousChromosome>,IFitnessFunction<ContinuousChromosome>> Members

            Individual<ContinuousChromosome> IIndividualFactory<ContinuousChromosome, Individual<ContinuousChromosome>>.CreateIndividual(ContinuousChromosome chromosome, IFitnessFunction<ContinuousChromosome> fitnessFunction)
            {
                TestForm.DrawChromosome(chromosome, TestForm.bmp, Color.Black);
                return new Individual<ContinuousChromosome>(chromosome, fitnessFunction);
            }

            #endregion
        }

        Bitmap bmp;
        Bitmap bestBmp;

        Thread workerThread;

        public TestForm()
        {
            InitializeComponent();
        }

        public void DrawChromosome(ContinuousChromosome chromosome, Bitmap bitmap, Color color)
        {
            lock (locker)
                bitmap.SetPixel(
                    (int)((chromosome[0].Value - chromosome[0].LowBound) / (chromosome[0].HighBound - chromosome[0].LowBound) * (bitmap.Width - 1)),
                    (int)((chromosome[1].Value - chromosome[1].LowBound) / (chromosome[1].HighBound - chromosome[1].LowBound) * (bitmap.Height - 1)),
                    color
                    );
        }

        public void RunGA()
        {
            var ga = new GeneticAlgorithm<
                ContinuousChromosome,
                Individual<ContinuousChromosome>,
                ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>
                >(
                    new ElitistReproductionStrategy<ContinuousChromosome, Individual<ContinuousChromosome>, ISelection<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (0.2,
                //new BTournamentSelection<ContinuousChromosome,Individual<ContinuousChromosome>>(4)
                        /*new ScaledProportionalSelection<ContinuousChromosome, Individual<ContinuousChromosome>, ISelector<ContinuousChromosome, Individual<ContinuousChromosome>>>
                            (2,
                            new RouletteSelector<ContinuousChromosome, Individual<ContinuousChromosome>>())*/
                        new RankSelection<ContinuousChromosome, Individual<ContinuousChromosome>, ISelector<ContinuousChromosome,Individual<ContinuousChromosome>>>
                            (1.9,
                            new RouletteSelector<ContinuousChromosome,Individual<ContinuousChromosome>>())
                        ),
                    new ContinuousPopulationInitializer
                         (50, 2, -20, 20),
                    new GenerationContinueCondition<ContinuousChromosome, Individual<ContinuousChromosome>>
                        (20),
                    //new IndividualFactory<ContinuousChromosome, IFitnessFunction<ContinuousChromosome>>(),
                    new GUIIndividualFactory(this),
                    new Panmixia<ContinuousChromosome, Individual<ContinuousChromosome>, ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>, ParentsPairFactory<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (new ParentsPairFactory<ContinuousChromosome, Individual<ContinuousChromosome>>(),
                        50),
                    new BLXCrossover<Individual<ContinuousChromosome>, ParentsPair<ContinuousChromosome, Individual<ContinuousChromosome>>>
                        (0.8, 0.05),
                    new DirectionalMutation<ContinuousChromosome>(0.03, 2)
                    //new PointMutation<ContinuousChromosome, ContinuousLocus>
                    //    (0.03)
                    );

            var bestSolution = ga.Run(new TestFunc(10, 10));

            DrawChromosome(bestSolution.Chromosome, bestBmp, Color.Red);
        }

        private delegate void InvokeDelegate();

        private void btnStart_Click(object sender, EventArgs e)
        {

            btnStart.Enabled = false;

            try
            {
                int runs = int.Parse(txtRuns.Text);
                if (runs < 0) throw new Exception();

                progressBar.Value = 0;
                progressBar.Maximum = runs;

                workerThread = new Thread(delegate()
                    {
                        try
                        {
                            for (int i = 0; i < runs; i++)
                            {
                                RunGA();
                                if (i % 50 == 0 || i == runs - 1)
                                    picView.Invoke(new InvokeDelegate(delegate()
                                        {
                                            lock (locker)
                                                picView.Refresh();
                                        }));
                                progressBar.Invoke(new InvokeDelegate(() => progressBar.Increment(1)));
                            }
                        }
                        catch { }
                        btnStart.Invoke(new InvokeDelegate(delegate()
                            {
                                btnStart.Enabled = true;
                            }));
                    });

                picView.Invoke(new InvokeDelegate(delegate()
                {
                    lock (locker)
                        picView.Refresh();
                }));

                workerThread.Start();

            }
            catch
            {
                MessageBox.Show("Введите положительное число в поле число запусков!");
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(picView.Width, picView.Height);
            bestBmp = new Bitmap(picView.Width, picView.Height);
            picView.Image = bmp;
        }

        private void picView_MouseDown(object sender, MouseEventArgs e)
        {
            lock (locker)
                picView.Image = bestBmp;
        }

        private void picView_MouseUp(object sender, MouseEventArgs e)
        {
            lock (locker)
                picView.Image = bmp;
        }

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workerThread != null)
                workerThread.Abort();
        }
    }
}
