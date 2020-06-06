using System.Data;
using CensusAnalyserApplication;
using NUnit.Framework;

namespace NUnitTestCensusAnalyser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static string INDIA_CENSUS_CSV_FILE_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.csv";

        [Test]
        public void GivenIndianCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29, csvFile.Rows.Count);
        }

    }
}