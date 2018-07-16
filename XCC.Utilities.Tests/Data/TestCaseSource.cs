using XCC.Data;

namespace XCC.Utilities.Tests
{
    /// <summary>
    /// Data sources for unit-test cases
    /// </summary>
    public class TestCaseDataSource
    {
        /// <summary>
        /// List of data-sets that represent valid input
        /// </summary>
        static DataSet[] ValidInput = {
            SampleDataSets.Sample1,
            SampleDataSets.Sample2,
            SampleDataSets.Sample3,
            SampleDataSets.Sample4,
            SampleDataSets.Sample5,
            SampleDataSets.Sample6,
            SampleDataSets.Sample8,
            SampleDataSets.Sample9,
            SampleDataSets.Sample10,
            SampleDataSets.Sample11,
            SampleDataSets.Sample12,
            SampleDataSets.Sample13,
            SampleDataSets.Sample17,
            SampleDataSets.Sample18,
            SampleDataSets.Sample19,
            SampleDataSets.Sample20,
            SampleDataSets.Sample21,
            SampleDataSets.Sample22,
        };

        /// <summary>
        /// List of data-sets that represent valid input, where-in columns are delimited by space
        /// </summary>
        static DataSet[] ValidInputFormat1 = {
            SampleDataSets.Sample1,
            SampleDataSets.Sample2,
            SampleDataSets.Sample3,
            SampleDataSets.Sample4,
            SampleDataSets.Sample5,
            SampleDataSets.Sample6,
            SampleDataSets.Sample8,
            SampleDataSets.Sample9,
            SampleDataSets.Sample11,
            SampleDataSets.Sample12,
            SampleDataSets.Sample13,
            SampleDataSets.Sample17,
            SampleDataSets.Sample18,
        };

        /// <summary>
        /// List of data-sets that represent valid input, where-in columns are delimited by comma
        /// </summary>
        static DataSet[] ValidInputFormat2 = {
            SampleDataSets.Sample10,
            SampleDataSets.Sample19,
            SampleDataSets.Sample20,
            SampleDataSets.Sample21,
            SampleDataSets.Sample22,
        };

        /// <summary>
        /// List of data-sets that represent invalid input such as non-intergers, or jagged matrix
        /// </summary>
        static DataSet[] InvalidMatrix = {
            SampleDataSets.Sample7,
            SampleDataSets.Sample23
        };

        /// <summary>
        /// List of data-sets that represent invalid input such as empty, null, or whitespace
        /// </summary>
        static DataSet[] EmptyInput = {
            SampleDataSets.Sample14,
            SampleDataSets.Sample15,
            SampleDataSets.Sample16
        };
    }
}
