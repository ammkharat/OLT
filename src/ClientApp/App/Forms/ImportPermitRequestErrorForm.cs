using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ImportPermitRequestErrorForm : BaseForm, IImportPermitRequestErrorFormView
    {        
        public event EventHandler OKButtonClicked; 

        public ImportPermitRequestErrorForm()
        {
            InitializeComponent();
                       
            okButton.Click += HandleOKButtonClick;            
        }
               
        private void HandleOKButtonClick(object sender, EventArgs e)
        {
            if (OKButtonClicked != null)
            {
                OKButtonClicked(sender, e);
            }
        }

        public string ErrorLabelText
        {
            set { descriptionLabel.Text = value; }
        }

        public string CopyRecommendationText
        {           
            set { copyRecommendationLabel.Text = value; }
        }

        public string MainDisplayText
        {
            set { mainDisplayTextBox.Text = value; }
        }
    }
}