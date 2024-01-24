using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using DayOfWeek = Com.Suncor.Olt.Common.Domain.DayOfWeek;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface ISchedulePickerView
    {
        ScheduleType SelectedScheduleType { get; set;}
        SchedulePresenterMode Mode { get; set;}
        bool MonthGroupEnabled { set;}
        bool WeeklyGroupEnabled { set;}
        bool FrequencyGroupEnabled { set;}
        bool TimeRangeGroupEnabled { set;}
        bool DayOfMonthEnabled { set;}
        bool NoEndDateEnabled { set;}
        bool EndTimeEnabled { set;}
        bool DateRangeGroupEnabled { set;}

        Date StartDate { get; set;}
        Date EndDate { get; set;}
        bool NoEndDate { get; set;}
        Time StartTime { get; set;}
        DateTime MinStartDate { set;}
        Time EndTime { get; set;}
        int Frequency { get; set;}
        int WeeklyFrequency { get; set;}
        DayOfMonth DayOfMonth { get; set;}
        WeekOfMonth WeekOfMonth { get; set;}
        DayOfWeek DayOfWeek { get; set;}
        List<Month> MonthsToInclude { get; set;}
        List<DayOfWeek> DaysToInclude { get; set;}

        string FrequencyUnitLabel { set;}

        string TimeRangeLabel { set; }

        void ShowScheduleWillNotFireError();
        void ShowFrequencyNotGreaterThanZeroError();
        void ShowWeeklyAtLeastOneDayOfWeekRequiredError();
        void ShowWeeklyFrequencyNotGreaterThanZeroError();
        void ShowMonthlyAtLeastOneMonthRequiredError();

        //RITM0265710 mangesh
        bool EveryShiftEnabled { set; }
        bool EveryShift { get; set; } 
    }
}
