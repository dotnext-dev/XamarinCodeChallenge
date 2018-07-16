using System;
using System.Collections.Generic;

using XCC.Contracts;

namespace XCC.Utilities
{
    /// <summary>
    /// Static helper extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Fills the cost grid.
        /// </summary>
        /// <param name="costGrid">Target cost-grid to be filled.</param>
        /// <param name="costValues">Parsed input cost values.</param>
        public static void FillCostGrid(this CostMatrix costGrid, IList<string[]> costValues)
        {
            if (costValues == null)
                throw new ArgumentNullException(nameof(costValues));

            for (var row = 0; row < costGrid.NumberOfRows; row++)
                for (var col = 0; col < costGrid.NumberOfColumns; col++)
                    costGrid[row, col] = costValues[row][col].ToCostValue();
        }

        /// <summary>
        /// Converts string to corresponding cost value.
        /// </summary>
        /// <returns>The cost value.</returns>
        /// <param name="value">Value.</param>
        public static int ToCostValue(this string value)
        {
            //TODO: this should probably throw an exception
            if (int.TryParse(value, out int result))
                return result;
            return 0;
        }

        /// <summary>
        /// Finds next row-index for move-up traversal
        /// </summary>
        /// <returns>The up.</returns>
        /// <param name="costGrid">Cost grid.</param>
        /// <param name="row">Row index</param>
        public static int RowUp(this CostMatrix costGrid, int row)
        {
            if (costGrid == null)
                throw new ArgumentNullException(nameof(costGrid));

            if (row < 0 || row >= costGrid.NumberOfRows)
                throw new IndexOutOfRangeException($"Invalid index for {nameof(row)}");

            if (row == 0)
                return costGrid.NumberOfRows - 1;

            return row - 1;
        }

        /// <summary>
        /// Finds next row-index for move-down traversal
        /// </summary>
        /// <returns>The up.</returns>
        /// <param name="costGrid">Cost grid.</param>
        /// <param name="row">Row index</param>
        public static int RowDown(this CostMatrix costGrid, int row)
        {
            if (costGrid == null)
                throw new ArgumentNullException(nameof(costGrid));

            if (row < 0 || row >= costGrid.NumberOfRows)
                throw new IndexOutOfRangeException($"Invalid index for {nameof(row)}");

            if (row == costGrid.NumberOfRows - 1)
                return 0;
            
            return row + 1;
        }
    }
}
