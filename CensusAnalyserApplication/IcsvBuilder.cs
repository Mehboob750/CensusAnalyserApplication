using System.Data;

namespace CensusAnalyserApplication
{
    /// <summary>
    /// Created Interface IcsvBuilder to accsess LoadData Method Globally
    /// </summary>
    public interface IcsvBuilder
    {
        public DataTable LoadData(DataTable csvData, string path);
    }
}
