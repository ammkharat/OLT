using System;
using Com.Suncor.Olt.Common.Domain.Schedule;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SapAutoImportConfiguration : DomainObject
    {
        public SapAutoImportConfiguration(long siteId, RecurringDailySchedule schedule)
        {
            Id = siteId;
            Schedule = schedule;
        }

        public bool IsEnabled
        {
            get { return Schedule != null; }
        }

        public long SiteId
        {
            get { return IdValue; }
            set { Id = value; }
        }

        public RecurringDailySchedule Schedule { get; set; }

        public Time ImportTime
        {
            get { return Schedule != null ? Schedule.StartTime : null; }
        }
    }
}