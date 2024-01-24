using System;

namespace Com.Suncor.Olt.Common.Extension
{
    public static class IntExtensions
    {
        public static bool TryParse(this string strVal, out int result)
        {
            return Int32.TryParse(strVal, out result);
        }

        public static TimeSpan Days(this int value)
        {
            return new TimeSpan(value, 0, 0, 0);
        }

        public static T ToEnum<T>(this byte value)
        {
            return (T) Enum.ToObject(typeof (T), value);
        }

        public static T ToEnum<T>(this int value)
        {
            return (T) Enum.ToObject(typeof (T), value);
        }

        public static string Format(this int? value)
        {
            return value.HasValue ? value.Value.ToString("D") : String.Empty;
        }

        public static bool IsOneLessThan(this int value, int other)
        {
            return (value + 1) == other;
        }

        public static TimeSpan Minutes(this int value)
        {
            return new TimeSpan(0, value, 0);
        }

        public static int ToPercent(this decimal value, int maximumValue)
        {
            if (maximumValue == 0) return 0;

            var percent = (int)Math.Round(((100m * value) / maximumValue));

            return percent;
        }

        public static int ToPercent(this int value, int maximumValue)
        {
            if (maximumValue == 0) return 0;

            var percent = (int) Math.Round(((100f*value)/maximumValue));

            return percent;
        }
    }
}