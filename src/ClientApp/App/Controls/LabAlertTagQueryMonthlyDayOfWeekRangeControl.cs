using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LabAlertTagQueryMonthlyDayOfWeekRangeControl : UserControl
    {
        public LabAlertTagQueryMonthlyDayOfWeekRangeControl()
        {
            InitializeComponent();

            fromWeekOfMonthComboBox.DisplayMember = "Name";
            toWeekOfMonthComboBox.DisplayMember = "Name";
            fromWeekOfMonthComboBox.DataSource = WeekOfMonth.All;
            toWeekOfMonthComboBox.DataSource = WeekOfMonth.All;

            fromDayOfWeekComboBox.DisplayMember = "Name";
            toDayOfWeekComboBox.DisplayMember = "Name";
            fromDayOfWeekComboBox.DataSource = DayOfWeek.All;
            toDayOfWeekComboBox.DataSource = DayOfWeek.All;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public LabAlertTagQueryMonthlyDayOfWeekRange LabAlertTagQueryRange
        {
            get
            {
                return new LabAlertTagQueryMonthlyDayOfWeekRange(
                    new Time(fromTimePicker.Hour, fromTimePicker.Minute),
                    new Time(toTimePicker.Hour, toTimePicker.Minute),
                    (WeekOfMonth)fromWeekOfMonthComboBox.SelectedItem,
                    (WeekOfMonth)toWeekOfMonthComboBox.SelectedItem,
                    (DayOfWeek)fromDayOfWeekComboBox.SelectedItem,
                    (DayOfWeek)toDayOfWeekComboBox.SelectedItem);
            }
            set
            {
                fromTimePicker.Hour = value.FromTime.Hour;
                fromTimePicker.Minute = value.FromTime.Minute;
                toTimePicker.Hour = value.ToTime.Hour;
                toTimePicker.Minute = value.ToTime.Minute;
                fromWeekOfMonthComboBox.SelectedItem = value.FromWeekOfMonth;
                toWeekOfMonthComboBox.SelectedItem = value.ToWeekOfMonth;
                fromDayOfWeekComboBox.SelectedItem = value.FromDayOfWeek;
                toDayOfWeekComboBox.SelectedItem = value.ToDayOfWeek;
            }
        }
    }
}
