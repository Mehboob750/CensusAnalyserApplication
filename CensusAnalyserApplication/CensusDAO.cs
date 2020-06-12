using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserApplication
{ 
    public class CensusDAO
    {
        public String state;
        public double population;
        public double densityPerSqKm;
        public double areaInSqKm;
        public double totalArea;
        public double populationDensity;
        public String stateId;
        public String stateCode;
        public double tin;
        public double srNo;



        public CensusDAO()
        {
        }

        public CensusDAO(IndiaCensusCSV indiaCensusCSV)
        {
            state = indiaCensusCSV.State;
            areaInSqKm = indiaCensusCSV.AreaInSqKm;
            populationDensity = indiaCensusCSV.DensityPerSqKm;
            population = indiaCensusCSV.Population;
        }

    }
}
