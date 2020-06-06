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
                using(TextFieldParser csvReader = new TextFieldParser(path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] fieldsOfFile = csvReader.ReadFields();
                    foreach(string field in fieldsOfFile)
                    {
                        DataColumn dataColumn = new DataColumn(field);
                        csvFile.Columns.Add(dataColumn);
                    }
                    while(!csvReader.EndOfData)
                    {
                        string[] rowsOfFile = csvReader.ReadFields();
                        csvFile.Rows.Add(rowsOfFile);
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
