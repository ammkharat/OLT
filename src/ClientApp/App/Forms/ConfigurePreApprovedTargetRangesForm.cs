using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ConfigurePreApprovedTargetRangesForm : BaseForm, IConfigurePreApprovedTargetRangesView
    {
        private readonly ConfigurePreApprovedTargetRangesFormPresenter presenter;

        public event EventHandler FormLoad;
        public event EventHandler Save;
        public event EventHandler Cancel;

        private bool writable;

        public ConfigurePreApprovedTargetRangesForm(TargetDefinition targetDefinition)
        {
            InitializeComponent();
            presenter = new ConfigurePreApprovedTargetRangesFormPresenter(this, targetDefinition);
        }

        public bool WritableMode
        {
            set
            {
                writable = value;

                nteMaxCheckBox.Enabled = value;
                nteMaxTextBox.Enabled = value;

                maxCheckBox.Enabled = value;
                maxTextBox.Enabled = value;

                minCheckBox.Enabled = value;
                minTextBox.Enabled = value;

                nteMinCheckBox.Enabled = value;
                nteMinTextBox.Enabled = value;

                saveButton.Enabled = value;
            }
        }

        public string TargetDefinitionName
        {
            set { targetDefinitionTextBox.Text = value; }
        }

        public bool NeverToExceedMinEnabled
        {
            set
            {
                nteMinCheckBox.Checked = value;
                SetNteMinControlStates();
            }
        }

        public bool NeverToExceedMaxEnabled
        {
            set
            {
                nteMaxCheckBox.Checked = value;
                SetNteMaxControlStates();
            }
        }

        public bool MinEnabled
        {
            set
            {
                minCheckBox.Checked = value;
                SetMinControlStates();
            }
        }

        public bool MaxEnabled
        {
            set
            {
                maxCheckBox.Checked = value;
                SetMaxControlStates();
            }
        }

        public decimal? PreApprovedNeverToExceedMin
        {
            get { return nteMinTextBox.ExtractNullableDecimalValue(); }
            set
            {
                nteMinTextBox.Text = value.Format();
            }
        }

        public decimal? PreApprovedNeverToExceedMax
        {
            get { return nteMaxTextBox.ExtractNullableDecimalValue(); }
            set
            {
                nteMaxTextBox.Text = value.Format();
            }
        }

        public decimal? PreApprovedMin
        {
            get { return minTextBox.ExtractNullableDecimalValue(); }
            set
            {
                minTextBox.Text = value.Format();
            }
        }

        public decimal? PreApprovedMax
        {
            get { return maxTextBox.ExtractNullableDecimalValue(); }
            set
            {
                maxTextBox.Text = value.Format();
            }
        }

        public string TagUnit
        {
            set
            {
                maxUnitLabel.Text = value;
                nteMaxUnitLabel.Text = value;
                minUnitLabel.Text = value;
                nteMinUnitLabel.Text = value;
            }
        }

        public TargetDefinition TargetDefinition
        {
            get { return presenter.BuildTargetDefinition(); }
        }

        private void nteMaxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetNteMaxControlStates();
        }

        private void maxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetMaxControlStates();
        }

        private void minCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetMinControlStates();
        }

        private void nteMinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetNteMinControlStates();
        }

        private void SetNteMaxControlStates()
        {
            if (!nteMaxCheckBox.Checked) nteMaxTextBox.Text = string.Empty;
            nteMaxTextBox.Enabled = writable && nteMaxCheckBox.Checked;
        }

        private void SetMaxControlStates()
        {
            if (!maxCheckBox.Checked) maxTextBox.Text = string.Empty;
            maxTextBox.Enabled = writable && maxCheckBox.Checked;
        }

        private void SetMinControlStates()
        {
            if (!minCheckBox.Checked) minTextBox.Text = string.Empty;
            minTextBox.Enabled = writable && minCheckBox.Checked;
        }

        private void SetNteMinControlStates()
        {
            if (!nteMinCheckBox.Checked) nteMinTextBox.Text = string.Empty;
            nteMinTextBox.Enabled = writable && nteMinCheckBox.Checked;
        }

        private void ConfigurePreApprovedTargetRangesForm_Load(object sender, EventArgs e)
        {
            FormLoad(sender, e);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ThresholdValuesHaveErrors())
                return;

            DialogResult = DialogResult.OK;
            Save(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Cancel(sender, e);
        }

        private bool ThresholdValuesHaveErrors()
        {
            ThresholdValuesErrorProvider.Clear();

            bool hasError = ValidateCheckedFieldIsMissingValue(maxCheckBox, maxTextBox) || ValidateCheckedFieldIsMissingValue(minCheckBox, minTextBox) ||
                            ValidateCheckedFieldIsMissingValue(nteMinCheckBox, nteMinTextBox) || ValidateCheckedFieldIsMissingValue(nteMaxCheckBox, nteMaxTextBox) ||
                            MinGreaterThanMax() || MaxGreaterThanNteMax() || MinLessThanNteMin();

            return hasError;
        }

        private bool ValidateCheckedFieldIsMissingValue(CheckBox checkBox, TextBox textBox)
        {
            bool hasError = checkBox.Checked && textBox.Text.Trim() == string.Empty;
            if (hasError)
                ThresholdValuesErrorProvider.SetError(textBox, StringResources.PreApprovedTargetRangesCheckedFieldsRequireAValue);
            return hasError;
        }

        private bool MinGreaterThanMax()
        {
            bool hasError = minCheckBox.Checked && maxCheckBox.Checked && PreApprovedMin > PreApprovedMax;
            if (hasError)
                ThresholdValuesErrorProvider.SetError(minTextBox, StringResources.PreApprovedTargetRangesMinCannotBeGreaterThanMax);
            return hasError;
        }

        private bool MaxGreaterThanNteMax()
        {
            bool hasError = maxCheckBox.Checked && nteMaxCheckBox.Checked &&
                            PreApprovedMax > PreApprovedNeverToExceedMax;
            if (hasError)
                ThresholdValuesErrorProvider.SetError(maxTextBox,
                                                      StringResources.PreApprovedTargetRangesMaxCannotBeGreaterThanNeverToExceed);
            return hasError;
        }

        private bool MinLessThanNteMin()
        {
            bool hasError = minCheckBox.Checked && nteMinCheckBox.Checked &&
                            PreApprovedMin < PreApprovedNeverToExceedMin;
            if (hasError)
                ThresholdValuesErrorProvider.SetError(minTextBox,
                                                      "Min value cannot be less than Never-to-Exceed Min Value.");
            return hasError;
        }
    }
}