using System;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class DateRangePicker : UserControl
    {
        public EventHandler OnNoEndDateCheckBoxCheckChanged;

        public DateRangePicker()
        {
            InitializeComponent();
            noEndDateCheckBox.CheckedChanged += noEndDateCheckBox_CheckedChanged;
            startDatePicker.ValueChanged += startDatePicker_ValueChanged;
            endDatePicker.ValueChanged += endDatePicker_ValueChanged;
        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (EndDate != null && StartDate > EndDate)
            {
                StartDateValueChangedHandlerEnabled = false;
                StartDate = EndDate;
                StartDateValueChangedHandlerEnabled = true;
            }
        }

        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (EndDate != null && StartDate > EndDate)
            {
                EndDateValueChangedHandlerEnabled = false;
                EndDate = StartDate;
                EndDateValueChangedHandlerEnabled = true;
            }
        }

        private void noEndDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnNoEndDateCheckBoxCheckChanged != null)
            {
                OnNoEndDateCheckBoxCheckChanged(this, e);
            }
            endDatePicker.Enabled = !NoEndDate;
            if (!NoEndDate)
            {
                startDatePicker_ValueChanged(this, e);
            }
        }

        public DateTime MinStartDate
        {
            set
            {
                startDatePicker.MinDate = value;
                endDatePicker.MinDate = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Date StartDate
        {
            get { return startDatePicker.Value; }
            set
            {
                startDatePicker.Value = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Date EndDate
        {
            get
            {
                Date result = null;
                if (!NoEndDate)
                {
                    result = endDatePicker.Value;
                }
                return result;
            }
            set
            {
                if (value != null)
                {
                    endDatePicker.Value = value;
                }
            }
        }

        public bool NoEndDateEnabled
        {
            set
            {
                noEndDateCheckBox.Enabled = value;
                endDatePicker.Enabled = value;
            }
        }

        public bool NoEndDate
        {
            get { return noEndDateCheckBox.Checked; }
            set { noEndDateCheckBox.Checked = value; }
        }

        public bool StartDateValueChangedHandlerEnabled
        {
            set
            {
                if (value)
                {
                    startDatePicker.ValueChanged += startDatePicker_ValueChanged;
                }
                else
                {
                    startDatePicker.ValueChanged -= startDatePicker_ValueChanged;
                }
            }
        }

        public bool EndDateValueChangedHandlerEnabled
        {
            set
            {
                if (value)
                {
                    endDatePicker.ValueChanged += endDatePicker_ValueChanged;
                }
                else
                {
                    endDatePicker.ValueChanged -= endDatePicker_ValueChanged;
                }
            }
        }
    }
}
