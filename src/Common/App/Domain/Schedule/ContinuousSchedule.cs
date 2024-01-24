using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class ContinuousSchedule : AbstractSchedule
    {
        public ContinuousSchedule(Date startDate, Date endDate, Time startTime, Time endTime, Site site)
            : base(null, startDate, endDate, startTime, endTime, null, site)
        {
        }

        public ContinuousSchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
        }

        public ContinuousSchedule(Date startDate, Date endDate, Time startTime, Time endTime,
            DateTime? lastInvokedDateTime, Site site)
            : base(null, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
        }


        public ContinuousSchedule(Date startDate, Time startTime, Site site)
            : base(null, startDate, null, startTime, null, null, site)
        {
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.Continuous; }
        }


        public override bool IsNextScheduledTimeValid
        {
            get
            {
                // The Continuous Schedule should not say that the Next Scheduled Time Is Valid if it was already been invoked.
                return !lastInvokedDateTime.HasValue && base.IsNextScheduledTimeValid;
            }
        }

        public override string RecurrencePatternString
        {
            get { return StringResources.ContinuousSchedule_RecurrencePatternString; }
        }

        public override string SimpleDescription
        {
            get { return ToString(); }
        }

        public override string BatchingKey
        {
            get { return string.Format("{0} between {1} and {2} ending {3}", Type.Name, StartTime, EndTime, EndDate); }
        }

        public override DateTime EndDateTime
        {
            get
            {
                DateTime result;

                if (HasEndDate && StartTime < EndTime)
                {
                    result = EndDate.CreateDateTime(EndTime);
                }
                else if (HasEndDate)
                {
                    result = EndDate.CreateDateTime(EndTime);
                }
                else
                {
                    result = DateTime.MaxValue;
                }
                return result;
            }
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            return DateRangeUtilities.OccurenceIsInWindow(new Range<DateTime>(StartDateTime, EndDateTime), window)
                ? new List<Range<DateTime>> {new Range<DateTime>(StartDateTime, EndDateTime)}
                : new List<Range<DateTime>>();
        }
 
        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            return new ContinuousScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime).GetNextInvokeDateTime();
        }

        public override string ToString(bool includeEndTime)
        {
            if (includeEndTime && HasEndDate)
            {
                return string.Format(StringResources.ContinuousSchedule_IncludeEndTime, StartDateTime.ToDateString(),
                    StartDateTime.ToTimeString(), EndDateTime.ToDateString(),
                    EndDateTime.ToTimeString());
            }
            return string.Format(StringResources.ContinuousSchedule_NotIncludeEndTime, StartDateTime.ToDateString(),
                StartDateTime.ToTimeString());
        }
    }
}