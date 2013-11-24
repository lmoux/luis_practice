using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.ArrayRotation
{
    public class Solver
    {
        public static T[,] GenerateRotation<T>(T[,] original)
        {
            return new Algebra.Matrix2d<T>(original)
                .GenerateClockwiseRotation();
        }

        public static T[,] GenerateTranspose<T>(T[,] original)
        {
            return new Algebra.Matrix2d<T>(original)
                .GenerateTranspose();
        }
    }
}
