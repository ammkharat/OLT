using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ShiftPattern : DomainObject, ICacheBySiteId
    {
        public ShiftPattern(long id, string name,
            Time startTime, Time endTime, DateTime createdDateTime, Site site, TimeSpan preShiftPadding,
            TimeSpan postShiftPadding)
        {
            Id = id;
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            CreatedDateTime = createdDateTime;
            Site = site;
            PreShiftPadding = preShiftPadding;
            PostShiftPadding = postShiftPadding;
        }

        public string Name { get; private set; }
        public Time StartTime { get; private set; }
        public Time EndTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public Site Site { get; private set; }

        internal TimeSpan PreShiftPadding { get; private set; }
        public TimeSpan PostShiftPadding { get; private set; }


        public string DisplayName
        {
            get { return GetDisplayName(Name, StartTime, EndTime); }
        }

        public bool IsOverlappingADay
        {
            get { return StartTime > EndTime; }
        }

        public TimeSpan ShiftLength
        {
            get
            {
                if (!IsOverlappingADay)
                    return EndTime - StartTime;

                var ts = StartTime - EndTime;
                var twentyFourHours = new TimeSpan(24, 0, 0);
                return (twentyFourHours - ts);
            }
        }

        [IgnoreToString]
        public long SiteId
        {
            get { return Site.IdValue; }
        }

        private static string GetDisplayName(string name, Time start, Time end)
        {
            return String.Format("{0} - {1} to {2}", name, start, end);
        }

        public bool IsTimeInShiftEndDateExclusive(Time time)
        {
            return time.InRangeEndTimeExclusive(StartTime, EndTime);
        }

        public bool IsTimeInShiftIncludingPadding(Time time)
        {
            var startTimeWithPadding = StartTime.Subtract(PreShiftPadding);
            var endTimeWithPadding = EndTime.Add(PostShiftPadding);

            return time.InRange(startTimeWithPadding, endTimeWithPadding);
        }

        public bool IsDateTimeInShiftIncludingPadding(DateTime dateTime)
        {
            return IsTimeInShiftIncludingPadding(dateTime.ToTime());
        }

        public int CompareTo(object obj)
        {
            var compareToObject = (ShiftPattern) obj;
            return StartTime.CompareTo(compareToObject.StartTime);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}