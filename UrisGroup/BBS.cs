using System;
using System.IO;
using SortAndSave;
using MadMilkman.Ini;
using System.Windows.Forms;
using System.ComponentModel;

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
                // not really needed at this point
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

           // MessageBox.Show(result.ToString());

            //load and write to job file for mailing email

          

            var MyIni = new IniFile(UrisGroup.fn);

            MyIni.Write("Weight", "30", "InitialInfo");
            MyIni.Write("OutputBase", dir + "\\" + "BBS", "InitialInfo");
            MyIni.Write("Description", jn + " URIS", "InitialInfo");
            MyIni.Write("JobReference", jn + " URIS", "InitialInfo");


            // clean up files

            File.Delete(dir + "\\" + jn + ".IMD");
            File.Delete(dir + "\\" + jn + ".EXD");
            File.Delete(dir + "\\BBS\\URIS.JOB");

            File.Copy(UrisGroup.fn, dir + "\\BBS\\URIS.JOB");

        }



    }

}
