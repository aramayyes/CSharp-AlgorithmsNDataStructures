using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the InsertionSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class InsertionSort<T> : BaseSorter<T>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the InsertionSort algoithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected sealed override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            /*
             * Iterate over all elements and if the current element is "smaller"
             * than the previous one, then find the correct position for that element
             * within the sorted sublist consisting of all the previous items, move
             * all greater elements to right by one position, and the insert the current element
             * into the correct position.
             */
            for (int i = 1; i < list.Count; i++)
            {
                T key = list[i];

                int j = i - 1;
                while (j > -1 && comparer.Compare(list[j], key) > 0)
                {
                    list[j + 1] = list[j--];
                }

                list[j + 1] = key;
            }
        }
    }
}
