using System;
using NUnit.Framework;
using XCC.Contracts;

namespace XCC.Utilities.Tests
{
    public static class Extensions
    {
        public static void AreEqual(CostMatrix costGrid, int[,] values, string message = null)
        {
            if(values == null)
            {
                Assert.IsTrue(costGrid.NumberOfColumns == 0 
                              && costGrid.NumberOfRows == 0, message);
                return;
            }

            if (values != null)
                Assert.IsTrue(costGrid.NumberOfColumns == values.GetLength(1) 
                              && costGrid.NumberOfRows == values.GetLength(0), message);

            for (var i = 0; i < values.GetLength(0); i++)
                for (var j = 0; j < values.GetLength(1); j++)
                    Assert.AreEqual(costGrid[i, j], values[i, j], message);
        }

        public static string ToMessage(int[] expected, int[] actual)
        {
            var expectedStr = string.Join(", ", expected ?? new int[0]);
            var actualStr = string.Join(", ", actual ?? new int[0]);

            return $"Expected: {expectedStr}{Environment.NewLine}Actual: {actualStr}";
        }
    }
}
