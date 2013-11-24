using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    public static class Utilities
    {
        public static void PrettyPrintSquare(this int[,] result, int rank)
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

        public static void PrettyPrint<T>(this T[,] result)
        {
            Console.WriteLine(result.ToPrettyString());
        }

        public static string ToPrettyString<T>(this T[,] result)
        {
            Func<T, string> formatter = number => string.Concat(number, " ").PadLeft(3);
            var builder = new StringBuilder();
            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int column = 0; column < result.GetLength(1); column++)
                {
                    builder.Append(formatter(result[row, column]));
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
