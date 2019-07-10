using System;
using System.IO;
using System.Windows.Forms;
using PgpCore;
using System.IO.Compression;
using Microsoft.Office.Interop.Outlook;




namespace UrisGroup
{
    public partial class UrisGroup : Form
 




    {
        public UrisGroup()
        {

        InitializeComponent();
            
        }

       static public string EncryptedFiles;
       static public string JobNumber;
       static public string MailDate;
       static public string fn;
       static public string tc;
       static public string dir;
        static public string segment;

        public void button1_Click(object sender, EventArgs e)
        {
            
            string Password = "1dunn0d0u";
            string skey = @"\\6.1.1.144\Company\Development\BBS Definition Files\secring.skr";
            string pkey = @"\\6.1.1.144\Company\Development\BBS Definition Files\pubring.skr";
            string TypeCheck = null;
            

            JobNumber = textBox1.Text;
            MailDate = textBox2.Text;

            System.Windows.Forms.Application.DoEvents();
           


            if (textBox2.Text.Length == 0)
            {

                MessageBox.Show("Please Enter the Mailing Date"); // check if a mailing date has been entered
                this.Close();
                System.Windows.Forms.Application.Exit();
                Environment.Exit(0);
            }

            if (textBox2.Text.Length == 0)
            {

                MessageBox.Show("Please Enter the Job Number"); // check if a job number has been entered
                this.Close();
                System.Windows.Forms.Application.Exit();
                Environment.Exit(0);
            }

            // check if we are doing an autonet or onecall

           


            listBox1.Items.Add("Selecting File ...."); // keep user updated

            OpenFileDialog openFileDialog2 = new OpenFileDialog(); // open file dialog to select encrypted file
            openFileDialog2.Filter = "pgp files (*.pgp)|*.pgp|All files (*.*)|*.*";
            openFileDialog2.ShowDialog();

            EncryptedFiles = openFileDialog2.FileName; // get file path for PGP 
            dir = Path.GetDirectoryName(EncryptedFiles);

            tc = TypChk(TypeCheck, EncryptedFiles);  // check what type of file we are working with

            bool csv = EncryptedFiles.Contains("csv"); // check if working with csv and if we need to convert it to xls

            listBox1.Items.Add("Decrypting File ....");
            DecryptFiles(EncryptedFiles, Password, skey, JobNumber, csv); // Decrypt files
            listBox1.Items.Add("*DONE*");
            

            listBox1.Items.Add("Prepearing Mailing Job ....");
            BBS.BBSNow(EncryptedFiles, MailDate, JobNumber, csv,tc); // run BBS Job
            listBox1.Items.Add("*DONE*");

            listBox1.Items.Add("Creating Output File ....");
            CSV.CreateData(JobNumber,EncryptedFiles,tc); // add booklet barcode and job number to export file
            CSV.ReplaceTxt(EncryptedFiles, JobNumber,tc); //replace £
            listBox1.Items.Add("*DONE*");

            listBox1.Items.Add("Creating PDF File ....");
            Composer(dir); // prepare file for composer and place on server

            listBox1.Items.Add("Moving Files ....");
            Email.MoveFiles();  // Move Files from composer 
             listBox1.Items.Add("*DONE*");

            EncryptFiles(); // Encrypt Files for email
            listBox1.Items.Add("Encrypt Files ....");
            listBox1.Items.Add("*DONE*");

            Email.SendEmail(); // Create and send email
            listBox1.Items.Add("Send Email ....");
            listBox1.Items.Add("*DONE*");


        }

        public void DecryptFiles(string EncryptedFiles, string Password, string key, string JobNumber, bool csv) // decrypt files
        {
            string ex;

            // check if we are extracting a csv or xls
            if (csv == true)
            {
                ex = ".csv";

            }
            else ex = ".xls";


            using (PGP pgp = new PGP())
            {
                string directory = Path.GetDirectoryName(EncryptedFiles);

                pgp.DecryptFile(@EncryptedFiles, Path.Combine(directory, JobNumber + ex), @key, Password);


            }


        }

        public void EncryptFiles()
        {

            ZipFile.CreateFromDirectory(dir + @"\Encrypt\", dir + "\\" + tc + " Booklet.zip");

            using (PGP pgp = new PGP())
            {

                string[] publicKeys = Directory.GetFiles(@"\\6.1.1.144\Company\Development\BBS Definition Files\Keys", "*asc");
                pgp.EncryptFile(dir + "\\" + tc + " Booklet.zip",dir + "\\" + JobNumber + tc +  " Booklet.pgp",publicKeys,true,true);


            }
        }

        public void Composer(string dir)
        {
            File.Copy(dir + "\\" + tc + ".txt", @"\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Input" + "\\" + UrisGroup.tc + ".txt");
            File.Copy(dir + "\\" + tc + ".txt", @"\\6.1.1.76\Composer Presets\VDP Presets\Unsplit\Input" + "\\" + UrisGroup.tc + " PROOF.txt");
        }

        public string TypChk(string tc,string en)
        {
            string dir = Path.GetDirectoryName(en);
            Directory.CreateDirectory(dir + "\\" + "BBS\\");

            int index = UrisGroup.dir.LastIndexOf(@"\");
            segment = UrisGroup.dir.Substring(1,index);

            if (OneCall.Checked)
            {
                tc = "OneCall";
                File.Copy("G:\\Development\\BBS Definition Files\\OneCall.EXD", dir + "\\BBS\\" + JobNumber  + ".EXD");
                File.Copy("G:\\Development\\BBS Definition Files\\OneCall.IMD", dir + "\\BBS\\" + JobNumber + ".IMD");
                fn = "G:\\Development\\BBS Definition Files\\URISO.JOB";
            }
            else if (AutoNet.Checked)
            {
                tc = "AutoNet1";
                File.Copy("G:\\Development\\BBS Definition Files\\AutoNet.EXD", dir + "\\BBS\\" + JobNumber + ".EXD");
                File.Copy("G:\\Development\\BBS Definition Files\\AutoNet.IMD", dir + "\\BBS\\" + JobNumber + ".IMD");
                fn = "G:\\Development\\BBS Definition Files\\URISA.JOB";

            }
            else
            {
                MessageBox.Show("No Type Checked");
                this.Close();
                System.Windows.Forms.Application.Exit();
                Environment.Exit(0);
            }

            return tc;
        } // check for differnt types

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = "OneCall";
            string JobNumber = "12345";
            string dir = @"\\6.1.1.118\c\TEST FOLDER";

            

            var objOutlook = new Microsoft.Office.Interop.Outlook.Application();
            var mailItem = (MailItem)(objOutlook.CreateItem(OlItemType.olMailItem));


            mailItem.To = "s.sumpton@agnortheast.com";
            mailItem.Subject = JobNumber + " " + tc + "A5 16pp Booklet Proofs";
            mailItem.Attachments.Add(dir + "\\" + JobNumber + " OneCall Booklet.pgp");
            mailItem.Importance = OlImportance.olImportanceHigh;
            var body = "Please see attached " + tc + " Booklets Proof";

            mailItem.Display();
            mailItem.HTMLBody = body + mailItem.HTMLBody;

            mailItem.Send();

        }
    }





    }


   



