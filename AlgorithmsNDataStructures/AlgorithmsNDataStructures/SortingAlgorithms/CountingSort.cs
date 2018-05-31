using System;
using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the CountingSort sorting algorithm.
    /// </summary>
    public class CountingSort : BaseSorter<int>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the CountingSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.
        /// This argument is ignored regardless of the given value.
        /// </param>
        protected override void DoSort(IList<int> list, IComparer<int> comparer)
        {
            const int Range = 255;

            // count and store the number of occurences of each element in the input list
            var counts = new int[Range];
            for (int i = 0; i < list.Count; i++)
            {
                var index = list[i];
                if (index < 0 || index > Range)
                {
                    throw new ArgumentException("The elements of the list must be between 0 and 255.", nameof(list));
                }

                ++counts[list[i]];
            }

            /*
             * Perform a prefix sum computation to determine, for each key, the starting
             * position in the output list.
             */
            for (int i = 1; i < Range; i++)
            {
                counts[i] += counts[i - 1];
            }

            // build the output list
            var outputs = new int[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                outputs[counts[list[i]] - 1] = list[i];
                --counts[list[i]];
            }

            // copy the elements from the output list to the initial list
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = outputs[i];
            }
        }
    }
}