using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic.FileIO;

namespace CensusAnalyserApplication
{
    public class CensusAnalyser
    {
        /// <summary>
        /// This Method takes the input path of Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public DataTable LoadIndiaCensusData(string path)
        {
            DataTable csvCensusData = new DataTable();
            csvCensusData = new OpenCSVBuilder().LoadData(csvCensusData, path);
            return csvCensusData;
        }

        /// <summary>
        ///  This Method takes the input path of StateCode Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India StateCode CSV File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public DataTable LoadIndiaStateCodeData(string path)
        {
            DataTable csvStateCodeData = new DataTable();
            csvStateCodeData = new OpenCSVBuilder().LoadData(csvStateCodeData, path);
            return csvStateCodeData;
        }

       
    }
}
