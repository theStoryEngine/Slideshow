using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace gallery_program
{
    public partial class gallery : Form
    {

        List<string> images = new List<string>();
        Random rnd = new Random();

        public gallery()
        {
            InitializeComponent();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK) {

                this.Activate();
                this.BringToFront();
                this.WindowState = FormWindowState.Maximized;
                string filePath = folderBrowserDialog1.SelectedPath;
                string[] extentions = { ".jpeg", ".jpg", ".JPG",  ".png" };
                foreach (string file in Directory.EnumerateFiles(filePath, ".")
                    .Where(s => extentions.Any(ext => ext == Path.GetExtension(s))))
                {
                    
                    images.Add(file);

                }
                if (images.Count < 1) MessageBox.Show("There where no images to find!");
                pictureBox1.Image = Image.FromFile(images[rnd.Next(images.Count)]);
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(images[rnd.Next(images.Count)]);

        }
    }
}