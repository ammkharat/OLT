using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class SubmitPermitRequestForm : BaseForm, ISubmitPermitRequestFormView
    {
        public event EventHandler SubmitButtonClicked;
        public event EventHandler CancelButtonClicked;

        public SubmitPermitRequestForm()
        {
            InitializeComponent();

            submitButton.Click += SubmitButton_Click;
            cancelButton.Click += CancelButton_Click;
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
            dateErrorProvider.Clear();
        }

        public void SetErrorForDate(string errorMessage)
        {
            dateErrorProvider.SetError(datePicker, errorMessage);
        }

        public void SetErrorForDateNotInRange(Date startDate, Date endDate)
        {
            SetErrorForDate(StringResources.SubmitPermitRequestError_WorkPermitDateMustBeBetweenRequestStartAndEndDates);
        }

        public void SetErrorForNoRequestsShareAnyDates()
        {
            SetErrorForDate(StringResources.SubmitPermitRequestError_WorkPermitDateMustBeBetweenRequestStartAndEndDates);
        }
    }
}