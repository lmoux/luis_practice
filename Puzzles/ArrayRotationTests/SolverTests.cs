using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Puzzles.Tests;
using Puzzles.Algebra;

namespace Puzzles.ArrayRotation.Tests
{
    [TestClass]
    public class SolverTests
    {
        [TestMethod]
        public void GenerateRotation()
        {
            var original = new int[3, 3]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            var expected = new int[3, 3]
            {
                {7, 4, 1},
                {8, 5, 2},
                {9, 6, 3}
            };

            TestingUtilities.AssertEquality(expected, Solver.GenerateRotation(original));
            TestingUtilities.AssertEquality(original,
                Solver.GenerateRotation(
                    Solver.GenerateRotation(
                        Solver.GenerateRotation(
                            Solver.GenerateRotation(original)))));

            int times = 0;
            Func<int[,], int[,]> function = x =>
                {
                    Console.WriteLine("Rotation #{0}", ++times);
                    var current = Solver.GenerateRotation(x);
                    Console.WriteLine(new Matrix2d<int>(current));
                    return current;
                };

            TestingUtilities.AssertEquality(original, function.Chain(4)(original));
        }

        [TestMethod]
        public void GenerateTranspose()
        {
            var original = new int[2, 3]
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            var expected = new int[3, 2]
            {
                {1, 4},
                {2, 5},
                {3, 6}
            };

            TestingUtilities.AssertEquality(expected, Solver.GenerateTranspose(original));
        }
    }
}
