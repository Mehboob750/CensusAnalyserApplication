using System;
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

        /// <summary>
        /// Used string variables to store the csv file paths
        /// </summary>
        public static string IndiaCensusCsvFilePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.csv";
        public static string IncorrcectFilePath = @"IndiaStateCensus.csv";
        public static string IncorrectExtensionTypePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.MP4";
        public static string IndiaStateCodeCsvFilePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCode.csv";
        public static string USCensusCsvFilePath= @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\USCensusData.csv";

        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int numberOfRecords = censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
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
                censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IncorrcectFilePath);
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
                censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, IncorrectExtensionTypePath);
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
                censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
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
                censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains NUll it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,null);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.type);
            }
        }

        /// <summary>
        /// Load the Indian StateCode File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int numberOfRecords= censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IndiaStateCodeCsvFilePath);
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
                censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IncorrcectFilePath);
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
                censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IncorrectExtensionTypePath);
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
                censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IndiaStateCodeCsvFilePath);
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
                censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IndiaStateCodeCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains NUll it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenStateCodeNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,null);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by State Name and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToState_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
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
            censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IndiaStateCodeCsvFilePath);
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
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population Density and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by AreaPerInSqKm and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToArea_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the US Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GiveUsCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int numberOfRecords = censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US,USCensusCsvFilePath);
            Assert.AreEqual(51, numberOfRecords);
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUSIncorrectFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, IncorrcectFilePath);
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
        public void GivenUSCensusCSVFile__WhenTypeIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, IncorrectExtensionTypePath);
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
        public void GivenUSCensusCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
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
        public void GivenUSCensusCSVFile__WhenHeaderIncorrect_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains NUll it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenFileNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, null);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.type);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulation_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedUSCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population Density and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedUSCensusData();
            Console.WriteLine(sortedData);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Area and result Store in Json Format
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToArea_ShouldPrintTheSortedResult()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedUSCensusData();
            Console.WriteLine(sortedData);
        }
    }
}