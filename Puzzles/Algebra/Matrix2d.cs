using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Algebra
{
    /// <summary>
    /// A wrapper for two dimensional arrays such that we can treat them as 2d matrices
    /// </summary>
    /// <typeparam name="T">The type of the  matrix elements</typeparam>
    public class Matrix2d<T>
    {
        #region Fields
        /// <summary>
        /// The original array representation
        /// </summary>
        private readonly T[,] original;

        /// <summary>
        /// How many columns
        /// </summary>
        private readonly int rank;

        /// <summary>
        /// How many rows
        /// </summary>
        private readonly int domain;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix2d{T}"/> class
        /// </summary>
        /// <param name="arrayRepresentation">The memory representation to use</param>
        public Matrix2d(T[,] arrayRepresentation)
        {
            // TODO: LMD, 20131124> Start using guard class (either our own or one from Nuget)
            if (arrayRepresentation == null)
                throw new ArgumentNullException("arrayRepresentation");

            this.original = arrayRepresentation;
            this.rank = arrayRepresentation.GetLength(1);
            this.domain = arrayRepresentation.GetLength(0);
        }
        #endregion

        #region Properties
        public int Domain { get { return this.domain; } }
        public int Rank { get { return this.rank; } }

        /// <summary>
        /// Access members
        /// </summary>
        /// <param name="row">The abscissa coordinate</param>
        /// <param name="column">The ordinate coordinate</param>
        /// <returns>The value at that coordinates</returns>
        public T this[int row, int column]
        {
            get
            {
                Contract.Requires(row >= 0 && row < this.Domain);
                Contract.Requires(column >= 0 && column < this.Rank);

                return this.original[row, column];
            }
        }

        /// <summary>
        /// Access members
        /// </summary>
        /// <param name="coordinates">Coordinates for abcissa and ordinate</param>
        /// <returns>The value at that coordinates</returns>
        public T this[Tuple<int, int> coordinates]
        {
            get
            {
                Contract.Requires(coordinates.Item1 >= 0 && coordinates.Item1 < this.Domain);
                Contract.Requires(coordinates.Item2 >= 0 && coordinates.Item2 < this.Rank);

                return this.original[coordinates.Item1, coordinates.Item2];
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates the path of points to visit all elements of 2-d matrix
        /// </summary>
        /// <typeparam name="T">The type matrix elements</typeparam>
        /// <param name="matrix">The matrix per se</param>
        /// <returns>A path that if followed would take through each column on each row</returns>
        public IEnumerable<Tuple<int, int>> VisitorPath()
        {
            for (int column = 0; column < this.rank; column++)
            {
                for (int row = 0; row < this.domain; row++)
                {
                    yield return Tuple.Create(row, column);
                }
            }
        }

        public IEnumerable<T> ValueVisitor()
        {
            foreach (var point in this.VisitorPath())
            {
                yield return this.original[point.Item1, point.Item2];
            }
        }

        public void Visitor(Action<int, int, T> observer)
        {
            if (observer == null)
                throw new ArgumentNullException("observer");

            foreach (var point in this.VisitorPath())
            {
                observer(point.Item1, point.Item2, this[point]);
            }
        }

        public override string ToString()
        {
            return Utilities.ToPrettyString(this.original);
        }

        public T[,] GenerateClockwiseRotation()
        {
            var result = new T[this.rank, this.domain];

            Action<int, int, T> tranposeAndReverseOrderWithinRow =
                (row, column, elementValue) =>
                {
                    result[column, this.domain - row - 1] = elementValue;
                };

            this.Visitor(tranposeAndReverseOrderWithinRow);

            return result;
        }

        public T[,] GenerateTranspose()
        {
            var result = new T[this.rank, this.domain];

            Action<int, int, T> transposer =
                (row, column, elementValue) =>
                {
                    result[column, row] = elementValue;
                };

            this.Visitor(transposer);

            return result;
        }
        #endregion
    }
}
