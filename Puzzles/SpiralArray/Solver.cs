using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = System.Tuple<int, int>;

namespace Puzzles.SpiralArray
{
    public class Solver
    {
        #region Constructors
        public Solver(int rank, bool verbose = false)
        {
            if (rank <= 0)
            {
                throw new ArgumentException("rank must be larger than zero");
            }

            this.Rank = rank;
            this.Verbose = verbose;
        }
        #endregion

        #region Properties
        public bool Verbose { get; private set; }

        public int Rank { get; private set; }
        #endregion

        #region Methods
        public void Solve()
        {
            var result = this.Generate();
            PrettyPrint(result, this.Rank);
        }

        public static void PrettyPrint(int[,] result, int rank)
        {
            var padding = Convert.ToInt32(
                Math.Ceiling(
                    Math.Log10(rank * rank)));
            var format = string.Concat("D", padding);
            Func<int, string> formatter = number => string.Concat(number.ToString(format), " ");

            for (int row = 0; row < rank; row++)
            {
                for (int column = 0; column < rank; column++)
                {
                    Console.Write(formatter(result[row, column]));
                }

                Console.Write(Environment.NewLine);
            }
        }

        public static IEnumerable<Point> SpiralPath(int rank)
        {
            var result = Enumerable.Empty<Point>();
            int squareOrigin = 0;
            for (int successiveInnerRanks = rank; successiveInnerRanks > 0; successiveInnerRanks -= 2)
            {
                result = result.Concat(
                    OuterLoop(
                        successiveInnerRanks, Tuple.Create(squareOrigin, squareOrigin))
                    .Distinct());
                squareOrigin++;
            }

            return result;
        }

        public static IEnumerable<Point> OuterLoop(int rank, Tuple<int, int> origin = null)
        {
            origin = origin ?? Tuple.Create(0, 0);
            int row = origin.Item1;
            int column = origin.Item2;

            // Top-side
            for (; column < rank + origin.Item2 - 1; column++)
            {
                yield return Tuple.Create(row, column);
            }

            // Right-side
            for (; row < rank + origin.Item1 - 1; row++)
            {
                yield return Tuple.Create(row, column);
            }

            // Bottom-side
            for (; column > origin.Item2; column--)
            {
                yield return Tuple.Create(row, column);
            }

            // Left-side
            for (; row > origin.Item1; row--)
            {
                yield return Tuple.Create(row, column);
            }

            if (rank % 2 != 0)
            {
                yield return Tuple.Create(row, column);
            }
        }

        public int[,] Generate()
        {
            var result = new int[this.Rank, this.Rank];
            var currentValue = 1;
            Action<int, int> set = (row, column) =>
            {
                if (this.Verbose)
                    Console.WriteLine("rank {0} => ({1},{2})", this.Rank, row, column);
                result[row, column] = currentValue++;
            };

            foreach (var point in SpiralPath(this.Rank))
            {
                set(point.Item1, point.Item2);
            }

            return result;
        }
        #endregion
    }
}
