namespace Puzzles
{
    /// <summary>
    /// Puzzles shall implement this interface to be picked up
    /// </summary>
    public interface IPuzzle
    {
        /// <summary>
        /// Getrs the identity of the puzzle
        /// </summary>
        Puzzles.DomainModel.Puzzle.Identifier Id { get; }

        /// <summary>
        /// Runs the puzzle
        /// </summary>
        void Run();
    }
}
