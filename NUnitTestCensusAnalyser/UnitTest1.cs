using System;
using System.Collections.Generic;
using System.Data;
using CensusAnalyserApplication;
using Nancy.Json;
using Newtonsoft.Json;
using NUnit.Framework;

namespace NUnitTestCensusAnalyser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        public CensusAnalyser censusAnalyser = new CensusAnalyser();

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
        /// Load the Indian Census File and Sort the data by State Name and Largest State by State Name
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToState_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData= censusAnalyser.GetStateWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedList[0].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by State Name and Smallest State by State Name
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToState_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetStateWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("West Bengal", sortedList[28].state);
        }

        /// <summary>
        /// Load the Indian State Code File and Sort the data by State Code and Largest State by State Code
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenSortedAccordingToStateCode_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA,IndiaStateCodeCsvFilePath);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Andhra Pradesh New", sortedList[0].state);
        }

        /// <summary>
        /// Load the Indian State Code File and Sort the data by State Code and Largest State by State Code
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenSortedAccordingToStateCode_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, IndiaStateCodeCsvFilePath);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("West Bengal", sortedList[36].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and returns the Largest State by Population
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulation_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedList[0].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and returns the Smallest State by Population
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulation_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Sikkim", sortedList[28].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population Density and returns the Largest State by Population Density
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Bihar", sortedList[0].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population Density and returns the Smallest State by Population Density
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedList[28].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by AreaPerInSqKm and returns the Largest State by Area
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA,IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Rajasthan", sortedList[0].state);
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by AreaPerInSqKm and returns the Smallest State by Area
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, IndiaCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Goa", sortedList[28].state);
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
        /// Load the US Census File and Sort the data by Population and returns the Largest State by Population
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulation_ShouldPrintTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("California", sortedList[0].state);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population and returns the Smallest State by Population
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulation_ShouldPrintTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Wyoming", sortedList[50].state);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population Density and returns the Largest State by Population Density
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheLargestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("District of Columbia", sortedList[0].state);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population Density and returns the Largest State by Population Density
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheSmallestState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetPopulationDensityWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Alaska", sortedList[50].state);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Area and returns the Largest Area
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheLargestArea()
        {
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("Alaska", sortedList[0].state);
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Area and returns the smallest Area
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheSmallestArea()
        {
            censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, USCensusCsvFilePath);
            string sortedData = censusAnalyser.GetAreaWiseSortedUSCensusData();
            List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
            Assert.AreEqual("District of Columbia", sortedList[50].state);
        }
    }
}