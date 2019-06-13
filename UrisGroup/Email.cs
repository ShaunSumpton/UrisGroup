using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                Thread.Sleep(500);

            }

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall.pdf", UrisGroup.dir + "\\Imposed\\" + UrisGroup.JobNumber + "_Uris_OneCall_Booklet_IMPOSED.pdf");

            string fp = @"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall PROOF.pdf";

            while (File.Exists(fp) == false)
            {
                //do Nothing
                Thread.Sleep(500);

            }

            File.Move(@"\\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Output\OneCall PROOF.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber+ "_Uris_OneCall_Booklet.pdf");
            File.Copy(@"G:\Development\BBS Definition Files\Uris_OneCall Insert.pdf", UrisGroup.dir + "\\Encrypt\\" + UrisGroup.JobNumber + "_Uris_OneCall Insert.pdf");

            
        }






    }

    
    
}


    
