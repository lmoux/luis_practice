using Puzzles;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Puzzles.DomainModel.Puzzle;

namespace Puzzles.Sorting
{
    [Export(typeof(IPuzzle))]
    public class Puzzle : IPuzzle
    {
        #region Fields
        private static readonly Domain.Identifier id;
        #endregion

        #region Constructors
        static Puzzle()
        {
            var bigoh = new DomainModel.BigOh("N^2");
            var description = DomainModel.Algorithms.Description.NewSorting(true, bigoh, bigoh);
            var algorithm = new DomainModel.Algorithms.Algorithm("Bubble sort", description);
            id = Domain.Identifier.NewAlgorithm(algorithm);
        }
        #endregion

        #region Properties
        public DomainModel.Puzzle.Identifier Id
        {
            get { return id; }
        }
        #endregion

        #region Methods
        public void Run()
        {
            Console.WriteLine("Put numbers to sort in the following separated by spaces");
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
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
            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }
        #endregion
    }
}
