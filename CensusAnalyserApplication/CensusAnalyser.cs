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
            DataTable csvCensusData = new DataTable();
            return LoadData(csvCensusData, path);
        }

        public static DataTable LoadIndiaStateCodeData(string path)
        {
            DataTable csvStateCodeData = new DataTable();
            return LoadData(csvStateCodeData, path);
        }

        public static DataTable LoadData(DataTable csvData, string path)
        {
            try
            {
                using (StreamReader csvReader = new StreamReader(path))
                {
                    string[] headers = csvReader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        csvData.Columns.Add(header);
                    }
                    while (!csvReader.EndOfStream)
                    {
                        string[] rows = csvReader.ReadLine().Split(',');
                        DataRow dataRow = csvData.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = rows[i];
                        }
                        csvData.Rows.Add(dataRow);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.CensusFileProblem, e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.IncorrectHeader, e.Message);
            }
            return csvData;
        }
    }
}
