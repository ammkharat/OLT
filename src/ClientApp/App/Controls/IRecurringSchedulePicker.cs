using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface IRecurringSchedulePicker
    {
        bool Validated { get; }
        DateTime EndDateTime { get; set; }
        DateTime StartDateTime { get; set;}
        Time FromTime { get;set; }
        Time ToTime { get; set;}
        int RecurringDailyFrequency { get; set; }
        int RecurringWeeklyFrequency { get; set;}
        List<Common.Domain.DayOfWeek> DaysOfWeek { get;set;}
        DayOfMonth DayOfMonth { get;set;}
        Common.Domain.DayOfWeek DayOfWeek { get; set;}
        WeekOfMonth WeekOfMonth { get; set;}
        List<Month> MonthsToInclude { get; set;}
        bool RecurringMonthlyScheduleIsBasedOnDayOfMonth { get; set;}
        void SetContinuous(Boolean check);
        void ShowRecurringDailySchedule();

        void ShowRecurringWeeklySchedule();

        void ShowRecurringMonthlySchedule();

        IList<DayOfMonth> RecurringMonthlyDaysOfMonth { set; }
        IList<WeekOfMonth> RecurringMonthlyWeeksOfMonth { set; }
        IList<Common.Domain.DayOfWeek> RecurringMonthlyDaysOfWeek { set; }

        void ShowErrorIfReoccuringScheduleFirstItemOutOfRange(bool show);

    }
}
