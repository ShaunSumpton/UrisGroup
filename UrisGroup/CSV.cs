using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Table;
using OfficeOpenXml.Drawing.Chart;
using System.Globalization;
using CsvHelper;
using System.Data;



namespace UrisGroup
{
    static class CSV
    {
        

        public static void CreateData(string jn,string en, string typ)
        {

            int SER = 001;
            string dir = Path.GetDirectoryName(en);
            string temp;
            DateTime Newmd = DateTime.Parse(UrisGroup.MailDate);

            if (typ == "OneCall")
            {

                 temp = "URISO";

            }
            else
            {
                temp = "URISA";
            }




            using (var reader = new StreamReader(dir + @"\BBS\"+ temp + @"_EXP.CSV")) //load CSV from BBS
            using (var csv = new CsvReader(reader))



            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.

                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);

                    // Create new columns to be appended the start of the datatable
                    DataColumn newCol = new DataColumn("SER", typeof(string));
                    DataColumn newCol1 = new DataColumn("BMbarcode1", typeof(string));
                    DataColumn newCol2 = new DataColumn("BMbarcode2", typeof(string));
                    DataColumn newCol3 = new DataColumn("BMbarcode3", typeof(string));
                    DataColumn newCol4 = new DataColumn("BMbarcode4", typeof(string));
                    DataColumn newCol5 = new DataColumn("JobNumber", typeof(string));
                    DataColumn newCol6 = new DataColumn("MailDate", typeof(string));

                    // Add new columns for Barcodes
                    dt.Columns.Add(newCol);
                    dt.Columns.Add(newCol1);
                    dt.Columns.Add(newCol2);
                    dt.Columns.Add(newCol3);
                    dt.Columns.Add(newCol4);
                    dt.Columns.Add(newCol5);
                    dt.Columns.Add(newCol6);

                    //Set positon of new columns
                    newCol.SetOrdinal(0);
                    newCol1.SetOrdinal(1);
                    newCol2.SetOrdinal(2);
                    newCol3.SetOrdinal(3);
                    newCol4.SetOrdinal(4);
                    newCol5.SetOrdinal(5);
                    newCol6.SetOrdinal(6);

                    //loop through each row and add data
                    foreach (DataRow row in dt.Rows)
                    {
                        row["SER"] = SER.ToString("000");
                        row["BMbarcode1"] = SER.ToString("*0000000") + "0104*";   // 0000 SER 0104 
                        row["BMbarcode2"] = SER.ToString("*0000000") + "0204*";   //  0000 SER 0204
                        row["BMbarcode3"] = SER.ToString("*0000000") + "0304*";   //  0000 SER 0304
                        row["BMbarcode4"] = SER.ToString("*0000000") + "0404*";   //  0000 SER 0404   
                        row["JobNumber"] = jn;
                        row["MailDate"] = Newmd.ToString("dd MMMM yyyy"); 

                        SER++;

                    }

                   
                    
                    // output to txt file
                    using (var textWriter = File.CreateText(dir + "\\"+ jn + ".txt"))
                    using (var csv1 = new CsvWriter(textWriter))
                    {
                        // Write columns
                        foreach (DataColumn column in dt.Columns)
                        {
                            csv1.WriteField(column.ColumnName);
                        }
                        csv1.NextRecord();

                        // Write row values
                        foreach (DataRow row in dt.Rows)
                        {
                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                csv1.WriteField(row[i]);
                            }
                            csv1.NextRecord();
                        }
                    }





                }


            }
        }

       public static void ReplaceTxt(string en, string jn,string typ)
        {

            string dir = Path.GetDirectoryName(en);

            string str = File.ReadAllText(dir + "\\" + jn + ".txt");
            str = str.Replace("?", "£");
            File.WriteAllText(dir + "\\" + jn + ".txt", str,Encoding.Default);
            File.Move(dir + "\\" + jn + ".txt",dir + "\\" + UrisGroup.tc + ".txt");

            File.Delete(dir + "\\" + jn + ".csv");
            File.Delete(dir + "\\" + jn + ".xls");

        }

       public static void ConvertCSV(string jn, string dir)
        {

            var format = new ExcelTextFormat();
            format.TextQualifier = '"';
            format.Delimiter = ',';
            format.Encoding = new UTF8Encoding();
            format.DataTypes = new eDataTypes[] {eDataTypes.String, eDataTypes.String, eDataTypes.String, eDataTypes.String, eDataTypes.String,
                eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,
                eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,eDataTypes.String,
                eDataTypes.String,eDataTypes.String,eDataTypes.String };
             

            FileInfo file = new FileInfo(dir + "\\" + jn + ".csv");

            using (var p = new ExcelPackage())
            {

                //Add the sheet to the workbook 
                ExcelWorksheet worksheet = p.Workbook.Worksheets.Add("One Call Fulfillment Template -$");

                //change format to text
                worksheet.Cells.Style.Numberformat.Format = "@";

                worksheet.Cells["A1"].LoadFromText(file, format);

            

                //Save the new workbook. We haven't specified the filename so use the Save as method.
                p.SaveAs(new FileInfo(dir + @"\" + jn + ".xls"));
            }





        }



    }

   
}



    

