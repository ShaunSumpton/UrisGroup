using System.IO;
using System.Threading;
using Microsoft.Office.Interop.Outlook;



namespace UrisGroup
{
    public class Email
    {
       

        static public void MoveFiles()
        {
            string fp1 = @"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall.pdf";
            int a= 0;
            Directory.CreateDirectory(UrisGroup.dir + "\\" + "Encrypt\\");

            while (File.Exists(fp1) == false)
            {
                //do Nothing
                a++;

            }

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall.pdf", UrisGroup.dir + "\\Imposed\\" + UrisGroup.JobNumber + "_Uris_OneCall_Booklet_IMPOSED.pdf");

            string fp = @"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall PROOF.pdf";

            while (File.Exists(fp) == false)
            {
                //do Nothing
                a++;

            }

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall PROOF.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber+ "_Uris_OneCall_Booklet.pdf");
            File.Copy(@"G:\Development\BBS Definition Files\Uris_OneCall Insert.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber + "_Uris_OneCall Insert.pdf");

            
        }


        static public void SendEmail()
        {

            Application app = new Application();
            MailItem mailItem = app.CreateItem(OlItemType.olMailItem);


            mailItem.Subject = UrisGroup.JobNumber + " " + UrisGroup.tc + "A5 16pp Booklet Proofs";
            mailItem.To = "s.sumpton@agnortheast.com";

            mailItem.Attachments.Add(UrisGroup.dir + "\\" + UrisGroup.JobNumber + " OneCall Booklet.pgp");//logPath is a string holding path to the log.txt file
            mailItem.Importance = OlImportance.olImportanceHigh;
            mailItem.Display(false);

            var signature = mailItem.HTMLBody;
            mailItem.HTMLBody = "Please see attached " + UrisGroup.tc + " Booklets"  + signature;
            mailItem.Send();

        }




    }

    
    
}


    
