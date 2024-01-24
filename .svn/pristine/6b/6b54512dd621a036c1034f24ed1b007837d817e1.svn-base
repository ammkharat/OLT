using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitFilterSelectorForm : BaseForm, IWorkPermitFilterSelectorFormView
    {
        private WorkPermitFilterSelectorPresenter presenter;

        public WorkPermitFilterSelectorForm()
        {
            InitializeComponent();
        }

        public WorkPermitFilterSelectorPresenter Presenter
        {
            set
            {
                presenter = value;
                selectButton.Click += presenter.HandleSelectButtonClick;
                cancelButton.Click += presenter.HandleCancelButtonClick;
                Load += presenter.HandleFormLoad;
                fixedRangeRadioButton.CheckedChanged += presenter.HandleFixedRangeSelected;
                customRangeRadioButton.CheckedChanged += presenter.HandleCustomRangeSelected;
            }
        }

        public void CloseForm(DialogResult result)
        {
            DialogResult = result;
            Close();
        }

        public bool FixedRangeChecked
        {
            get { return fixedRangeRadioButton.Checked; }
            set { fixedRangeRadioButton.Checked = value; }
        }

        public bool CustomRangeChecked
        {
            get { return customRangeRadioButton.Checked; }
            set { customRangeRadioButton.Checked = value; }
        }

        public void AddFixedRangeDuration(Duration[] durations)
        {
            fixedRangeComboBox.Items.Clear();
            fixedRangeComboBox.Items.AddRange(durations);
        }

        public Duration SelectedFixedRangeDuration
        {
            get { return (Duration) fixedRangeComboBox.SelectedItem; }
            set { fixedRangeComboBox.SelectedItem = value; }
        }

        public Date StartDate
        {
            get { return startRangeDatePicker.Value; }
        }

        public Date EndDate
        {
            get { return endRangeDatePicker.Value; }
        }

        public bool StartDateEnabled
        {
            set { startRangeDatePicker.Enabled = value; }
        }

        public bool EndDateEnabled
        {
            set { endRangeDatePicker.Enabled = value; }
        }

        public bool FixedRangeDurationEnabled
        {
            set { fixedRangeComboBox.Enabled = value; }
        }

        public void DisplayErrorDialog(string message)
        {
            OltMessageBox.Show(this, message);
        }

        public DialogResult DisplayWarningDialog(string message)
        {
            return OltMessageBox.ShowCustomYesNo(this, message, string.Empty, MessageBoxIcon.Warning, StringResources.Yes, StringResources.No);
        }

        public Range<Date> SelectedRange
        {
            get { return presenter.DateRange; }
        }

        public bool ArchiveChecked
        {
            get { return archivedCheckBox.Checked; }
            set { archivedCheckBox.Checked = value; }
        }

        public bool ApprovedChecked
        {
            get { return approvedCheckBox.Checked; }
            set { approvedCheckBox.Checked = value; }
        }

        public bool CompletedChecked
        {
            get { return completedCheckBox.Checked; }
            set { completedCheckBox.Checked = value; }
        }

        public bool IssuedChecked
        {
            get { return issuedCheckBox.Checked; }
            set { issuedCheckBox.Checked = value; }
        }

        public bool PendingChecked
        {
            get { return pendingCheckBox.Checked; }
            set { pendingCheckBox.Checked = value; }
        }

        public bool RejectedCheck
        {
            get { return rejectedCheckBox.Checked; }
            set { rejectedCheckBox.Checked = value; }
        }
    }
}