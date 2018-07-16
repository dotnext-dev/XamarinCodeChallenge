using System.Text;

namespace XCC.Contracts
{
    /// <summary>
    /// Represents a cost matrix grid
    /// </summary>
    public class CostMatrix
    {
        #region fields

        readonly int[,] m_values;
        readonly int m_noOfRows;
        readonly int m_noOfCols;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Contracts.CostMatrix"/> class.
        /// </summary>
        /// <param name="noOfRows">No of rows.</param>
        /// <param name="noOfColumns">No of columns.</param>
        public CostMatrix(int noOfRows, int noOfColumns)
        {
            m_values = new int[noOfRows, noOfColumns];
            m_noOfCols = noOfColumns;
            m_noOfRows = noOfRows;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Contracts.CostMatrix"/> class.
        /// </summary>
        /// <param name="values">Cost values array to be used to initialize</param>
        public CostMatrix(int[,] values)
        {
            m_values = values;
            m_noOfCols = values != null ? values.GetLength(1) : 0;
            m_noOfRows = values != null ? values.GetLength(0) : 0;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the number of rows in matrix.
        /// </summary>
        /// <value>The number of rows.</value>
        public int NumberOfRows => m_noOfRows;

        /// <summary>
        /// Gets the number of columns in matrix.
        /// </summary>
        /// <value>The number of columns.</value>
        public int NumberOfColumns => m_noOfCols;

        #endregion

        #region indexers

        /// <summary>
        /// Gets or sets the cost value for the specified row, and column.
        /// </summary>
        /// <param name="row">Row index</param>
        /// <param name="col">Column index</param>
        public int this[int row, int col]
        {
            get => m_values[row, col];
            set => m_values[row, col] = value;
        }

        #endregion

        #region methods 

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:XCC.Contracts.CostMatrix"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:XCC.Contracts.CostMatrix"/>.</returns>
        public override string ToString()
        {
            //Print matrix in array-initialization-code format
            var sb = new StringBuilder();

            //Grid start indicator
            sb.Append("{");
            for (var i = 0; i < m_noOfRows; i++)
            {
                //Row start indicator (we also add delimiter for the consecutive rows
                sb.Append(i == 0 ? "{" : ",{");
                for (var j = 0; j < m_noOfCols; j++)
                {
                    //Print each cell value (alongwith delimiter for consecutive columns)
                    sb.Append(j == 0 ? string.Empty : ",");
                    sb.Append(m_values[i, j]);
                }
                //Row end indicator
                sb.Append("}");
            }
            //Grid end indicator
            sb.Append("}");

            //Print final string
            return sb.ToString();
        }

        #endregion
    }
}
