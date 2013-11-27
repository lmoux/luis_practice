using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var importer = PluginImporter.Import();
            var puzzles = (importer.KnownPuzzles ?? Enumerable.Empty<IPuzzle>()).ToList();

            Console.WriteLine("Found a total of {0} puzzles:", puzzles.Count);
            for (int puzzleIndex = 0; puzzleIndex < puzzles.Count; puzzleIndex++)
            {
                var puzzle = puzzles[puzzleIndex];
                Console.WriteLine("ID: {0}", puzzleIndex);
                Console.WriteLine(puzzle.Id);
            }

            if (puzzles.Count == 0)
                return;

            while (true)
            {
                Console.WriteLine("Choose one of the puzzle IDs [0-{0}]", puzzles.Count-1);
                Console.WriteLine("Alternatively, to exit, either press Ctrl-C or type Exit and press <Enter>");
                Console.WriteLine();

                int targetPuzzle;
                var input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input) || string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                    return;

                if (!int.TryParse(input, out targetPuzzle) || !(targetPuzzle < puzzles.Count && targetPuzzle >= 0))
                {
                    Console.Error.WriteLine("Expected a number between 0 and {0}", puzzles.Count);
                    continue;
                }

                puzzles[targetPuzzle].Run();
                Console.WriteLine("--------------------------Finished-----------------------------------");
            }
        }
    }
}
