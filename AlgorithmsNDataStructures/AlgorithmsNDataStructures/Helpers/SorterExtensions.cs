using System;
using System.Collections.Generic;

using AlgorithmsNDataStructures.SortingAlgorithms;

namespace AlgorithmsNDataStructures.Helpers
{
    /// <summary>
    /// Contains extension methods for types that implement <see cref="ISorter{T}"/>.
    /// </summary>
    public static class SorterExtensions
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the given <see cref="Comparison{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the list.</typeparam>
        /// <param name="sorter">The object that implements <see cref="ISorter{T}"/>.</param>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparison">The Comparison`1 to use when comparing elements.</param>
        public static void Sort<T>(this ISorter<T> sorter, IList<T> list, Comparison<T> comparison)
        {
            if (sorter == null)
            {
                throw new ArgumentNullException(nameof(sorter));
            }

            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }

            sorter.Sort(list, Comparer<T>.Create(comparison));
        }
    }
}
