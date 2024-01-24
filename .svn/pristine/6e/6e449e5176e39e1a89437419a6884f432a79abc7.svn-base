using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class AnalyticsExcelExportForm : BaseForm, IAnalyticsExcelExportView
    {
        public event Action RunButtonClicked;
        public event Action FormLoad;

        public AnalyticsExcelExportForm()
        {
            InitializeComponent();

            runButton.Click += HandleRunButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        public List<string> EventNameValues
        {
            set
            {
                eventListBox.Items.Clear();
                eventListBox.Items.AddRange(value.ToArray());
            }
        }

        public List<string> SelectedEventNames
        {
            get
            {
                List<string> eventNames = new List<string>();
                foreach (string eventName in eventListBox.CheckedItems)
                {
                    eventNames.Add(eventName);
                }
                return eventNames;
            }
        }

        public DateTime FromDateTime
        {
            get { return fromDatePicker.Value.ToDateTimeAtStartOfDay(); }
        }

        public DateTime ToDateTime
        {
            get
            {
                return toDatePicker.Value.ToDateTimeAtEndOfDay();
            }
        }

        public void SetErrorForFromDateAfterToDate()
        {
            errorProvider.SetError(toDatePicker, "The 'To' date must be later than the 'From' date.");
        }

        public void SetErrorForNoEventNamesSelected()
        {
            errorProvider.SetError(eventListBox, "You must select at least one event.");
        }

        protected override void OnLoad(EventArgs e)
        {
            FormLoad();
        }

        private void HandleRunButtonClick(object sender, EventArgs eventArgs)
        {
            if (RunButtonClicked != null)
            {
                RunButtonClicked();
            }
        }
    }
}
