using System;
using System.Collections.Generic;
using System.Globalization;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DayOfMonth
    {
        public static readonly DayOfMonth First = new DayOfMonth(1);
        public static readonly DayOfMonth Last = new DayOfMonth(99);

        private static readonly DayOfMonth[] days =
        {
            First,
            new DayOfMonth(2),
            new DayOfMonth(3),
            new DayOfMonth(4),
            new DayOfMonth(5),
            new DayOfMonth(6),
            new DayOfMonth(7),
            new DayOfMonth(8),
            new DayOfMonth(9),
            new DayOfMonth(10),
            new DayOfMonth(11),
            new DayOfMonth(12),
            new DayOfMonth(13),
            new DayOfMonth(14),
            new DayOfMonth(15),
            new DayOfMonth(16),
            new DayOfMonth(17),
            new DayOfMonth(18),
            new DayOfMonth(19),
            new DayOfMonth(20),
            new DayOfMonth(21),
            new DayOfMonth(22),
            new DayOfMonth(23),
            new DayOfMonth(24),
            new DayOfMonth(25),
            new DayOfMonth(26),
            new DayOfMonth(27),
            new DayOfMonth(28),
            new DayOfMonth(29),
            new DayOfMonth(30),
            new DayOfMonth(31),
            Last
        };

        private readonly int value;

        private DayOfMonth(int value)
        {
            this.value = value;
        }

        public int Value
        {
            get { return value; }
        }

        public string Name
        {
            get
            {
                if (Value == 1)
                {
                    return StringResources.FirstText;
                }
                if (Value == 99)
                {
                    return StringResources.Last;
                }
                return Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        public string NthName
        {
            get
            {
                if (Value == 1)
                {
                    return StringResources.Ordinal1;
                }
                if (Value == 2)
                {
                    return StringResources.Ordinal2;
                }
                if (Value == 3)
                {
                    return StringResources.Ordinal3;
                }
                if (Value == 4)
                {
                    return StringResources.Ordinal4;
                }
                if (Value == 5)
                {
                    return StringResources.Ordinal5;
                }
                if (Value == 6)
                {
                    return StringResources.Ordinal6;
                }
                if (Value == 7)
                {
                    return StringResources.Ordinal7;
                }
                if (Value == 8)
                {
                    return StringResources.Ordinal8;
                }
                if (Value == 9)
                {
                    return StringResources.Ordinal9;
                }
                if (Value == 10)
                {
                    return StringResources.Ordinal10;
                }
                if (Value == 11)
                {
                    return StringResources.Ordinal11;
                }
                if (Value == 12)
                {
                    return StringResources.Ordinal12;
                }
                if (Value == 13)
                {
                    return StringResources.Ordinal13;
                }
                if (Value == 14)
                {
                    return StringResources.Ordinal14;
                }
                if (Value == 15)
                {
                    return StringResources.Ordinal15;
                }
                if (Value == 16)
                {
                    return StringResources.Ordinal16;
                }
                if (Value == 17)
                {
                    return StringResources.Ordinal17;
                }
                if (Value == 18)
                {
                    return StringResources.Ordinal18;
                }
                if (Value == 19)
                {
                    return StringResources.Ordinal19;
                }
                if (Value == 20)
                {
                    return StringResources.Ordinal20;
                }
                if (Value == 21)
                {
                    return StringResources.Ordinal21;
                }
                if (Value == 22)
                {
                    return StringResources.Ordinal22;
                }
                if (Value == 23)
                {
                    return StringResources.Ordinal23;
                }
                if (Value == 24)
                {
                    return StringResources.Ordinal24;
                }
                if (Value == 25)
                {
                    return StringResources.Ordinal25;
                }
                if (Value == 26)
                {
                    return StringResources.Ordinal26;
                }
                if (Value == 27)
                {
                    return StringResources.Ordinal27;
                }
                if (Value == 28)
                {
                    return StringResources.Ordinal28;
                }
                if (Value == 29)
                {
                    return StringResources.Ordinal29;
                }
                if (Value == 30)
                {
                    return StringResources.Ordinal30;
                }
                if (Value == 31)
                {
                    return StringResources.Ordinal31;
                }
                if (Value == 99)
                {
                    return StringResources.LastLowercase;
                }

                return null;
            }
        }

        public static IList<DayOfMonth> All
        {
            get { return days; }
        }

        public static DayOfMonth Day(int index)
        {
            if (index == Last.Value)
            {
                return Last;
            }
            if (index < 1 || index > 31)
            {
                throw new ArgumentException("The day of month " + index + " is invalid. It does not exist.");
            }
            return days[index - 1];
        }

        public override int GetHashCode()
        {
            return value;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DayOfMonth))
            {
                return false;
            }

            var dayOfMonth = (DayOfMonth) obj;
            return dayOfMonth.value == value;
        }


        public override string ToString()
        {
            if (value == 1)
            {
                return StringResources.FirstText;
            }
            return value == 99 ? StringResources.Last : value.ToString(CultureInfo.InvariantCulture);
        }

        public static bool operator <(DayOfMonth d1, DayOfMonth d2)
        {
            return d1.value < d2.value;
        }

        public static bool operator >(DayOfMonth d1, DayOfMonth d2)
        {
            return d1.value > d2.value;
        }

        public static int operator -(DayOfMonth d1, DayOfMonth d2)
        {
            var result = d1.value - d2.value;
            return result;
        }

        public int GetActualDayOfMonth(int year, int month)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);

            if (value > daysInMonth)
            {
                return daysInMonth;
            }

            return value;
        }

        public DayOfMonth GetActualDay(Month month, int year)
        {
            var dayOfMonth = GetActualDayOfMonth(year, month.Value);
            return Day(dayOfMonth);
        }
    }
}