using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureWorkPermitArchivalProcessForm : BaseForm, IConfigureWorkPermitArchivalProcessForm
    {
        public ConfigureWorkPermitArchivalProcessForm()
        {
            InitializeComponent();            

            ConfigureWorkPermitArchivalProcessFormPresenter presenter = new ConfigureWorkPermitArchivalProcessFormPresenter(this);

            Load += presenter.LoadForm;
            FormClosing += presenter.FormClosing;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
        }
        
        public string SiteName
        {
            set { siteNameDataLabel.Text = value; }
        }

        public int DaysBeforeArchivingClosedWorkPermits
        {
            get { return (int)(archiveClosedAfterDaysNumbericBox.Value); }
            set { archiveClosedAfterDaysNumbericBox.Value = value; }
        }

        public int DaysBeforeDeletingPendingWorkPermits
        {
            get { return (int)(deletePendingAfterDaysNumericBox.Value); }
            set { deletePendingAfterDaysNumericBox.Value = value; }
        }

        public int DaysBeforeClosingIssuedWorkPermits
        {
            get { return (int)(closeIssuedAfterDaysNumericBox.Value); }
            set { closeIssuedAfterDaysNumericBox.Value = value; }
        }

        public void ClearErrorMessages()
        {
            errorProvider.Clear();
        }
        
        public void ShowDaysBeforeArchivingClosedWorkPermitsError(string message)
        {
            errorProvider.SetError(archiveClosedAfterDaysNumbericBox, message);
        }
        
        public void ShowDaysBeforeDeletingPendingWorkPermitsError(string message)
        {
            errorProvider.SetError(deletePendingAfterDaysNumericBox, message);
        }
        
        public void ShowDaysBeforeClosingIssuedWorkPermitsError(string message)
        {
            errorProvider.SetError(closeIssuedAfterDaysNumericBox, message);
        }
    }
}