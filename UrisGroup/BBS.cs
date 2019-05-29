using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrisGroup;
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



            var MyIni = new IniFile("C:\\TEST FOLDER\\URIS.JOB");
            MyIni.Write("Weight", "100", "InitialInfo");





            // Check for Default Auto Net/One Call Job



            //result = BBSAPI.RunMailingJob();







        }



    }

}
