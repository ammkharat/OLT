using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Time : ComparableObject, IComparable
    {
        private const int START_DAY = 100;
        private const string HOUR_ERROR_MSG = "Hour must be between 0 and 23";
        private const string MINUTE_ERROR_MSG = "Minute must be between 0 and 59";
        private const string SECONDS_ERROR_MSG = "Second must be between 0 and 59";
        public static Time START_OF_DAY = new Time(0, 0, 0);
        public static Time NOON = new Time(12, 0, 0);
        public static Time MIDNIGHT = new Time(0, 0, 0);
        public static Time END_OF_DAY = new Time(23, 59, 59);

        public static readonly Date ARBITRARAY_DATE = new Date(1900, 01, 01);
        private readonly TimeSpan internalTimeSpan;

        public Time(int hour) : this(hour, 0, 0)
        {
        }

        public Time(int hour, int minute) : this(hour, minute, 0)
        {
        }

        /// <summary>
        ///     Only the hours, minutes, and seconds are used to generate the time
        /// </summary>
        /// <param name="dateTime"></param>
        public Time(DateTime dateTime) : this(dateTime.Hour, dateTime.Minute, dateTime.Second)
        {
        }

        public Time(TimeSpan span) : this(span.Hours, span.Minutes, span.Seconds)
        {
        }

        public Time(int hour, int minute, int second)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(HOUR_ERROR_MSG);
            }


            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(MINUTE_ERROR_MSG);
            }


            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(SECONDS_ERROR_MSG);
            }

            //adding 1 for day to allow subtraction to flip around clock
            internalTimeSpan = new TimeSpan(START_DAY, hour, minute, second);
        }

        public int Second
        {
            get { return internalTimeSpan.Seconds; }
        }

        public int Minute
        {
            get { return internalTimeSpan.Minutes; }
        }

        public int Hour
        {
            get { return internalTimeSpan.Hours; }
        }

        /// <summary>
        ///     Number of current minutes this time represents (seconds are rounded down)
        /// </summary>
        public int TotalMinutes
        {
            get { return internalTimeSpan.Minutes + internalTimeSpan.Hours*60; }
        }

        public TimeSpan TimeOfDay
        {
            get { return ToDateTime().TimeOfDay; }
        }

        public int CompareTo(object timeObject)
        {
            if (timeObject == null)
            {
                throw new NullReferenceException("Value to compare cannot be null");
            }

            return TimeSpan.Compare(internalTimeSpan, ((Time) timeObject).internalTimeSpan);
        }


        public override string ToString()
        {
            return ToDateTime().ToString("t");
        }

        // Use this method sparingly.  
        // We don't want to display seconds in most cases.
        public string ToStringWithSeconds()
        {
            return ToDateTime().ToString("T");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Time))
                return false;

            var time = (Time) obj;

            return 0 == internalTimeSpan.CompareTo(time.internalTimeSpan);
        }

        public override int GetHashCode()
        {
            return (int) internalTimeSpan.TotalSeconds;
        }

        public DateTime ToDateTime()
        {
            return ARBITRARAY_DATE.CreateDateTime(this);
        }

        public DateTime ToDateTime(Date date)
        {
            return new DateTime(date.Year, date.Month, date.Day, Hour, Minute, Second).GetNetworkPortable();
        }

        public static bool operator >(Time t1, Time t2)
        {
            return t1.CompareTo(t2) > 0;
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.CompareTo(t2) < 0;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) >= 0;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            return t1.CompareTo(t2) <= 0;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return t1.AreNotEqualOperator(t2);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return t1.AreEqualOperator(t2);
        }

        public static TimeSpan operator -(Time t1, Time t2)
        {
            return t1.internalTimeSpan - t2.internalTimeSpan;
        }

        /// <summary>
        ///     Check whether the current instance is between (or equal to) the fromTime and toTime
        /// </summary>
        /// <param name="fromTime">Begin time</param>
        /// <param name="toTime">End time</param>
        /// <returns>true if object time is between fromTime and toTime</returns>
        public bool InRange(Time fromTime, Time toTime)
        {
            if (fromTime < toTime) // eg. like 9 AM to 6 PM
                return (this >= fromTime && this <= toTime);

            if (this <= fromTime && this <= toTime) // eg like 10pm to 2am and this = 1am
                return true;

            return (this >= fromTime && this >= toTime);
        }

        public bool InRangeEndTimeExclusive(Time fromTime, Time toTime)
        {
            if (fromTime < toTime)
                return (this >= fromTime && this < toTime);

            if (this <= fromTime && this < toTime)
                return true;

            return (this >= fromTime && this >= toTime);
        }

        public Time Add(int hour, int minute, int second)
        {
            return Add(new TimeSpan(hour, minute, second));
        }

        public Time Add(int hour, int minute)
        {
            return Add(new TimeSpan(hour, minute, 0));
        }

        public Time Add(int hour)
        {
            return Add(new TimeSpan(hour, 0, 0));
        }

        public Time Add(TimeSpan timespan)
        {
            return new Time(internalTimeSpan.Add(timespan));
        }

        public Time Subtract(TimeSpan timeSpan)
        {
            return new Time(internalTimeSpan.Subtract(timeSpan));
        }

        public TimeSpan Subtract(Time othertime)
        {
            return internalTimeSpan.Subtract(othertime.internalTimeSpan);
        }

        public Time AddHours(int numberOfHours)
        {
            return Add(numberOfHours);
        }

        public Time AddMinutes(int numberOfMinutes)
        {
            return Add(0, numberOfMinutes);
        }
    }
}