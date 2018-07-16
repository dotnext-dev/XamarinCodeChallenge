
namespace XCC.Contracts
{
    /// <summary>
    /// Represents a base contract for a path-provider.
    /// </summary>
    public abstract class PathProviderBase
    {
        #region fields

        protected int m_maxCost;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Contracts.PathProviderBase"/> class.
        /// </summary>
        /// <param name="costValue">Cost value.</param>
        protected PathProviderBase(int costValue)
        {
            m_maxCost = costValue;
        }

        /// <summary>
        /// Applies strategy/algorithm for calculating lowest-cost path across
        /// the specified cost-matrix.
        /// </summary>
        /// <returns>The lowest traversal path.</returns>
        /// <param name="matrix">The cost matrix.</param>
        public abstract TraversalPath GetLowestTraversalPath(CostMatrix matrix);
    }
}
