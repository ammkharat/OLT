using System;
using System.Collections;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using DayOfWeek = System.DayOfWeek;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class DateTimeExtensions
    {
        private const int DaysPerWeek = 7;

        public static DateTime AddWeeks(this DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(DaysPerWeek*weeks);
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return new Time(dateTime).ToString();
        }

        public static string ToTimeString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToTimeString();
            return String.Empty;
        }

        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("d");
        }

        public static string ToLongDateAndTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("f");
        }

        public static string ToLongDateAndTimeStringOrEmptyString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToString("f") : string.Empty;
        }

        public static string ToShortDateAndTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("g");
        }

        public static string ToShortDateAndTimeStringOrEmptyString(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToString("g") : string.Empty;
        }

        public static Time ToTime(this DateTime dateTime)
        {
            return new Time(dateTime);
        }

        public static Date ToDate(this DateTime dateTime)
        {
            return new Date(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static Time ToTime(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return new Time(dateTime.Value.Hour, dateTime.Value.Minute, dateTime.Value.Second);
            }

            return null;
        }

        public static Date ToDate(this DateTime? dateTime)
        {
            Date result = null;
            if (dateTime.HasValue)
            {
                result = new Date(dateTime.Value.Year, dateTime.Value.Month, dateTime.Value.Day);
            }
            return result;
        }

        public static DateTime RollForward(this DateTime startDateTime, Time desiredTime)
        {
            var startTime = new Time(startDateTime);

            return desiredTime >= startTime
                ? new Date(startDateTime).CreateDateTime(desiredTime)
                : new Date(startDateTime).AddDays(1).CreateDateTime(desiredTime);
        }

        public static DateTime StartOfDay(this DateTime dateTime)
        {
            var date = new Date(dateTime);
            return date.CreateDateTime(Time.START_OF_DAY);
        }

        public static DateTime EndOfDay(this DateTime dateTime)
        {
            var date = new Date(dateTime);
            return date.CreateDateTime(Time.END_OF_DAY);
        }

        public static DateTime RollBackward(this DateTime startDateTime, Time desiredTime, bool allowEquality)
        {
            var startTime = new Time(startDateTime);

            if (allowEquality)
            {
                return desiredTime <= startTime
                    ? new Date(startDateTime).CreateDateTime(desiredTime)
                    : new Date(startDateTime).SubtractDays(1).CreateDateTime(desiredTime);
            }
            return desiredTime < startTime
                ? new Date(startDateTime).CreateDateTime(desiredTime)
                : new Date(startDateTime).SubtractDays(1).CreateDateTime(desiredTime);
        }

        public static DateTime RollBackward(this DateTime startDateTime, Time desiredTime)
        {
            return startDateTime.RollBackward(desiredTime, true);
        }

        public static DateTime TruncateToHour(this DateTime dateTime)
        {
            return new DateTime(
                dateTime.Year, dateTime.Month, dateTime.Day,
                dateTime.Hour, 0, 0);
        }

        public static DateTime TruncateToDay(this DateTime dateTime)
        {
            return new DateTime(
                dateTime.Year, dateTime.Month, dateTime.Day);
        }

        public static DateTime GetNetworkPortable(this DateTime dateTime)
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
        }

        public static DateTime SubtractDays(this DateTime dateTime, int days)
        {
            return dateTime.AddDays(-1*days);
        }

        public static DateTime BuildDateTimeWithNoSecondsOrMilliseconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        }

        public static bool TryParse(string date, string time, out DateTime dateTime)
        {
            date = date.TrimOrNull();
            time = time.TrimOrNull();

            if (date == null || time == null)
            {
                dateTime = default(DateTime);
                return false;
            }

            return DateTime.TryParse(date + " " + time, out dateTime);
        }

        public static DateTime? ToSQLServerFriendlyDate(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                dateTime = dateTime.Value.ToSQLServerFriendlyDate();
            }

            return dateTime;
        }

        public static DateTime ToSQLServerFriendlyDate(this DateTime dateTime)
        {
            if (dateTime <= DateTime.MinValue)
            {
                dateTime = new DateTime(1755, 03, 09);
            }
            else if (dateTime >= DateTime.MaxValue)
            {
                dateTime = new DateTime(2075, 03, 09);
            }

            return dateTime;
        }

        public static DateTime CreateSQLServerFriendlyMinDate()
        {
            return new DateTime(1755, 03, 09);
        }

        public static DateTime CreateSQLServerFriendlyMaxDate()
        {
            return new DateTime(2075, 03, 09);
        }

        public static bool IsWeekendDayOfWeek(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsWithinTimeSpan(this DateTime dateTime, TimeSpan timeSpan)
        {
            var start = DateTime.Now.Subtract(timeSpan);
            var end = DateTime.Now;

            return dateTime.Ticks >= start.Ticks && dateTime.Ticks <= end.Ticks;
        }

        public static bool IsWithinTimeSpan(this DateTime? dateTime, TimeSpan timeSpan)
        {
            if (dateTime.HasValue == false) return false;

            var start = DateTime.Now.Subtract(timeSpan);
            var end = DateTime.Now;

            return dateTime.Value.Ticks >= start.Ticks && dateTime.Value.Ticks <= end.Ticks;
        }

        public static IEnumerable<DateTime> EachDay(this DateTime start, DateTime end)
        {
            var currentDay = new DateTime(start.Year, start.Month, start.Day);
            while (currentDay <= end)
            {
                yield return currentDay;
                currentDay = currentDay.AddDays(1);
            }
        }
    }
}