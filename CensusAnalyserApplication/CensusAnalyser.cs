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
        public static DataTable LoadIndiaCensusData(string path)
        {
            DataTable csvFile = new DataTable();

            try
            {
                using(StreamReader csvReader = new StreamReader(path))
                {
                    string[] headers = csvReader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        csvFile.Columns.Add(header);
                    }
                    while (!csvReader.EndOfStream)
                    {
                        string[] rows = csvReader.ReadLine().Split(',');
                        DataRow dataRow = csvFile.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        csvFile.Rows.Add(dataRow);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.CensusFileProblem,e.Message);
            }
            return csvFile;
        }
    }
}
