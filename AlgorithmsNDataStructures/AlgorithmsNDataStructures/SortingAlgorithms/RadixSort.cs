using System;
using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the RadixSort sorting algorithm.
    /// </summary>
    public class RadixSort : BaseSorter<int>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the RadixSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.
        /// This argument is ignored regardless of the given value.
        /// </param>
        protected override void DoSort(IList<int> list, IComparer<int> comparer)
        {
            var buckets = new Queue<int>[10];

            int power = 1;
            int maxElement = list[GetMaxIndex(list)];
            while (power <= maxElement)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] < 0)
                    {
                        throw new ArgumentException("The elements of the list must be greater than 0.", nameof(list));
                    }

                    // find the current digit.
                    int digit = (list[i] / power) % 10;

                    if (buckets[digit] == null)
                    {
                        buckets[digit] = new Queue<int>();
                    }

                    // add the current element to te correct bucket
                    buckets[digit].Enqueue(list[i]);
                }

                // move all the elements from the buckets to the initial list.
                int listIndex = 0;
                for (int k = 0; k < buckets.Length; k++)
                {
                    var bucket = buckets[k];
                    if (bucket != null)
                    {
                        for (int i = bucket.Count; i > 0; i--)
                        {
                            list[listIndex++] = bucket.Dequeue();
                        }
                    }
                }

                power *= 10;
            }
        }

        /// <summary>
        /// Gets the index of the max element in the given list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <returns>Index of the max element.</returns>
        private int GetMaxIndex(IList<int> list)
        {
            int maxIndex = 0;
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (list[i] > list[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}