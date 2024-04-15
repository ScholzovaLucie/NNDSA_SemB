using System;
using System.Collections.Generic;
using System.Linq;

public class TreapStatistics
{
    private List<int> heights = new List<int>();

    public void AddHeight(int height)
    {
        heights.Add(height);
    }

    public double GetAverageHeight() => heights.Any() ? heights.Average() : 0;
    public int GetMaxHeight() => heights.Any() ? heights.Max() : 0;
    public int GetMinHeight() => heights.Any() ? heights.Min() : 0;
    public int GetModeHeight() => heights.GroupBy(h => h).OrderByDescending(g => g.Count()).First().Key;

    public IEnumerable<double> GetCumulativeAverages()
    {
        double sum = 0;
        return heights.Select((h, index) => (sum += h) / (index + 1));
    }

    public int GetExperimentCount() => heights.Count;

    public void SaveStatsToFile(string filePath)
    {
        try
        {
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Průměrná výška stromu: {GetAverageHeight()}");
                writer.WriteLine($"Maximální výška stromu: {GetMaxHeight()}");
                writer.WriteLine($"Minimální výška stromu: {GetMinHeight()}");
                writer.WriteLine($"Modus výšek stromu: {GetModeHeight()}");
                writer.WriteLine("Kumulativní průměry výšek:");
                foreach (var avg in GetCumulativeAverages())
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