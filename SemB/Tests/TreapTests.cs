using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemB.Treap;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemB.Tests
{
    [TestFixture]
    public class TreapTests
    {
        private Treap<string, int> treap;
        private TreapStatistics stats;

        [SetUp]
        public void Setup()
        {
            treap = new Treap<string, int>(() => new Random().Next(100)); // Předpokládá, že priority jsou typu int
            stats = new TreapStatistics();
        }

        [Test]
        public void TestTreapOperations()
        {
            // Příklad vkládání náhodně generovaných názvů obcí do Treapu
            for (int i = 0; i < 10000; i++) // 10 000 pokusů
            {
                treap.Clear(); // Resetuje Treap před každým pokusem
                for (int j = 0; j < 1023; j++) // Vloží 1 023 náhodných prvků
                {
                    string obec = "Obec" + new Random().Next(1000000).ToString("D6");
                    treap.Add(obec);
                }
                int height = treap.Height();
                stats.AddHeight(height);
            }

            // Test statistické analýzy
            NUnit.Framework.Assert.That(stats.GetMaxHeight(), Is.GreaterThan(0));
            NUnit.Framework.Assert.That(stats.GetMinHeight(), Is.LessThan(100)); // Předpokládejme rozumné maximum pro výšku
            NUnit.Framework.Assert.That(stats.GetAverageHeight(), Is.GreaterThan(0));

            // Výpis statistik (nepotřebné pro test, ale užitečné pro debug)
            Console.WriteLine($"Průměrná výška: {stats.GetAverageHeight()}");
            Console.WriteLine($"Maximální výška: {stats.GetMaxHeight()}");
            Console.WriteLine($"Minimální výška: {stats.GetMinHeight()}");
            Console.WriteLine($"Modus výšky: {stats.GetModeHeight()}");
        }
    }


    
}
