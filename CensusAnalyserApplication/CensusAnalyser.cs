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
        public List<IndiaStateCodeCSV> stateCodeList = new List<IndiaStateCodeCSV>();
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

        public string GetStateWiseSortedCensusData()
        {
            if (censusList == null || censusList.Count() == 0)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            object listAlphabetically = censusList.OrderBy(x => x.state);
            string dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically);
            return dataInJsonFormat;
        }

        public string GetStateCodeWiseSortedCensusData()
        {
            if (censusList == null || censusList.Count() == 0)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            object listAlphabetically = censusList.OrderBy(x => x.stateCode);
            string dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically);
            return dataInJsonFormat;
        }

        public string GetPopulationWiseSortedCensusData()
        {
            if (censusList == null || censusList.Count() == 0)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            object listByPopulation = censusList.OrderBy(x => x.population);
            string dataInJsonFormat = JsonConvert.SerializeObject(listByPopulation);
            return dataInJsonFormat;
        }
    }
}