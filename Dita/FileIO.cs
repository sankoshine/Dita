using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace Dita
{
    class FileIO
    {
        public static List<string> importTXT(string filepath)
        {
            var reader = new StreamReader(File.OpenRead(filepath), System.Text.Encoding.Default);
            List<string> list = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                list.Add(line);
            }
            return list;
        }

        public static string outputTXT(string filepath, List<string> list)
        {
            var csv = new StringBuilder();
            foreach(string line in list)
            {
                csv.AppendLine(line);
            }
            File.AppendAllText(filepath, csv.ToString(), System.Text.Encoding.Default);
            return csv.ToString();
        }
          
        public static List< List<string> > importXLS(string filepath)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filepath);
            Excel.Worksheet xlWorkSheet = xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorkSheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            List< List<string> >  list = new List< List<string> > ();
            List<string> inner;

            for(int i = 1; i <= rowCount; i++)
            {
                inner = new List<string>();
                for(int j = 1; j <= colCount; j++)
                {
                    inner.Add(xlRange.Cells[i,j].Value2.ToString());
                }
                list.Add(inner);
            }

            object misValue = System.Reflection.Missing.Value;
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            return list;
        }
    }
}
