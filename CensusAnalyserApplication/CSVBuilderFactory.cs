using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserApplication
{
    public class CSVBuilderFactory
    {
        public static IcsvBuilder createCSVBuilder()
        {
            return new OpenCSVBuilder();
        }
    }
}
