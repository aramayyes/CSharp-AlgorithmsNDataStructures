using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Represents the HeapSort sorting algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public class HeapSort<T> : BaseSorter<T>
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
        /// using the HeapSort algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected override void DoSort(IList<T> list, IComparer<T> comparer)
        {
            this.comparer = comparer;
            this.list = list;

            BuildHeap();

            int heapSize = list.Count;
            for (int i = heapSize - 1; i >= 0; i--)
            {
                // extract the root of the heap, as it's the "greatest" and move it to end
                T temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                // heapify the rest the list
                MaxHeapify(i, 0);
            }
        }

        /// <summary>
        /// Rearranges the elements of the <see cref="list"/> to get a heap.
        /// </summary>
        private void BuildHeap()
        {
            int heapSize = list.Count;
            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                MaxHeapify(heapSize, i);
            }
        }

        /// <summary>
        /// Rearranges the elements of the <see cref="list"/> to get a heap from the tree.
        /// </summary>
        /// <param name="heapSize">Size of the tree.</param>
        /// <param name="rootIndex">Index of the root element of the tree.</param>
        private void MaxHeapify(int heapSize, int rootIndex)
        {
            int largestIndex = rootIndex;
            int leftChildIndex = (2 * rootIndex) + 1;
            int rightChildIndex = (2 * rootIndex) + 2;

            if (leftChildIndex < heapSize && comparer.Compare(list[leftChildIndex], list[largestIndex]) > 0)
            {
                largestIndex = leftChildIndex;
            }

            if (rightChildIndex < heapSize && comparer.Compare(list[rightChildIndex], list[largestIndex]) > 0)
            {
                largestIndex = rightChildIndex;
            }

            if (largestIndex != rootIndex)
            {
                /*
                 * If one of the childs is greater than the root element,
                 * then swap the root with that child element. If both of the childs are greater
                 * than the root, then swap the root element with the "greatest" of them.
                 */
                T temp = list[rootIndex];
                list[rootIndex] = list[largestIndex];
                list[largestIndex] = temp;

                // recursively heapify the rest of the tree
                MaxHeapify(heapSize, largestIndex);
            }
        }
    }
}