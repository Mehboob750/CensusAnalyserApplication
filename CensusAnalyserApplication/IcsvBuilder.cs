using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CensusAnalyserApplication
{
    public interface IcsvBuilder
    { 
        public DataTable LoadData(DataTable csvData, string path);
    }
}
