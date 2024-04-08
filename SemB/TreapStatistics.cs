using System;
using System.Collections.Generic;
using System.Linq;

public class TreapStatistics
{
    private List<int> heights = new List<int>();

    // Přidá výšku stromu do seznamu pro pozdější analýzu
    public void AddHeight(int height)
    {
        heights.Add(height);
    }

    // Vypočítá a vrátí průměrnou výšku stromu
    public double GetAverageHeight()
    {
        if (heights.Count == 0) return 0;
        return heights.Average();
    }

    // Vrátí maximální výšku stromu
    public int GetMaxHeight()
    {
        return heights.Count == 0 ? 0 : heights.Max();
    }

    // Vrátí minimální výšku stromu
    public int GetMinHeight()
    {
        return heights.Count == 0 ? 0 : heights.Min();
    }

    // Vrátí modus výšek stromů (nejčastěji se vyskytující výška)
    public int GetModeHeight()
    {
        if (heights.Count == 0) return 0;
        return heights.GroupBy(n => n)
                      .OrderByDescending(g => g.Count())
                      .First()
                      .Key;
    }

    // Vypočítá a vrátí kumulativní průměry výšek stromů
    public IEnumerable<double> GetCumulativeAverages()
    {
        var cumulativeAverages = new List<double>();
        double sum = 0;
        for (int i = 0; i < heights.Count; i++)
        {
            sum += heights[i];
            cumulativeAverages.Add(sum / (i + 1));
        }
        return cumulativeAverages;
    }

    // Vrátí počet provedených experimentů
    public int GetExperimentCount()
    {
        return heights.Count;
    }

    public void PrintCumulativeAverages()
    {
        double sum = 0;
        for (int i = 0; i < heights.Count; i++)
        {
            sum += heights[i];
            Console.WriteLine($"Kumulativní průměr po {i + 1} experimentech: {sum / (i + 1)}");
        }
    }
}
