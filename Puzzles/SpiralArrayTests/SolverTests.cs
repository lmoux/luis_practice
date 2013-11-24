using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Puzzles.Tests;

namespace Puzzles.SpiralArray.Tests
{
    [TestClass]
    public class SolverTests
    {
        public static Dictionary<int, int[,]> testBed = new Dictionary<int, int[,]>
        {
            {1, new int[1,1]{{1}}},
            {2, new int[2,2]{{1,2}, {4, 3}}},
            {3, new int[3,3]{{1,2,3}, {8,9,4}, {7,6,5}}},
            {4, new int[4,4]{{1,2,3,4}, {12,13,14,5}, {11,16,15,6}, {10,9,8,7}}},
            {5, new int[5,5]{{1,2,3,4,5}, {16,17,18,19,6}, {15,24,25,20,7}, {14,23,22,21,8}, {13,12,11,10,9}}},
        };

        [TestMethod]
        public void SpiralPathWalks()
        {
            //var points = Solver.OuterLoop(2, Tuple.Create(1,1)).ToList();
            //foreach (var point in points) Console.WriteLine(point);

            foreach (var point in Solver.SpiralPath(3)) Console.WriteLine(point);


            Assert.AreEqual(1, Solver.SpiralPath(1).Count());
            Assert.AreEqual(12, Solver.OuterLoop(4).Count());
            Assert.AreEqual(4, Solver.OuterLoop(2).Count());
            Assert.AreEqual(4, Solver.OuterLoop(2, Tuple.Create(1, 1)).Count());

            Assert.IsTrue(
                TestingUtilities.AreEquivalent(
                    new List<Tuple<int, int>>
                                {
                                    Tuple.Create(0,0),
                                },
                    Solver.OuterLoop(1)));

            Assert.IsTrue(
                TestingUtilities.AreEquivalent(
                    new List<Tuple<int, int>>
                                {
                                    Tuple.Create(0,0),
                                    Tuple.Create(0,1),
                                    Tuple.Create(0,2),
                                    Tuple.Create(1,2),
                                    Tuple.Create(2,2),
                                    Tuple.Create(2,1),
                                    Tuple.Create(2,0),
                                    Tuple.Create(1,0),
                                    Tuple.Create(1,1),
                                },
                    Solver.SpiralPath(3)));

            Assert.IsTrue(
                TestingUtilities.AreEquivalent(
                    new List<Tuple<int, int>>
                    {
                        Tuple.Create(0,0),
                        Tuple.Create(0,1),
                        Tuple.Create(1,1),
                        Tuple.Create(1,0),
                    },
                    Solver.OuterLoop(2)));

            Assert.IsTrue(
                TestingUtilities.AreEquivalent(
                    new List<Tuple<int, int>>
                    {
                        Tuple.Create(0,0),
                        Tuple.Create(0,1),
                        Tuple.Create(0,2),
                        Tuple.Create(1,2),
                        Tuple.Create(2,2),
                        Tuple.Create(2,1),
                        Tuple.Create(2,0),
                        Tuple.Create(1,0),
                    },
                    Solver.OuterLoop(3)));

        }

        [TestMethod]
        public void GenerateSpiralArray()
        {
            foreach (var test in testBed)
            {
                var actual = new Solver(test.Key).Generate();
                try
                {
                    TestingUtilities.AssertEquality(test.Value, actual);
                }
                catch
                {
                    Console.WriteLine("Expected:");
                    Utilities.PrettyPrintSquare(test.Value, test.Key);
                    Console.WriteLine("-------------");
                    Console.WriteLine("Actual:");
                    Utilities.PrettyPrintSquare(actual, test.Key);
                    Console.WriteLine("-------------");
                    Assert.Fail();
                }
            }

            //new Solver(2).Solve(), 

        }
    }
}
