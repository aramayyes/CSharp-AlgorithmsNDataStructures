using System;
using System.Collections.Generic;

using AlgorithmsNDataStructures.Helpers;
using AlgorithmsNDataStructures.SortingAlgorithms;

namespace ConsoleTesterApp
{
    /// <summary>
    /// Contains the Main method.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        public static void Main()
        {
            var intArr = new[] { 1, 4, 32, 322, -70, 5, 87, 67, 3, 6, 43, 8, 46, 57 };

            Console.WriteLine("Before sorting:");
            Console.WriteLine(string.Join(", ", intArr));
            Console.WriteLine();

            ISorter<int> sorter = new QuickSort<int>();
            sorter.Sort(intArr, Comparer<int>.Default);

            Console.WriteLine("After sorting:");
            Console.WriteLine(string.Join(", ", intArr));

            Console.Read();
        }
    }
}
