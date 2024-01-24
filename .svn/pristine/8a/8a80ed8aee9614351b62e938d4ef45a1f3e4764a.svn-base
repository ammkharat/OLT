using Com.Suncor.Olt.Client.Presenters;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigureDisplayLimitsForm : BaseForm, ISiteConfigurationFormView
    {
        private ConfigureDisplayLimitsFormPresenter presenter;

        public ConfigureDisplayLimitsForm()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            presenter = new ConfigureDisplayLimitsFormPresenter(this);
            Load += presenter.LoadForm;
            Closing += presenter.FormClosing;
            saveButton.Click += presenter.HandleSaveButtonClick;
            cancelButton.Click += presenter.HandleCancelButtonClick;
            daysToDisplayActionItemsTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
            daysToDisplayShiftHandoversTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
            daysToDisplayShiftLogsTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
            daysToDisplayDeviationAlertsTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
            daysToDisplayLabAlertsTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
            daysToDisplayCokerCardsTextBox.Validating += presenter.HandleValidatingForDisplayLimits;
        }
       
        public string SiteName
        {
            set { siteDisplayLabel.Text = value; }
        }

        public string DaysToDisplayActionItems
        {
            get { return daysToDisplayActionItemsTextBox.Text; }
            set { daysToDisplayActionItemsTextBox.Text = value; }
        }

        public string DaysToDisplayShiftLogs
        {
            get { return daysToDisplayShiftLogsTextBox.Text; }
            set { daysToDisplayShiftLogsTextBox.Text = value; }
        }

        public string DaysToDisplayShiftHandovers
        {
            get { return daysToDisplayShiftHandoversTextBox.Text; }
            set { daysToDisplayShiftHandoversTextBox.Text = value; }
        }

        public string DaysToDisplayDeviationAlerts
        {
            get { return daysToDisplayDeviationAlertsTextBox.Text; }
            set { daysToDisplayDeviationAlertsTextBox.Text = value; }
        }

        public string DaysToDisplayWorkPermitsBackwards
        {
            get { return daysToDisplayWorkPermitsBackwardsTextBox.Text; }
            set { daysToDisplayWorkPermitsBackwardsTextBox.Text = value; }
        }

        public string DaysToDisplayWorkPermitsForwards
        {
            get { return daysToDisplayWorkPermitsForwardsTextBox.Text; }
            set { daysToDisplayWorkPermitsForwardsTextBox.Text = value; }
        }

        public string DaysToDisplayLabAlerts
        {
            get { return daysToDisplayLabAlertsTextBox.Text; }
            set { daysToDisplayLabAlertsTextBox.Text = value; }
        }

        public string DaysToDisplayEvents
        {
            get { return daysToDisplayEventsTextBox.Text; }
            set { daysToDisplayEventsTextBox.Text = value; }
        }

        public string DaysToDisplayCokerCards
        {
            get { return daysToDisplayCokerCardsTextBox.Text; }
            set { daysToDisplayCokerCardsTextBox.Text = value; }
        }

        public string DaysToDisplayPermitRequestsBackwards
        {
            get { return daysToDisplayPermitRequestsBackwardsTextBox.Text; }
            set { daysToDisplayPermitRequestsBackwardsTextBox.Text = value; }
        }

        public string DaysToDisplayPermitRequestsForwards
        {
            get { return daysToDisplayPermitRequestsForwardsTextBox.Text; }
            set { daysToDisplayPermitRequestsForwardsTextBox.Text = value; }
        }

        public string DaysToDisplayElectronicFormsBackwards
        {
            get { return daysToDisplayElectronicFormsBackwardsTextBox.Text; }
            set { daysToDisplayElectronicFormsBackwardsTextBox.Text = value; }
        }

        public string DaysToDisplayDocumentSuggestionFormsForwards
        {
            get { return daysToDisplayDocumentSuggestionFormsForwardsTextBox.Text; }
            set { daysToDisplayDocumentSuggestionFormsForwardsTextBox.Text = value; }
        }

        public string DaysToDisplayDocumentSuggestionFormsBackwards
        {
            get { return daysToDisplayDocumentSuggestionFormsBackwardsTextBox.Text; }
            set { daysToDisplayDocumentSuggestionFormsBackwardsTextBox.Text = value; }
        }

        public string DaysToDisplayElectronicFormsForwards
        {
            get { return daysToDisplayElectronicFormsForwardsTextBox.Text; }
            set { daysToDisplayElectronicFormsForwardsTextBox.Text = value; }
        }

        public string DaysToDisplaySAPNotificationsBackwards
        {
            get { return daysToDisplaySAPNotificationsTextBox.Text; }
            set { daysToDisplaySAPNotificationsTextBox.Text = value; }
        }

        public string DaysToDisplayDirectivesBackwards
        {
            get { return daysToDisplayDirectivesBackwardsTextBox.Text; }
            set { daysToDisplayDirectivesBackwardsTextBox.Text = value; }
        }

        public string DaysToDisplayDirectivesForwards
        {
            get { return daysToDisplayDirectivesForwardsTextBox.Text; }
            set { daysToDisplayDirectivesForwardsTextBox.Text = value; }
        }

        public bool ActionItemConfigurationVisible
        {
            set { actionItemPanel.Visible = value; }
        }

        public bool CokerCardConfigurationVisible
        {
            set { cokerCardPanel.Visible = value; }
        }

        public bool DeviationConfigurationVisible
        {
            set { deviationPanel.Visible = value; }
        }
        
        public bool DocumentSuggestionConfigurationVisible
        {
            set { documentSuggestionFormsPanel.Visible = value; }
        }

        public bool LabAlertConfigurationVisible
        {
            set { labAlertPanel.Visible = value; }
        }

        public bool PermitConfigurationVisible
        {
            set 
            { 
                workPermitPanel.Visible = value;
                permitRequestPanel.Visible = value;
            }
        }

        public bool ShiftHandoverConfigurationVisible
        {
            set { shiftHandoverPanel.Visible = value; }
        }

        public bool LogConfigurationVisible
        {
            set { shiftLogsPanel.Visible = value; }
        }
        
        public bool EventsConfigurationVisible
        {
            set { eventsConfigurationPanel.Visible = value; }
        }

        public bool ElectronicFormsVisible
        {
            set
            {
                electronicFormsPanel.Visible = value;
            }
        }

        public bool DirectiveConfigurationVisible
        {
            set { directivesPanel.Visible = value; }
        }

        public void CloseForm()
        {
            Close();
        }

        public void SetErrorForActionItems(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayActionItemsTextBox, errorMessage);
        }

        public void SetErrorForShiftLogs(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayShiftLogsTextBox, errorMessage);
        }

        public void SetErrorForShiftHandovers(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayShiftHandoversTextBox, errorMessage);
        }

        public void SetErrorForDeviationAlerts(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayDeviationAlertsTextBox, errorMessage);
        }

        public void SetErrorForLabAlerts(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayLabAlertsTextBox, errorMessage);
        }

        public void SetErrorForCokerCards(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayCokerCardsTextBox, errorMessage);
        }

        public void ClearErrors()
        {
            itemCountErrorProvider.Clear();
        }

        public void SetErrorForEvents(string errorMessage)
        {
            itemCountErrorProvider.SetError(daysToDisplayEventsTextBox,errorMessage);
        }
    }
}