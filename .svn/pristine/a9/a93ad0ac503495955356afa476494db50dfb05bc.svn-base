using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SubmitPermitRequestWithGroupsOptionForm : BaseForm, ISubmitPermitRequestWithGroupsOptionFormView
    {
        public event EventHandler SubmitButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action GroupSelectionChanged;

        public event Action SubmissionTypeChanged;
        
        public SubmitPermitRequestWithGroupsOptionForm()
        {
            InitializeComponent();

            submitButton.Click += SubmitButton_Click;
            cancelButton.Click += CancelButton_Click;
            groupComboBox.SelectedValueChanged += GroupComboBoxOnSelectedValueChanged;

            allCompletedRadioButton.CheckedChanged += AllCompletedRadioButtonOnCheckedChanged;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            onlySelectedRadioButton.Checked = true;
            allCompletedRadioButton.Checked = false;
            AllCompletedRadioButtonOnCheckedChanged(null, null);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (SubmitButtonClicked != null)
            {
                SubmitButtonClicked(sender, e);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void GroupComboBoxOnSelectedValueChanged(object sender, EventArgs eventArgs)
        {
            if (GroupSelectionChanged != null)
            {
                GroupSelectionChanged();
            }
        }

        private void AllCompletedRadioButtonOnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (SubmissionTypeChanged != null)
            {
                SubmissionTypeChanged();
            }
        }

        public void DisableAllCompletedPermitRequestsOption()
        {
            allCompletedRadioButton.Checked = false;
            onlySelectedRadioButton.Checked = true;

            allCompletedRadioButton.Enabled = false;
            groupComboBox.Enabled = false;
        }

        public Date Date
        {
            get { return datePicker.Value; }
            set { datePicker.Value = value; }
        }

        public bool DateEnabled
        {
            set { datePicker.Enabled = value; }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorForDate(string errorMessage)
        {
            errorProvider.SetError(datePicker, errorMessage);
        }

        public void SetErrorForDateNotInRange(Date startDate, Date endDate)
        {
            string errorMessage = String.Format(StringResources.SubmitPermitRequestError_WorkPermitDateMustBeBetweenGivenStartAndEndDates, startDate, endDate);
            SetErrorForDate(errorMessage);
        }

        public void SetErrorForNoRequestsShareAnyDates()
        {
            SetErrorForDate(StringResources.SubmitPermitRequestError_NoneOfTheSelectedPermitRequestsShareAnyDates);
        }

        public void SetErrorForNoCompletedPermitRequestsFound()
        {
            SetErrorForDate(StringResources.SubmitPermitRequestError_NoCompletedPermitRequestsFoundForTheSelectedDate);
        }

        public List<IWorkPermitGroup> AllGroups
        {
            set { groupComboBox.DataSource = value; }
        }

        public IWorkPermitGroup Group
        {
            get { return (IWorkPermitGroup) groupComboBox.SelectedItem; }
        }

        public bool GroupSelectionEnabled
        {
            set { groupComboBox.Enabled = value; }
        }

        public bool SubmitAllCompletedPermitRequestsForASpecificGroup
        {
            get { return allCompletedRadioButton.Checked; }
        }

        public bool SubmitOnlySelectedPermitRequests
        {
            get { return onlySelectedRadioButton.Checked; }
        }
    }
}
