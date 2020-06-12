using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CensusAnalyserApplication
{
    /// <summary>
    /// This class is used to read the data from US Csv File
    /// </summary>
    public class USCensusAdapter
    {
        //usCensusList contains the US Census Data 
        public List<CensusDAO> usCensusList = new List<CensusDAO>();

        /// <summary>
        /// This Method takes the input path of US Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of US Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public List<CensusDAO> LoadUSCensusData(string csvFilePath)
        {
            DataTable usCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            usCensusData = csvBuilder.LoadData(usCensusData, csvFilePath);
            usCensusList = ConvertToList.USCensusDataInList(usCensusData, usCensusList);
            return usCensusList;
        }
    }
}
