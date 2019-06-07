using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PgpCore;
using CsvHelper;
using System.Data.SqlClient;




namespace UrisGroup
{
    public partial class UrisGroup : Form





    {
        public UrisGroup()
        {
            InitializeComponent();
            


        }

        public void button1_Click(object sender, EventArgs e)
        {
            string EncryptedFiles;
            string Password = "1dunn0d0u";
            string key = @"C:\TEST FOLDER\secring.skr";
            string JobNumber = textBox1.Text;
            string MailDate = textBox2.Text;


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

            listBox1.Items.Add("Selecting File ...."); // keep user updated

            OpenFileDialog openFileDialog2 = new OpenFileDialog(); // open file dialog to select encrypted file
            openFileDialog2.Filter = "pgp files (*.pgp)|*.pgp|All files (*.*)|*.*";
            openFileDialog2.ShowDialog();

            EncryptedFiles = openFileDialog2.FileName; // get file path for PGP 

          

            // check what type of file we are working with
            bool csv = EncryptedFiles.Contains("csv");

            listBox1.Items.Add("Decrypting File ....");
            DecryptFiles(EncryptedFiles, Password, key, JobNumber); // Decrypt files

            listBox1.Items.Add("Prepearing Mailing Job ....");
            BBS.BBSNow(EncryptedFiles, MailDate, JobNumber); // run BBS Job


            CSV.CreateData(JobNumber); // add booklet barcode and job number to export file

            //Composer(): // prepare file for composer and place on server

        }

        public void DecryptFiles(string EncryptedFiles, string Password, string key, string JobNumber)
        {
            using (PGP pgp = new PGP())
            {
                string directory = Path.GetDirectoryName(EncryptedFiles);

                pgp.DecryptFile(@EncryptedFiles, Path.Combine(directory, JobNumber + ".xls"), @key, Password);


            }


        }


        

        private void button2_Click(object sender, EventArgs e)
        {

           
            {
             
                using (var reader = new StreamReader(@"C:\TEST FOLDER\BBS\URIS_EXP.CSV"))
                using (var csv = new CsvReader(reader))
                


                {
                    // Do any configuration to `CsvReader` before creating CsvDataReader.
                  csv.
                    using (var dr = new CsvDataReader(csv))
                    {
                        var dt = new DataTable();
                        dt.Load(dr);

                        var dt2 = new DataTable();
                        dt2 = dt.Clone();

                        dt.Columns.Add("bmbarcode1", typeof(string)).SetOrdinal(0);
                        dt.Columns.Add("bmbarcode2", typeof(string)).SetOrdinal(1);
                        dt.Columns.Add("bmbarcode3", typeof(string)).SetOrdinal(2);
                        dt.Columns.Add("bmbarcode4", typeof(string)).SetOrdinal(3);
                        dt.Columns.Add("JobNumber", typeof(string)).SetOrdinal(4);

                        CSV.ToCSV(dt, @"C:\TEST FOLDER\Test.csv");

                         int totalRows = dt.Rows.Count;
                        int r = 0;
                        DataRow dtRow; 

                        do
                        {
                            dtRow = dt2.NewRow();
     
                            dtRow[0] = "1001";
                            dtRow[1] = "1001";
                            dtRow[2] = "1001";
                            dtRow[3] = "1001";
                            dt2.Rows.Add(dtRow);

                            r++;

                        } while (r < totalRows);

                    

                        dataGridView1.DataSource = dt;
                    }

                    

                }










            }


        }


        


    }
}
