using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class TimeRangePicker : UserControl
    {
        public TimeRangePicker()
        {
            InitializeComponent();
            startTimePicker.ValueChanged += startTimePicker_ValueChanged;
        }

        void startTimePicker_ValueChanged(object sender, System.EventArgs e)
        {
            if (!endTimePicker.Enabled)
            {
                endTimePicker.Value = startTimePicker.Value.AddMinutes(1);
            }
        }

        public bool EndTimeEnabled
        {
            set { endTimePicker.Enabled = value; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Time StartTime
        {
            get
            {
                return new Time(startTimePicker.Hour, startTimePicker.Minute);
            }
            set
            {
                if (value != null)
                {
                    startTimePicker.Hour = value.Hour;
                    startTimePicker.Minute = value.Minute;
                }
                else
                {
                    startTimePicker.Hour = 0;
                    startTimePicker.Minute = 0;
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Time EndTime
        {
            get
            {
                return new Time(endTimePicker.Hour, endTimePicker.Minute);
            }
            set
            {
                if (value != null)
                {
                    endTimePicker.Hour = value.Hour;
                    endTimePicker.Minute = value.Minute;
                }
                else
                {
                    endTimePicker.Hour = 0;
                    endTimePicker.Minute = 0;
                }
            }
        }
    }
}