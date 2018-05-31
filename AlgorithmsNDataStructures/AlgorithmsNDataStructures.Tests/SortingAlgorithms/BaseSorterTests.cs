using System;
using System.Collections.Generic;

using AlgorithmsNDataStructures.SortingAlgorithms;
using AlgorithmsNDataStructures.Helpers;

using Xunit;

namespace AlgorithmsNDataStructures.Tests.SortingAlgorithms
{
    public class BaseSorterTests
    {
        [Fact]
        public void Sort_ShouldThrowIfInputListIsNull()
        {
            var baseSorter = new MockChildOfBaseSorter<int>();
            List<int> nullList = null;

            Assert.Throws<ArgumentNullException>("list", () => baseSorter.Sort(nullList, Comparer<int>.Default));
        }

        [Fact]
        public void Sort_ShouldThrowIfInputComparerIsNull()
        {
            var baseSorter = new MockChildOfBaseSorter<int>();
            var list = new List<int>();
            IComparer<int> comparer = null;

            Assert.Throws<ArgumentNullException>("comparer", () => baseSorter.Sort(list, comparer));
        }

        [Fact]
        public void Sort_ShouldNotModifyTheListIfZeroElement()
        {
            var baseSorter = new MockChildOfBaseSorter<int>();
            var list = new List<int>();

            baseSorter.Sort(list, Comparer<int>.Default);

            Assert.Empty(list);
        }

        [Fact]
        public void Sort_ShouldNotModifyTheListIfOneElement()
        {
            var baseSorter = new MockChildOfBaseSorter<int>();
            int theOnlyOneValue = 2;
            var list = new List<int>
            {
                theOnlyOneValue
            };

            baseSorter.Sort(list, Comparer<int>.Default);

            Assert.Single(list);
            Assert.Equal(theOnlyOneValue, list[0]);
        }

        public class ExtensionMethods
        {
            [Fact]
            public void SortExtension_ShouldThrowIfInputListIsNull()
            {
                var baseSorter = new MockChildOfBaseSorter<int>();
                List<int> nullList = null;

                Assert.Throws<ArgumentNullException>("list", () => baseSorter.Sort(nullList, (x, y) => x - y));
            }

            [Fact]
            public void SortExtension_ShouldThrowIfInputComparisonIsNull()
            {
                var baseSorter = new MockChildOfBaseSorter<int>();
                var list = new List<int>();
                Comparison<int> comparison = null;

                Assert.Throws<ArgumentNullException>("comparison", () => baseSorter.Sort(list, comparison));
            }
        }

        private class MockChildOfBaseSorter<T> : BaseSorter<T>
        {
            protected override void DoSort(IList<T> list, IComparer<T> comparer)
            {
                return;
            }
        }
    }
}