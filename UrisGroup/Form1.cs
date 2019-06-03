﻿using System;
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

            //MessageBox.Show(EncryptedFiles);

            listBox1.Items.Add("Decrypting File ....");
            DecryptFiles(EncryptedFiles, Password, key, JobNumber); // Decrypt files

            listBox1.Items.Add("Prepearing Mailing Job ....");
            BBS.BBSNow(EncryptedFiles, MailDate, JobNumber); // run BBS Job


            //CreateData(); // add booklet barcode and job number to export file

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

        
    }
}
