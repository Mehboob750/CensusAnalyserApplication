using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration.Attributes;

namespace CensusAnalyserApplication
{
    public class IndiaCensusCSV
    {
        public string State { get; set; }
        public double Population { get; set; }
        public double AreaInSqKm { get; set; }
        public double DensityPerSqKm { get; set; }

    }
}
