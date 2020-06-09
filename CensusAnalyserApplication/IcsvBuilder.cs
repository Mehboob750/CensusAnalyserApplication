using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
