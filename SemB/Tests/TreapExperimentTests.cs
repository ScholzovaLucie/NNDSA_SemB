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
        [TestMethod]
        public void PerformRandomExperiments()
        {
            const int experiments = 10000;
            const int nodesPerExperiment = 1023;
            var random = new Random();
            var results = new List<int>(); // Seznam pro uchování výšek stromů z experimentů

            for (int i = 0; i < experiments; i++)
            {
                var treap = new Treap<int>(); // Předpokládáme, že Treap je implementován pro int
                for (int j = 0; j < nodesPerExperiment; j++)
                {
                    treap.Add(random.Next()); 
                }

                int treeHeight = treap.Height(); // Implementujte metodu pro výpočet výšky stromu
                results.Add(treeHeight); // Ukládáme výšku stromu z každého experimentu do seznamu
            }

            // Zde můžete přidat logiku pro další zpracování nebo ověření výsledků
            Assert.IsTrue(results.Count == experiments, "Počet experimentů neodpovídá počtu zaznamenaných výsledků.");
        }
        }
}
