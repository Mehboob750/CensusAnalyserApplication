using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyserApplication
{
    public class CensusAnalyser
    {
        //censusList contains the India Census Data And India State Code Data
        public List<CensusDAO> censusList = new List<CensusDAO>();
        
        //usCensusList contains the US Census Data 
        public List<USCensusDAO> usCensusList = new List<USCensusDAO>();
        public Dictionary<string, CensusDAO> csvFileMap = new Dictionary<string, CensusDAO>();

        /// <summary>
        /// This Method takes the input path of Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public int LoadIndiaCensusData(string path)
        {
            DataTable csvCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvCensusData = csvBuilder.LoadData(csvCensusData, path);
            censusList = ConvertToList.IndiaCensusDataInList(csvCensusData, censusList);
            return censusList.Count();
        }

        /// <summary>
        ///  This Method takes the input path of StateCode Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India StateCode CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public int LoadIndiaStateCodeData(string path)
        {
            DataTable csvStateCodeData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvStateCodeData = csvBuilder.LoadData(csvStateCodeData, path);
            censusList = ConvertToList.IndiaStateDataInList(csvStateCodeData, censusList);
            return censusList.Count();
        }

        /// <summary>
        /// This Method takes the input path of US Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of US Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public int LoadUsCensusData(string path)
        {
            DataTable usCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            usCensusData = csvBuilder.LoadData(usCensusData, path);
            usCensusList = ConvertToList.USCensusDataInList(usCensusData, usCensusList);
            return usCensusList.Count();
         }

        /// <summary>
        /// This Method is used to check whether the list is empty if empty it will through Exception
        /// </summary>
        /// <param name="censusList">Parameter CensusList contains the Loaded Data</param>
        /// <returns>if it has data it returns true</returns>
        public bool CheckListEmpty(List<CensusDAO> censusList)
        {
            if (censusList == null || censusList.Count() == 0)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            return true;
        }

        /// <summary>
        /// This Method is used to Convert the Sorted List Data into Json Data Format
        /// </summary>
        /// <param name="list">Parameter List Contains the sorted result </param>
        /// <returns>It returns the Data in Json Format</returns>
        public string ListDataToJsonData(object list)
        {
            string dataInJsonFormat = JsonConvert.SerializeObject(list);
            return dataInJsonFormat;
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Name
        /// </summary>
        /// <returns>It returns the Sorted List to ListDataToJsonData Method</returns>
        public string GetStateWiseSortedCensusData()
        {
            CheckListEmpty(censusList);
            object listAlphabetically = censusList.OrderBy(x => x.state);
            return ListDataToJsonData(listAlphabetically);
        }

        /// <summary>
        /// This Method Used To Sort State Code  Data by State Code
        /// </summary>
        /// <returns>It returns the Sorted List to ListDataToJsonData Method</returns>
        public string GetStateCodeWiseSortedCensusData()
        {
            CheckListEmpty(censusList);
            object listByState = censusList.OrderBy(x => x.state);
            return ListDataToJsonData(listByState);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Population
        /// </summary>
        /// <returns>It returns the Sorted List to ListDataToJsonData Method</returns>
        public string GetPopulationWiseSortedCensusData()
        {
            CheckListEmpty(censusList);
            object listByPopulation = censusList.OrderBy(x => x.population).Reverse();
            return ListDataToJsonData(listByPopulation);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by Density
        /// </summary>
        /// <returns>It returns the Sorted List to ListDataToJsonData Method</returns>
        public string GetPopulationDensityWiseSortedCensusData()
        {
            CheckListEmpty(censusList);
            object listByPopulationDensity = censusList.OrderBy(x => x.densityPerSqKm).Reverse();
            return ListDataToJsonData(listByPopulationDensity);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Area
        /// </summary>
        /// <returns>It returns the Sorted List to ListDataToJsonData Method</returns>
        public string GetAreaWiseSortedCensusData()
        {
            CheckListEmpty(censusList);
            object listByArea = censusList.OrderBy(x => x.areaInSqKm).Reverse();
            return ListDataToJsonData(listByArea);
        }

        
    }
}