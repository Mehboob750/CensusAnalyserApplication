namespace NUnitTestCensusAnalyser
{
    using System;
    using System.Collections.Generic;
    using CensusAnalyserApplication;
    using Nancy.Json;
    using NUnit.Framework;

    /// <summary>
    /// This class is contains the Test Cases to check the functionality of Census Analyzer Application
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Used string variable to store the India Census CSV File Path
        /// </summary>
        private static string indiaCensusCsvFilePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.csv";

        /// <summary>
        /// Used string variable to store the Incorrect File Type Path
        /// </summary>
        private static string incorrcectFilePath = @"IndiaStateCensus.csv";

        /// <summary>
        /// Used string variable to store the Incorrect Extension Type Path
        /// </summary>
        private static string incorrectExtensionTypePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCensusData.MP4";

        /// <summary>
        /// Used string variable to store the India State Code CSV File Path
        /// </summary>
        private static string indiaStateCodeCsvFilePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\IndiaStateCode.csv";

        /// <summary>
        /// Used string variable to store the US Census CSV File Path
        /// </summary>
        private static string unitedStateCensusCsvFilePath = @"C:\Users\Mehboob Shaikh\source\repos\CensusAnalyserApplication\NUnitTestCensusAnalyser\Resources\USCensusData.csv";

        /// <summary>
        /// Created the Reference of Census Analyzer Class Globally
        /// </summary>
        private CensusAnalyser censusAnalyser = null;

        /// <summary>
        ///  Created the Object of Census Analyzer Class
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.censusAnalyser = new CensusAnalyser();
        }

        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            try
            {
                int numberOfRecords = this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                Assert.AreEqual(29, numberOfRecords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIncorrectFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, incorrcectFilePath);
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
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, incorrectExtensionTypePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimiter to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
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
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains null it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, null);
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
            try
            {
                int numberOfRecords = this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, indiaStateCodeCsvFilePath);
                Assert.AreEqual(37, numberOfRecords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIncorrectStateCodeFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, incorrcectFilePath);
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
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, incorrectExtensionTypePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimiter to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, indiaStateCodeCsvFilePath);
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
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, indiaStateCodeCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains null it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenStateCodeNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, null);
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
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetStateWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Andhra Pradesh", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by State Name and Smallest State by State Name
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToState_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetStateWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("West Bengal", sortedList[28].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian State Code File and Sort the data by State Code and Largest State by State Code
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenSortedAccordingToStateCode_ShouldReturnTheLargestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, indiaStateCodeCsvFilePath);
                string sortedData = this.censusAnalyser.GetStateCodeWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Andhra Pradesh New", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian State Code File and Sort the data by State Code and Smallest State by State Code
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVFile__WhenSortedAccordingToStateCode_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaStateCodeData(CensusAnalyser.Country.INDIA, indiaStateCodeCsvFilePath);
                string sortedData = this.censusAnalyser.GetStateCodeWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("West Bengal", sortedList[36].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and returns the Largest State by Population
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulation_ShouldReturnTheLargestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Uttar Pradesh", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population and returns the Smallest State by Population
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulation_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Sikkim", sortedList[28].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population Density and returns the Largest State by Population Density
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheLargestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationDensityWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Bihar", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by Population Density and returns the Smallest State by Population Density
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationDensityWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Arunachal Pradesh", sortedList[28].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by AreaPerInSquareKm and returns the Largest State by Area
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheLargestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetAreaWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Rajasthan", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the Indian Census File and Sort the data by AreaPerInSquareKm and returns the Smallest State by Area
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadIndiaCensusData(CensusAnalyser.Country.INDIA, indiaCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetAreaWiseSortedCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Goa", sortedList[28].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GiveUsCensusCSVFile_WhenLoaded_ShouldReturnCorrectRecord()
        {
            try
            {
                int numberOfRecords = this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                Assert.AreEqual(51, numberOfRecords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUSIncorrectFile_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, incorrcectFilePath);
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
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, incorrectExtensionTypePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CensusFileProblem, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimiter to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenDelimeterIncorrect_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
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
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.IncorrectHeader, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Census File and if it contains null it throws Custom Exception
        /// </summary>
        [Test]
        public void GivenFileNull_WhenLoaded_ShouldThrowCustomException()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, null);
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
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("California", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population and returns the Smallest State by Population
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulation_ShouldPrintTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Wyoming", sortedList[50].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population Density and returns the Largest State by Population Density
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheLargestState()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationDensityWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("District of Columbia", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Population Density and returns the Smallest State by Population Density
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToPopulationDensity_ShouldReturnTheSmallestState()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetPopulationDensityWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Alaska", sortedList[50].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Area and returns the Largest Area
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheLargestArea()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetAreaWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("Alaska", sortedList[0].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Load the US Census File and Sort the data by Area and returns the smallest Area
        /// </summary>
        [Test]
        public void GivenUSCensusCSVFile__WhenSortedAccordingToArea_ShouldReturnTheSmallestArea()
        {
            try
            {
                this.censusAnalyser.LoadUsCensusData(CensusAnalyser.Country.US, unitedStateCensusCsvFilePath);
                string sortedData = this.censusAnalyser.GetAreaWiseSortedUSCensusData();
                List<CensusDAO> sortedList = new JavaScriptSerializer().Deserialize<List<CensusDAO>>(sortedData);
                Assert.AreEqual("District of Columbia", sortedList[50].State);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}