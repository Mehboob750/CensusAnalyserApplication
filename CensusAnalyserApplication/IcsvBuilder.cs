using System.Data;

namespace CensusAnalyserApplication
{
    /// <summary>
    /// Created Interface IcsvBuilder to accsess LoadData Method Globally
    /// </summary>
    public interface IcsvBuilder
    {
        //Accecc LoadData Method Globally
        public DataTable LoadData(DataTable csvData, string path);
    }
}
