namespace CensusAnalyserApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// This Class contains the Method Which is Used to Convert The Loaded Data into the List
    /// </summary>
   public class ConvertToList
    {
        /// <summary>
        /// This Method is Used To Convert the Loaded India Census Data into List
        /// </summary>
        /// <param name="csvCensusData">Parameter contains the Loaded Data of Indian Census in DataTable Format</param>
        /// <param name="censusList">It is an object of list to store the data in list </param>
        /// <returns>It returns the Converted data in List Format</returns>
        public static List<CensusDAO> IndiaCensusDataInList(DataTable csvCensusData, List<CensusDAO> censusList)
        {
            // For Loop is Used To Iterate through DataTable
            for (int counter = 0; counter < csvCensusData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.State = csvCensusData.Rows[counter]["State"].ToString();
                censusDAO.Population = Convert.ToInt32(csvCensusData.Rows[counter]["Population"].ToString());
                censusDAO.DensityPerSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["DensityPerSqKm"].ToString());
                censusDAO.AreaInSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["AreaInSqKm"].ToString());
                censusList.Add(censusDAO);
            }

            return censusList;
        }

        /// <summary>
        /// This Method is Used To Convert the Loaded India State Code Data into List
        /// </summary>
        /// <param name="csvStateCodeData">Parameter contains the Loaded Data of Indian State Code in DataTable Format</param>
        /// <param name="censusList">It is an object of list to store the data in list </param>
        /// <returns>It returns the Converted data in List Format</returns>
        public static List<CensusDAO> IndiaStateDataInList(DataTable csvStateCodeData, List<CensusDAO> censusList)
        {
            // For Loop is Used To Iterate through DataTable
            for (int counter = 0; counter < csvStateCodeData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.SrNo = Convert.ToInt32(csvStateCodeData.Rows[counter]["SrNo"].ToString());
                censusDAO.State = csvStateCodeData.Rows[counter]["StateName"].ToString();
                censusDAO.Tin = Convert.ToInt32(csvStateCodeData.Rows[counter]["TIN"].ToString());
                censusDAO.StateCode = csvStateCodeData.Rows[counter]["StateCode"].ToString();
                censusList.Add(censusDAO);
            }

            return censusList;
        }

        /// <summary>
        /// This Method is Used To Convert the Loaded US Census Data into List
        /// </summary>
        /// <param name="unitedStateCensusData">Parameter contains the Loaded Data of US Census in DataTable Format</param>
        /// <param name="unitedStateCensusList">It gives the Converted data in List Format</param>
        /// <returns>It returns the Converted data in List Format</returns>
        public static List<CensusDAO> USCensusDataInList(DataTable unitedStateCensusData, List<CensusDAO> unitedStateCensusList)
        {
            // For Loop is Used To Iterate through DataTable
            for (int counter = 0; counter < unitedStateCensusData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.StateId = unitedStateCensusData.Rows[counter]["StateId"].ToString();
                censusDAO.State = unitedStateCensusData.Rows[counter]["State"].ToString();
                censusDAO.Population = Convert.ToDouble(unitedStateCensusData.Rows[counter]["Population"].ToString());
                censusDAO.HousingUnits = Convert.ToDouble(unitedStateCensusData.Rows[counter]["Housingunits"].ToString());
                censusDAO.TotalArea = Convert.ToDouble(unitedStateCensusData.Rows[counter]["Totalarea"].ToString());
                censusDAO.WaterArea = Convert.ToDouble(unitedStateCensusData.Rows[counter]["Waterarea"].ToString());
                censusDAO.LandArea = Convert.ToDouble(unitedStateCensusData.Rows[counter]["Landarea"].ToString());
                censusDAO.PopulationDensity = Convert.ToDouble(unitedStateCensusData.Rows[counter]["PopulationDensity"].ToString());
                censusDAO.HousingDensity = Convert.ToDouble(unitedStateCensusData.Rows[counter]["HousingDensity"].ToString());
                unitedStateCensusList.Add(censusDAO);
            }

            return unitedStateCensusList;
        }
    }
}
