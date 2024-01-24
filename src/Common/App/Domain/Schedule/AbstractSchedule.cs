using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public abstract class AbstractSchedule : DomainObject, ISchedule
    {
        protected readonly Site site;
        private Date endDate;
        private Time endTime;

        [IgnoreComparing] protected DateTime? lastInvokedDateTime;
        private Date startDate;
        private Time startTime;

        protected AbstractSchedule(long? id, Date startDate, Date endDate, Time startTime, Time endTime,
            DateTime? lastInvokedDateTime, Site site)
        {
            if (startDate == null)
            {
                throw new ArgumentNullException("startDate", "start date cannot be null");
            }

            if (endDate == Date.MaxValue)
            {
                throw new ArgumentException("end date should not be max value, pass in null instead");
            }

            this.startDate = startDate;
            this.endDate = endDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.lastInvokedDateTime = lastInvokedDateTime;
            this.id = id;
            this.site = site;
        }

        public DateTime? LastInvokedDateTime
        {
            get { return lastInvokedDateTime; }
            set { lastInvokedDateTime = value; }
        }

        public Date EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public Date StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public Time StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public Time EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public bool CrossesDayBoundary
        {
            get { return StartTime >= EndTime && StartDate < EndDate; }
        }

        public Site Site
        {
            get { return site; }
        }

        public bool HasEndDate
        {
            get { return endDate != null; }
        }

        public virtual bool HasEndTime
        {
            get { return true; }
        }

        public bool Deleted { get; set; }

        public virtual DateTime NextInvokeDateTime
        {
            get { return GetNextInvokeDateTime(lastInvokedDateTime); }
        }

        public abstract ScheduleType Type { get; }

        public abstract string SimpleDescription { get; }

        public List<DateTime> NextInvokeDateTimes(DateTime endDateTime)
        {
            var invokeDateTime = NextInvokeDateTime;

            if (invokeDateTime > endDateTime)
            {
                return new List<DateTime>();
            }

            var dateTimes = new List<DateTime>();

            var anyDateTimeBeforeOltExisted = new DateTime(1900, 1, 1);
            var previousInvokeDateTime = anyDateTimeBeforeOltExisted;

            while (invokeDateTime < endDateTime && previousInvokeDateTime != invokeDateTime)
            {
                dateTimes.Add(invokeDateTime);
                previousInvokeDateTime = invokeDateTime;
                invokeDateTime = GetNextInvokeDateTime(invokeDateTime);
            }

            return dateTimes;
        }

        public abstract string BatchingKey { get; }
        public abstract List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window);

        public virtual bool IsNextScheduledTimeValid
        {
            get { return (StartDateTime < EndDateTime && NextInvokeDateTime != Constants.PAST_END_TIME); }
        }

        public abstract string RecurrencePatternString { get; }

        public virtual DateTime EndDateTime
        {
            get { return EndDate.CreateDateTime(EndTime); }
        }

        public abstract string ToString(bool includeEndTime);

        public virtual DateTime StartDateTime
        {
            get { return StartDate.CreateDateTime(StartTime); }
        }

        public virtual bool IsRecurring
        {
            get { return false; }
        }

        public bool Overlaps(ISchedule otherSchedule)
        {
            var otherStartIsAfterThisEnd = otherSchedule.StartDateTime > EndDateTime;
            var otherEndIsBeforeThisStart = otherSchedule.EndDateTime < StartDateTime;

            if (otherStartIsAfterThisEnd || otherEndIsBeforeThisStart)
                return false;

            return true;
        }

        protected abstract DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime);
    }
}