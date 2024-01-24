using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class ScheduleBatch : IComparable<ScheduleBatch>
    {
        private static readonly ScheduleBatchSortComparer scheduleBatchComparer = new ScheduleBatchSortComparer();

        private static readonly IEqualityComparer<ISchedule> scheduleBatchingEqualityComparer =
            new BatchingKeyEqualityComparer();

        private readonly TimeZoneConvertedSchedule batchSchedule;
        private readonly OltTimeZoneInfo schedulerTimeZone;
        private readonly HashSet<ISchedule> schedules = new HashSet<ISchedule>(new ScheduleIdComparer());

        public ScheduleBatch(ISchedule batchSchedule, OltTimeZoneInfo schedulerTimeZone)
        {
            this.schedulerTimeZone = schedulerTimeZone;
            this.batchSchedule = new TimeZoneConvertedSchedule(batchSchedule, schedulerTimeZone);
        }

        internal bool IsNextScheduledTimeValid
        {
            get { return batchSchedule.IsNextScheduledTimeValid; }
        }

        internal DateTime NextInvokeDateTime
        {
            get { return batchSchedule.NextInvokeDateTime; }
        }

        public int ScheduleCount
        {
            get { return schedules.Count; }
        }

        public static IComparer<ScheduleBatch> SortComparer
        {
            get { return scheduleBatchComparer; }
        }

        public string BatchingKey
        {
            get { return batchSchedule.Schedule.BatchingKey; }
        }

        public int CompareTo(ScheduleBatch other)
        {
            return scheduleBatchComparer.Compare(this, other);
        }

        public void AddSchedule(ISchedule schedule)
        {
            if (HasSameSchedule(schedule))
            {
                schedules.Add(schedule);
            }
            else
            {
                var errorMessage =
                    string.Format(
                        "Cannot add schedule {0} with Id {1} in site {2} to this batch. Schedules/Sites doesn't match {3}, Site {4}.",
                        schedule.ToString(true), schedule.Site.IdValue,
                        schedule.IdValue, batchSchedule.Schedule.ToString(true), batchSchedule.Schedule.Site.IdValue);
                throw new OLTException(errorMessage);
            }
        }

        public void RemoveSchedule(ISchedule schedule)
        {
            schedules.Remove(schedule);
        }

        /// <summary>
        ///     Sets the last invoked date times and returns those Schedules that had their Last Invoked Date Time set, meaning
        ///     they are active Schedules.
        /// </summary>
        /// <param name="intendedScheduleExecutionTime"></param>
        /// <returns></returns>
        public List<ISchedule> SetLastInvokedDateTime(DateTime? intendedScheduleExecutionTime)
        {
            // this is what is used by the scheduler.
            batchSchedule.SetLastInvokedDateTime(intendedScheduleExecutionTime);

            var activeSchedules = new List<ISchedule>();

            // must also update all the last invoked datetimes of those schedules in the Batch whose StartDateTime is not in the future.
            schedules.ForEach(schedule =>
            {
                var startDateTimeInSchedulerTimeZone = OltTimeZoneInfo.ConvertTime(schedule.StartDateTime,
                    schedule.Site.TimeZone, schedulerTimeZone);
                if (startDateTimeInSchedulerTimeZone <= intendedScheduleExecutionTime)
                {
                    schedule.LastInvokedDateTime = batchSchedule.LastInvokedDateTime;
                    activeSchedules.Add(schedule);
                }
            });

            return activeSchedules;
        }

        public bool Contains(ISchedule schedule)
        {
            return schedules.Contains(schedule);
        }

        public bool HasSameSchedule(ISchedule schedule)
        {
            return scheduleBatchingEqualityComparer.Equals(batchSchedule.Schedule, schedule);
        }

        public override string ToString()
        {
            return string.Format("Schedule Batch '{0}' and contains {1} Schedules.", batchSchedule.Schedule.BatchingKey,
                schedules.Count);
        }

        public string VerboseToString()
        {
            var csvIds = schedules.BuildCommaSeparatedList(s => s.IdValue.ToString(CultureInfo.InvariantCulture));
            return string.Format("Schedule Batch '{0}' has {1} schedules:{2}{3}", batchSchedule.Schedule.BatchingKey,
                schedules.Count, Environment.NewLine, csvIds);
        }

        private sealed class BatchingKeyEqualityComparer : IEqualityComparer<ISchedule>
        {
            public bool Equals(ISchedule x, ISchedule y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;

                return Equals(x.Site, y.Site) &&
                       string.Equals(x.BatchingKey, y.BatchingKey, StringComparison.InvariantCulture);
            }

            public int GetHashCode(ISchedule schedule)
            {
                unchecked
                {
                    return ((schedule.Site != null ? schedule.Site.GetHashCode() : 0)*397) ^
                           (schedule.BatchingKey != null ? schedule.BatchingKey.GetHashCode() : 0);
                }
            }
        }

        private sealed class ScheduleBatchSortComparer : IComparer<ScheduleBatch>
        {
            public int Compare(ScheduleBatch x, ScheduleBatch y)
            {
                var scheduleX = x.batchSchedule;

                var scheduleY = y.batchSchedule;

                return TimeZoneConvertedSchedule.SortComparer.Compare(scheduleX, scheduleY);
            }
        }

        private sealed class ScheduleIdComparer : IEqualityComparer<ISchedule>
        {
            public bool Equals(ISchedule x, ISchedule y)
            {
                if (x == null)
                {
                    return y == null;
                }
                if (y == null)
                {
                    return false;
                }

                return Nullable.Equals(x.Id, y.Id);
            }

            public int GetHashCode(ISchedule obj)
            {
                return obj.Id.GetValueOrDefault(-1).GetHashCode();
            }
        }
    }
}