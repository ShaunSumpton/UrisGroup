using System;
using System.IO;
using System.Windows.Forms;
using PgpCore;




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

        public void button1_Click(object sender, EventArgs e)
        {
            
            string Password = "1dunn0d0u";
            string skey = @"C:\TEST FOLDER\secring.skr";
            string pkey = @"C:\TEST FOLDER\pubring.skr";
            string TypeCheck = null;
            

            JobNumber = textBox1.Text;
            MailDate = textBox2.Text;
            Application.DoEvents();
           


            if (textBox2.Text.Length == 0)
            {

                MessageBox.Show("Please Enter the Mailing Date"); // check if a mailing date has been entered
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }

            if (textBox2.Text.Length == 0)
            {

                MessageBox.Show("Please Enter the Job Number"); // check if a job number has been entered
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }

            // check if we are doing an autonet or onecall

           


            listBox1.Items.Add("Selecting File ...."); // keep user updated

            OpenFileDialog openFileDialog2 = new OpenFileDialog(); // open file dialog to select encrypted file
            openFileDialog2.Filter = "pgp files (*.pgp)|*.pgp|All files (*.*)|*.*";
            openFileDialog2.ShowDialog();

            EncryptedFiles = openFileDialog2.FileName; // get file path for PGP 
            dir = Path.GetDirectoryName(EncryptedFiles);
            tc = TypChk(TypeCheck, EncryptedFiles);


            listBox1.Items.Add("*DONE*");



            // check what type of file we are working with
            bool csv = EncryptedFiles.Contains("csv");

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
            Email.MoveFiles();
            EncryptFiles();

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

            using (PGP pgp = new PGP())
            {

                string[] publicKeys = Directory.GetFiles(@"C:\TEST FOLDER\Keys", "*asc");
                pgp.EncryptFile(dir + "\\Encrypt\\",dir + "\\" + JobNumber + " OneCall Booklet.pgp",publicKeys,true,true);


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

            if (OneCall.Checked)
            {
                tc = "OneCall";
                File.Copy("G:\\Development\\BBS Definition Files\\OneCall.EXD", dir + "\\" + JobNumber  + ".EXD");
                File.Copy("G:\\Development\\BBS Definition Files\\OneCall.IMD", dir + "\\" + JobNumber + ".IMD");
                fn = "G:\\Development\\BBS Definition Files\\URISO.JOB";
            }
            else if (AutoNet.Checked)
            {
                tc = "AutoNet";
                File.Copy("G:\\Development\\BBS Definition Files\\AutoNet.EXD", dir + "\\" + JobNumber + ".EXD");
                File.Copy("G:\\Development\\BBS Definition Files\\AutoNet.IMD", dir + "\\" + JobNumber + ".IMD");
                fn = "G:\\Development\\BBS Definition Files\\URISA.JOB";

            }
            else
            {
                MessageBox.Show("No Type Checked");
                this.Close();
                Application.Exit();
                Environment.Exit(0);
            }

            return tc;
        }

        
    }





    }


   



