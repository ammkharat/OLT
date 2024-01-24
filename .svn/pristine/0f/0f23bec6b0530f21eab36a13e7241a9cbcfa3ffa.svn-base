using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Utility
{
    [Serializable]
    public class DateRange
    {
        private static readonly Date artificialEndDate = new Date(2075, 03, 09);
        private static readonly Date artificialStartDate = new Date(1955, 03, 09);
        private readonly Comparer<Date> comparer;

        private readonly Range<Date> range;

        public DateRange(Date startDate, Date endDate)
        {
            range = new Range<Date>(startDate, endDate);
            comparer = Comparer<Date>.Default;
        }

        public DateRange(Range<Date> dateRange)
        {
            range = dateRange ?? new Range<Date>(null, null);
            comparer = Comparer<Date>.Default;
        }

        public Date LowerBound
        {
            get { return range.LowerBound ?? artificialStartDate; }
        }

        public Date UpperBound
        {
            get { return range.UpperBound ?? artificialEndDate; }
        }

        public DateTime SqlFriendlyStart
        {
            get
            {
                var lowerBound = LowerBound;
                return lowerBound.CreateDateTime(Time.START_OF_DAY);
            }
        }

        public DateTime SqlFriendlyEnd
        {
            get
            {
                var upperBound = UpperBound;
                return upperBound.CreateDateTime(Time.END_OF_DAY);
            }
        }

        public bool DateRangeIsWiderThanOneYear
        {
            get
            {
                var lowerBound = range.LowerBound;
                var upperBound = range.UpperBound;
                if (upperBound.Year == lowerBound.Year)
                {
                    return false;
                }
                if (upperBound.Year - lowerBound.Year > 1)
                {
                    return true;
                }
                if (upperBound.Year - lowerBound.Year == 1)
                {
                    if (upperBound.Month > lowerBound.Month)
                    {
                        return true;
                    }
                    if (upperBound.Month < lowerBound.Month)
                    {
                        return false;
                    }
                    return upperBound.Day > lowerBound.Day;
                }
                return true;
            }
        }

        public void ForEachDay(Action<Date> action)
        {
            var ts = UpperBound - LowerBound;
            var days = ts.Days + 1;
            for (var i = 0; i < days; i++)
            {
                action(LowerBound.AddDays(i));
            }
        }

        public bool ContainsInclusive(DateTime dateTime)
        {
            var startDateTime = LowerBound.CreateDateTime(Time.START_OF_DAY);
            var endDateTime = UpperBound.CreateDateTime(Time.END_OF_DAY);
            return new Range<DateTime>(startDateTime, endDateTime).ContainsInclusive(dateTime);
        }

        public bool Overlaps(DateTime from, DateTime to)
        {
            return from <= SqlFriendlyEnd && to >= SqlFriendlyStart;
        }

        public bool Overlaps(Date from, Date to)
        {
            return from <= UpperBound && to >= LowerBound;
        }

        // TODO: Why not use Equals? find usage.
//        public bool EqualsLower(Date date)
//        {
//            return range.LowerBound.Equals(date);
//        }
//
        // TODO: Why not use Equals? find usage.
//        public bool EqualsUpper(Date date)
//        {
//            return range.UpperBound.Equals(date);
//        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", LowerBound, UpperBound);
        }

        public override int GetHashCode()
        {
            return LowerBound.GetHashCode() + 29*UpperBound.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            var otherRange = obj as DateRange;
            if (otherRange == null) return false;
            if (comparer.Compare(LowerBound, otherRange.LowerBound) != 0) return false;
            if (comparer.Compare(UpperBound, otherRange.UpperBound) != 0) return false;
            return true;
        }
    }
}