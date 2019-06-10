using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;


namespace UrisGroup
{
    static class CSV
    {

       public static void CreateData(string jn)
        {

            int SER = 001;
            using (var reader = new StreamReader(@"C:\TEST FOLDER\BBS\URIS_EXP.CSV")) //load CSV from BBS
            using (var csv = new CsvReader(reader))



            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.

                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);


                    DataColumn newCol = new DataColumn("SER", typeof(string));
                    DataColumn newCol1 = new DataColumn("bmbarcode1", typeof(string));
                    DataColumn newCol2 = new DataColumn("bmbarcode2", typeof(string));
                    DataColumn newCol3 = new DataColumn("bmbarcode3", typeof(string));
                    DataColumn newCol4 = new DataColumn("bmbarcode4", typeof(string));
                    DataColumn newCol5 = new DataColumn("JobNumber", typeof(string));

                    // Add new columns for Barcodes
                    dt.Columns.Add(newCol);
                    dt.Columns.Add(newCol1);
                    dt.Columns.Add(newCol2);
                    dt.Columns.Add(newCol3);
                    dt.Columns.Add(newCol4);
                    dt.Columns.Add(newCol5);

                    //Set positon of new columns
                    newCol.SetOrdinal(0);
                    newCol1.SetOrdinal(1);
                    newCol2.SetOrdinal(2);
                    newCol3.SetOrdinal(3);
                    newCol4.SetOrdinal(4);
                    newCol5.SetOrdinal(5);


                    foreach (DataRow row in dt.Rows)
                    {
                        row["SER"] = SER.ToString("000");
                        row["BMbarcode1"] = SER.ToString("*0000000") + "0104*";   // 0000 SER 0104 
                        row["BMbarcode2"] = SER.ToString("*0000000") + "0204*";   //  0000 SER 0204
                        row["BMbarcode3"] = SER.ToString("*0000000") + "0304*";   //  0000 SER 0304
                        row["BMbarcode4"] = SER.ToString("*0000000") + "0404*";   //  0000 SER 0404   
                        row["JobNumber"] = jn;

                        SER++;

                    }


                    //ToCSV(dt, @"C:\TEST FOLDER\Test.csv");

                    using (var textWriter = File.CreateText(@"C:\TEST FOLDER\output.txt"))
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
        
    }


}



    

