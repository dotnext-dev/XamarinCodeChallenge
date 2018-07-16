using System;
using System.Text;
using XCC.Contracts;
using XCC.Utilities;

namespace ConsoleSandbox
{
    class MainClass
    {
        #region fields

        static readonly string INPUT_DELIMITER = "#";
        static readonly string COLUMN_DELIMITER = ",";
        static readonly int MAX_COST = 50;

        static ConsoleColor MSG_COLOR = ConsoleColor.DarkGreen;
        static ConsoleColor ERR_COLOR = ConsoleColor.DarkRed;
        static ConsoleColor INPUT_COLOR = ConsoleColor.DarkBlue;
        static ConsoleColor OUTPUT_COLOR = ConsoleColor.DarkCyan;
        static ConsoleColor DATA_COLOR = ConsoleColor.DarkGray;

        #endregion

        public static void Main(string[] args)
        {
            PrintInitMessage();
            var inputStr = ReadMatrix();

            try
            {
                var isDelimiterUsedInInput = inputStr.Contains(COLUMN_DELIMITER);
                var parser = new StringInputParser(
                    isDelimiterUsedInInput ? COLUMN_DELIMITER : " ");
                var grid = parser.Parse(inputStr);

                PrintCostMatrix(grid);

                var pathProvider = new SmartPathProvider(MAX_COST);
                var lowestPath = pathProvider.GetLowestTraversalPath(grid);

                PrintTraversalPath(lowestPath);
            }
            catch (Exception ex)
            {
                PrintErrorMessage(ex.Message);
            }

            WaitForKeyPress();
        }

        #region helper methods

        /// <summary>
        /// Prints the message.
        /// </summary>
        static void PrintInitMessage()
        {
            Console.WriteLine();

            Console.ForegroundColor = MSG_COLOR;
            Console.WriteLine($"Enter matrix with newline as row delimiter, and '{COLUMN_DELIMITER}' or space as column delimiter.");
            Console.ForegroundColor = DATA_COLOR;
            Console.WriteLine(@"Sample input: 
    1,2,3
    4,5,6");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Enter {INPUT_DELIMITER} when done.");
        }

        /// <summary>
        /// Reads the matrix for input.
        /// </summary>
        /// <returns>The matrix.</returns>
        static string ReadMatrix()
        {
            Console.ForegroundColor = INPUT_COLOR;
            var inputBuilder = new StringBuilder();
            var keepReadingInput = true;
            while (keepReadingInput)
            {
                var inputStr = Console.ReadLine()?.Trim();
                if (inputStr.EndsWith(INPUT_DELIMITER, StringComparison.Ordinal))
                {
                    keepReadingInput = false;
                    inputStr = inputStr.Replace(INPUT_DELIMITER, string.Empty); //remove all occurances
                }

                if (!string.IsNullOrEmpty(inputStr))
                {
                    if (inputBuilder.Length == 0)
                        inputBuilder.Append(inputStr);
                    else
                        inputBuilder.Append($"{Environment.NewLine}{inputStr}");
                }
            }

            return inputBuilder.ToString();
        }

        /// <summary>
        /// Prints the cost matrix.
        /// </summary>
        /// <param name="grid">Grid.</param>
        static void PrintCostMatrix(CostMatrix grid)
        {
            Console.WriteLine();

            Console.ForegroundColor = MSG_COLOR;
            Console.WriteLine("You entered: ");

            Console.ForegroundColor = DATA_COLOR;
            Console.WriteLine(grid.ToString());
        }

        /// <summary>
        /// Prints the traversal path.
        /// </summary>
        /// <param name="lowestPath">Lowest path.</param>
        static void PrintTraversalPath(TraversalPath lowestPath)
        {
            Console.WriteLine();

            Console.ForegroundColor = MSG_COLOR;
            Console.WriteLine("Result: ");

            Console.ForegroundColor = OUTPUT_COLOR;
            Console.WriteLine(lowestPath.ToString());
        }

        /// <summary>
        /// Prints the error message.
        /// </summary>
        /// <param name="message">Message.</param>
        static void PrintErrorMessage(string message)
        {
            Console.WriteLine();

            Console.ForegroundColor = ERR_COLOR;
            Console.WriteLine(message);
        }

        /// <summary>
        /// Waits for key press.
        /// </summary>
        static void WaitForKeyPress()
        {
            Console.WriteLine();

            Console.ForegroundColor = MSG_COLOR;
            Console.WriteLine("Press any key to exit..");

            Console.ForegroundColor = INPUT_COLOR;
            Console.ReadKey();
        }

        #endregion
    }
}

