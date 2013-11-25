using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzles.Tests;
namespace Puzzles.Sorting.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void InPlaceBubbleSort()
        {
            var collection = new int[] { 2, 1, 3, 6, 5, 4, 7, 8, 9, 0};
            var unsortedCollection = collection.ToList();

            Assert.AreEqual(10, collection.Length);
            Solver.InPlace.BubbleSort(collection);
            Assert.IsFalse(TestingUtilities.AreEquivalent(collection, unsortedCollection));
            Assert.IsTrue(TestingUtilities.AreEquivalent(collection, Enumerable.Range(0, 10)));
        }

    }
}
