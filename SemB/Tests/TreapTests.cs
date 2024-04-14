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
    public class TreapTests
    {
        Random rng = new Random();
        int GenerateRandomPriority()
        {
            return rng.Next(1, 1000);

        }
        [TestMethod]
        public void TestInsertAndSearch()
        {
            var treap = new Treap<int, int>(GenerateRandomPriority);
            treap.Add(10);
            Assert.IsTrue(treap.Find(10), "Prvek 10 nebyl nalezen.");
        }

        [TestMethod]
        public void TestDelete()
        {
            var treap = new Treap<int, int>(GenerateRandomPriority);
            treap.Add(20);
            treap.Remove(20);
            Assert.IsFalse(treap.Find(20), "Prvek 20 byl nalezen, i když měl být odstraněn.");
        }
    }


    
}
