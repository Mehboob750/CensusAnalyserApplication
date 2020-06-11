using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CensusAnalyserApplication
{
    public class CensusAnalyser
    {
        public List<IndiaCensusCSV> censusList = new List<IndiaCensusCSV>();

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
            for(int counter=0; counter<csvCensusData.Rows.Count;counter++)
            {
                IndiaCensusCSV indiaCensus = new IndiaCensusCSV();
                indiaCensus.State = csvCensusData.Rows[counter]["State"].ToString();
                indiaCensus.Population = Convert.ToInt32(csvCensusData.Rows[counter]["Population"].ToString());
                indiaCensus.DensityPerSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["DensityPerSqKm"].ToString());
                indiaCensus.AreaInSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["AreaInSqKm"].ToString());
                censusList.Add(indiaCensus);
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
            List<IndiaStateCodeCSV> stateCodeList = new List<IndiaStateCodeCSV>();
            for (int counter = 0; counter < csvStateCodeData.Rows.Count; counter++)
            {
                IndiaStateCodeCSV indiaStateCode = new IndiaStateCodeCSV();
                indiaStateCode.SrNo = Convert.ToInt32(csvStateCodeData.Rows[counter]["SrNo"].ToString());
                indiaStateCode.StateName = csvStateCodeData.Rows[counter]["StateName"].ToString();
                indiaStateCode.TIN = Convert.ToInt32(csvStateCodeData.Rows[counter]["TIN"].ToString());
                indiaStateCode.StateCode = csvStateCodeData.Rows[counter]["StateCode"].ToString();
                stateCodeList.Add(indiaStateCode);
            }
            return stateCodeList.Count();
        }

        public string GetStateWiseSortedCensusData()
        {
            if (censusList == null || censusList.Count() == 0)
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            object listAlphabetically = censusList.OrderBy(x => x.State);
            string dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically);
            return dataInJsonFormat;
        }

    }
}