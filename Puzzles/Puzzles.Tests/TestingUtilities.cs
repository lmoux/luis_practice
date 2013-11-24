using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Puzzles.Tests
{
    public class TestingUtilities
    {
        public static bool AreEquivalent<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            return first
                .Zip(second, (y, x) => y.Equals(x))
                .Aggregate(true, (current, accumulation) => accumulation &= current);
        }

        public static void AssertEquality(int[,] first, int[,] second)
        {
            Assert.AreEqual(first.Length, second.Length);
            for (int row = 0; row < first.GetLength(0); row++)
                for (int column = 0; column < first.GetLength(1); column++)
                {
                    Assert.AreEqual(first[row, column], second[row, column], Tuple.Create(row, column).ToString());
                }
        }
    }
}
