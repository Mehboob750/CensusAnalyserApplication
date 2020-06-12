using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserApplication
{ 
    public class CensusDAO
    {
        /// <summary>
        /// Fields Which Are Used In Indian Census Data
        /// </summary>
        public String state;
        public double population;
        public double densityPerSqKm;
        public double areaInSqKm;
        public String stateId;
        public String stateCode;
        public double tin;
        public double srNo;

        /// <summary>
        /// Fields Which Are Used In US Census Data
        /// </summary>
        public double housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        /// <summary>
        /// Default Constructor;
        /// </summary>
        public CensusDAO()
        {
        }
    }
}
