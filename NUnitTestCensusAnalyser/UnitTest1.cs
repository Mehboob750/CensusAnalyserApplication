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
        public static string INCORRECT_FILE_CSV_FILE_PATH = @"IndiaStateCensus.csv";
        public static string INCORRECT_Type_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.MP4";
        public static string INDIA_StateCode_CSV_FILE_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCode.csv";


        [Test]
        public void GivenIndianCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29, csvFile.Rows.Count);
        }

        [Test]
        public void GivenIncorrectFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INCORRECT_FILE_CSV_FILE_PATH);
            }
            catch(CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianCensusCSVFile__WhenTypeIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INCORRECT_Type_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianCensusCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianCensusCSVFile__WhenHeaderIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        [Test]
        public void GivenIndianStateCodeCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            DataTable csvFile = CensusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            Assert.AreEqual(37, csvFile.Rows.Count);
        }

        [Test]
        public void GivenIncorrectStateCodeFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaStateCodeData(INCORRECT_FILE_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianStateCodeCSVFile__WhenTypeIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaStateCodeData(INCORRECT_Type_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianStateCodeCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        [Test]
        public void GivenIndianStateCodeCSVFile__WhenHeaderIncorrect_ShouldThrowCustomException()
        {
            try
            {
                DataTable csvFile = CensusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }
    }
}