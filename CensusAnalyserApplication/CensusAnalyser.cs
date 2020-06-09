using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            List<IndiaCensusCSV> censusList = new List<IndiaCensusCSV>();
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

        public int readfromfile(string path)
        {
            var lines = System.IO.File.ReadAllLines(path).Skip(1).TakeWhile(t => t != null);
            foreach (string item in lines)
            { 
                var values = item.Split(',');
                censusList.Add(new IndiaCensusCSV()
                {
                    State = values[0],
                    Population = int.Parse(values[1]),
                    AreaInSqKm = int.Parse(values[2]),
                    DensityPerSqKm = int.Parse(values[3])
                });
            }
            foreach (IndiaCensusCSV s in censusList)
            {
                Console.WriteLine(s.State +"\t"+s.Population+"\t"+s.AreaInSqKm+"\t"+s.DensityPerSqKm);
            }
            return censusList.Count();
        }
    }
}