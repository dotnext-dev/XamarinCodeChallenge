using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using XCC.Contracts;

namespace XCC.Utilities
{
    /// <summary>
    /// Represents an utility-parser that parses matrix 
    /// from string to <see cref="T:XCC.Contracts.CostMatrix" />
    /// </summary>
    public class StringInputParser : IInputParser
    {
        #region contants

        /// <summary>
        /// The Regex value pattern for an integer.
        /// </summary>
        const string VALUE_PATTERN = @"-?\d+";

        /// <summary>
        /// The Regex newline pattern.
        /// <remarks>Expected to be compatible with multiple platforms</remarks>
        /// </summary>
        const string NEWLINE_PATTERN = @"[\r\n]+";

        #endregion

        #region fields

        readonly string m_columnDelimiter;
        readonly string m_regExValidator;

        #endregion

        #region constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCC.Utilities.StringInputParser"/> class.
        /// </summary>
        /// <param name="columnDelimiter">Column delimiter for columns in a matrix (new-line is treated as row delimiter)</param>
        public StringInputParser(string columnDelimiter = " ")
        {
            m_columnDelimiter = columnDelimiter;

            //Build regex pattern for input verification (extra spaces or newlines are allowed).
            var columnPattern = $"(\\s*{VALUE_PATTERN}\\s*)(\\{m_columnDelimiter}(\\s*{VALUE_PATTERN}\\s*))*";
            m_regExValidator = $"^({columnPattern})({NEWLINE_PATTERN}({columnPattern}))*\\z";
        }

        #endregion

        #region methods

        /// <summary>
        /// Determines whether input represents a valid string
        /// </summary>
        /// <returns><c>true</c>, if input is in expected format, <c>false</c> otherwise.</returns>
        /// <param name="input">Input string that represents the cost matrix</param>
        bool IsValid(string input)
        {
            return Regex.IsMatch(input, m_regExValidator);
        }

        #endregion

        #region IInputParser methods

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
        public CostMatrix Parse(string input)
        {
            //Check for empty input
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));

            //Check whether input is in expected delimited format (extra spaces or newlines are allowed).
            if (!IsValid(input))
                throw new FormatException($"Invalid {nameof(input)}: Unexpected pattern, or characters.");

            //Split input string for rows (using newline as delimiter)
            var valueRows = Regex.Split(input.Trim(), NEWLINE_PATTERN);

            //Initialize with invalid value
            var numberOfColumns = -1;

            //Initialize list (which we will use to fill, or generate cost matrix later)
            var costValueList = new List<string[]>();
            foreach(var valueRow in valueRows)
            {
                //ignore empty rows (usually caused by extra whitespace)
                if (string.IsNullOrWhiteSpace(valueRow))
                    continue;

                //split each row for column values
                var values = Regex.Split(valueRow.Trim(), m_columnDelimiter);
                //remove empty strings (usually caused by extra whitespace)
                values = values.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

                //Initialize first and validate in the next round
                if (numberOfColumns == -1)
                    numberOfColumns = values.Length;
                else if (numberOfColumns != values.Length)
                    throw new FormatException($"Invalid {nameof(input)}: Column sizing is not uniform.");

                costValueList.Add(values);
            }

            //Once we have parsed cost-value list, use it to generate cost-matrix
            var costGrid = new CostMatrix(costValueList.Count, numberOfColumns);
            costGrid.FillCostGrid(costValueList);

            return costGrid;
        }

        #endregion
    }
}


