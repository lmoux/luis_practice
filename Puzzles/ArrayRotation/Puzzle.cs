using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.ArrayRotation
{
    [Export(typeof(IPuzzle))]
    public class Puzzle : IPuzzle
    {
        public PuzzleNature Kind
        {
            get { return PuzzleNature.Mathematical; }
        }

        public string Title
        {
            get { return "Rotates 2-dimensional arrays"; }
        }

        public string Description
        {
            get { return this.Title; }
        }

        public void Run()
        {
            var rows = new List<List<int>>();
            var maxColumns = int.MinValue;

            Console.WriteLine("Input array, one row at a time, using space or tabs as delimiter");
            Console.WriteLine("Leave line empty to trigger transpose");
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                var nextRow = new List<int>();
                foreach (var prospect in input.Split(new char[] { '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    int element = default(int);
                    int.TryParse(prospect, out element);
                    nextRow.Add(element);
                }

                maxColumns = maxColumns < nextRow.Count ? nextRow.Count : maxColumns;
                rows.Add(nextRow);
            }

            var actualArray = new int[rows.Count, maxColumns];
            for (var rowIndex = 0; rowIndex < rows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < rows[rowIndex].Count; columnIndex++)
                {
                    actualArray[rowIndex, columnIndex] = rows[rowIndex][columnIndex];
                }
            }

            Console.WriteLine("Original array");
            actualArray.PrettyPrint();
            Console.WriteLine();
            Console.WriteLine("Transposed array");
            Solver.GenerateTranspose(actualArray)
                .PrettyPrint();
            Console.WriteLine();
            Console.WriteLine("Fully rotated array");
            Solver.GenerateRotation(actualArray)
                .PrettyPrint();
        }

    }
}
