using XCC.Contracts;

namespace XCC.Utilities
{
    /// <summary>
    /// Represents recursion based path provider
    /// <remarks>Mostly used for generating or verifying results for unit-tests</remarks>
    /// </summary>
    public class BruteForcePathProvider : PathProviderBase
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Utilities.BruteForcePathProvider"/> class.
        /// </summary>
        /// <param name="maxCost">Max cost.</param>
        public BruteForcePathProvider(int maxCost) : base(maxCost) { }

        #endregion

        #region PathProviderBase methods

        /// <summary>
        /// Applies strategy/algorithm for calculating lowest-cost path across
        /// the specified cost-matrix.
        /// </summary>
        /// <returns>The lowest traversal path.</returns>
        /// <param name="matrix">The cost matrix.</param>
        public override TraversalPath GetLowestTraversalPath(CostMatrix matrix)
        {
            //start with null-path
            TraversalPath lowestCostPath = null;

            for (int row = 0; row < matrix.NumberOfRows; row++)
            {
                //for each row in matrix initiate recursive method to calculate lowest 
                //traversal path. But, we start from the end (last column and move on to first column)
                var costPath = ComputeLowestCostPath(matrix, row, matrix.NumberOfColumns - 1);

                //for every row, compare cost (lowest traversal for corresponding row) and 
                //accordingly set the lowestCostPath
                if (lowestCostPath == null || costPath <= lowestCostPath)
                    lowestCostPath = costPath;
            }

            //if not path found, send empty traversal path
            return lowestCostPath ?? new TraversalPath(0);
        }

        #endregion

        #region methods

        /// <summary>
        /// Computes the lowest cost path, in recursive manner.
        /// </summary>
        /// <returns>Calculate the lowest cost path.</returns>
        /// <param name="matrix">Cost matrix.</param>
        /// <param name="row">For specified row.</param>
        /// <param name="column">For specified column.</param>
        TraversalPath ComputeLowestCostPath(CostMatrix matrix, int row, int column)
        {
            TraversalPath lowestPath;

            if (column == 0)
            {
                //If we have reached the first column, we send back a new path instance
                lowestPath = new TraversalPath(matrix.NumberOfColumns);
            }
            else
            {
                //Calculate lowest path for one-row up from previous column
                var rowUpCostPath = ComputeLowestCostPath(matrix, matrix.RowUp(row), column - 1);
                //Calculate lowest path for current row from previous column
                var rowNextCostPath = ComputeLowestCostPath(matrix, row, column - 1);
                //Calculate lowest path for one-row down from previous column
                var rowDownCostPath = ComputeLowestCostPath(matrix, matrix.RowDown(row), column - 1);

                //and find the lowest path from all three possible moves
                lowestPath = rowUpCostPath;
                if (rowNextCostPath < lowestPath)
                    lowestPath = rowNextCostPath;
                if (rowDownCostPath < lowestPath)
                    lowestPath = rowDownCostPath;
            }

            //once we have the lowest possible move (or cost) we append that to current path
            //and also validate if it reaches max possible cost (if it does we invalidate the 
            //path to abadon it)
            var nextPathTraversalCost = lowestPath.TotalCost + matrix[row, column];
            if (nextPathTraversalCost <= m_maxCost)
                lowestPath.Append(row, matrix[row, column]);
            else
                lowestPath.Invalidate();
            
            return lowestPath;
        }

        #endregion
    }
}
