using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzles.Sorting
{
    public static class Solver
    {
        public static class InPlace
        {
            /// <summary>
            /// Sorts in ascending order by comparing adjacent elements
            /// </summary>
            /// <param name="collection">Collection to sort in place</param>
            public static void BubbleSort(IList<int> collection)
            {
                while (true)
                {
                    bool isSorted = true;
                    for (int i = 0; i < collection.Count - 1; i++)
                    {
                        for (int j = i + 1; j < collection.Count; j++)
                        {
                            if (collection[i] > collection[j])
                            {
                                Swap(collection, i, j);
                                isSorted = false;
                            }
                        }
                    }

                    if (isSorted) break;
                }
            }

            /// <summary>
            /// Sorts in ascending order by comparing adjacent elements
            /// </summary>
            /// <param name="collection">Collection to sort in place</param>
            public static void BubbleSortAnotherApproach(IList<int> collection)
            {
                // The invariant here is that at every pass, anything after the upper bound is sorted
                // That is, the collection is ordered from the right and it propagates one step at a time
                // till the whole collection is ordered
                var upperBound = collection.Count;
                while (upperBound > 0)
                {
                    for (int i = 0; i < upperBound - 1; i++)
                    {
                        var j = i + 1;
                        if (collection[i] > collection[j])
                        {
                            Swap(collection, i, j);
                        }
                    }

                    upperBound--;
                }
            }

            private static void Swap(IList<int> collection, int firstIndex, int secondIndex)
            {
                var temporary = collection[secondIndex];
                collection[secondIndex] = collection[firstIndex];
                collection[firstIndex] = temporary;
            }
        }
    }
}
