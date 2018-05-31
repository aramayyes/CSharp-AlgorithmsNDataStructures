using System;
using System.Collections.Generic;

using AlgorithmsNDataStructures.SortingAlgorithms;

using Xunit;

namespace AlgorithmsNDataStructures.Tests.SortingAlgorithms
{
    public class RadixSortTests : RadixSort
    {
        [Fact]
        public void Sort_ShouldSortSimpleArray()
        {
            var comparer = Comparer<int>.Default;
            var (inputList, expectedList) = TestDataForSortingContainer.GetSmallDataAsc();

            DoSort(inputList, comparer);

            Assert.Equal(expectedList, inputList);
        }

        [Fact]
        public void Sort_ShouldFailIfElementsAreNegative()
        {
            var comparer = Comparer<int>.Default;
            var (inputList, expectedList) = TestDataForSortingContainer.GetDataAsc();

            Assert.Throws<ArgumentException>("list", () => DoSort(inputList, comparer));
        }
    }
}