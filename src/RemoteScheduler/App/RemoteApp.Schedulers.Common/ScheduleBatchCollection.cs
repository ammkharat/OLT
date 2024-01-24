using System;
using System.Collections.Generic;
using System.Text;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class ScheduleBatchCollection
    {
        private readonly List<ScheduleBatch> batches = new List<ScheduleBatch>();
        private readonly OltTimeZoneInfo schedulerTimeZone;

        public ScheduleBatchCollection(OltTimeZoneInfo schedulerTimeZone)
        {
            this.schedulerTimeZone = schedulerTimeZone;
        }

        public ScheduleBatch First
        {
            get { return IsEmpty ? null : batches[0]; }
        }

        public DateTime NextInvokeDateTime
        {
            get { return First.NextInvokeDateTime; }
        }

        public bool IsEmpty
        {
            get { return batches == null || batches.Count == 0; }
        }

        public ScheduleBatch AddSchedule(ISchedule schedule)
        {
            var scheduleBatch = batches.Find(batch => batch.HasSameSchedule(schedule));

            if (scheduleBatch == null)
            {
                scheduleBatch = new ScheduleBatch(schedule, schedulerTimeZone);
                batches.Add(scheduleBatch);
            }
            scheduleBatch.AddSchedule(schedule);
            return scheduleBatch;
        }

        public bool ShouldBeFirst(ScheduleBatch scheduleBatch)
        {
            return IsEmpty || scheduleBatch.CompareTo(First) < 0;
        }

        public void Sort()
        {
            batches.Sort(ScheduleBatch.SortComparer);
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                return;
            batches.RemoveAt(0);
        }

        public bool IsInFirstBatch(ISchedule schedule)
        {
            if (IsEmpty)
                return false;
            return First.Contains(schedule);
        }

        public bool IsOnlyScheduleInFirstBatch(ISchedule schedule)
        {
            return First.ScheduleCount == 1 && IsInFirstBatch(schedule);
        }

        public void RemoveSchedule(ISchedule schedule)
        {
            if (IsEmpty)
                return;
            for (var i = 0; i < batches.Count; i++)
            {
                var batch = batches[i];
                if (batch.Contains(schedule))
                {
                    batch.RemoveSchedule(schedule);
                    if (batch.ScheduleCount == 0)
                    {
                        batches.RemoveAt(i);
                    }
                    break;
                }
            }
        }

        public bool HasExistingBatchForSchedule(ISchedule schedule)
        {
            return batches.Exists(batch => batch.HasSameSchedule(schedule));
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var batch in batches)
            {
                builder.AppendLine(batch.VerboseToString());
            }
            return builder.ToString();
        }
    }
}