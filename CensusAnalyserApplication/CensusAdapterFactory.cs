using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CensusAnalyserApplication
{
    public class CensusAdapterFactory
    {
        public List<CensusDAO> LoadCensusData(CensusAnalyser.Country country, string csvFilePath)
        {
            if (country.Equals(CensusAnalyser.Country.INDIA))
                return new IndiaCensusAdapter().LoadCensusData(csvFilePath);
            else if (country.Equals(CensusAnalyser.Country.US))
                return new USCensusAdapter().LoadUSCensusData(csvFilePath);
            else
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INVALID_COUNTRY, "Invalid Country");
        }
    }
}
