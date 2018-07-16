using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCC.Contracts
{
    /// <summary>
    /// Represents a possible traversal path, alongwith total cost for a cost-grid
    /// </summary>
    public class TraversalPath
    {
        #region fields

        int m_totalCost;
        readonly int[] m_rowIndices;
        int m_lastPathIndex;
        bool m_valid;

        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Contracts.TraversalPath"/> class.
        /// </summary>
        /// <param name="numberOfColumns">Number of columns.</param>
        public TraversalPath(int numberOfColumns)
        {
            m_totalCost = 0;
            m_rowIndices = new int[numberOfColumns];
            m_lastPathIndex = -1;
            m_valid = true;
        }

        #endregion

        #region indexers 

        /// <summary>
        /// Gets or sets the row-index in path for the specified column.
        /// </summary>
        /// <param name="forColumn">The column index.</param>
        public int this[int forColumn]
        {
            get => m_rowIndices[forColumn];
            set 
            {
                m_rowIndices[forColumn] = value;
                m_lastPathIndex = forColumn;
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// Validates cost before returning the total cost.
        /// </summary>
        /// <value>The total valid cost.</value>
        int TotalValidCost => m_valid ? m_totalCost : int.MaxValue;

        /// <summary>
        /// Gets the total cost value for specified traversal path.
        /// </summary>
        /// <value>The total cost.</value>
        public int TotalCost => m_totalCost;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:XCC.Contracts.TraversalPath"/> is valid.
        /// </summary>
        /// <value><c>true</c> if is valid; otherwise, <c>false</c>.</value>
        public bool IsValid => m_valid;

        /// <summary>
        /// Gets the set of specified row indices for current traversal path.
        /// </summary>
        /// <value>The row indices.</value>
        public int[] RowIndices => (m_rowIndices ?? new int[0])
                                        .TakeWhile(x => x != default(int))
                                        .ToArray();
        #endregion

        #region operators

        /// <summary>
        /// Determines whether one specified <see cref="XCC.Contracts.TraversalPath"/> is lower than another specfied <see cref="XCC.Contracts.TraversalPath"/>.
        /// </summary>
        /// <param name="a">The first <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <param name="b">The second <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> is lower than <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator <(TraversalPath a, TraversalPath b)
        {
            return a.TotalValidCost < b.TotalValidCost;
        }

        /// <summary>
        /// Determines whether one specified <see cref="XCC.Contracts.TraversalPath"/> is greater than another specfied <see cref="XCC.Contracts.TraversalPath"/>.
        /// </summary>
        /// <param name="a">The first <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <param name="b">The second <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> is greater than <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator >(TraversalPath a, TraversalPath b)
        {
            return a.TotalValidCost > b.TotalValidCost;
        }

        /// <summary>
        /// Determines whether one specified <see cref="XCC.Contracts.TraversalPath"/> is lower than or equal to another
        /// specfied <see cref="XCC.Contracts.TraversalPath"/>.
        /// </summary>
        /// <param name="a">The first <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <param name="b">The second <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> is lower than or equal to <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator <=(TraversalPath a, TraversalPath b)
        {
            return a.TotalValidCost <= b.TotalValidCost;
        }

        /// <summary>
        /// Determines whether one specified <see cref="XCC.Contracts.TraversalPath"/> is greater than or equal to
        /// another specfied <see cref="XCC.Contracts.TraversalPath"/>.
        /// </summary>
        /// <param name="a">The first <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <param name="b">The second <see cref="XCC.Contracts.TraversalPath"/> to compare.</param>
        /// <returns><c>true</c> if <c>a</c> is greater than or equal to <c>b</c>; otherwise, <c>false</c>.</returns>
        public static bool operator >=(TraversalPath a, TraversalPath b)
        {
            return a.TotalValidCost >= b.TotalValidCost;
        }

        #endregion

        #region methods

        /// <summary>
        /// Invalidate this traversal-path (assuming next possible move exceeds max-traversal cost).
        /// </summary>
        public void Invalidate()
        {
            m_valid = false;
        }

        /// <summary>
        /// Append the specified row-index to path and add cost to total-cost.
        /// </summary>
        /// <param name="rowIndex">Row index.</param>
        /// <param name="cost">Cost.</param>
        public void Append(int rowIndex, int cost)
        {
            //if current path is valid (i.e. not exceeded max cost or invalidated)
            if (m_valid)
            {
                //append row-index using lastPathIndex value
                this[++m_lastPathIndex] = rowIndex + 1;

                //add cost to total-cost
                m_totalCost += cost;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:XCC.Contracts.TraversalPath"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:XCC.Contracts.TraversalPath"/>.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            //Print path instance in expected output-format
            sb.AppendLine(m_valid ? "Yes" : "No");
            sb.AppendLine(m_totalCost.ToString());
            sb.Append(string.Join(",", RowIndices));

            return sb.ToString();
        }

        #endregion

        /// <summary>
        /// Copy the specified source traversal-path and to destination traversal-path.
        /// </summary>
        /// <param name="sourcePath">Source path.</param>
        /// <param name="destinationPath">Destination path.</param>
        public static void Copy(TraversalPath sourcePath, TraversalPath destinationPath)
        {
            //validate arguments
            if (sourcePath == null)
                throw new ArgumentNullException(nameof(sourcePath));
            
            if (destinationPath == null)
                throw new ArgumentNullException(nameof(destinationPath));

            //copy field-values from source object to destination instance
            destinationPath.m_totalCost = sourcePath.m_totalCost;
            Array.Copy(sourcePath.m_rowIndices, destinationPath.m_rowIndices,
                       Math.Min(sourcePath.m_rowIndices.Length, destinationPath.m_rowIndices.Length));
            destinationPath.m_lastPathIndex = sourcePath.m_lastPathIndex;
            destinationPath.m_valid = sourcePath.m_valid;
        }
    }
}
