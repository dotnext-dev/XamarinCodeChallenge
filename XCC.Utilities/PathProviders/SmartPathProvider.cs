using XCC.Contracts;

namespace XCC.Utilities
{
    /// <summary>
    /// Represents dynamic/cache based path provider.
    /// <remarks>This strategy is supposed to be efficient and better than recursion.</remarks>
    /// </summary>
    public class SmartPathProvider : PathProviderBase
    {
        #region constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Utilities.SmartPathProvider"/> class.
        /// </summary>
        /// <param name="maxCost">Max cost.</param>
        public SmartPathProvider(int maxCost) : base(maxCost) { }

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
            //create a matrix that will cache traversal-cost for each cell
            TraversalPath[,] cachedPaths = new TraversalPath[matrix.NumberOfRows, matrix.NumberOfColumns];

            //in this case we first go column by column 
            for (int column = 0; column < matrix.NumberOfColumns; column++)
            {
                //and calculate lowest traversal cost for that particular cell (each row in column)
                for (int row = 0; row < matrix.NumberOfRows; row++)
                {
                    //initilize traversal path 
                    cachedPaths[row, column] = new TraversalPath(column + 1);

                    //get cost for current cell 
                    var currentCellCost = matrix[row, column];
                    int traversalCost;
                    if (column == 0)
                    {
                        //as it is first column, traversal-cost is same as current cell
                        traversalCost = currentCellCost;
                    }
                    else
                    {
                        //get adjacent up row index
                        var rowUpIndex = matrix.RowUp(row);
                        //get adjacent down row index
                        var rowDownIndex = matrix.RowDown(row);

                        //get traversal cost for adjacent up-row for previous column
                        var traversalPathFromUpRow = cachedPaths[rowUpIndex, column - 1];
                        //get traversal cost from current row for previous column
                        var traversalPathFromPrevRow = cachedPaths[row, column - 1];
                        //get traversal cost from adjacent down-row for previous column
                        var traversalPathFromDownRow = cachedPaths[rowDownIndex, column - 1];

                        //and find the lowest path from all three possible moves
                        var lowestTraversalPath = traversalPathFromUpRow;
                        if (traversalPathFromPrevRow < lowestTraversalPath)
                            lowestTraversalPath = traversalPathFromPrevRow;
                        if (traversalPathFromDownRow < lowestTraversalPath)
                            lowestTraversalPath = traversalPathFromDownRow;

                        //once we have the lowest traversal cost we copy that onto current cell cache
                        TraversalPath.Copy(lowestTraversalPath, cachedPaths[row, column]);
                        //and calculate total
                        traversalCost = lowestTraversalPath.TotalCost + currentCellCost;
                    }

                    //if traversal cost is valid, we append that current cell cache 
                    if (traversalCost <= m_maxCost)
                        cachedPaths[row, column].Append(row, currentCellCost);
                    //else we abadon the path (that is invalidate the cell)
                    else
                        cachedPaths[row, column].Invalidate();
                }
            }

            //With the cache grid ready and initialized, we find the lowest cost by 
            //traversing 
            TraversalPath lowestCostPath = null;
            if (matrix.NumberOfColumns >= 1)
                for (int row = 0; row < matrix.NumberOfRows; row++)
                {
                    var costPath = cachedPaths[row, matrix.NumberOfColumns - 1];
                    if (lowestCostPath == null || costPath <= lowestCostPath)
                        lowestCostPath = costPath;
                }

            return lowestCostPath ?? new TraversalPath(0);
        }

        #endregion
    }
}
