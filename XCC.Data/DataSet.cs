
namespace XCC.Data
{
    /// <summary>
    /// Represents a set of data representing sample input and expected output
    /// <remarks>Mostly will be used for unit-tests or mock-data for demo</remarks>
    /// </summary>
    public class DataSet
    {
        #region properties

        /// <summary>
        /// Gets or sets the input string represting the cost matrix.
        /// <remarks>The input consists of a sequence of row specifications. 
        /// Each row is represented by a series of delimited integers on a single line. 
        /// Note: integers are not restricted to being positive. </remarks>
        /// </summary>
        /// <value>The input.</value>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the mapped cost values in 2D array.
        /// </summary>
        /// <value>The mapped cost values.</value>
        public int[,] MappedCostValues { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a <see cref="T:XCC.Data.DataSet"/> valid path available.
        /// <remarks>Path is considered valid if the value doesn't exceed MAX cost for traversal</remarks>
        /// </summary>
        /// <value><c>true</c> if is path available; otherwise, <c>false</c>.</value>
        public bool IsPathAvailable { get; set; }

        /// <summary>
        /// Gets or sets the total cost. (valid or invalidated)
        /// </summary>
        /// <value>The total cost.</value>
        public int TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the path row indices. (valid or invalidated)
        /// </summary>
        /// <value>The path row indices.</value>
        public int[] PathRowIndices { get; set; }

        #endregion
    }
}
