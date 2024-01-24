using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public abstract class RecurringSchedule : AbstractSchedule
    {
        protected RecurringSchedule(long? id, Date startDate, Date endDate, Time startTime, Time endTime,
            DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
        }

        public override bool IsRecurring
        {
            get { return true; }
        }

        public override bool IsNextScheduledTimeValid
        {
            get { return Frequency > 0 && base.IsNextScheduledTimeValid; }
        }

        public override string BatchingKey
        {
            get
            {
                return EndDate != null
                    ? string.Format("{0} between {1} and {2}, Frequency {3} ending {4}", Type.Name, StartTime, EndTime,
                        Frequency, EndDate)
                    : string.Format("{0} between {1} and {2}, Frequency {3} with no End Date", Type.Name, StartTime,
                        EndTime, Frequency);
            }
        }

        public override DateTime EndDateTime
        {
            get
            {
                DateTime result;

                if (HasEndDate && !CrossesDayBoundary)
                {
                    result = EndDate.CreateDateTime(EndTime);
                }
                else if (HasEndDate)
                {
                    result = EndDate.AddDays(1).CreateDateTime(EndTime);
                }
                else
                {
                    result = DateTime.MaxValue;
                }
                return result;
            }
        }

        public abstract int Frequency { get; }

        /// <summary>
        ///     Returns the occurrence previous to the given date/time. For example, if this schedule
        ///     is a recurring daily schedule that recurs every 5 days, the given date/time minus
        ///     5 days will be returned.
        /// </summary>
        public abstract DateTime GetPreviousOccurrence(DateTime someDateTime);

        public List<DateTime> GetReadTimes(DateTime currentDateTimeAtSite, int samplesRequired)
        {
            var readTimes = new List<DateTime>(samplesRequired);

            var readTime = currentDateTimeAtSite;
            for (var i = 0; i < samplesRequired; i++)
            {
                readTimes.Add(readTime);
                readTime = GetPreviousOccurrence(readTime);
            }
            // Order the read times chronologically:
            readTimes.Reverse();
            return readTimes;
        }
    }
}