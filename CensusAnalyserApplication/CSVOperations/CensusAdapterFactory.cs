namespace CensusAnalyserApplication
{
    using System.Collections.Generic;

    /// <summary>
    /// It is an Adapter Class
    /// </summary>
    public class CensusAdapterFactory
    {
        /// <summary>
        /// This Method check the Country and According to country that Adapter Class is return
        /// </summary>
        /// <param name="country">It contains the country name</param>
        /// <param name="csvFilePath">It contains the CSV File Path</param>
        /// <returns>It returns the Adapter Class Based On Country</returns>
        public List<CensusDAO> LoadCensusData(CensusAnalyser.Country country, string csvFilePath)
        {
            // Check the country is Equal to India or US
            if (country.Equals(CensusAnalyser.Country.INDIA))
            {
                return new IndiaCensusAdapter().LoadCensusData(csvFilePath);
            }
            else if (country.Equals(CensusAnalyser.Country.US))
            {
                return new USCensusAdapter().LoadUSCensusData(csvFilePath);
            }
            else
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.InvalidCountry, "Invalid Country");
            }
        }
    }
}
