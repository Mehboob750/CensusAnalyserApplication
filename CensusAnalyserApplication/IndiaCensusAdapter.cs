using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUnit.Framework;

namespace CensusAnalyserApplication
{
    /// <summary>
    /// This class is used to read the Indian Csv Files
    /// </summary>
    public class IndiaCensusAdapter
    {
        //censusList contains the India Census Data And India State Code Data
        public List<CensusDAO> censusList = new List<CensusDAO>();

        /// <summary>
        /// This Method is Used to Check File Path
        /// </summary>
        /// <param name="csvFilePath">This Parameter is used to check which File is to Load</param>
        /// <returns>If path matches According to that method is return</returns>
        public List<CensusDAO> LoadCensusData(string csvFilePath)
        {
            try
            {
                if (csvFilePath.Contains("IndiaStateCode"))
                    return this.LoadIndiaStateCodeData(csvFilePath);
                return this.LoadIndiaCensusData(csvFilePath);
            }
            catch(NullReferenceException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.Message);
            }
        }

        /// <summary>
        /// This Method takes the input path of India Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public List<CensusDAO> LoadIndiaCensusData(string csvFilePath)
        {
            DataTable csvCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvCensusData = csvBuilder.LoadData(csvCensusData, csvFilePath);
            censusList = ConvertToList.IndiaCensusDataInList(csvCensusData, censusList);
            return censusList;
        }

        /// <summary>
        ///  This Method takes the input path of StateCode Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India StateCode CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public List<CensusDAO> LoadIndiaStateCodeData(string csvFilePath)
        {
            DataTable csvStateCodeData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvStateCodeData = csvBuilder.LoadData(csvStateCodeData, csvFilePath);
            censusList = ConvertToList.IndiaStateDataInList(csvStateCodeData, censusList);
            return censusList;
        }
    }
}
