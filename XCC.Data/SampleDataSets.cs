using System;

namespace XCC.Data
{
    /// <summary>
    /// Sample data sets for unit-testing or UI demos.
    /// </summary>
    public static class SampleDataSets
    {
        /// <summary>
        /// Max possible cost for a traversal path
        /// </summary>
        public static int MaxCost = 50;

        public static DataSet Sample1 = new DataSet
        {
            Input = @"3 4 1 2 8 6
6 1 8 2 7 4
5 9 3 9 9 5
8 4 1 3 2 6
3 7 2 8 6 4",
            MappedCostValues = new int[,] {
                { 3, 4, 1, 2, 8, 6 },
                { 6, 1, 8, 2, 7, 4 },
                { 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6 },
                { 3, 7, 2, 8, 6, 4 }
            },
            IsPathAvailable = true,
            TotalCost = 16,
            PathRowIndices = new int[] { 1, 2, 3, 4, 4, 5 }
        };

        public static DataSet Sample2 = new DataSet
        {
            Input = @"3 4 1 2 8 6
6 1 8 2 7 4
5 9 3 9 9 5
8 4 1 3 2 6
3 7 2 1 2 3",
            MappedCostValues = new int[,] {
                { 3, 4, 1, 2, 8, 6 },
                { 6, 1, 8, 2, 7, 4 },
                { 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6 },
                { 3, 7, 2, 1, 2, 3 }
            },
            IsPathAvailable = true,
            TotalCost = 11,
            PathRowIndices = new int[] { 1, 2, 1, 5, 4, 5 }
        };

        public static DataSet Sample3 = new DataSet
        {
            Input = @"19 10 19 10 19
21 23 20 19 12
20 12 20 11 10",
            MappedCostValues = new int[,] {
                { 19, 10, 19, 10, 19 },
                { 21, 23, 20, 19, 12 },
                { 20, 12, 20, 11, 10 }
            },
            IsPathAvailable = false,
            TotalCost = 48,
            PathRowIndices = new int[] { 1, 1, 1 }
        };

        public static DataSet Sample4 = new DataSet
        {
            Input = @"5 8 5 3 5",
            MappedCostValues = new int[,] {
                { 5, 8, 5, 3, 5}
            },
            IsPathAvailable = true,
            TotalCost = 26,
            PathRowIndices = new int[] { 1, 1, 1, 1, 1 }
        };

        public static DataSet Sample5 = new DataSet
        {
            Input = @"5
8
5
3
5",
            MappedCostValues = new int[,] { { 5 }, { 8 }, { 5 }, { 3 }, { 5 } },
            IsPathAvailable = true,
            TotalCost = 3,
            PathRowIndices = new int[] { 4 }
        };

        public static DataSet Sample6 = new DataSet
        {
            Input = @"3",
            MappedCostValues = new int[,] { { 3 } },
            IsPathAvailable = true,
            TotalCost = 3,
            PathRowIndices = new int[] { 1 }
        };

        public static DataSet Sample7 = new DataSet
        {
            Input = @"5 4 H
8 M 7
5 7 5",
            MappedCostValues = new int[,] { { } },
        };

        public static DataSet Sample8 = new DataSet
        {
            Input = @"69 10 19 10 19
51 23 20 19 12
60 12 20 11 10",
            MappedCostValues = new int[,] {
                { 69, 10, 19, 10, 19 },
                { 51, 23, 20, 19, 12 },
                { 60, 12, 20, 11, 10 }
            },
            IsPathAvailable = false,
            TotalCost = 0,
            PathRowIndices = new int[] { }
        };

        public static DataSet Sample9 = new DataSet
        {
            Input = @"60 3 3 6
6 3 7 9
5 6 8 3",
            MappedCostValues = new int[,] {
                { 60, 3, 3, 6 },
                { 6, 3, 7, 9 },
                { 5, 6, 8, 3 }
            },
            IsPathAvailable = true,
            TotalCost = 14,
            PathRowIndices = new int[] { 3, 2, 1, 3 }
        };

