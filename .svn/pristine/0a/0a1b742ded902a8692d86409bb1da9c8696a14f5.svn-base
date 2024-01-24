using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LabAlertTagQueryWeeklyRangeControl : UserControl
    {
        public LabAlertTagQueryWeeklyRangeControl()
        {
            InitializeComponent();
            fromDayOfWeekComboBox.DisplayMember = "Name";
            toDayOfWeekComboBox.DisplayMember = "Name";
            fromDayOfWeekComboBox.DataSource = DayOfWeek.All;
            toDayOfWeekComboBox.DataSource = DayOfWeek.All;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public LabAlertTagQueryWeeklyRange LabAlertTagQueryRange
        {
            get
            {
                return new LabAlertTagQueryWeeklyRange(
                    new Time(fromTimePicker.Hour, fromTimePicker.Minute),
                    new Time(toTimePicker.Hour, toTimePicker.Minute),
                    (DayOfWeek)fromDayOfWeekComboBox.SelectedItem,
                    (DayOfWeek)toDayOfWeekComboBox.SelectedItem);
            }
            set
            {
                fromTimePicker.Hour = value.FromTime.Hour;
                fromTimePicker.Minute = value.FromTime.Minute;
                toTimePicker.Hour = value.ToTime.Hour;
                toTimePicker.Minute = value.ToTime.Minute;
                fromDayOfWeekComboBox.SelectedItem = value.FromDayOfWeek;
                toDayOfWeekComboBox.SelectedItem = value.ToDayOfWeek;
            }
        }
    }
}
