namespace CensusAnalyserApplication
{
    using System.Data;

    /// <summary>
    /// Created Interface ICSVBuilder to access LoadData Method Globally
    /// </summary>
    public interface IcsvBuilder
    {
        /// <summary>
        /// Access LoadData Method Globally
        /// </summary>
        /// <param name="csvData">It is the reference of Data Table</param>
        /// <param name="path">It stores the path of CSV file</param>
        /// <returns>It returns the loaded data in data table format</returns>
        public DataTable LoadData(DataTable csvData, string path);
    }
}
