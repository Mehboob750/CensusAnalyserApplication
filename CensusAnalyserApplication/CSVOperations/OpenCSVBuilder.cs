namespace CensusAnalyserApplication
{
    using System;
    using System.Data;
    using System.IO;

    /// <summary>
    /// This class load the data from CSV file
    /// </summary>
    public class OpenCSVBuilder : IcsvBuilder
    {
        /// <summary>
        /// This Method is Used to Load both Census And StateCode data
        /// </summary>
        /// <param name="csvData">parameter is the object of DataTable to store the loaded data</param>
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

                    // While Loop is used to iterate through csv File
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
            catch (ArgumentNullException e)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.ValueCanNotBeNull, e.Message);
            }

            return csvData;
        }
    }
}