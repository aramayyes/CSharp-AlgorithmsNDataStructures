using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the SelectionSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class SelectionSort<T> : BaseSorter<T>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the SelectionSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count; i++)
            {
                /*
                 * Find the minimum element in the sublist consisting of all the other next elements
                 * and swap the current element with the found minimum element.
                 */
                int smallestIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (comparer.Compare(list[j], list[smallestIndex]) < 0)
                    {
                        smallestIndex = j;
                    }
                }

                T temp = list[smallestIndex];
                list[smallestIndex] = list[i];
                list[i] = temp;
            }
        }
    }
}