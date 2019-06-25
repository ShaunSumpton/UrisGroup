using System.IO;
using System.Threading;
using Microsoft.Office.Interop.Outlook;



namespace UrisGroup
{
    public class Email
    {
       

        static public void MoveFiles()
        {

         


            string fp1 = @"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\" + UrisGroup.tc + ".pdf"; // path we are moving the files from
            int a= 0;
            Directory.CreateDirectory(UrisGroup.dir + "\\" + "Encrypt\\"); // create directory in job folder

            while (File.Exists(fp1) == false)
            {
                //do Nothing
                Thread.Sleep(1000);

            }

            string filePth = @"\" + UrisGroup.segment + @"Imposed\" + UrisGroup.JobNumber + @"_Uris_" + UrisGroup.tc + "_Booklet_IMPOSED.pdf";

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\"+ UrisGroup.tc + ".pdf",filePth); // move file when it exsists in folder

            string fp = @"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\" + UrisGroup.tc +" PROOF.pdf"; 
                
            while (File.Exists(fp) == false)
            {
                //do Nothing
                Thread.Sleep(1000);

            }

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\" + UrisGroup.tc + " PROOF.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber + "_Uris_" + UrisGroup.tc + "_Booklet.pdf");
            File.Copy(@"G:\Development\BBS Definition Files\Uris_" + UrisGroup.tc + " Insert.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber + "_Uris_" + UrisGroup.tc + " Insert.pdf");

            
        }


        static public void SendEmail()
        {

            Application app = new Application();
            MailItem mailItem = app.CreateItem(OlItemType.olMailItem);


            mailItem.Subject = UrisGroup.JobNumber + " " + UrisGroup.tc + "A5 16pp Booklet Proofs";
            mailItem.To = "Data Processsing Group<dpo@agne.local>; 'DG Admin' < administration@directgroup.co.uk >; 'DG Data Management' < datamanagement@directgroup.co.uk >; Gary Bell; Sean Costigan";

            mailItem.Attachments.Add(UrisGroup.dir + "\\" + UrisGroup.JobNumber + " OneCall Booklet.pgp");
            mailItem.Importance = OlImportance.olImportanceHigh;
            mailItem.Display(false);



            var signature = mailItem.HTMLBody;
            var body = "Please see attached " + UrisGroup.tc + " Booklets Proof";
            mailItem.HTMLBody = body + signature;
            //mailItem.Send();

        }




    }

    
    
}


    
