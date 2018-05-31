using System.Collections.Generic;

namespace AlgorithmsNDataStructures.SortingAlgorithms
{
    /// <summary>
    /// Exposes methods that sorts the given <see cref="IList{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the list.</typeparam>
    public interface ISorter<T>
    {
        /// <summary>
        /// Sorts the elements in the entire <paramref name="list"/>
        /// using the given comparer or the default comparer if the former is null.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">
        /// The IComparer`1 generic interface
        /// implementation to use when comparing elements.
        /// </param>
        void Sort(IList<T> list, IComparer<T> comparer);
    }
}
