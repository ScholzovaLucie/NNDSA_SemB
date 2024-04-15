using SemB.Generator;
using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Experimenty
{
    internal class StatistickeExperimenty
    {
        private Treap<string, int> treap;
        private TreapStatistics statistics;

        public StatistickeExperimenty(IPriorityGenerator<int> priorityGenerator)
        {
            treap = new Treap<string, int>(priorityGenerator);
            statistics = new TreapStatistics();
        }

        public void RunExperiment()
        {
            for (int i = 0; i < 10000; i++)
            {
                treap.Clear();
                for (int j = 0; j < 1023; j++)
                {
                    treap.Add($"Obec_{i}_{j}");
                }
                statistics.AddHeight(treap.Height());
            }
            PrintStatistics();
        }

        private void PrintStatistics()
        {
            Console.WriteLine($"Počet experimentů: {statistics.GetExperimentCount()}");
            Console.WriteLine($"Průměrná výška: {statistics.GetAverageHeight()}");
            Console.WriteLine($"Maximální výška: {statistics.GetMaxHeight()}");
            Console.WriteLine($"Minimální výška: {statistics.GetMinHeight()}");
            Console.WriteLine($"Modus výšky: {statistics.GetModeHeight()}");
        }

        public void SaveStatsToFile( string filename )
        {
            statistics.SaveStatsToFile( filename );
        }
    }

}
