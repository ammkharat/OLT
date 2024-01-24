using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureRestrictionReportingLimitsForm : BaseForm, IConfigureRestrictionReportingLimitsFormView
    {
        private ConfigureRestrictionReportingLimitsFormPresenter presenter;

        public ConfigureRestrictionReportingLimitsForm()
        {
            InitializeComponent();
            InitializePresenter();           
        }

        private void InitializePresenter()
        {
            presenter = new ConfigureRestrictionReportingLimitsFormPresenter(this);
            Load += presenter.LoadForm;
            Closing += presenter.FormClosing;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            daysToEditDeviationAlertsTextBox.Validating += presenter.DaysToEditDeviationAlertsTextBox_Validating;
        }
      
        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public string DaysToEditDeviationAlerts
        {
            get { return daysToEditDeviationAlertsTextBox.Text; }
            set { daysToEditDeviationAlertsTextBox.Text = value; }
        }

        public void CloseForm()
        {
            Close();
        }

        public void SetErrorForDaysToEditDeviationAlerts(string errorMessage)
        {
            errorProvider.SetError(daysToEditDeviationAlertsTextBox, errorMessage);
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }
    }
}