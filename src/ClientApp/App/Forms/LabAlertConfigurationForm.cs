using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class LabAlertConfigurationForm : BaseForm, ILabAlertConfigurationFormView
    {
        private LabAlertConfigurationFormPresenter presenter;

        public LabAlertConfigurationForm()
        {
            InitializeComponent();
            InitializePresenter();         
        }

        private void InitializePresenter()
        {
            presenter = new LabAlertConfigurationFormPresenter(this);
            Load += presenter.LoadForm;
            Closing += presenter.FormClosing;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            retryAttemptsTextBox.Validating += presenter.HandleValidatingForRetryAttempts;           
        }
       
        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public string RetryAttempts
        {
            get { return retryAttemptsTextBox.Text; }
            set { retryAttemptsTextBox.Text = value; }
        }
 
        public void CloseForm()
        {
            Close();
        }

        public void SetErrorForRetryAttempts(string errorMessage)
        {
            errorProvider.SetError(retryAttemptsTextBox, errorMessage);
        }
        
        public void ClearErrors()
        {
            errorProvider.Clear();
        }      
    }
}