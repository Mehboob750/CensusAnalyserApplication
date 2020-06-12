using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CensusAnalyserApplication
{
    public class CensusAdapterFactory
    {
        /// <summary>
        /// This Method check the Country and According to country that Adapter Class is return
        /// </summary>
        /// <param name="country">It contains the country name</param>
        /// <param name="csvFilePath">It contains the csv File Path</param>
        /// <returns>It returns the Adapter Class Based On Country</returns>
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
