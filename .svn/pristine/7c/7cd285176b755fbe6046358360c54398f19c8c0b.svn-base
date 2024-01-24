using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkAssignmentAdvancedConfigurationForm : BaseForm, IWorkAssignmentAdvancedConfigurationView
    {
        public WorkAssignmentAdvancedConfigurationForm()
        {
            InitializeComponent();

            okButton.Click += HandleOkButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        public event Action OkButtonClick;
        public event Action CancelButtonClick;

        public bool ShowActionItemsOnHandoverBasedOnWorkAssignmentAndFlocs
        {
            get { return flocAndWorkAssignmentRadioButton.Checked; }
            set
            {
                flocAndWorkAssignmentRadioButton.Checked = value;
                flocRadioButton.Checked = !value;
            }
        }

        public bool ShowLubesCsdOnShiftHandoverReportIsVisible
        {
            set
            {
                showActiveApprovedCsdOnShiftHandoverReportCheckbox.Visible = value;
                criticalSystemDefeatLabel.Visible = value;
            }
        }

        public bool ShowEventExcursionsOnShiftHandoverReport
        {
            get { return showEventExcursionsDurringShiftCheckbox.Checked; }
            set { showEventExcursionsDurringShiftCheckbox.Checked = value; }
        }

        public bool ShowEventExcursionsIsVisible
        {
            set
            {
                eventExcursionsLabel.Visible = value;
                showEventExcursionsDurringShiftCheckbox.Visible = value;
            }
        }

        public bool ShowLubesCsdOnShiftHandoverReport
        {
            get { return showActiveApprovedCsdOnShiftHandoverReportCheckbox.Checked; }
            set { showActiveApprovedCsdOnShiftHandoverReportCheckbox.Checked = value; }
        }

        public bool CopyTargetAlertResponseToLog
        {
            get { return copyTargetResponseToLogCheckBox.Checked; }
            set { copyTargetResponseToLogCheckBox.Checked = value; }
        }

        private void HandleOkButtonClick(object sender, EventArgs e)
        {
            if (OkButtonClick != null)
            {
                OkButtonClick();
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            if (CancelButtonClick != null)
            {
                CancelButtonClick();
            }
        }
    }
}