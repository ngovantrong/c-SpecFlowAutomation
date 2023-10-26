using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace FINWebUIAutomation.Support
{
    public static class ExcelOperations
    {
        public static DataTable ExcelToDataTable(string fileName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //open file and returns as Stream
            FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
                                                                                           //Set the First Row as Column Name
                                                                                           //excelReader.IsFirstRowAsColumnNames = true;
                                                                                           //Return as DataSet
            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                {
                    UseHeaderRow = true
                }
            });
            //Get all the Tables
            DataTableCollection table = resultSet.Tables;
            //Store it in DataTable
            DataTable resultTable = table["Sheet1"];
            return resultTable;

        }


        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static List<Datacollection> dataCol = new List<Datacollection>();
        static int totalRowCount = 0;

        public static int GetTotalRowCount()
        {
            return totalRowCount;

        }

        public static void PopulateInCollection(string fileName)
        {
            DataTable table = ExcelToDataTable(fileName);
            totalRowCount = table.Rows.Count;

            dataCol = new List<Datacollection>();

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }


        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                //Retriving Data using LINQ to reduce much of iterations 
                String data = (from item in dataCol
                               where item.colName == columnName && item.rowNumber == rowNumber
                               select item.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

