using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LogGuidelineConfigurationEditForm : BaseForm, ILogGuidelineConfigurationEditView
    {                       
        public event EventHandler SaveAndCloseButtonClicked;
        public event EventHandler CancelButtonClicked;

        public LogGuidelineConfigurationEditForm()
        {           
            InitializeComponent();

            saveAndCloseButton.Click += SaveAndCloseButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveAndCloseButtonClicked != null)
            {
                SaveAndCloseButtonClicked(sender, e);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        public string GuidelineText
        {
            get { return guidelineTextBox.Text; }
            set { guidelineTextBox.Text = value; }
        }             
    }
}
