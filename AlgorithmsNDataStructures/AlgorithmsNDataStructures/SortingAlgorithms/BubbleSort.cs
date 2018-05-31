using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the BubbleSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class BubbleSort<T> : BaseSorter<T>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the BubbleSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1 - i; j++)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
        }
    }
}