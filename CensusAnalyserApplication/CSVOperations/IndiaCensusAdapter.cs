namespace CensusAnalyserApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// This class is used to read the Indian CSV Files
    /// </summary>
    public class IndiaCensusAdapter
    {
        /// <summary>
        /// indiaCensusList contains the India Census Data And India State Code Data
        /// </summary>
        private List<CensusDAO> censusList = new List<CensusDAO>();

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
                {
                    return this.LoadIndiaStateCodeData(csvFilePath);
                }

                return this.LoadIndiaCensusData(csvFilePath);
            }
            catch (NullReferenceException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.Message);
            }
        }

        /// <summary>
        /// This Method takes the input path of India Census CSV File and give to the LoadData Method
        /// </summary>
        /// <param name="csvFilePath">parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public List<CensusDAO> LoadIndiaCensusData(string csvFilePath)
        {
            DataTable csvCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            csvCensusData = csvBuilder.LoadData(csvCensusData, csvFilePath);
            this.censusList = ConvertToList.IndiaCensusDataInList(csvCensusData, this.censusList);
            return this.censusList;
        }

        /// <summary>
        ///  This Method takes the input path of StateCode CSV File and give to the LoadData Method
        /// </summary>
        /// <param name="csvFilePath">parameter contains the path of India StateCode CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public List<CensusDAO> LoadIndiaStateCodeData(string csvFilePath)
        {
            DataTable csvStateCodeData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            csvStateCodeData = csvBuilder.LoadData(csvStateCodeData, csvFilePath);
            this.censusList = ConvertToList.IndiaStateDataInList(csvStateCodeData, this.censusList);
            return this.censusList;
        }
    }
}
