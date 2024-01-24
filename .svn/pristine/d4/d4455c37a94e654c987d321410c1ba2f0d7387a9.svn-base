using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConvertLogBasedDirectivesProgressForm : BaseForm
    {
        public event Action<ConvertLogBasedDirectivesProgressForm> OkButtonClick;

        public ConvertLogBasedDirectivesProgressForm()
        {
            InitializeComponent();

            OkButtonEnabled = false;
            okButton.Click += (sender, args) => OkButtonClick(this);
        }

        public string WindowCaption
        {
            set { Text = value; }
        }

        public void AppendText(string message)
        {
            progressTextBox.AppendText(message + Environment.NewLine);
        }

        public bool OkButtonEnabled
        {
            set { okButton.Enabled = value; }
        }
    }
}
