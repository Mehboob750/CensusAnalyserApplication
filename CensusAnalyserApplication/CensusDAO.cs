namespace CensusAnalyserApplication
{
    using System;

    /// <summary>
    /// This Class is used to Access the Fields of CSV files
    /// </summary>
    public class CensusDAO
    {
        /// <summary>
        /// It stores the State Field of CSV file
        /// </summary>
        public string State;

        /// <summary>
        /// It stores the population Field of CSV file
        /// </summary>
        public double Population;

        /// <summary>
        /// It stores the density Field of CSV file
        /// </summary>
        public double DensityPerSqKm;

        /// <summary>
        /// It stores the area Field of CSV file
        /// </summary>
        public double AreaInSqKm;

        /// <summary>
        /// It stores the State Id Field of CSV file
        /// </summary>
        public string StateId;

        /// <summary>
        /// It stores the State code Field of CSV file
        /// </summary>
        public string StateCode;

        /// <summary>
        /// It stores the Tin Field of CSV file
        /// </summary>
        public double Tin;

        /// <summary>
        /// It stores the serial number Field of CSV file
        /// </summary>
        public double SrNo;

        /// <summary>
        /// It stores the housing units Field of CSV file
        /// </summary>
        public double HousingUnits;

        /// <summary>
        /// It stores the Total area Field of CSV file
        /// </summary>
        public double TotalArea;

        /// <summary>
        /// It stores the water area Field of CSV file
        /// </summary>
        public double WaterArea;

        /// <summary>
        /// It stores the land area Field of CSV file
        /// </summary>
        public double LandArea;

        /// <summary>
        /// It stores the population density Field of CSV file
        /// </summary>
        public double PopulationDensity;

        /// <summary>
        /// It represent the serial number Field of CSV file
        /// </summary>
        public double HousingDensity;

        /// <summary>
        /// Default Constructor;
        /// </summary>
        public CensusDAO()
        {
        }
    }
}
