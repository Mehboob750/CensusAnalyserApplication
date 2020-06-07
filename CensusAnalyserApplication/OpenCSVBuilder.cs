using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CensusAnalyserApplication
{
    public class OpenCSVBuilder : IcsvBuilder
    {
        /// <summary>
        /// This Method is Used to Load both Census And StateCode data
        /// </summary>
        /// <param name="csvData">csvData parameter is the object of DataTable to store the loaded data</param>
        /// <param name="path">path parameter contains the path of the CSV File</param>
        /// <returns>It returns the loaded data</returns>
        public DataTable LoadData(DataTable csvData, string path)
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
