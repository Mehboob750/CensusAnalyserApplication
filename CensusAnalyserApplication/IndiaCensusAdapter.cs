using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CensusAnalyserApplication
{
    public class IndiaCensusAdapter
    {
        //censusList contains the India Census Data And India State Code Data
        public List<CensusDAO> censusList = new List<CensusDAO>();

        public List<CensusDAO> LoadCensusData(string csvFilePath)
        {
            if (csvFilePath.Contains("IndiaStateCode"))
                return this.LoadIndiaStateCodeData(csvFilePath);
            return this.LoadIndiaCensusData(csvFilePath);
        }

        public List<CensusDAO> LoadIndiaCensusData(string csvFilePath)
        {
            DataTable csvCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvCensusData = csvBuilder.LoadData(csvCensusData, csvFilePath);
            censusList = ConvertToList.IndiaCensusDataInList(csvCensusData, censusList);
            return censusList;
        }

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
