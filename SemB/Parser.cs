using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB
{
    internal class Parser<TK, TP> where TK : IComparable<TK> where TP : IComparable<TP>
    {
        public void LoadValuesFromFile(Treap<TK, TP> treap, string filePath)
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    treap.Add((TK)Convert.ChangeType(line, typeof(TK)));
                }
                Console.WriteLine("Hodnoty byly úspěšně načteny.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chyba při načítání souboru: {e.Message}");
            }
        }

        public void SaveTreeToFile(Treap<TK, TP> treap, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var value in treap.InOrderTraversal())
                    {
                        writer.WriteLine(value);
                    }
                }
                Console.WriteLine("Hodnoty stromu byly úspěšně uloženy.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chyba při ukládání souboru: {e.Message}");
            }
        }

        public void SaveStatsToFile(TreapStatistics stats, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Průměrná výška stromu: {stats.GetAverageHeight()}");
                    writer.WriteLine($"Maximální výška stromu: {stats.GetMaxHeight()}");
                    writer.WriteLine($"Minimální výška stromu: {stats.GetMinHeight()}");
                    writer.WriteLine($"Modus výšek stromu: {stats.GetModeHeight()}");

                    var cumulativeAverages = stats.GetCumulativeAverages();
                    writer.WriteLine("Kumulativní průměry výšek:");
                    foreach (var avg in cumulativeAverages)
                    {
                        writer.WriteLine(avg);
                    }
                }
                Console.WriteLine("Statistická analýza byla úspěšně uložena.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chyba při ukládání souboru: {e.Message}");
            }
        }
    }
}
