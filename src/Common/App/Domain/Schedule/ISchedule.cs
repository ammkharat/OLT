using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    /// <summary>
    ///     Interface for All the Schedule Domain Object
    /// </summary>
    public interface ISchedule
    {
        long? Id { get; set; }

        // Method which will return when the Schedule has to be invoked next
        // This method is used by Scheduler for sorting Schedule objects in the list
        DateTime NextInvokeDateTime { get; }

        Date StartDate { get; set; }
        Date EndDate { get; set; }
        DateTime StartDateTime { get; }
        DateTime EndDateTime { get; }
        DateTime? LastInvokedDateTime { get; set; }
        Time StartTime { get; set; }
        Time EndTime { get; set; }

        /// <summary>
        ///     Tests if the start and end times form a time range which crosses a day boundary.
        ///     For example, a schedule from 8am to 8pm doesn't cross a day boundary, but a schedule
        ///     from 8pm to 8am does.
        /// </summary>
        bool CrossesDayBoundary { get; }

        bool HasEndDate { get; }
        bool IsNextScheduledTimeValid { get; }
        bool HasEndTime { get; }

        ScheduleType Type { get; }
        string RecurrencePatternString { get; }
        bool IsRecurring { get; }

        bool Deleted { get; set; }
        // NOTE: Eric: Sorry, this is here - NMock not recognizing 'object' methods.
        string SimpleDescription { get; }

        Site Site { get; }

        long IdValue { get; }

        string BatchingKey { get; }
        List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window); 
        string ToString(bool includeEndTime);
        string ToString();
        bool Overlaps(ISchedule otherSchedule);
        List<DateTime> NextInvokeDateTimes(DateTime endDateTime);
    }
}