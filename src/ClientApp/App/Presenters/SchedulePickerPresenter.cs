using System;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Clock = Com.Suncor.Olt.Common.Utility.Clock;

namespace Com.Suncor.Olt.Client.Presenters
{
    public enum SchedulePresenterMode
    {
        ActionItem,
        Target,
        Log
    } ;

    public class SchedulePickerPresenter
    {
        private const int DEFAULT_MINUTE_FREQUENCY = 15;

        private readonly ISchedulePickerView view;
        private long? scheduleId;

        private int NEXT_HOUR;

        public SchedulePickerPresenter(ISchedulePickerView view)
        {
            this.view = view;
        }

        public ISchedule Schedule
        {
            get { return CreateScheduleFromView(); }
            set
            {
                if (value != null)
                {
                    scheduleId = value.Id;
                    UpdateViewFromSchedule(value);
                }
            }
        }

        public void SchedulePicker_Load(object sender, EventArgs e)
        {
            if (scheduleId.HasNoValue())
            {
                DateTime now = Clock.Now;
                DateTime nextHourComingUp = now.AddHours(1);

                view.StartDate = new Date(nextHourComingUp);
                NEXT_HOUR = nextHourComingUp.Hour;

                view.StartTime = new Time(NEXT_HOUR);

                view.EndTime = view.Mode == SchedulePresenterMode.Log ? view.StartTime : new Time(NEXT_HOUR).Add(1);

                if (view.Mode == SchedulePresenterMode.Target)
                {
                    view.EndDate = view.StartDate.AddDays(1);
                }

                // Default repeating frequency to 1 (0 doesn't really make sense when you want repeating):
                view.Frequency = 1;
                view.WeeklyFrequency = 1;
            }
            // Snapshot current time so that All the values are consistent in case the clock rolls over:
        }

        public void UpdateViewFromSchedule(ISchedule value)
        {
            ScheduleType selectedType = value.Type;

            view.SelectedScheduleType = selectedType;
            view.NoEndDate = !value.HasEndDate;

            view.StartDate = value.StartDate;
            view.EndDate = value.EndDate;
            view.StartTime = value.StartTime;
            view.EndTime = value.EndTime;

            if (selectedType == ScheduleType.Hourly)
            {
                var schedule = value as RecurringHourlySchedule;
                view.Frequency = schedule.Frequency;
            }
            else if (selectedType == ScheduleType.ByMinute)
            {
                var schedule = value as RecurringMinuteSchedule;
                view.Frequency = schedule.Frequency;
            }
            else if (selectedType == ScheduleType.Daily)
            {
                var schedule = value as RecurringDailySchedule;
                view.Frequency = schedule.Frequency;
                view.EveryShift = schedule.EveryShift; //RITM0265710 mangesh   commented out by ayman to fix code overlap
            }
            else if (selectedType == ScheduleType.Weekly)
            {
                var schedule = value as RecurringWeeklySchedule;
                view.DaysToInclude = schedule.DaysOfWeek;
                view.WeeklyFrequency = schedule.Frequency;
            }
            else if (selectedType == ScheduleType.MonthlyDayOfMonth)
            {
                var schedule = value as RecurringMonthlyDayOfMonthSchedule;
                view.DayOfMonth = schedule.DayOfMonth;
                view.MonthsToInclude = schedule.MonthsToInclude;
            }
            else if (selectedType == ScheduleType.MonthlyDayOfWeek)
            {
                var schedule = value as RecurringMonthlyDayOfWeekSchedule;
                view.WeekOfMonth = schedule.WeekOfMonth;
                view.DayOfWeek = schedule.DayOfWeek;
                view.MonthsToInclude = schedule.MonthsToInclude;
            }
            else if (selectedType == ScheduleType.RoundTheClock)
            {
                var schedule = value as RoundTheClockSchedule;
                view.Frequency = schedule.Frequency;
            }
        }

