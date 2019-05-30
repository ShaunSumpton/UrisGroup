using System;
using System.IO;
using SortAndSave;
using MadMilkman.Ini;
using System.Windows.Forms;

namespace UrisGroup
{
    public class BBS
    {



        public static void BBSNow(String en, String md, String jn)
        {
            
            DateTime Newmd = DateTime.Parse(md);
            string dir = Path.GetDirectoryName(en);
            Directory.CreateDirectory(dir + "\\" + "BBS");
            
            BBSAPI.SetInstallationFolder("C:\\SORTANDSAVE");
            BBSAPI.SetOutputBase(dir + "\\" + "BBS");
            BBSAPI.SetWeight(30);
            BBSAPI.SetDescription(jn);
            BBSAPI.SetReference(jn);
            BBSAPI.SetCollectionDate(md.ToString());
            BBSAPI.SetHandoverDate(Newmd.AddDays(1).ToString());

           var MyIni = new IniFile("C:\\TEST FOLDER\\URIS.JOB");
            string FileLoc = "One Call" + "," + "One Call" + "," + "C:\\TEST FOLDER\\" + jn + ".xls" + "," + "31/12/2019" + "," + "'One Call Fulfillment Template -$'";
            MyIni.Write(" ", FileLoc, "Data Sources");
            

            int result = BBSAPI.RunMailingJob("C:\\TEST FOLDER\\URIS.JOB");

            MessageBox.Show(result.ToString());



          

            

            

            //Console.WriteLine("1234","1234", "C:\\TEST FOLDER\\1234.xls", "31/12/2199","'Test'");



           // IniOptions options = new IniOptions();
           // IniFile iniFile = new IniFile(options);

            // Load file from path.
            //iniFile.Load(@"C:\\TEST FOLDER\\URIS.JOB");

            
           // MyIni.Write("Weight", "100", "InitialInfo");
           // MyIni.Write("OutputBase", dir + "\\" + "BBS", "InitialInfo");

           // BBSAPI.RunMailingJob("C:\\TEST FOLDER\\URIS.JOB");




            // Check for Default Auto Net/One Call Job



            //result = BBSAPI.RunMailingJob();







        }



    }

}
