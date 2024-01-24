using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ImageForm : Form
    {
        public ImageForm(MemoryStream ms)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromStream(ms);
            FormTitle = "Images";

        }

        public string FormTitle
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}
