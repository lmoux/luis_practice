using Puzzles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Sorting
{
    [Export(typeof(IPuzzle))]
    public class Puzzle: IPuzzle
    {
        #region Properties
        public PuzzleNature Kind
        {
            get { return PuzzleNature.Algorithm; }
        }

        public string Title
        {
            get { return "Sort a collection of numbers"; }
        }

        public string Description
        {
            get
            {
                return "Order ascendingly a collection of numbers without relying on framework implementations for sorting.";
            }
        }
        #endregion

        #region Methods
        public void Run()
        {
            Console.WriteLine("Put numbers to sort in the following separated by spaces");
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select( x =>
                    {
                        int number;
                        var include = int.TryParse(x, out number);
                        return new { Include = include, Number = number };
                    })
                .Where(x => x.Include)
                .Select(x => x.Number)
                .ToList();

            Console.WriteLine("Sorted: ");
            Solver.InPlace.BubbleSort(numbers);
            foreach(int number in numbers)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }
        #endregion
    }
}
