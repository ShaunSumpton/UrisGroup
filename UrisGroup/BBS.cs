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

        static private string InstallFlder = "C:\\SORTANDSAVE\\SYSTEM\\";
        

        public static void BBSNow(String en, String md, String jn)
        {
           
            DateTime Newmd = DateTime.Parse(md);
            string dir = Path.GetDirectoryName(en);
            Directory.CreateDirectory(dir + "\\" + "BBS\\");


            File.Copy(dir + "\\" + "OneCall.EXD", dir + "\\" + jn + ".EXD");
            File.Copy(dir + "\\" + "OneCall.IMD", dir + "\\" + jn + ".IMD");

            BBSAPI.ResetMailingOptions();
            BBSAPI.SetInstallationFolder(InstallFlder);
            BBSAPI.SetOutputBase(dir + "\\" + "BBS\\");
            BBSAPI.SetWeight(30);
            BBSAPI.SetDescription(jn);
            BBSAPI.SetReference(jn);
            BBSAPI.SetCollectionDate(md.ToString());
            BBSAPI.SetHandoverDate(Newmd.AddDays(1).ToString());
            BBSAPI.SetInput(1,"C:\\TEST FOLDER\\" + jn + ".xls");
            //BBSAPI.SetTable(1, "One Call Fulfillment Template -$");


            var MyIni = new IniFile("C:\\TEST FOLDER\\URIS.JOB");

            MyIni.Write("Weight", "30", "InitialInfo");
            MyIni.Write("OutputBase", dir + "\\" + "BBS", "InitialInfo");
            MyIni.Write("")


            string mjob = "C:\\TEST FOLDER\\URIS.JOB";
            int result =  BBSAPI.RunMailingJob(mjob);

           MessageBox.Show(result.ToString());



          

            

            

            //Console.WriteLine("1234","1234", "C:\\TEST FOLDER\\1234.xls", "31/12/2199","'Test'");



           // IniOptions options = new IniOptions();
           // IniFile iniFile = new IniFile(options);

            // Load file from path.
            //iniFile.Load(@"C:\\TEST FOLDER\\URIS.JOB");

            
          

           // BBSAPI.RunMailingJob("C:\\TEST FOLDER\\URIS.JOB");




            // Check for Default Auto Net/One Call Job



            //result = BBSAPI.RunMailingJob();







        }



    }

}
