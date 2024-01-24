using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Utility;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SimpleSchedulePickerPresenter
    {
        private readonly ISimpleSchedulePickerView view;
        private long? scheduleId;

        public SimpleSchedulePickerPresenter(ISimpleSchedulePickerView view)
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

        public void UpdateViewFromSchedule(ISchedule value)
        {
            ScheduleType scheduleType = value.Type;

            view.SelectedScheduleType = scheduleType;

            if (scheduleType == ScheduleType.Daily)
            {
                RecurringDailySchedule schedule = (RecurringDailySchedule)value;
                view.Daily_Time = schedule.StartTime;
            }
            else if (scheduleType == ScheduleType.Weekly)
            {
                RecurringWeeklySchedule schedule = (RecurringWeeklySchedule)value;
                if (schedule.DaysOfWeek.Count == 1)
                {
                    view.Weekly_DayOfWeek = schedule.DaysOfWeek[0];
                }
                else
                {
                    throw new Exception("Cannot set more than one day of the week: " + schedule.DaysOfWeek);
                }
                view.Weekly_Time = schedule.StartTime;
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfWeek)
            {
                RecurringMonthlyDayOfWeekSchedule schedule = (RecurringMonthlyDayOfWeekSchedule)value;
                view.MonthlyByDayOfWeek_WeekOfMonth = schedule.WeekOfMonth;
                view.MonthlyByDayOfWeek_DayOfWeek = schedule.DayOfWeek;
                view.MonthlyByDayOfWeek_Time = schedule.StartTime;
            }
            else if (scheduleType == ScheduleType.MonthlyDayOfMonth)
            {
                RecurringMonthlyDayOfMonthSchedule schedule = (RecurringMonthlyDayOfMonthSchedule)value;
                view.MonthlyByDayOfMonth_DayOfMonth = schedule.DayOfMonth;
                view.MonthlyByDayOfMonth_Time = schedule.StartTime;
            }
            else
            {
                throw new Exception("Unrecognized schedule type: " + scheduleType);
            }
        }

        public ISchedule CreateScheduleFromView()
        {
            ISchedule result = null;
            Site site = ClientSession.GetUserContext().Site;
            ScheduleType scheduleType = view.SelectedScheduleType;

            if (scheduleType != null)
            {
                DateTime now = Clock.Now;

                if (scheduleType == ScheduleType.Daily)
                {
                    result = new RecurringDailySchedule(
                        new Date(now), null, view.Daily_Time, view.Daily_Time, 1, site);
                }
                else if (scheduleType == ScheduleType.Weekly)
                {
                    result = new RecurringWeeklySchedule(
                        new Date(now), null, view.Weekly_Time, view.Weekly_Time, 
                        new List<DayOfWeek>{view.Weekly_DayOfWeek}, 1, site);
                }
                else if (scheduleType == ScheduleType.MonthlyDayOfWeek)
                {
                    result = new RecurringMonthlyDayOfWeekSchedule(
                        new Date(now), null, view.MonthlyByDayOfWeek_Time, view.MonthlyByDayOfWeek_Time,
                        view.MonthlyByDayOfWeek_WeekOfMonth, view.MonthlyByDayOfWeek_DayOfWeek,
                        new List<Month>(Month.All), site); 
                }
                else if (scheduleType == ScheduleType.MonthlyDayOfMonth)
                {
                    result = new RecurringMonthlyDayOfMonthSchedule(
                        new Date(now), null, view.MonthlyByDayOfMonth_Time, view.MonthlyByDayOfMonth_Time,
                        view.MonthlyByDayOfMonth_DayOfMonth, new List<Month>(Month.All), site); 
                }
                else
                {
                    throw new Exception("Unrecognized schedule type: " + scheduleType);
                }

                result.Id = scheduleId;
            }


            return result;
        }

        public bool ValidateViewHasError()
        {
            return false;
        }
    }
}