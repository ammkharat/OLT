using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ScheduleDisplay : UserControl
    {
        private ISchedule schedule;
        private bool showEndDateForSingle;

        private bool showEndTimeOnlyIfEndDateNotNull;
        private bool showEndTimeRegardlessOfEndDateNull;
        private bool showStartEndTimesForContinuous;

        public ScheduleDisplay()
        {
            InitializeComponent();
        }

        public ISchedule Schedule
        {
            get { return schedule; }

            set
            {
                schedule = value;
                if (value != null)
                {
                    startDateData.Text = Date.ToDateString(schedule.StartDate);
                    endDateData.Text = schedule.HasEndDate
                        ? Date.ToDateString(schedule.EndDate)
                        : StringResources.NoData;

                    if (schedule.IsRecurring)
                    {
                        startTimeData.Text = schedule.StartTime.ToString();
                        endTimeData.Text = schedule.HasEndTime ? schedule.EndTime.ToString() : StringResources.NoData;
                    }
                    else if (schedule is SingleSchedule)
                    {
                        startTimeData.Text = schedule.StartDateTime.ToTimeString();
                        endTimeData.Text = schedule.HasEndTime
                            ? schedule.EndDateTime.ToTimeString()
                            : StringResources.NoData;
                    }
                    else if (schedule is ContinuousSchedule && showStartEndTimesForContinuous)
                    {
                        startTimeData.Text = schedule.StartDateTime.ToTimeString();
                        endTimeData.Text = schedule.HasEndTime
                            ? schedule.EndDateTime.ToTimeString()
                            : StringResources.NoData;
                    }
                    else
                    {
                        startTimeData.Text = string.Empty;
                        endTimeData.Text = string.Empty;
                    }

                    // Override the end time display for all schedules regardless of end date
                    if (showEndTimeRegardlessOfEndDateNull)
                    {
                        endTimeData.Text = schedule.EndTime.ToString();
                    }

                    // Override the end time display for all schedules that have null for end date
                    if (showEndTimeOnlyIfEndDateNotNull)
                    {
                        endTimeData.Text = schedule.HasEndDate
                            ? schedule.EndTime.ToString()
                            : StringResources.NoData;
                    }

                    // Override the end date display for single schedules to use EndDateTime
                    if (showEndDateForSingle)
                    {
                        endDateData.Text = schedule.EndDateTime.ToDateString();
                    }

                    occursData.Text = schedule.RecurrencePatternString;
                }
            }
        }

        [Browsable(true), Category("OLT")]
        public bool ShowStartAndEndTimesForContinuousSchedules
        {
            set { showStartEndTimesForContinuous = value; }
            get { return showStartEndTimesForContinuous; }
        }

        [Browsable(true), Category("OLT"), DefaultValue(false)]
        public bool ShowEndTimeRegardlessOfEndDateNull
        {
            set { showEndTimeRegardlessOfEndDateNull = value; }
            get { return showEndTimeRegardlessOfEndDateNull; }
        }

        [Browsable(true), Category("OLT"), DefaultValue(false)]
        public bool ShowEndTimeOnlyIfEndDateNotNull
        {
            set { showEndTimeOnlyIfEndDateNotNull = value; }
            get { return showEndTimeOnlyIfEndDateNotNull; }
        }

        [Browsable(true), Category("OLT"), DefaultValue(false)]
        public bool ShowEndDateTimeForSingleEndDate
        {
            set { showEndDateForSingle = value; }
            get { return showEndDateForSingle; }
        }
    }
}