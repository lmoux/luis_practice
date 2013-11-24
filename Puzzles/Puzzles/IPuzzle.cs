namespace Puzzles
{
    /// <summary>
    /// Puzzles shall implement this interface to be picked up
    /// </summary>
    public interface IPuzzle
    {
        /// <summary>
        /// Gets what kind of puzzle we are dealing with
        /// </summary>
        PuzzleNature Kind { get; }

        /// <summary>
        /// The name of the puzzle
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Describes the puzzle including the rules
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Runs the puzzle
        /// </summary>
        void Run();
    }
}
