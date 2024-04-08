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
    public class TreapStatisticsTests
    {
        [TestMethod]
        public void TestStatistics()
        {
            var stats = new TreapStatistics();
            stats.AddHeight(10);
            stats.AddHeight(20);
            stats.AddHeight(30);

            Assert.AreEqual(20, stats.GetAverageHeight(), "Průměrná výška není správná.");
            Assert.AreEqual(30, stats.GetMaxHeight(), "Maximální výška není správná.");
            Assert.AreEqual(10, stats.GetMinHeight(), "Minimální výška není správná.");
        }
    }
}
