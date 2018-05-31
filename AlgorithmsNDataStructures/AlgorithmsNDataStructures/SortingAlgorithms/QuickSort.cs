using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the QuickSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class QuickSort<T> : BaseSorter<T>
    {
        /// <summary>
        /// Holds the elements that should be sorted.
        /// </summary>
        private IList<T> list;

        /// <summary>
        /// This comparer is used to compare the elements of the <see cref="list"/>.
        /// </summary>
        private IComparer<T> comparer;

        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the QuickSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            this.list = list;
            this.comparer = comparer;

            RecursiveQuickSort(0, this.list.Count - 1);
        }

        /// <summary>
        /// Sorts the selected part of the <see cref="list"/> using QuickSort algorithm.
        /// </summary>
        /// <param name="leftIndex">First index of the selected part.</param>
        /// <param name="rightIndex">Last index of the selected part.</param>
        private void RecursiveQuickSort(int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            /*
             * Reorder the array so that all elements with values less than a certain element (pivot)
             * come before that element, and all the elements with values greater than the pivot
             * come after it. Then recursively sort the left and right parts of the list got after
             * partition.
             */
            int resultIndex = Partition(leftIndex, rightIndex);
            RecursiveQuickSort(leftIndex, resultIndex - 1);
            RecursiveQuickSort(resultIndex + 1, rightIndex);
        }

        /// <summary>
        /// Rearranges the selected part of the array so that the smaller elements than the pivot
        /// are placed before the pivot and the greater elements are placed after the pivot element.
        /// As the pivot is taken the last element.
        /// </summary>
        /// <param name="leftIndex">First index of the selected part.</param>
        /// <param name="rightIndex">Last index of the selected part.</param>
        /// <returns>The new index of the pivot element.</returns>
        private int Partition(int leftIndex, int rightIndex)
        {
            T pivot = list[rightIndex];
            int greaterGroupLeftmostIndex = leftIndex;
            for (int i = leftIndex; i < rightIndex; i++)
            {
                /*
                 * If the current element is "smaller" than the pivot, then move that element
                 * to the 'SmallerGroup'. This can be done by swapping the current element with
                 * the leftmost element of the 'GreaterGroup'.
                 */
                if (comparer.Compare(list[i], pivot) <= 0)
                {
                    T temp1 = list[greaterGroupLeftmostIndex];
                    list[greaterGroupLeftmostIndex] = list[i];
                    list[i] = temp1;

                    greaterGroupLeftmostIndex++;
                }
            }

            // move the pivot element to the correct position
            T temp2 = list[greaterGroupLeftmostIndex];
            list[greaterGroupLeftmostIndex] = list[rightIndex];
            list[rightIndex] = temp2;

            return greaterGroupLeftmostIndex;
        }
    }
}