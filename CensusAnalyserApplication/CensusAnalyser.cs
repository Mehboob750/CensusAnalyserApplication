using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;

namespace CensusAnalyserApplication
{
    public class CensusAnalyser
    {
        public List<CensusDAO> censusList = new List<CensusDAO>();
        public Dictionary<string, CensusDAO> csvFileMap = new Dictionary<string, CensusDAO>();

        /// <summary>
        /// This Method takes the input path of Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public int LoadIndiaCensusData(string path)
        {
            DataTable csvCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvCensusData = csvBuilder.LoadData(csvCensusData, path);
            for (int counter = 0; counter < csvCensusData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.state = csvCensusData.Rows[counter]["State"].ToString();
                censusDAO.population = Convert.ToInt32(csvCensusData.Rows[counter]["Population"].ToString());
                censusDAO.densityPerSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["DensityPerSqKm"].ToString());
                censusDAO.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["AreaInSqKm"].ToString());
                censusList.Add(censusDAO);
            }
            return censusList.Count();
        }

        /// <summary>
        ///  This Method takes the input path of StateCode Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India StateCode CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public int LoadIndiaStateCodeData(string path)
        {
            DataTable csvStateCodeData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.createCSVBuilder();
            csvStateCodeData = csvBuilder.LoadData(csvStateCodeData, path);
            for (int counter = 0; counter < csvStateCodeData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.srNo = Convert.ToInt32(csvStateCodeData.Rows[counter]["SrNo"].ToString());
                censusDAO.state = csvStateCodeData.Rows[counter]["StateName"].ToString();
                censusDAO.tin = Convert.ToInt32(csvStateCodeData.Rows[counter]["TIN"].ToString());
                censusDAO.stateCode = csvStateCodeData.Rows[counter]["StateCode"].ToString();
                censusList.Add(censusDAO);
            }
            return censusList.Count();
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