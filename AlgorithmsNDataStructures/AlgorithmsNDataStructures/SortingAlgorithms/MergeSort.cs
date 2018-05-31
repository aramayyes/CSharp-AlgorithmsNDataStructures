using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the MergeSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class MergeSort<T> : BaseSorter<T>
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
        /// using the MergeSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.list = list;
            RecursiveMergeSort(0, list.Count - 1);
        }

        /// <summary>
        /// Sorts the selected part of the <see cref="list"/> using MergeSort algorithm.
        /// </summary>
        /// <param name="leftIndex">First index of the selected part.</param>
        /// <param name="rightIndex">Last index of the selected part.</param>
        private void RecursiveMergeSort(int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex)
            {
                return;
            }

            int middleIndex = (leftIndex + rightIndex) / 2;

            /*
             * Sort the left and right parts of the list, and then merge them.
             */
            RecursiveMergeSort(leftIndex, middleIndex);
            RecursiveMergeSort(middleIndex + 1, rightIndex);
            Merge(leftIndex, middleIndex, rightIndex);
        }

        /// <summary>
        /// Merges two parts of the <see cref="list"/>.
        /// </summary>
        /// <param name="leftIndex">First index of the first part.</param>
        /// <param name="middleIndex">Last index of the first part.</param>
        /// <param name="rightIndex">Last index of the second part.</param>
        private void Merge(int leftIndex, int middleIndex, int rightIndex)
        {
            T[] tempArray = new T[rightIndex - leftIndex + 1];

            int firstIndex = leftIndex;
            int secondIndex = middleIndex + 1;
            for (int k = 0; k < (rightIndex - leftIndex + 1); k++)
            {
                /*
                 * Copy the elements from the left and right parts of the list to a temporary array.
                 * The current item of that array is the "smallest" of the two elements from the
                 * left and right parts.
                 */
                if (firstIndex <= middleIndex && secondIndex <= rightIndex)
                {
                    if (comparer.Compare(list[firstIndex], list[secondIndex]) <= 0)
                    {
                        tempArray[k] = list[firstIndex++];
                    }
                    else
                    {
                        tempArray[k] = list[secondIndex++];
                    }
                }
                else if (firstIndex <= middleIndex)
                {
                    tempArray[k] = list[firstIndex++];
                }
                else if (secondIndex <= rightIndex)
                {
                    tempArray[k] = list[secondIndex++];
                }
            }

            // copy the sorted elements from the temporary array to the initial list
            for (int i = leftIndex; i <= rightIndex; i++)
            {
                list[i] = tempArray[i - leftIndex];
            }
        }
    }
}