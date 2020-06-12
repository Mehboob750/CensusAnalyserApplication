using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CensusAnalyserApplication
{
    public class USCensusAdapter
    {
        //usCensusList contains the US Census Data 
        public List<CensusDAO> usCensusList = new List<CensusDAO>();

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
