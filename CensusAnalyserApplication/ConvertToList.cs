using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CensusAnalyserApplication
{
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
        public static List<CensusDAO> IndiaCensusDataInList(DataTable csvCensusData,List<CensusDAO> censusList)
        {
            for (int counter = 0; counter < csvCensusData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.state = csvCensusData.Rows[counter]["State"].ToString();
                censusDAO.population = Convert.ToInt32(csvCensusData.Rows[counter]["Population"].ToString());
                censusDAO.densityPerSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["DensityPerSqKm"].ToString());
                censusDAO.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[counter]["AreaInSqKm"].ToString());
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
            for (int counter = 0; counter < csvStateCodeData.Rows.Count; counter++)
            {
                CensusDAO censusDAO = new CensusDAO();
                censusDAO.srNo = Convert.ToInt32(csvStateCodeData.Rows[counter]["SrNo"].ToString());
                censusDAO.state = csvStateCodeData.Rows[counter]["StateName"].ToString();
                censusDAO.tin = Convert.ToInt32(csvStateCodeData.Rows[counter]["TIN"].ToString());
                censusDAO.stateCode = csvStateCodeData.Rows[counter]["StateCode"].ToString();
                censusList.Add(censusDAO);
            }
            return censusList;
        }

        /// <summary>
        /// This Method is Used To Convert the Loaded US Census Data into List
        /// </summary>
        /// <param name="usCensusData">Parameter contains the Loaded Data of US Census in DataTable Format</param>
        /// <param name="usCensusList">It returns the Converted data in List Format</param>
        /// <returns></returns>
        public static List<USCensusDAO> USCensusDataInList(DataTable usCensusData, List<USCensusDAO> usCensusList)
        {
            for (int counter = 0; counter < usCensusData.Rows.Count; counter++)
            {
                USCensusDAO usCensusDAO = new USCensusDAO();
                usCensusDAO.stateId = usCensusData.Rows[counter]["StateId"].ToString();
                usCensusDAO.state = usCensusData.Rows[counter]["State"].ToString();
                usCensusDAO.population = Convert.ToDouble(usCensusData.Rows[counter]["Population"].ToString());
                usCensusDAO.housingUnits = Convert.ToDouble(usCensusData.Rows[counter]["Housingunits"].ToString());
                usCensusDAO.totalArea = Convert.ToDouble(usCensusData.Rows[counter]["Totalarea"].ToString());
                usCensusDAO.waterArea = Convert.ToDouble(usCensusData.Rows[counter]["Waterarea"].ToString());
                usCensusDAO.landArea = Convert.ToDouble(usCensusData.Rows[counter]["Landarea"].ToString());
                usCensusDAO.populationDensity = Convert.ToDouble(usCensusData.Rows[counter]["PopulationDensity"].ToString());
                usCensusDAO.housingDensity = Convert.ToDouble(usCensusData.Rows[counter]["HousingDensity"].ToString());
                usCensusList.Add(usCensusDAO);
            }
            return usCensusList;
        }
    }
}
