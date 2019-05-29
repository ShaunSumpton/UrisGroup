using System;
using System.IO;
using SortAndSave;


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
    

           BBSAPI.RunMailingJob("C:\\TEST FOLDER\\URIS.JOB");

            var MyIni = new IniFile("C:\\TEST FOLDER\\URIS.JOB");

            MyIni.Write("", "","Data Sources");
            MyIni.Write("Weight", "100", "InitialInfo");





            // Check for Default Auto Net/One Call Job



            //result = BBSAPI.RunMailingJob();







        }

        

    }

}