        public static DataSet Sample10 = new DataSet
        {
            Input = @"6,3,-5,9
            -5,2,4,10
3,-2,6,10
6,-1,-2,10",
            MappedCostValues = new int[,] {
                { 6, 3, -5, 9 },
                {-5, 2, 4, 10 },
                { 3, -2, 6, 10 },
                { 6, -1, -2, 10 }
            },
            IsPathAvailable = true,
            TotalCost = 0,
            PathRowIndices = new int[] { 2, 3, 4, 1 }
        };

        public static DataSet Sample11 = new DataSet
        {
            Input = @"51 51
0 51
51 51
5 5",
            MappedCostValues = new int[,] {
                { 51, 51},
                { 0, 51},
                { 51, 51},
                {  5, 5}
            },
            IsPathAvailable = true,
            TotalCost = 10,
            PathRowIndices = new int[] { 4, 4 }
        };


        public static DataSet Sample12 = new DataSet
        {
            Input = @"51 51 51
0 51 51
51 51 51
5 5 51",
            MappedCostValues = new int[,] {
                { 51, 51, 51},
                { 0, 51, 51},
                { 51, 51, 51},
                { 5, 5, 51}
            },
            IsPathAvailable = false,
            TotalCost = 10,
            PathRowIndices = new int[] { 4, 4 }
        };

        public static DataSet Sample13 = new DataSet
        {
            Input = @"1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2 2",
            MappedCostValues = new int[,] {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}
            },
            IsPathAvailable = true,
            TotalCost = 20,
            PathRowIndices = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        public static DataSet Sample14 = new DataSet
        {
            Input = null,
            MappedCostValues = new int[,] { { } },
        };

        public static DataSet Sample15 = new DataSet
        {
            Input = "  \n\t  ",
            MappedCostValues = new int[,] { { } },
        };

        public static DataSet Sample16 = new DataSet
        {
            Input = String.Empty,
            MappedCostValues = new int[,] { { } },
        };

