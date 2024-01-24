using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface ISimpleSchedulePickerView
    {
        ScheduleType SelectedScheduleType { get; set;}

        Time Daily_Time { get; set; }
        DayOfWeek Weekly_DayOfWeek { get; set; }
        Time Weekly_Time { get; set; }
        WeekOfMonth MonthlyByDayOfWeek_WeekOfMonth { get; set; }
        DayOfWeek MonthlyByDayOfWeek_DayOfWeek { get; set; }
        Time MonthlyByDayOfWeek_Time { get; set; }
        DayOfMonth MonthlyByDayOfMonth_DayOfMonth { get; set; }
        Time MonthlyByDayOfMonth_Time { get; set; }
    }
}
