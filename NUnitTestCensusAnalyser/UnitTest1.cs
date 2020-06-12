using System;
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

        /// <summary>
        /// Used string variables to store the csv file paths
        /// </summary>
        public static string INDIA_CENSUS_CSV_FILE_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.csv";
        public static string INCORRECT_FILE_CSV_FILE_PATH = @"IndiaStateCensus.csv";
        public static string INCORRECT_Type_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.MP4";
        public static string INDIA_StateCode_CSV_FILE_PATH = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCode.csv";

        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int numberOfRecords = censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29, numberOfRecords);
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIncorrectFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(INCORRECT_FILE_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file path with incorrect extension type to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenTypeIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(INCORRECT_Type_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimeter to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenHeaderIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian StateCode File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int numberOfRecords= censusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            Assert.AreEqual(37, numberOfRecords);
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIncorrectStateCodeFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCodeData(INCORRECT_FILE_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file path with incorrect extension type to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenTypeIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCodeData(INCORRECT_Type_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimeter to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenHeaderIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by State Name and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToState_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData= censusAnalyser.GetStateWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the Indian State Code File and Sort the data by State Code and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToStateCode_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaStateCodeData(INDIA_StateCode_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulation_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetPopulationWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }
    }
}