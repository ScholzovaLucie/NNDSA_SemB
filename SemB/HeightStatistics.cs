using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB
{
    internal class HeightStatistics
    {
        private List<int> heights;
        private int sum;
        private int min;
        private int max;
        private double average;
        private int mode;

        public HeightStatistics(List<int> heights)
        {
            this.heights = heights;
            sum = 0;
            min = int.MaxValue;
            max = int.MinValue;
            mode = 0;
            
        }

        public void Analyze()
        {
            ComputeSum();
            ComputeMin();
            ComputeMax();
            ComputeAverage();
            ComputeMode();

            PrintStatistics();
            PrintCumulativeAverages();
        }

        private void ComputeSum()
        {
            foreach (int height in heights)
            {
                sum += height;
            }
        }

        private void ComputeMin()
        {
            foreach (int height in heights)
            {
                min = Math.Min(min, height);
            }
        }

        private void ComputeMax()
        {
            foreach (int height in heights)
            {
                max = Math.Max(max, height);
            }
        }

        private void ComputeAverage()
        {
            average = (double)sum / heights.Count;
        }

        private void ComputeMode()
        {
            Dictionary<int, int> heightFrequency = new Dictionary<int, int>();
            int maxFrequency = 0;

            foreach (int height in heights)
            {
                if (!heightFrequency.ContainsKey(height))
                    heightFrequency[height] = 1;
                else
                    heightFrequency[height]++;

                if (heightFrequency[height] > maxFrequency)
                {
                    mode = height;
                    maxFrequency = heightFrequency[height];
                }
            }
        }

        private void PrintStatistics()
        {
            Console.WriteLine($"Průměr výšky stromu: {average}");
            Console.WriteLine($"Maximum výšky stromu: {max}");
            Console.WriteLine($"Minimum výšky stromu: {min}");
            Console.WriteLine($"Modus výšky stromu: {mode}");
        }

        private void PrintCumulativeAverages()
        {
            double cumulativeAverage = 0;
            for (int i = 0; i < heights.Count; i++)
            {
                cumulativeAverage += heights[i];
                cumulativeAverage /= (i + 1);
                Console.WriteLine($"Kumulativní průměr po {i + 1}. pokusu: {cumulativeAverage}");
            }
        }
    }
}
