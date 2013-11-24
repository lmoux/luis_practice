using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.TowersOfHanoi
{
    [Export(typeof(IPuzzle))]
    public class Puzzle : IPuzzle
    {
        #region Fields
        private const string description = @"
It consists of three rods, and a number of disks of different sizes which can slide onto any rod. The puzzle starts with the disks in a neat stack in ascending order of size on one rod, the smallest at the top, thus making a conical shape.
The objective of the puzzle is to move the entire stack to another rod, obeying the following simple rules:
1. Only one disk may be moved at a time.
2. Each move consists of taking the upper disk from one of the stacks and placing it on top of another stack.
3. No disk may be placed on top of a smaller disk.
With three disks, the puzzle can be solved in seven moves. The minimum number of moves required to solve a Tower of Hanoi puzzle is 2n - 1, where n is the number of disks.
(from Wikipedia)
";
        #endregion

        #region Properties
        public PuzzleNature Kind { get { return PuzzleNature.Mathematical; } }

        public string Title { get { return "Towers of Hanoi"; } }

        public string Description { get { return description; } }
        #endregion

        #region Methods
        public void Run()
        {
            Console.WriteLine("How many disks?");
            var input = Console.ReadLine().Trim();
            int numberOfDisks;
            if (int.TryParse(input, out numberOfDisks) && numberOfDisks >= 0 && numberOfDisks <= TowersOfHanoi.Solver.MaximumSize)
            {
                new TowersOfHanoi
                    .Solver(numberOfDisks)
                    .Solve();
            }
            else 
            {
                Console.Error.WriteLine("Expected a positive number up to {0}", TowersOfHanoi.Solver.MaximumSize);
            }
        }
        #endregion
    }
}
