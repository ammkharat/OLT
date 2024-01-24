using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LabAlertTagQueryDailyRangeControl : UserControl
    {
        public LabAlertTagQueryDailyRangeControl()
        {
            InitializeComponent();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public LabAlertTagQueryDailyRange LabAlertTagQueryRange
        {
            get
            {
                return new LabAlertTagQueryDailyRange(
                    new Time(fromTimePicker.Hour, fromTimePicker.Minute),
                    new Time(toTimePicker.Hour, toTimePicker.Minute));
            }
            set
            {
                fromTimePicker.Hour = value.FromTime.Hour;
                fromTimePicker.Minute = value.FromTime.Minute;
                toTimePicker.Hour = value.ToTime.Hour;
                toTimePicker.Minute = value.ToTime.Minute;
            }
        }
    }
}
