﻿namespace UrisGroup
{
    partial class UrisGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.OneCall = new System.Windows.Forms.RadioButton();
            this.AutoNet = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mail Date";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(119, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(119, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 20);
            this.textBox2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UrisGroup.Properties.Resources.URIS_logo___164x58;
            this.pictureBox1.Location = new System.Drawing.Point(272, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 60);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Open Sans", 14F);
            this.button1.Location = new System.Drawing.Point(280, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 105);
            this.button1.TabIndex = 5;
            this.button1.Text = "Process Job";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OneCall
            // 
            this.OneCall.AutoSize = true;
            this.OneCall.Font = new System.Drawing.Font("Open Sans", 14F);
            this.OneCall.Location = new System.Drawing.Point(16, 89);
            this.OneCall.Name = "OneCall";
            this.OneCall.Size = new System.Drawing.Size(101, 30);
            this.OneCall.TabIndex = 6;
            this.OneCall.TabStop = true;
            this.OneCall.Text = "OneCall";
            this.OneCall.UseVisualStyleBackColor = true;
            // 
            // AutoNet
            // 
            this.AutoNet.AutoSize = true;
            this.AutoNet.Font = new System.Drawing.Font("Open Sans", 14F);
            this.AutoNet.Location = new System.Drawing.Point(138, 89);
            this.AutoNet.Name = "AutoNet";
            this.AutoNet.Size = new System.Drawing.Size(95, 30);
            this.AutoNet.TabIndex = 7;
            this.AutoNet.TabStop = true;
            this.AutoNet.Text = "Atlanta";
            this.AutoNet.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 129);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(222, 160);
            this.listBox1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(308, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UrisGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 307);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.AutoNet);
            this.Controls.Add(this.OneCall);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UrisGroup";
            this.Text = "Uris Group";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton OneCall;
        private System.Windows.Forms.RadioButton AutoNet;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
    }
}

