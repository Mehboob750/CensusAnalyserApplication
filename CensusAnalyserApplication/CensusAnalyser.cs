namespace CensusAnalyserApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// This class is used to analyze the data Which is Loaded from CSV file
    /// </summary>
    public class CensusAnalyser
    {
        /// <summary>
        /// indiaCensusList contains the India Census Data And India State Code Data
        /// </summary>
        private List<CensusDAO> indiaCensusList = new List<CensusDAO>();

        /// <summary>
        /// unitedStateCensusList contains the US Census Data
        /// </summary>
        private List<CensusDAO> unitedStateCensusList = new List<CensusDAO>();

        /// <summary>
        /// Enum is used to define Enumerated data types
        /// </summary>
        public enum Country
        {
            /// <summary>
            /// It shows the country as India
            /// </summary>
            INDIA,

            /// <summary>
            /// It shows the country as US
            /// </summary>
            US
        }

        /// <summary>
        /// This Method is Uses CensusAdapterFactory to Load Indian Census Data
        /// </summary>
        /// <param name="country">country parameter contains the information of country</param>
        /// <param name="csvFilePath">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public int LoadIndiaCensusData(Country country, string csvFilePath)
        {
            this.indiaCensusList = new CensusAdapterFactory().LoadCensusData(country, csvFilePath);
            return this.indiaCensusList.Count();
        }

        /// <summary>
        /// This Method is Uses CensusAdapterFactory to Load India StateCode Data
        /// </summary>
        /// <param name="country">country parameter contains the information of country</param>
        /// <param name="csvFilePath">path parameter contains the path of India State Code CSV File</param>
        /// <returns>It returns the LoadedData in List</returns>
        public int LoadIndiaStateCodeData(Country country, string csvFilePath)
        {
            this.indiaCensusList = new CensusAdapterFactory().LoadCensusData(country, csvFilePath);
            return this.indiaCensusList.Count();
        }

        /// <summary>
        /// This Method is Uses CensusAdapterFactory to Load India US Census Data
        /// </summary>
        /// <param name="country">country parameter contains the information of country</param>
        /// <param name="csvFilePath">path parameter contains the path of US Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public int LoadUsCensusData(Country country, string csvFilePath)
        {
            this.unitedStateCensusList = new CensusAdapterFactory().LoadCensusData(country, csvFilePath);
            return this.unitedStateCensusList.Count();
        }

        /// <summary>
        /// This Method is used to check whether the list is empty if empty it will through Exception
        /// </summary>
        /// <param name="censusList">Parameter CensusList contains the Loaded Data</param>
        /// <returns>if it has data it returns true</returns>
        public bool CheckListEmpty(List<CensusDAO> censusList)
        {
            // Check if List is Empty or Null
            if (censusList == null || censusList.Count() == 0)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.UnableToParse, "No Census Data");
            }

            return true;
        }

        /// <summary>
        /// This Method is used to Convert the Sorted List Data into JSON Data Format
        /// </summary>
        /// <param name="list">Parameter List Contains the sorted result </param>
        /// <returns>It returns the Sorted Data in JSON Format</returns>
        public string ListDataToJsonData(object list)
        {
            // Serialize the List to the JSON Format
            string dataInJsonFormat = JsonConvert.SerializeObject(list);
            return dataInJsonFormat;
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Name
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetStateWiseSortedCensusData()
        {
            this.CheckListEmpty(this.indiaCensusList);

            // Sort list by using OrderBy Method
            object listAlphabetically = this.indiaCensusList.OrderBy(x => x.State);
            return this.ListDataToJsonData(listAlphabetically);
        }

        /// <summary>
        /// This Method Used To Sort State Code  Data by State Code
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetStateCodeWiseSortedCensusData()
        {
           this.CheckListEmpty(this.indiaCensusList);

            // Sort list by using OrderBy Method
            object listByState = this.indiaCensusList.OrderBy(x => x.StateCode);
            return this.ListDataToJsonData(listByState);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Population
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetPopulationWiseSortedCensusData()
        {
            this.CheckListEmpty(this.indiaCensusList);
            object listByPopulation = this.indiaCensusList.OrderBy(x => x.Population).Reverse();
            return this.ListDataToJsonData(listByPopulation);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by Density
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetPopulationDensityWiseSortedCensusData()
        {
            this.CheckListEmpty(this.indiaCensusList);
            object listByPopulationDensity = this.indiaCensusList.OrderBy(x => x.DensityPerSqKm).Reverse();
            return this.ListDataToJsonData(listByPopulationDensity);
        }

        /// <summary>
        /// This Method Used To Sort Census Data by State Area
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetAreaWiseSortedCensusData()
        {
            this.CheckListEmpty(this.indiaCensusList);
            object listByArea = this.indiaCensusList.OrderBy(x => x.AreaInSqKm).Reverse();
            return this.ListDataToJsonData(listByArea);
        }

        /// <summary>
        /// This Method is used to sort the US census Data by Population
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetPopulationWiseSortedUSCensusData()
        {
            this.CheckListEmpty(this.unitedStateCensusList);
            object listByPopulation = this.unitedStateCensusList.OrderBy(x => x.Population).Reverse();
            return this.ListDataToJsonData(listByPopulation);
        }

        /// <summary>
        /// This Method is used to sort the US census Data by Population Density
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetPopulationDensityWiseSortedUSCensusData()
        {
            this.CheckListEmpty(this.unitedStateCensusList);
            object listByPopulationDensity = this.unitedStateCensusList.OrderBy(x => x.PopulationDensity).Reverse();
            return this.ListDataToJsonData(listByPopulationDensity);
        }

        /// <summary>
        /// This Method is used to sort the US census Data by Area
        /// </summary>
        /// <returns>It returns the Sorted List to List Data To JSON Data Method</returns>
        public string GetAreaWiseSortedUSCensusData()
        {
            this.CheckListEmpty(this.unitedStateCensusList);
            object listByArea = this.unitedStateCensusList.OrderBy(x => x.TotalArea).Reverse();
            return this.ListDataToJsonData(listByArea);
        }
    }
}