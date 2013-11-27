using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.TowersOfHanoi
{
    /// <summary>
    /// Solves the Towers of Hanoi puzzle for three rods and arbitrary number of disks
    /// </summary>
    public class Solver
    {
        #region Fields
        /// <summary>
        /// The maximum number of disks we can currently solve
        /// </summay>
        public const int MaximumSize = 32;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Solver"/> class
        /// </summary>
        /// <param name="numberOfDisks">How many disks to simulate</param>
        public Solver(int numberOfDisks)
        {
            if (numberOfDisks > MaximumSize)
                new ArgumentException(
                    string.Format("The data structures we used can handle up to {0} disks", MaximumSize));

            this.NumberOfDisks = numberOfDisks;
        }
        #endregion

        #region Properties
        public int NumberOfDisks { get; private set; }
        public int TotalMoves { get; private set; }
        public int TheoreticalMinimum { get { return Convert.ToInt32(Math.Pow(2, this.NumberOfDisks) - 1); } }
        #endregion

        #region Methods
        public void Solve()
        {
            Console.WriteLine("Theoretical minimum of moves: {0}", this.TheoreticalMinimum);
            this.Move(this.NumberOfDisks, 1, 3, 2);
            Console.WriteLine("Total moves: {0}", this.TotalMoves);
        }

        /// <summary>
        /// Performs the basic operation of moving a number of disks to a rod utilizing a proxy rod
        /// </summary>
        /// <param name="numberOfDisks">The number of disks to move</param>
        /// <param name="fromRod">The originating rod</param>
        /// <param name="toRod">The target rod</param>
        /// <param name="viaRod">The proxy rod</param>
        private void Move(int numberOfDisks, int fromRod, int toRod, int viaRod)
        {
            if (numberOfDisks > 0)
            {
                Move(numberOfDisks - 1, fromRod, viaRod, toRod);
                Console.WriteLine("Move disk from pole #{0} to #{1}", fromRod, toRod);
                this.TotalMoves++;
                Move(numberOfDisks - 1, viaRod, toRod, fromRod);
            }
        }
        #endregion
    }
}