        public static DataSet Sample17 = new DataSet
        {
            Input = @"3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6
6 1 8 2 7 4 6 1 8 2 7 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6
5 9 3 9 9 5 5 9 3 9 9 5 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6
8 4 1 3 2 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 7 2 8 6 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
6 1 8 2 7 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
5 9 3 9 9 5 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
8 4 1 3 2 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 7 2 8 6 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
6 1 8 2 7 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
5 9 3 9 9 5 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
8 4 1 3 2 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 7 2 8 6 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 6 1 8 2 7 4 5 9 3 9 9 5
3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
6 1 8 2 7 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
5 9 3 9 9 5 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
8 4 1 3 2 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
3 7 2 8 6 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
6 1 8 2 7 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
5 9 3 9 9 5 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
8 4 1 3 2 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5
3 7 2 8 6 4 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 3 4 1 2 8 6 5 9 3 9 9 5",
            MappedCostValues = new int[,] {
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6 },
                { 6, 1, 8, 2, 7, 4, 6, 1, 8, 2, 7, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6 },
                { 5, 9, 3, 9, 9, 5, 5, 9, 3, 9, 9, 5, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6 },
                { 8, 4, 1, 3, 2, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 7, 2, 8, 6, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 6, 1, 8, 2, 7, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 5, 9, 3, 9, 9, 5, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 7, 2, 8, 6, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 6, 1, 8, 2, 7, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 5, 9, 3, 9, 9, 5, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 7, 2, 8, 6, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5 },
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 6, 1, 8, 2, 7, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 5, 9, 3, 9, 9, 5, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 3, 7, 2, 8, 6, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 6, 1, 8, 2, 7, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 5, 9, 3, 9, 9, 5, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 8, 4, 1, 3, 2, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 },
                { 3, 7, 2, 8, 6, 4, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 5, 9, 3, 9, 9, 5 } },
            IsPathAvailable = false,
            TotalCost = 44,
            PathRowIndices = new int[] { 21, 22, 23, 24, 24, 25, 1, 2, 1, 1, 2, 2, 2, 3, 4, 5 }
        };

        public static DataSet Sample18 = new DataSet
        {
            Input = @"
            3 4 1 2 8    6 3 4 1 2 8   6 6 1 8 2 7 4 5

6 1 8 2   7 4 6 1 8 2 7 4 5 9 3 9 9 5 5 

5 9 3 9 9 5    5 9 3 9 9 5 8   4 1 3 2 6 8 

8 4 1 3 2 6 8 4 1 3 2 6 8 4 1 3 2 6 8 

3 7 2 8 6 4 3 7 2 8 6 4 3 7 2 8 6 4 3  
   ",
            MappedCostValues = new int[,] {
                { 3, 4, 1, 2, 8, 6, 3, 4, 1, 2, 8, 6, 6, 1, 8, 2, 7, 4, 5 },
                { 6, 1, 8, 2, 7, 4, 6, 1, 8, 2, 7, 4, 5, 9, 3, 9, 9, 5, 5 },
                { 5, 9, 3, 9, 9, 5, 5, 9, 3, 9, 9, 5, 8, 4, 1, 3, 2, 6, 8 },
                { 8, 4, 1, 3, 2, 6, 8, 4, 1, 3, 2, 6, 8, 4, 1, 3, 2, 6, 8 },
                { 3, 7, 2, 8, 6, 4, 3, 7, 2, 8, 6, 4, 3, 7, 2, 8, 6, 4, 3 }
            }
,
            IsPathAvailable = true,
            TotalCost = 50,
            PathRowIndices = new int[] { 1, 2, 3, 4, 4, 5, 1, 2, 3, 4, 4, 5, 5, 1, 5, 4, 4, 5, 5 }
        };

        public static DataSet Sample19 = new DataSet
        {
            Input = @"6,  3,  -5,  9
              -5,  2, 4, 10 

             3 , -2 , 6, 10 
  6, -1 ,-2,  10
 10, 014,   13,19",
            MappedCostValues = new int[,] {
                { 6, 3, -5, 9 },
                {-5, 2, 4, 10 },
                { 3, -2, 6, 10 },
                { 6, -1, -2, 10 },
                { 10, 14, 13, 19 }
            },
            IsPathAvailable = true,
            TotalCost = 1,
            PathRowIndices = new int[] { 2, 3, 4, 4 }
        };

        public static DataSet Sample20 = new DataSet
        {
            Input = @"3,4,1,2,8,6
6,1,8,2,7,4
5,9,3,9,9,5
8,4,1,3,2,6
8,4,1,3,2,6
",
            MappedCostValues = new int[,] {
                {3,4,1,2,8,6},
                {6,1,8,2,7,4},
                {5,9,3,9,9,5},
                {8,4,1,3,2,6},
                {8,4,1,3,2,6}
            },
            IsPathAvailable = true,
            TotalCost = 15,
            PathRowIndices = new int[] { 1, 2, 1, 1, 5, 5 }
        };

        public static DataSet Sample21 = new DataSet
        {
            Input = @"3,4,1,2,8,6
6,1,8,2,7,4
5,9,3,9,9,5
8,4,1,3,2,6
3,7,2,1,2,3
",
            MappedCostValues = new int[,] {
                {3,4,1,2,8,6},
                {6,1,8,2,7,4},
                {5,9,3,9,9,5},
                {8,4,1,3,2,6},
                {3,7,2,1,2,3}
            },
            IsPathAvailable = true,
            TotalCost = 11,
            PathRowIndices = new int[] { 1, 2, 1, 5, 4, 5 }
        };

        public static DataSet Sample22 = new DataSet
        {
            Input = @"19,10,19,10,19
21,23,20,19,12
20,12,20,11,10",
            MappedCostValues = new int[,] {
                {19,10,19,10,19},
                {21,23,20,19,12},
                {20,12,20,11,10}
            },
            IsPathAvailable = false,
            TotalCost = 48,
            PathRowIndices = new int[] { 1, 1, 1 }
        };

        public static DataSet Sample23 = new DataSet
        {
            Input = @"19,10
21,23,20
20,12,20",
            MappedCostValues = new int[,] { }
        };
    }
}
