using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TestTool
{
    public partial class SapHandlerControl : UserControl
    {
        static readonly char[] Separator = { '\\' };

        public SapHandlerControl()
        {
            InitializeComponent();

            DirSel.Click += DirSel_Click;
            UserTestFile.TextChanged += UserTestFile_TextChanged;
            btnSubmit.Click += btnSubmit_Click;
        }

        private void DirSel_Click(object sender, EventArgs e)
        {
            UseropenFileDialog.ShowDialog();
            string[] splitPath = UseropenFileDialog.FileName.Split(Separator);
            UserTestFile.Text = splitPath[splitPath.Length - 1];
        }

        private void PostToHandler(string HandlerName, int numRepeats, long uniqueField)
        {
            if (UserTestFile.Text.Length != 0)
            {
                string messageData = tbSourceData.Text;
                string strDestUrl = urlTextBox.Text;
                if (!strDestUrl.EndsWith("/"))
                {
                    strDestUrl += "/";
                }

                for (int i = 0; i < numRepeats; i++)
                {
                    if (numRepeats > 1)
                    {
                        messageData = messageData.Replace(uniqueField.ToString(), (uniqueField + 1).ToString());
                        uniqueField++;
                    }

                    tbResults.Text = Submit.SyncSubmit(messageData, strDestUrl + HandlerName + ".ashx");
                }
            }
            else
            {
                MessageBox.Show("Please select a data file", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserTestFile_TextChanged(object sender, EventArgs e)
        {
            // Read data file
            string fileName = UseropenFileDialog.FileName;
            using (StreamReader stream = new StreamReader(fileName, Encoding.Default, true))
            {
                string textOfFile = stream.ReadToEnd();

                // Convert data to string
                tbSourceData.Text = textOfFile;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int numRepeats = 1;
            long uniquefield = 0;
            if (int.TryParse(repeatsTextBox.Text, out numRepeats) &&
                !long.TryParse(uniqueFieldTextBox.Text, out uniquefield))
            {
                MessageBox.Show("Please enter a unique field to increment for each repetition.  It must be a number.");
                return;
            }

            tbResults.Text = "";

            string handler = "";

            switch (lbDestination.Text)
            {
                case "":
                    MessageBox.Show("Please select a message type", "No Selected Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "Functional Location":
                    handler = "FLOC";
                    break;
                case "Notification":
                    handler = "Notification";
                    break;
                case "Work Order":
                    handler = "WorkOrder";
                    break;
            }

            PostToHandler(handler, numRepeats, uniquefield);
        }
    }
}
