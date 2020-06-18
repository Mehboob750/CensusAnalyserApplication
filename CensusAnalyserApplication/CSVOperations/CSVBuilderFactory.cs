namespace CensusAnalyserApplication
{
    /// <summary>
    /// This Class is created to remove the relation of Census analyzer with LoadCSVData 
    /// </summary>
    public class CSVBuilderFactory
    {
        /// <summary>
        /// This Method is used to create object of OpenCSVBuilder
        /// </summary>
        /// <returns>It returns the object of OpenCSVBuilder Class</returns>
        public static IcsvBuilder CreateCSVBuilder()
        {
            return new OpenCSVBuilder();
        }
    }
}
