using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Date : ComparableObject, IComparable
    {
        public static Date MaxValue = new Date(DateTime.MaxValue);

        private readonly DateTime internalDate;

        public Date(int year, int month, int day)
        {
            internalDate = new DateTime(year, month, day).GetNetworkPortable();
        }

        public Date(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {
        }

        public int Year
        {
            get { return internalDate.Year; }
        }

        public int Month
        {
            get { return internalDate.Month; }
        }

        public int Day
        {
            get { return internalDate.Day; }
        }

        public Date NextWeekDayDay
        {
            get
            {
                var nextWorkDay = internalDate.AddDays(1);
                while (nextWorkDay.DayOfWeek == System.DayOfWeek.Saturday ||
                       nextWorkDay.DayOfWeek == System.DayOfWeek.Sunday)
                {
                    nextWorkDay = nextWorkDay.AddDays(1);
                }
                return new Date(nextWorkDay);
            }
        }

        public Date NextNonWeekendDate
        {
            get
            {
                var copy = new DateTime(internalDate.Ticks).GetNetworkPortable();
                var nextDay = copy.AddDays(1);

                while (nextDay.IsWeekendDayOfWeek())
                {
                    nextDay = nextDay.AddDays(1);
                }

                return new Date(nextDay);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Value to compare cannot be null");
            }

            return CompareTo((Date) obj);
        }

        public Date AddTimeSpan(TimeSpan timeSpan)
        {
            return new Date(internalDate.Add(timeSpan));
        }

        public Date SubtractDays(int days)
        {
            return new Date(internalDate.AddDays(-1*days));
        }

        public Date AddDays(int days)
        {
            return new Date(internalDate.AddDays(days));
        }

        public Date AddMonths(int months)
        {
            return new Date(internalDate.AddMonths(months));
        }

        public static bool operator >(Date d1, Date d2)
        {
            return d1.CompareTo(d2) > 0;
        }

        public static bool operator <(Date d1, Date d2)
        {
            return d1.CompareTo(d2) < 0;
        }

        public static bool operator >=(Date d1, Date d2)
        {
            return d1.CompareTo(d2) >= 0;
        }

        public static bool operator <=(Date d1, Date d2)
        {
            return d1.CompareTo(d2) <= 0;
        }

        public int CompareTo(Date dateObject)
        {
            if (dateObject == null)
            {
                return internalDate.CompareTo(DateTime.MaxValue);
            }

            return DateTime.Compare(internalDate, dateObject.internalDate);
        }

        public static bool operator ==(Date x, Date y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(Date x, Date y)
        {
            return x.AreNotEqualOperator(y);
        }

        public static TimeSpan operator -(Date x, Date y)
        {
            return x.internalDate - y.internalDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var result = ((Date) obj).internalDate == internalDate;
            return result;
        }

        public override int GetHashCode()
        {
            return internalDate.GetHashCode();
        }

        public DateTime CreateDateTime(Time time)
        {
            return new DateTime(internalDate.Year, internalDate.Month, internalDate.Day, time.Hour, time.Minute,
                time.Second);
        }

        public override string ToString()
        {
            return internalDate.ToDateString();
        }

        public string ToLongDate()
        {
            return internalDate.ToLongDateString();
        }

        public static string ToDateString(Date date)
        {
            return date != null ? ToDateTimeOrMaxValue(date).ToDateString() : StringResources.NoEnd;
        }

        public static DateTime ToDateTimeOrMaxValue(Date date)
        {
            return date != null ? new DateTime(date.Year, date.Month, date.Day) : DateTime.MaxValue;
        }

        public static DateTime? ToDateTimeOrNull(Date date)
        {
            return date != null ? new DateTime(date.Year, date.Month, date.Day) : new DateTime?();
        }

        public DateTime ToDateTimeAtStartOfDay()
        {
            return Time.START_OF_DAY.ToDateTime(this);
        }

        public DateTime ToDateTimeAtEndOfDay()
        {
            return Time.END_OF_DAY.ToDateTime(this);
        }
    }
}