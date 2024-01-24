using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class DayOfWeek : IComparable
    {
        public static readonly DayOfWeek Sunday = new DayOfWeek(7);
        public static readonly DayOfWeek Monday = new DayOfWeek(1);
        public static readonly DayOfWeek Tuesday = new DayOfWeek(2);
        public static readonly DayOfWeek Wednesday = new DayOfWeek(3);
        public static readonly DayOfWeek Thursday = new DayOfWeek(4);
        public static readonly DayOfWeek Friday = new DayOfWeek(5);
        public static readonly DayOfWeek Saturday = new DayOfWeek(6);

        private static readonly DayOfWeek[] allDaysOfWeek =
        {
            Sunday, Monday, Tuesday, Wednesday, Thursday, Friday,
            Saturday
        };

        private readonly int value;

        public DayOfWeek(int value)
        {
            this.value = value;
        }

        public static List<DayOfWeek> All
        {
            get { return new List<DayOfWeek>(allDaysOfWeek); }
        }

        public string Name
        {
            get
            {
                if (Value == 7)
                {
                    return StringResources.Sunday;
                }
                if (Value == 1)
                {
                    return StringResources.Monday;
                }
                if (Value == 2)
                {
                    return StringResources.Tuesday;
                }
                if (Value == 3)
                {
                    return StringResources.Wednesday;
                }
                if (Value == 4)
                {
                    return StringResources.Thursday;
                }
                if (Value == 5)
                {
                    return StringResources.Friday;
                }
                if (Value == 6)
                {
                    return StringResources.Saturday;
                }
                return null;
            }
        }

        public int Value
        {
            get { return value; }
        }

        public int CompareTo(object obj)
        {
            return obj == null ? 1 : value.CompareTo(((DayOfWeek) obj).value);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DayOfWeek))
            {
                return false;
            }

            var dayOfWeek = (DayOfWeek) obj;
            return dayOfWeek.value == value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static DayOfWeek Get(int dayOfWeekIntValue)
        {
            foreach (var day in allDaysOfWeek)
            {
                if (day.Value == dayOfWeekIntValue)
                {
                    return day;
                }
            }
            return null;
        }

        public static DayOfWeek ConvertFromValue(int value)
        {
            return All.Find(obj => obj.value == value);
        }

        public static DayOfWeek ConvertFromSystem(System.DayOfWeek input)
        {
            switch (input)
            {
                case System.DayOfWeek.Friday:
                    return Friday;
                case System.DayOfWeek.Monday:
                    return Monday;
                case System.DayOfWeek.Saturday:
                    return Saturday;
                case System.DayOfWeek.Sunday:
                    return Sunday;
                case System.DayOfWeek.Thursday:
                    return Thursday;
                case System.DayOfWeek.Tuesday:
                    return Tuesday;
                case System.DayOfWeek.Wednesday:
                    return Wednesday;
                default:
                    throw new InvalidProgramException("Bad Day of Week");
            }
        }

        public static DayOfWeek ConvertFromString(string strDayOfWeek)
        {
            strDayOfWeek = strDayOfWeek.ToLower();

            if (strDayOfWeek.Equals(Monday.Name.ToLower()))
            {
                return Monday;
            }
            if (strDayOfWeek.Equals(Tuesday.Name.ToLower()))
            {
                return Tuesday;
            }
            if (strDayOfWeek.Equals(Wednesday.Name.ToLower()))
            {
                return Wednesday;
            }
            if (strDayOfWeek.Equals(Thursday.Name.ToLower()))
            {
                return Thursday;
            }
            if (strDayOfWeek.Equals(Friday.Name.ToLower()))
            {
                return Friday;
            }
            if (strDayOfWeek.Equals(Saturday.Name.ToLower()))
            {
                return Saturday;
            }
            if (strDayOfWeek.Equals(Sunday.Name.ToLower()))
            {
                return Sunday;
            }

            throw new InvalidProgramException("Bad Day of Week");
        }

        public static int operator -(DayOfWeek d1, DayOfWeek d2)
        {
            var result = d1.value - d2.value;

            if (result < 0)
            {
                result = result + 7;
            }
            return result;
        }

        public DayOfWeek GetClosestForwardDayOfWeekIn(List<DayOfWeek> checkList)
        {
            if (checkList.IsEmpty())
            {
                return null;
            }

            checkList.Sort();

            var foundDayOfWeek = checkList.Find(dayOfWeek => dayOfWeek.value >= value) ?? checkList[0];

            return foundDayOfWeek;
        }

        public bool IsLastDayOfWeekIn(List<DayOfWeek> checkList)
        {
            return checkList.DoesNotHave(day => day.value > value);
        }
    }
}