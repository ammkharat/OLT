using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class SimpleSchedulePicker : UserControl, ISimpleSchedulePickerView
    {
        private static readonly ScheduleType[] ALLOWED_SCHEDULES =
                {
                        ScheduleType.Daily,
                        ScheduleType.Weekly,
                        ScheduleType.MonthlyDayOfMonth,
                        ScheduleType.MonthlyDayOfWeek
                };

        public Action<ScheduleType, Time> ScheduleTypeChanged;
        public Action<Time> DailyTimeChanged;

        private readonly SimpleSchedulePickerPresenter presenter;

        public SimpleSchedulePicker()
        {
            InitializeComponent();

            presenter = new SimpleSchedulePickerPresenter(this);

            HideAllRecurrencePatterns();
            dailyGroupBox.Visible = true;

            scheduleTypesComboBox.DisplayMember = "Name";
            scheduleTypesComboBox.DataSource = new List<ScheduleType>(ALLOWED_SCHEDULES);

            daily_TimePicker.Value = new Time(0);
            daily_TimePicker.ValueChanged += DailyTimePicker_ValueChanged;

            weekly_DayOfWeekComboBox.DisplayMember = "Name";
            weekly_DayOfWeekComboBox.DataSource = DayOfWeek.All;
            weekly_TimePicker.Value = new Time(0);

            monthlyByDayOfWeek_DayOfWeekComboBox.DisplayMember = "Name";
            monthlyByDayOfWeek_DayOfWeekComboBox.DataSource = DayOfWeek.All;
            monthlyByDayOfWeek_WeekOfMonthComboBox.DisplayMember = "Name";
            monthlyByDayOfWeek_WeekOfMonthComboBox.DataSource = WeekOfMonth.All;
            monthlyByDayOfWeek_TimePicker.Value = new Time(0);

            monthlyByDayOfMonth_DayOfMonthComboBox.DisplayMember = "NthName";
            monthlyByDayOfMonth_DayOfMonthComboBox.DataSource = DayOfMonth.All;
            monthlyByDayOfMonth_TimePicker.Value = new Time(0);

            scheduleTypesComboBox.SelectedIndexChanged += ScheduleTypesComboBox_SelectedIndexChanged;
        }

        private void ScheduleTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllRecurrencePatterns();

            ScheduleType scheduleType = (ScheduleType)scheduleTypesComboBox.SelectedItem;
            if (scheduleType == ScheduleType.Daily)
            {
                dailyGroupBox.Visible = true;
            }
            else if (scheduleType == ScheduleType.Weekly)
            {
                weeklyGroupBox.Visible = true;
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfWeek)
            {
                monthlyByDayOfWeekGroupBox.Visible = true;
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfMonth)
            {
                monthlyByDayOfMonthGroupBox.Visible = true;
            }
            else
            {
                throw new Exception("Unrecognized schedule type: " + scheduleType);
            }

            if (ScheduleTypeChanged != null)
            {
                ScheduleTypeChanged(scheduleType, daily_TimePicker.Value);
            }
        }

        private void DailyTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (DailyTimeChanged != null)
            {
                DailyTimeChanged(daily_TimePicker.Value);
            }
        }

        private void HideAllRecurrencePatterns()
        {
            dailyGroupBox.Visible = false;
            weeklyGroupBox.Visible = false;
            monthlyByDayOfWeekGroupBox.Visible = false;
            monthlyByDayOfMonthGroupBox.Visible = false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ISchedule Schedule
        {
            get { return presenter.Schedule; }
            set { presenter.Schedule = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public ScheduleType SelectedScheduleType
        {
            get { return scheduleTypesComboBox.SelectedItem as ScheduleType; }
            set { scheduleTypesComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Time Daily_Time
        {
            get { return daily_TimePicker.Value; }
            set { daily_TimePicker.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DayOfWeek Weekly_DayOfWeek
        {
            get { return (DayOfWeek)weekly_DayOfWeekComboBox.SelectedItem; }
            set { weekly_DayOfWeekComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Time Weekly_Time
        {
            get { return weekly_TimePicker.Value; }
            set { weekly_TimePicker.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public WeekOfMonth MonthlyByDayOfWeek_WeekOfMonth
        {
            get { return (WeekOfMonth)monthlyByDayOfWeek_WeekOfMonthComboBox.SelectedItem; }
            set { monthlyByDayOfWeek_WeekOfMonthComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DayOfWeek MonthlyByDayOfWeek_DayOfWeek
        {
            get { return (DayOfWeek)monthlyByDayOfWeek_DayOfWeekComboBox.SelectedItem; }
            set { monthlyByDayOfWeek_DayOfWeekComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Time MonthlyByDayOfWeek_Time
        {
            get { return monthlyByDayOfWeek_TimePicker.Value; }
            set { monthlyByDayOfWeek_TimePicker.Value = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public DayOfMonth MonthlyByDayOfMonth_DayOfMonth
        {
            get { return (DayOfMonth)monthlyByDayOfMonth_DayOfMonthComboBox.SelectedItem; }
            set { monthlyByDayOfMonth_DayOfMonthComboBox.SelectedItem = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Time MonthlyByDayOfMonth_Time
        {
            get { return monthlyByDayOfMonth_TimePicker.Value; }
            set { monthlyByDayOfMonth_TimePicker.Value = value; }
        }

        public bool HasScheduleError
        {
            get { return presenter.ValidateViewHasError(); }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public Time DailyTime
        {
            get { return daily_TimePicker.Value; }
        }
    }
}