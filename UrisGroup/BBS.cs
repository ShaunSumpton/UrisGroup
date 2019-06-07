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

        static private string InstallFlder = "C:\\SORTANDSAVE\\SYSTEM\\";             // set sort and save system folder
        

        public static void BBSNow(String en, String md, String jn)
        {
           
            DateTime Newmd = DateTime.Parse(md);                                    // Mail Date
            string dir = Path.GetDirectoryName(en);                                //Get directory we are working in
            Directory.CreateDirectory(dir + "\\" + "BBS\\");                      // create a folder for BBS Files


            File.Copy("G:\\Development\\BBS Definition Files\\OneCall.EXD", dir + "\\" + jn + ".EXD");
            File.Copy("G:\\Development\\BBS Definition Files\\OneCall.EXD", dir + "\\" + jn + ".IMD");

            BBSAPI.ResetMailingOptions();
            BBSAPI.SetInstallationFolder(InstallFlder);
            BBSAPI.SetOutputBase(dir + "\\" + "BBS\\");
            BBSAPI.SetWeight(30);
            BBSAPI.SetDescription(jn);
            BBSAPI.SetReference(jn);
            BBSAPI.SetCollectionDate(Newmd.ToString("yyyyMMdd"));
            BBSAPI.SetHandoverDate(Newmd.AddDays(1).ToString("yyyymmdd"));
            BBSAPI.SetInput(1,dir + "\\" + jn  + ".xls");


           // BBSAPI.SetTable(1, "One Call Fulfillment Template -");


            string mjob = "G:\\Development\\BBS Definition Files\\URIS.JOB";
            int result = BBSAPI.RunMailingJob(mjob);

            MessageBox.Show(result.ToString());

            //load and write to job file for mailing email

            var MyIni = new IniFile("G:\\Development\\BBS Definition Files\\URIS.JOB");

            MyIni.Write("Weight", "30", "InitialInfo");
            MyIni.Write("OutputBase", dir + "\\" + "BBS", "InitialInfo");
            MyIni.Write("Description", jn + " URIS", "InitialInfo");
            MyIni.Write("JobReference", jn + " URIS", "InitialInfo");


            // clean up files

            File.Delete(dir + "\\" + jn + ".IMD");
            File.Delete(dir + "\\" + jn + ".EXD");
            File.Delete(dir + "\\BBS\\URIS.JOB");

            File.Copy("G:\\Development\\BBS Definition Files\\URIS.JOB", dir + "\\BBS\\URIS.JOB");

        }



    }

}
