using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class LabAlertTagQueryMonthlyDayOfMonthRangeControl : UserControl
    {
        public LabAlertTagQueryMonthlyDayOfMonthRangeControl()
        {
            InitializeComponent();
            fromDayOfMonthComboBox.DisplayMember = "NthName";
            toDayOfMonthComboBox.DisplayMember = "NthName";
            fromDayOfMonthComboBox.DataSource = DayOfMonth.All;
            toDayOfMonthComboBox.DataSource = DayOfMonth.All;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public LabAlertTagQueryMonthlyDayOfMonthRange LabAlertTagQueryRange
        {
            get
            {
                return new LabAlertTagQueryMonthlyDayOfMonthRange(
                    new Time(fromTimePicker.Hour, fromTimePicker.Minute),
                    new Time(toTimePicker.Hour, toTimePicker.Minute),
                    (DayOfMonth)fromDayOfMonthComboBox.SelectedItem,
                    (DayOfMonth)toDayOfMonthComboBox.SelectedItem);
            }
            set
            {
                fromTimePicker.Hour = value.FromTime.Hour;
                fromTimePicker.Minute = value.FromTime.Minute;
                toTimePicker.Hour = value.ToTime.Hour;
                toTimePicker.Minute = value.ToTime.Minute;
                fromDayOfMonthComboBox.SelectedItem = value.FromDayOfMonth;
                toDayOfMonthComboBox.SelectedItem = value.ToDayOfMonth;
            }
        }
    }
}
