using System;
using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Provides base functionality for types that implement <see cref="ISorter{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public abstract class BaseSorter<T> : ISorter<T>
    {
        /// <inheritdoc/>
        /// <see cref="ISorter{T}.Sort(IList{T}, IComparer{T})"/>
        public void Sort(IList<T> list, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            if (list.Count < 2)
            {
                return;
            }

            DoSort(list, comparer);
        }

        /// <summary>
        /// Here is where the actual sorting is done.
        /// Each derived class implements this method using the corresponding sorting algorithm.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The IComparer`1 generic interface implementation to use when comparing elements.</param>
        protected abstract void DoSort(IList<T> list, IComparer<T> comparer);
    }
}