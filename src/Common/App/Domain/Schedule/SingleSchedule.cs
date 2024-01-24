using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class SingleSchedule : AbstractSchedule
    {
        public SingleSchedule(Date startDate, Time startTime, Time endTime, Site site)
            : base(null, startDate, null, startTime, endTime, null, site)
        {
        }

        public SingleSchedule(long id, Date startDate, Time startTime, Time endTime,
            DateTime? lastInvokeDateTime, Site site)
            : base(id, startDate, null, startTime, endTime, lastInvokeDateTime, site)
        {
        }

        public override string BatchingKey
        {
            get { return string.Format("{0} at {1}", Type.Name, StartDateTime); }
        }

        public override bool IsNextScheduledTimeValid
        {
            get
            {
                // The Single Schedule should not say that the Next Scheduled Time Is Valid if it was already been invoked.
                return !lastInvokedDateTime.HasValue && base.IsNextScheduledTimeValid;
            }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.Single; }
        }

        public override string SimpleDescription
        {
            get { return ToString(); }
        }

        public override string RecurrencePatternString
        {
            get { return StringResources.SingleSchedule_RecurrencePatternString; }
        }

        public override DateTime EndDateTime
        {
            get
            {
                var result = StartTime < EndTime
                    ? StartDate.CreateDateTime(EndTime)
                    : StartDate.AddDays(1).CreateDateTime(EndTime);
                return result;
            }
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            return DateRangeUtilities.OccurenceIsInWindow(new Range<DateTime>(StartDateTime, EndDateTime), window)
                ? new List<Range<DateTime>> {new Range<DateTime>(StartDateTime, EndDateTime)}
                : new List<Range<DateTime>>();
        }




        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return new SingleScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime).GetNextInvokeDateTime();
        }

        public override string ToString(bool includeEndTime)
        {
            return includeEndTime
                ? string.Format(StringResources.SingleSchedule_ToString_IncludeEndTime,
                    StartDateTime.ToLongDateAndTimeString(),
                    EndDateTime.ToLongDateAndTimeString())
                : string.Format(StringResources.SingleSchedule_ToString_NotIncludeEndTime,
                    StartDateTime.ToDateString(), StartDateTime.ToTimeString());
        }

        public override string ToString()
        {
            return ToString(HasEndTime);
        }
    }
}