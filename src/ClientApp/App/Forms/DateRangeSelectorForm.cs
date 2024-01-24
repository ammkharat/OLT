using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DateRangeSelectorForm : BaseForm, IDateRangeSelectorFormView
    {
        private DateRangeSelectorPresenter presenter;

        public DateRangeSelectorForm()
        {
            InitializeComponent();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            presenter = new DateRangeSelectorPresenter(this);
            selectButton.Click += presenter.HandleSelectButtonClicked;
            cancelButton.Click += presenter.HandleCancelButtonClicked;
            Load += presenter.HandleFormLoad;
            fixedRangeRadioButton.CheckedChanged += presenter.HandleFixedRangeSelected;
            customRangeRadioButton.CheckedChanged += presenter.HandleCustomRangeSelected;
        }

        public DialogResultAndOutput<Range<Date>> DisplayFormAsDialog(IWin32Window owner)
        {
            DialogResult result = ShowDialog(owner);
            DialogResultAndOutput<Range<Date>> dialogResultAndOutput = new DialogResultAndOutput<Range<Date>>(result, presenter.DateRange);
            Dispose();
            return dialogResultAndOutput;
            
        }

        public bool FixedRangeChecked
        {
            get { return fixedRangeRadioButton.Checked; }            
        }

        public bool CustomRangeChecked
        {
            get { return customRangeRadioButton.Checked; }
            set { customRangeRadioButton.Checked = value; }
        }

        //RITM0232944 - Vibhor
        public void SetErrorForStartDateCannotGreaterThanendDate()
        {
            errorProvider.SetError(endRangeDatePicker, StringResources.StartDateBeforeEndDate);                        
        }       

        public void AddFixedRangeDuration(Duration duration)
        {
            fixedRangeComboBox.Items.Add(duration);
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
    }
}