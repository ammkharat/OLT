using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SarniaMessagePopupForm : Form
    {
        public SarniaMessagePopupForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.CenterToScreen();
        }

        private void oltButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
