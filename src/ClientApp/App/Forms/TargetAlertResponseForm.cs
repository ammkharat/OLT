using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class TargetAlertResponseForm : BaseForm, ITargetAlertResponseFormView
    {
        public event EventHandler LoadView;
        public event EventHandler SearchFunctionalLocation;
        public event EventHandler ClearFunctionalLocation;
        public event EventHandler CreateResponse;
        public event EventHandler CancelResponse;
        public event EventHandler OnCreateLogCheckChanged;

        public TargetAlertResponseForm()
        {
            components = null;
            InitializeComponent();            
            copyResponseToLogCheckBox.CheckedChanged += OnCreateLog_CheckChanged;
        }
      
        public string Title
        {
            set
            {
                Text = value;
            }
        }

        public TargetGapReason[] GapReasonChoices
        {
            set { reasonComboBox.DataSource = value; }
        }

        public TargetGapReason GapReason
        {
            get { return reasonComboBox.SelectedItem as TargetGapReason; }
        }

        public string ResponsibleFunctionalLocationText
        {
            set { responsibleFlocTextBox.Text = value; }
        }

        public string Comment
        {
            get { return commentTextBox.Text.Trim(); }
            set { commentTextBox.Text = value; }
        }

        public bool CreateLogChecked
        {
            get { return copyResponseToLogCheckBox.Checked; }
            set { copyResponseToLogCheckBox.Checked = value; }
        }

        private void TargetAlertResponseForm_Load(object sender, EventArgs e)
        {
            if (LoadView != null) { LoadView(sender, e); }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (SearchFunctionalLocation != null) { SearchFunctionalLocation(sender, e); }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (ClearFunctionalLocation != null) { ClearFunctionalLocation(sender, e); }
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (CreateResponse != null) { CreateResponse(sender, e); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (CancelResponse != null) { CancelResponse(sender, e);  }
        }

        private void OnCreateLog_CheckChanged(object sender, EventArgs e)
        {
            if (OnCreateLogCheckChanged != null) { OnCreateLogCheckChanged(sender, e); }
        }
        
        public DateTime CreateDateTime
        {
            get { return oltLastModifiedDateAuthorHeader.LastModifiedDate; }
            set { oltLastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public string ShiftPatternName
        {
            set { shiftLabelData.Text = value; }
        }

        public User Author
        {
            set { oltLastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public string TargetName
        {
            set { summary.TargetName = value; }
        }

        public string CategoryName
        {
            set { summary.CategoryName = value; }
        }

        public string TargetDefinitionAuthor
        {
            set { summary.Author = value; }
        }

        public string FunctionalLocationName
        {
            set { summary.FunctionalLocationName = value; }
        }

        public string FunctionalLocationDescription
        {
            set { summary.FunctionalLocationDescription = value; }
        }

        public string MeasurementTagName
        {
            set { summary.MeasurementTagName = value; }
        }

        public string Description
        {
            set { summary.Description = value; }
            get { return summary.Description; }
        }

        public string MeasurementTagUnit
        {
            set { summary.MeasurementTagUnits = value; }
        }

        public decimal? NeverToExceedMaximum
        {
            set { summary.NeverToExceedMaximum = value; }
        }

        public decimal? MaxValue
        {
            set { summary.MaxValue = value; }
        }

        public decimal? MinValue
        {
            set { summary.MinValue = value; }
        }

        public decimal? NeverToExceedMinimum
        {
            set { summary.NeverToExceedMinimum = value; }
        }
        
        public string TargetValue
        {
            set { summary.TargetValue = value; }
        }
        
        public void ClearErrorProviders()
        {
            reasonForGapRequiredErrorProvider.Clear();
        }

        public void ShowGapReasonRequiredError()
        {
            reasonForGapRequiredErrorProvider.SetError(reasonComboBox, StringResources.GapRequiredMessage);
        }

        public void EnableMakingAnOperatingEngineerLog(bool operatingEngineerLogsEnabledForSite)
        {
            makeLogAnOperatingEngineerCheckBox.Visible = operatingEngineerLogsEnabledForSite;
            makeLogAnOperatingEngineerCheckBox.Enabled = copyResponseToLogCheckBox.Checked;
        }

        public bool IsLogAnOperatingEngineeringLog
        {
            get
            {
                return makeLogAnOperatingEngineerCheckBox.Checked;
            }
            set
            {
                makeLogAnOperatingEngineerCheckBox.Checked = value;
            }
        }

        public string OperatingEngineerLogDisplayText
        {
            set { makeLogAnOperatingEngineerCheckBox.Text = value; }
        }

        public string TargetNameLabel
        {
            set { summary.NameLabel = value; }
        }

        public string TargetSummaryLabel
        {
            set { summary.SummaryLabel = value; }
        }

        public bool ShowConfirmationDialog()
        {
            return ConfirmCancelDialog();
        }

        public void HideDetails()
        {
            summary.Visible = false;
        }
    }
}
