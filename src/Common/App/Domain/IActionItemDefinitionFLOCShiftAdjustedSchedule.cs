using System;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Domain
{
    public interface IActionItemDefinitionFLOCShiftAdjustedSchedule
    {
        Date EndDate { get; }
        DateTime EndDateTime { get; }
        bool HasEndDate { get; }
        long? Id { get; set; }
        bool IsNextScheduledTimeValid { get; }
        DateTime NextInvokeDateTime { get; }
        Date StartDate { get; }
        DateTime StartDateTime { get; }
        ScheduleType Type { get; }
    }
}