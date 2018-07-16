using NUnit.Framework;
using System;
using XCC.Data;

namespace XCC.Utilities.Tests
{
    [TestFixture()]
    public class StringInputParserTests
    {
        [TestCaseSource(typeof(TestCaseDataSource), "ValidInputFormat1")]
        public void Ensure_IsSuccessfullyParsed_OnValidMatrixInput_Format1(DataSet data)
        {   
            var target = new StringInputParser();

            var actualCostGrid = target.Parse(data.Input);

            var expectedValues = data.MappedCostValues;
            Extensions.AreEqual(actualCostGrid, data.MappedCostValues);
        }

        [TestCaseSource(typeof(TestCaseDataSource), "ValidInputFormat2")]
        public void Ensure_IsSuccessfullyParsed_OnValidMatrixInput_Format2(DataSet data)
        {
            var target = new StringInputParser(columnDelimiter: ",");

            var actualCostGrid = target.Parse(data.Input);

            var expectedValues = data.MappedCostValues;
            Extensions.AreEqual(actualCostGrid, data.MappedCostValues);
        }

        [TestCaseSource(typeof(TestCaseDataSource), "InvalidMatrix")]
        public void Ensure_ExIsThrown_OnInvalidMatrixInput(DataSet data)
        {
            var target = new StringInputParser();
            Assert.Throws<FormatException>(
                () => target.Parse(data.Input));
        }

        [TestCaseSource(typeof(TestCaseDataSource), "EmptyInput")]
        public void Ensure_ExIsThrown_OnEmptyInput(DataSet data)
        {
            var target = new StringInputParser();
            Assert.Throws<ArgumentNullException>(
                () => target.Parse(data.Input));
        }
    }
}
