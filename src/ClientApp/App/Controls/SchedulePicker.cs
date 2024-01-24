using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Localization;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class SchedulePicker : UserControl, ISchedulePickerView
    {
        public Action<ScheduleType> ScheduleTypeChanged;

        private readonly SchedulePickerPresenter presenter;
        private SchedulePresenterMode mode;

        public SchedulePicker()
        {
            InitializeComponent();
            InitializeSelectionData();
            presenter = new SchedulePickerPresenter(this);
            RegisterPresenterEventHandlers();
        }

        private void RegisterPresenterEventHandlers()
        {
            Load += presenter.SchedulePicker_Load;
            scheduleTypesComboBox.SelectedIndexChanged += ScheduleTypesComboBox_SelectedIndexChanged;
            dateRangePicker.OnNoEndDateCheckBoxCheckChanged += presenter.HandleNoEndDateCheckChanged;
        }

        private void ScheduleTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.ScheduleTypesComboBox_SelectedIndexChanged(sender, e);
            if (ScheduleTypeChanged != null)
            {
                ScheduleType scheduleType = (ScheduleType)scheduleTypesComboBox.SelectedItem;
                ScheduleTypeChanged(scheduleType);
            }
        }

        private void InitializeSelectionData()
        {
            janCheckBox.Value = Month.January;
            febCheckBox.Value = Month.February;
            marCheckBox.Value = Month.March;
            aprCheckBox.Value = Month.April;
            mayCheckBox.Value = Month.May;
            junCheckBox.Value = Month.June;
            julCheckBox.Value = Month.July;
            augCheckBox.Value = Month.August;
            sepCheckBox.Value = Month.September;
            octCheckBox.Value = Month.October;
            novCheckBox.Value = Month.November;
            decCheckBox.Value = Month.December;
            mondayCheckBox.Value = DayOfWeek.Monday;
            tuesdayCheckBox.Value = DayOfWeek.Tuesday;
            wednesdayCheckBox.Value = DayOfWeek.Wednesday;
            thursdayCheckBox.Value = DayOfWeek.Thursday;
            fridayCheckBox.Value = DayOfWeek.Friday;
            saturdayCheckBox.Value = DayOfWeek.Saturday;
            sundayCheckBox.Value = DayOfWeek.Sunday;
            scheduleTypesComboBox.DisplayMember = "Name";
            dayOfWeekComboBox.DisplayMember = "Name";
            dayOfMonthComboBox.DisplayMember = "Name";
            weekOfMonthComboBox.DisplayMember = "Name";
            dayOfMonthComboBox.DataSource = DayOfMonth.All;
            dayOfWeekComboBox.DataSource = DayOfWeek.All;
            weekOfMonthComboBox.DataSource = WeekOfMonth.All;
        }

        public List <ScheduleType> AllowedScheduleTypes
        {
            set { scheduleTypesComboBox.DataSource = value; }
        }

        public string TimeRangeLabel
        {
            set { timeRangeGroupBox.Text = value; }
        }

        public string FrequencyUnitLabel
        {
            set { unitLabel.Text = value; }
        }

        public bool MonthGroupEnabled
        {
            set { monthlyGroupBox.Enabled = value; }
        }

        public bool WeeklyGroupEnabled
        {
            set { weeklyGroupBox.Enabled = value; }
        }

        public bool FrequencyGroupEnabled
        {
            set { frequencyGroupBox.Enabled = value; }
        }

        public bool TimeRangeGroupEnabled
        {
            set { timeRangeGroupBox.Enabled = value; }
        }

        public bool DateRangeGroupEnabled
        {
            set { dateRangeGroupBox.Enabled = value; }
        }

        public bool DayOfMonthEnabled
        {
            set
            {
                dayOfMonthComboBox.Enabled = value;
                weekOfMonthComboBox.Enabled = !value;
                dayOfWeekComboBox.Enabled = !value;
            }
        }

        public bool NoEndDateEnabled
        {
            set
            {
                dateRangePicker.NoEndDateEnabled = value;
                dateRangePicker.NoEndDate = !value;
            }
        }

        //RITM0265710 - mangesh
        public bool EveryShiftEnabled
        {
            set
            {
                everyShiftCheckBox.Visible = value;
            }
        }

        public bool EndTimeEnabled
        {
            set { timeRangePicker.EndTimeEnabled = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ISchedule Schedule
        {
            get { return presenter.Schedule; }
            set { presenter.Schedule = value; }
        }

        public SchedulePresenterMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ScheduleType SelectedScheduleType
        {
            get { return scheduleTypesComboBox.SelectedItem as ScheduleType; }
            set { scheduleTypesComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Date StartDate
        {
            get { return dateRangePicker.StartDate; }
            set { dateRangePicker.StartDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime MinStartDate
        {
            set { dateRangePicker.MinStartDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Date EndDate
        {
            get { return dateRangePicker.EndDate; }
            set { dateRangePicker.EndDate = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Time StartTime
        {
            get { return timeRangePicker.StartTime; }
            set { timeRangePicker.StartTime = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Time EndTime
        {
            get { return timeRangePicker.EndTime; }
            set { timeRangePicker.EndTime = value; }
        }

        public int Frequency
        {
            get { return (int) frequencyUpDown.Value; }
            set { frequencyUpDown.Value = value; }
        }

        //RITM0265710 - mangesh
        public bool EveryShift
        {
            get { return (bool)everyShiftCheckBox.Checked; }
            set { everyShiftCheckBox.Checked = value; }
        }

        public int WeeklyFrequency
        {
            get { return (int) weeklyUpDown.Value; }
            set { weeklyUpDown.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DayOfMonth DayOfMonth
        {
            get { return dayOfMonthComboBox.SelectedItem as DayOfMonth; }
            set { dayOfMonthComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WeekOfMonth WeekOfMonth
        {
            get { return weekOfMonthComboBox.SelectedItem as WeekOfMonth; }
            set { weekOfMonthComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DayOfWeek DayOfWeek
        {
            get { return dayOfWeekComboBox.SelectedItem as DayOfWeek; }
            set { dayOfWeekComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List <Month> MonthsToInclude
        {
            get
            {
                List <Month> monthsToInclude = new List <Month>();
                foreach (Control control in monthlyGroupBox.Controls)
                {
                    if(control is OltCheckBox && ((OltCheckBox) control).Checked)
                    {
                        monthsToInclude.Add(((OltCheckBox) control).Value as Month);
                    }
                }
                return monthsToInclude;
            }
            set
            {
                foreach (Control control in monthlyGroupBox.Controls)
                {
                    if(control is OltCheckBox)
                    {
                        OltCheckBox checkBox = control as OltCheckBox;
                        foreach (Month month in value)
                        {
                            if(checkBox.Value.Equals(month))
                            {
                                checkBox.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public List <DayOfWeek> DaysToInclude
        {
            get
            {
                List <DayOfWeek> daysToInclude = new List <DayOfWeek>();
                foreach (Control control in weeklyGroupBox.Controls)
                {
                    if(control is OltCheckBox && ((OltCheckBox) control).Checked)
                    {
                        daysToInclude.Add(((OltCheckBox) control).Value as DayOfWeek);
                    }
                }
                return daysToInclude;
            }
            set
            {
                foreach (Control control in weeklyGroupBox.Controls)
                {
                    if(control is OltCheckBox)
                    {
                        OltCheckBox checkBox = control as OltCheckBox;
                        foreach (DayOfWeek day in value)
                        {
                            if(checkBox.Value.Equals(day))
                            {
                                checkBox.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public bool NoEndDate
        {
            get { return dateRangePicker.NoEndDate; }
            set { dateRangePicker.NoEndDate = value; }
        }

        public bool HasScheduleError
        {
            get { return presenter.ValidateViewHasError(); }
        }
        
        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void ShowScheduleWillNotFireError()
        {
            errorProvider.SetError(scheduleTypesComboBox, StringResources.SchedulePickerScheduleWillNotFireError);
        }

        public void ShowFrequencyNotGreaterThanZeroError()
        {
            errorProvider.SetError(frequencyUpDown, StringResources.SchedulePickerFrequencyShouldBeGreaterThanZeroError);
        }

        public void ShowWeeklyAtLeastOneDayOfWeekRequiredError()
        {
            errorProvider.SetError(wednesdayCheckBox, StringResources.SchedulePickerOneDayOfWeekRequiredError);
        }

        public void ShowWeeklyFrequencyNotGreaterThanZeroError()
        {
            errorProvider.SetError(weeklyUpDown, StringResources.SchedulePickerWeeklyFrequencyShouldBeGreaterThanZeroError);
        }

        public void ShowMonthlyAtLeastOneMonthRequiredError()
        {
            errorProvider.SetError(junCheckBox, StringResources.SchedulePickerAtLeastOneMonthRequiredError);
        }

        public void ShowErrorMessage(string message)
        {
            errorProvider.SetError(scheduleTypesComboBox, message);
        }
    }
}