using System.Collections.Generic;

using AlgorithmsNDataStructures.SortingAlgorithms;

using Xunit;

namespace AlgorithmsNDataStructures.Tests.SortingAlgorithms
{
    public class InsertionSortTests : InsertionSort<int>
    {
        [Fact]
        public void Sort_ShouldSortArrayAsc()
        {
            var comparer = Comparer<int>.Default;
            var (inputList, expectedList) = TestDataForSortingContainer.GetDataAsc();

            DoSort(inputList, comparer);

            Assert.Equal(expectedList, inputList);
        }
    }
}