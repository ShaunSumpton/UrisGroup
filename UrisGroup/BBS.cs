using System;
using System.IO;
using SortAndSave;
using MadMilkman.Ini;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.Office.Interop;

namespace UrisGroup
{
    public class BBS
    {

        private static readonly string InstallFlder = "C:\\SORTANDSAVE\\SYSTEM\\";             // set sort and save system folder
        

        public static void BBSNow(String en, String md, String jn,bool csv,string TypeCheck)
        {

            DateTime Newmd = DateTime.Parse(md);                                  // Mail Date
            string ex;
            
            string dir = Path.GetDirectoryName(en);                                //Get directory we are working in
            //Directory.CreateDirectory(dir + "\\" + "BBS\\");                     // create a folder for BBS Files



            // check if we are extracting a csv or xls

            if (csv == true)
            {
                // open excel import csv and save as xls
                CSV.ConvertCSV(jn, dir);

            }
            else
            {

                CSV.TocCsvthenXLS(jn, dir);
                //CSV.ConvertCSV(jn, dir);

                // Tidy up xls


                ex = ".xls";
            }

            
            BBSAPI.ResetMailingOptions();
            BBSAPI.SetInstallationFolder(InstallFlder);
            BBSAPI.SetOutputBase(dir + "\\" + "BBS\\");
            BBSAPI.SetWeight(30);
            BBSAPI.SetDescription(jn);
            BBSAPI.SetReference(jn);
            BBSAPI.SetCollectionDate(Newmd.ToString("yyyyMMdd"));
            BBSAPI.SetHandoverDate(Newmd.AddDays(1).ToString("yyyymmdd"));
            BBSAPI.SetInput(1,dir + "\\" + jn  + ".xls");
            //BBSAPI.SetTable(1, "One Call Fulfillment Template -$");

            

            int result = BBSAPI.RunMailingJob(UrisGroup.fn);
            string dataSr;
            string FlePth = dir + "\\" + jn + ".xls";

            // MessageBox.Show(result.ToString());

            //load and write to job file for mailing email

            if (UrisGroup.tc == "OneCall")
            {
                dataSr = @"""OneCall"",""OneCall""," + FlePth + @",""31/12/2199"",""'One Call Fulfillment Template -$'""";
                File.Copy(@"G:\Development\BBS Definition Files\URISOA.JOB", dir + "\\BBS\\URIS.JOB");
            }
            else
            {
                dataSr = @"""AutoNet"",""AutoNet""," + FlePth + @",""31/12/2199"",""'AG Tab$'""";
                File.Copy(@"G:\Development\BBS Definition Files\URISOA.JOB", dir + "\\BBS\\URIS.JOB");
            }



            var MyIni = new IniFile(dir + "\\BBS\\URIS.JOB");

            MyIni.Write("Weight", "30", "InitialInfo");
            MyIni.Write("OutputBase", dir + "\\" + "BBS", "InitialInfo");
            MyIni.Write("Description", jn + " URIS", "InitialInfo");
            MyIni.Write("JobReference", jn + " URIS", "InitialInfo");
            MyIni.Write("CollectionDate", Newmd.ToString("dd/MM/yyyy"), "InitialInfo");
            MyIni.Write("HandoverDate", Newmd.AddDays(1).ToString("dd/MM/yyyy"), "InitialInfo");
            MyIni.Write("", dataSr, "Data Sources");

           
            
           

            string text = File.ReadAllText(dir + "\\BBS\\URIS.JOB");
            text = text.Replace(((char)34).ToString() + "=", ((char)34).ToString());
            text = text.Replace("=" + ((char)34).ToString(), ((char)34).ToString());
            File.WriteAllText(dir + "\\BBS\\URIS.JOB", text);

            // clean up files

            File.Delete(dir + "\\" + jn + ".IMD");
            File.Delete(dir + "\\" + jn + ".EXD");

            //File.Delete(dir + "\\BBS\\URIS.JOB");
            //File.Copy(UrisGroup.fn, dir + "\\BBS\\URIS.JOB");

        }



    }

}
