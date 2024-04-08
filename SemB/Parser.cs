using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB
{
    internal class Parser<TKey> where TKey : IComparable
    {
        // Načítá hodnoty z textového souboru a vkládá je do treapu
        public void LoadValuesFromFile(Treap<TKey> treap, string filePath)
        {
            try
            {
                foreach (var line in File.ReadLines(filePath))
                {
                    // Předpokládáme, že treap má metodu Insert, která přijímá hodnotu typu T
                    // Zde je nutné přidat logiku pro převod řetězce na typ T, pokud T není string
                    treap.Add((TKey)Convert.ChangeType(line, typeof(TKey)));
                }
                Console.WriteLine("Hodnoty byly úspěšně načteny.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Chyba při načítání souboru: {e.Message}");
            }
        }

        // Ukládá hodnoty stromu do textového souboru
        public void SaveTreeToFile(Treap<TKey> treap, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    // Předpokládáme, že treap má metodu pro průchod (např. InOrderTraversal), která vrací IEnumerable<T>
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

        // Ukládá statistickou analýzu do souboru
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
