
namespace XCC.Contracts
{
    /// <summary>
    /// Represents contract inteface for cost grid/matrix input
    /// </summary>
    public interface IInputParser
    {
        /// <summary>
        /// Parse the specified input into cost-matrix/grid
        /// </summary>
        /// <returns>The parsed matrix.</returns>
        /// <param name="input">String input</param>
        /// <remarks>The input consists of a sequence of row specifications. 
        /// Each row is represented by a series of delimited integers on a single line. 
        /// Note: integers are not restricted to being positive. </remarks>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="FormatException" />
        CostMatrix Parse(string input);
    }
}
