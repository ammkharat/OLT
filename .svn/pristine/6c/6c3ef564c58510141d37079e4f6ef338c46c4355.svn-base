using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace TestTool
{
    public partial class DevExRtfControl : UserControl
    {
        private string rtfContents = null;

        public DevExRtfControl()
        {
            InitializeComponent();
            saveButton.Click += saveButton_Click;
            loadButton.Click += loadButton_Click;
            clearButton.Click += ClearButtonOnClick;
        }

        private void ClearButtonOnClick(object sender, EventArgs eventArgs)
        {
            richTextEditor1.ResetText();
        }

        void loadButton_Click(object sender, System.EventArgs e)
        {
            if (rtfContents == null)
            {
                OltMessageBox.Show("There is nothing saved that can be loaded.");
            }
            else
            {
                richTextEditor1.Text = rtfContents;
            }
        }

        void saveButton_Click(object sender, System.EventArgs e)
        {
            rtfContents = richTextEditor1.Text;
            loadButton.Enabled = true;
        }
    }
}
