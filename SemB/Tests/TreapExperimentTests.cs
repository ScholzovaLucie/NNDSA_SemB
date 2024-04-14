using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemB.Treap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Tests
{
    [TestClass]
    internal class TreapExperimentTests
    {
        Random rng = new Random();
        int GenerateRandomPriority()
        {
            return rng.Next(1, 1000);
        }

        [TestMethod]
        public void PerformRandomExperiments()
        {
            const int experiments = 10000;
            const int nodesPerExperiment = 1023;
            var random = new Random();
            var results = new List<int>();

            for (int i = 0; i < experiments; i++)
            {
                var treap = new Treap<int, int>(GenerateRandomPriority); 
                for (int j = 0; j < nodesPerExperiment; j++)
                {
                    treap.Add(random.Next()); 
                }

                int treeHeight = treap.Height(); 
                results.Add(treeHeight); 
            }

            Assert.IsTrue(results.Count == experiments, "Počet experimentů neodpovídá počtu zaznamenaných výsledků.");
        }

        }
}
