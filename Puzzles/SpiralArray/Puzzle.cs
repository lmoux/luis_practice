using Puzzles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Puzzles.DomainModel.Puzzle;

namespace Puzzles.SpiralArray
{
    [Export(typeof(IPuzzle))]
    public class Puzzle : IPuzzle
    {
        private static readonly Domain.Identifier id = Domain.Identifier.NewGeneralLogic("Spiral NxN array", description);
 
        private const string description = @"
Generate an NxN square matrix on which elements are arrainged in spiral order such as:
For N = 3:
    01 02 03
    08 09 04
    07 06 05

For N = 4
    01 02 03 04
    12 13 14 05
    11 16 15 06
    10 09 08 07

For N = 5
    01 02 03 04 05
    16 17 18 09 06
    15 24 25 20 07
    14 23 22 21 08
    13 12 11 10 09
";

        public Domain.Identifier Id { get { return id; } }

        public void Run()
        {
            Console.WriteLine("How many columns?");
            var input = Console.ReadLine().Trim();
            int numberOfColumns;
            if (int.TryParse(input, out numberOfColumns))
            {
                new SpiralArray
                    .Solver(numberOfColumns)
                    .Solve();
            }
            else
            {
                Console.Error.WriteLine("Expected a positive number");
            }
        }
    }
}