        public ISchedule CreateScheduleFromView()
        {
            ISchedule result = null;
            ScheduleType selectedType = view.SelectedScheduleType;

            Site site = ClientSession.GetUserContext().Site;
            
            if (selectedType != null)
            {
                if (selectedType == ScheduleType.Single)
                {
                    result = new SingleSchedule(view.StartDate, view.StartTime, view.EndTime, site);
                }
                else if (selectedType == ScheduleType.Continuous)
                {
                    result = new ContinuousSchedule(view.StartDate, view.EndDate, view.StartTime, view.EndTime, site);
                }
                else if (selectedType == ScheduleType.Hourly)
                {
                    result = new RecurringHourlySchedule(view.StartDate,
                                                         view.EndDate,
                                                         view.StartTime,
                                                         view.EndTime,
                                                         view.Frequency, site);
                }
                else if (selectedType == ScheduleType.ByMinute)
                {
                    result = new RecurringMinuteSchedule(view.StartDate,
                                                         view.EndDate,
                                                         view.StartTime,
                                                         view.EndTime,
                                                         view.Frequency, site);
                }
                else if (selectedType == ScheduleType.Daily)
                {
                    result = new RecurringDailySchedule(view.StartDate,
                        view.EndDate,
                        view.StartTime,
                        view.EndTime,
                        view.Frequency, site,
                        view.EveryShift);//RITM0265710 - mangesh
                }
                else if (selectedType == ScheduleType.Weekly)
                {
                    result = new RecurringWeeklySchedule(view.StartDate,
                                                         view.EndDate,
                                                         view.StartTime,
                                                         view.EndTime,
                                                         view.DaysToInclude,
                                                         view.WeeklyFrequency, site);
                }
                else if (selectedType == ScheduleType.MonthlyDayOfMonth)
                {
                    result = new RecurringMonthlyDayOfMonthSchedule(view.StartDate,
                                                                    view.EndDate,
                                                                    view.StartTime,
                                                                    view.EndTime,
                                                                    view.DayOfMonth,
                                                                    view.MonthsToInclude, site);
                }
                else if (selectedType == ScheduleType.MonthlyDayOfWeek)
                {
                    result = new RecurringMonthlyDayOfWeekSchedule(view.StartDate,
                                                                   view.EndDate,
                                                                   view.StartTime,
                                                                   view.EndTime,
                                                                   view.WeekOfMonth,
                                                                   view.DayOfWeek,
                                                                   view.MonthsToInclude, site);
                }
                else if (selectedType == ScheduleType.RoundTheClock)
                {
                    result = new RoundTheClockSchedule(view.StartDate,
                                                           view.EndDate, 
                                                           view.StartTime, 
                                                           view.EndTime, 
                                                           view.Frequency,
                                                           site);
                }
                else
                {
                    throw new ArgumentException("This schedule type not supported");
                }

                result.Id = scheduleId;
            }


            return result;
        }

        public void ScheduleTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleType selectedType = view.SelectedScheduleType;

            view.MonthGroupEnabled = true;
            view.WeeklyGroupEnabled = true;
            view.FrequencyGroupEnabled = true;
            view.TimeRangeGroupEnabled = true;
            view.NoEndDateEnabled = true;
            view.DateRangeGroupEnabled = true;
            view.EndTimeEnabled = true;

            //RITM0265710 - mangesh
            view.EveryShiftEnabled = false;
            view.EveryShift = false;

            SetDefaultStartAndEndTimeNextHourTime();

            if (selectedType == ScheduleType.Single)
            {
                view.NoEndDateEnabled = false;
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
                view.FrequencyGroupEnabled = false;
            }
            else if (selectedType == ScheduleType.Continuous)
            {
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
                view.FrequencyGroupEnabled = false;
            }
            else if (selectedType == ScheduleType.Hourly)
            {
                SetDefaultStartAndEndTimeAt24Hours();
                view.FrequencyUnitLabel = StringResources.SchedulePickerFrequencyUnitsLabel_Hours;
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
            }
            else if (selectedType == ScheduleType.ByMinute)
            {
                SetDefaultStartAndEndTimeAt24Hours();
                view.Frequency = DEFAULT_MINUTE_FREQUENCY;
                view.FrequencyUnitLabel = StringResources.SchedulePickerFrequencyUnitsLabel_Minutes;
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
            }
            else if (selectedType == ScheduleType.Daily)
            {
                view.FrequencyUnitLabel = StringResources.SchedulePickerFrequencyUnitsLabel_Days;
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
                if (view.Mode != SchedulePresenterMode.ActionItem)
                {
                    view.EndTimeEnabled = false;
                }
                view.EveryShiftEnabled = true;
            }
            else if (selectedType == ScheduleType.Weekly)
            {
                view.MonthGroupEnabled = false;
                view.FrequencyGroupEnabled = false;
                if (view.Mode != SchedulePresenterMode.ActionItem)
                {
                    view.EndTimeEnabled = false;
                }
            }
            else if (selectedType == ScheduleType.MonthlyDayOfMonth)
            {
                view.DayOfMonthEnabled = true;
                view.WeeklyGroupEnabled = false;
                view.FrequencyGroupEnabled = false;
                if (view.Mode != SchedulePresenterMode.ActionItem)
                {
                    view.EndTimeEnabled = false;
                }
            }
            else if (selectedType == ScheduleType.MonthlyDayOfWeek)
            {
                view.DayOfMonthEnabled = false;
                view.WeeklyGroupEnabled = false;
                view.FrequencyGroupEnabled = false;
                if (view.Mode != SchedulePresenterMode.ActionItem)
                {
                    view.EndTimeEnabled = false;
                }
            }
            else if (selectedType == ScheduleType.RoundTheClock)
            {
                SetDefaultStartAndEndTimeAt24Hours();
                view.Frequency = DEFAULT_MINUTE_FREQUENCY;
                view.FrequencyUnitLabel = StringResources.SchedulePickerFrequencyUnitsLabel_Minutes;
                view.MonthGroupEnabled = false;
                view.WeeklyGroupEnabled = false;
            }

