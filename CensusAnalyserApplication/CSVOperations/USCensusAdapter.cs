namespace CensusAnalyserApplication
{
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// This class is used to read the data from US CSV File
    /// </summary>
    public class USCensusAdapter
    {
        /// <summary>
        /// unitedStateCensusList contains the US Census Data 
        /// </summary>
        private List<CensusDAO> unitedStateCensusList = new List<CensusDAO>();

        /// <summary>
        /// This Method takes the input path of US Census CSV File and give to the LoadData Method
        /// </summary>
        /// <param name="csvFilePath">parameter contains the path of US Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public List<CensusDAO> LoadUSCensusData(string csvFilePath)
        {
            DataTable unitedStateCensusData = new DataTable();
            IcsvBuilder csvBuilder = CSVBuilderFactory.CreateCSVBuilder();
            unitedStateCensusData = csvBuilder.LoadData(unitedStateCensusData, csvFilePath);
            this.unitedStateCensusList = ConvertToList.USCensusDataInList(unitedStateCensusData, this.unitedStateCensusList);
            return this.unitedStateCensusList;
        }
    }
}
