using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Algebra
{
    /// <summary>
    /// Some functional goodies I have found useful
    /// </summary>
    public static class Functional
    {
        /// <summary>
        /// Recursively call a specified method
        /// </summary>
        /// <typeparam name="T">The argument and result type</typeparam>
        /// <param name="function">The function to chain</param>
        /// <param name="times">How many times to recursively call</param>
        /// <returns>A function whose evaluation chains recursive calls to the original</returns>
        public static Func<T, T> Chain<T>(this Func<T, T> function, int times)
        {
            return x => Enumerable.Range(1, times)
                .Aggregate(x, (state, current) => function(state));
        }
    }
}
