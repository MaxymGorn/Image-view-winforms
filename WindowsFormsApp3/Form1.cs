using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<string> Imagefiles = new List<string>();
        int imageCount = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void AddImageToList()
        {
           foreach(var el in  Imagefiles)
            {
                Iimagel_ist.Items.Add(el);
            }
        }
        private void findImagesInDirectory(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string s in files)
            {
                if (s.EndsWith(".jpg") || s.EndsWith(".png") || s.EndsWith(".gif")) 
                {
                    Imagefiles.Add(s);
                }
            }
            AddImageToList();
            try
            {
                pictureBox1.ImageLocation = Imagefiles.First();
            }
            catch
            {
                MessageBox.Show("No files found!");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(Imagefiles.Count!=0)
            if (imageCount + 1 == Imagefiles.Count)
            {
                MessageBox.Show("No Other Images!");
            }
            else 
            {
                string nextImage = Imagefiles[imageCount + 1];
                pictureBox1.ImageLocation = nextImage;
                imageCount += 1;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (imageCount == 0)
            {
                MessageBox.Show("No Other Images!","Eror!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string prevImage = Imagefiles[imageCount - 1];
                pictureBox1.ImageLocation = prevImage;
                imageCount -= 1;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Imagefiles.Count == 0)
                {
                    throw new Exception("Dont have image!");
                }
                timer1.Start();

            }
            catch (Exception eror)
            {
                MessageBox.Show(eror.Message, "Notifications: eror", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         

           
        }
     

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(Imagefiles.Count!=0)
            {
                imageCount = 0;
                pictureBox1.ImageLocation = Imagefiles[imageCount];
            }
           
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Iimagel_ist.Items.Clear();
            imageCount = 0;
            Imagefiles.Clear();
            string defaultimage = @"..\..\Resources\yak_znayty_robotu_v_ineti.jpg";
            pictureBox1.ImageLocation = defaultimage;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    findImagesInDirectory(fbd.SelectedPath);
                }
            }
        }

        private void Iimagelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageCount = Iimagel_ist.SelectedIndex;
            pictureBox1.ImageLocation = Imagefiles[imageCount];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Imagefiles.Count!=0)
            {
                if (Iimagel_ist.Items.Count - 1 == imageCount)
                {
                    imageCount = 0;
                }
                imageCount++;
                pictureBox1.ImageLocation = Imagefiles[imageCount];
            }
        
        }

        private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageCount = 0;
            Iimagel_ist.Items.Clear();
            Imagefiles.Clear();
            pictureBox1.ImageLocation = @"..\..\Resources\yak_znayty_robotu_v_ineti.jpg";
        }
    }
}
