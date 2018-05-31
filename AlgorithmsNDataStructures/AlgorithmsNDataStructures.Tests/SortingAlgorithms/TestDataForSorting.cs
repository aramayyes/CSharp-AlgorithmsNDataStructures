using System.Collections.Generic;

namespace AlgorithmsNDataStructures.Tests.SortingAlgorithms
{
    static class TestDataForSortingContainer
    {
        public static (List<int>, List<int>) GetDataAsc()
        {
            return
            (
            new List<int>
            {
                4,787,74,-80,26,5,44,-2,1048,23,0,94,153,256,-475,98,-2015,11,35,-99
            },
            new List<int>
            {
                -2015,-475,-99,-80,-2,0,4,5,11,23,26,35,44,74,94,98,153,256,787,1048
            }
            );
        }

        public static (List<int>, List<int>) GetDataDesc()
        {
            return
            (
            new List<int>
            {
                4,787,74,-80,26,5,44,-2,1048,23,0,94,153,256,-475,98,-2015,11,35,-99
            },
            new List<int>
            {
                1048,787,256,153,98,94,74,44,35,26,23,11,5,4,0,-2,-80,-99,-475,-2015
            }
            );
        }

        public static (List<int>, List<int>) GetSmallDataAsc()
        {
            return
            (
            new List<int>
            {
                4,78,74,81,26,5,44,3,108,23,0,94,153,216,45,98,201,11,35,99
            },
            new List<int>
            {
                0,3,4,5,11,23,26,35,44,45,74,78,81,94,98,99,108,153,201,216
            }
            );
        }

        public static (List<int>, List<int>) GetSmallDataDesc()
        {
            return
            (
            new List<int>
            {
                4,78,74,81,26,5,44,3,108,23,0,94,153,216,45,98,201,11,35,99
            },
            new List<int>
            {
                216,201,153,108,99,98,94,81,78,74,45,44,35,26,23,11,5,4,3,0
            }
            );
        }
    }

}