            SetPollingLabel(selectedType != ScheduleType.RoundTheClock);
        }
        
        private void SetPollingLabel(bool usePollingLabel)
        {
            if (view.Mode == SchedulePresenterMode.ActionItem)
            {
                view.TimeRangeLabel = StringResources.SchedulePickerPollingLabel_StartEndTimes;
            }
            else
            {
                view.TimeRangeLabel = usePollingLabel ? StringResources.SchedulePickerPollingLabel_DailyPollingTimes : StringResources.SchedulePickerPollingLabel_StartEndTimes;    
            }            
        }

        private void SetDefaultStartAndEndTimeAt24Hours()
        {
            if (view.Mode == SchedulePresenterMode.Target && scheduleId.HasNoValue())
            {
                view.StartTime = new Time(0, 0); // midnight AM
                view.EndTime = new Time(23, 59); // midnight PM
            }
        }

        private void SetDefaultStartAndEndTimeNextHourTime()
        {
            if (scheduleId.HasNoValue())
            {
                view.StartTime = new Time(NEXT_HOUR);
                view.EndTime = new Time(NEXT_HOUR).Add(1);
            }
        }

        public void HandleNoEndDateCheckChanged(object sender, EventArgs e)
        {
            if (view.SelectedScheduleType == ScheduleType.Continuous ||
                view.SelectedScheduleType == ScheduleType.RoundTheClock)
            {
                view.EndTimeEnabled = !view.NoEndDate;
            }                       
        }

        public bool ValidateViewHasError()
        {
            bool hasError = false;
            ScheduleType selectedScheduleType = view.SelectedScheduleType;

            if (selectedScheduleType == ScheduleType.Weekly)
            {
                if (view.DaysToInclude.Count == 0)
                {
                    view.ShowWeeklyAtLeastOneDayOfWeekRequiredError();
                    hasError = true;
                }

                if (view.WeeklyFrequency < 1)
                {
                    view.ShowWeeklyFrequencyNotGreaterThanZeroError();
                    hasError = true;
                }
            }
            else if (selectedScheduleType == ScheduleType.MonthlyDayOfMonth ||
                     selectedScheduleType == ScheduleType.MonthlyDayOfWeek)
            {
                if (view.MonthsToInclude.Count == 0)
                {
                    view.ShowMonthlyAtLeastOneMonthRequiredError();
                    hasError = true;
                }
            }
            else if (selectedScheduleType == ScheduleType.Hourly ||
                     selectedScheduleType == ScheduleType.ByMinute ||
                     selectedScheduleType == ScheduleType.Daily)
            {
                if (view.Frequency < 1)
                {
                    hasError = true;
                    view.ShowFrequencyNotGreaterThanZeroError();
                }
            }

            // This validation can only be performed if the schedule has no problems:
            if (hasError == false)
            {
                ISchedule schedule = Schedule;

                if (schedule.IsNextScheduledTimeValid == false)
                {
                    view.ShowScheduleWillNotFireError();
                    hasError = true;
                }
            }

            return hasError;
        }
    }
}