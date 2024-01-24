using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class Month : IComparable
    {
        public static readonly Month January = new Month(1);
        public static readonly Month February = new Month(2);
        public static readonly Month March = new Month(3);
        public static readonly Month April = new Month(4);
        public static readonly Month May = new Month(5);
        public static readonly Month June = new Month(6);
        public static readonly Month July = new Month(7);
        public static readonly Month August = new Month(8);
        public static readonly Month September = new Month(9);
        public static readonly Month October = new Month(10);
        public static readonly Month November = new Month(11);
        public static readonly Month December = new Month(12);

        private static readonly Month[] allMonths =
        {
            January, February, March, April, May, June, July, August, September,
            October, November, December
        };

        private readonly int value;

        private Month(int value)
        {
            this.value = value;
        }

        public string Abbreviation
        {
            get { return Name.Substring(0, 3); }
        }

        public static List<Month> All
        {
            get { return new List<Month>(allMonths); }
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
                    return StringResources.January;
                }
                if (Value == 2)
                {
                    return StringResources.February;
                }
                if (Value == 3)
                {
                    return StringResources.March;
                }
                if (Value == 4)
                {
                    return StringResources.April;
                }
                if (Value == 5)
                {
                    return StringResources.May;
                }
                if (Value == 6)
                {
                    return StringResources.June;
                }
                if (Value == 7)
                {
                    return StringResources.July;
                }
                if (Value == 8)
                {
                    return StringResources.August;
                }
                if (Value == 9)
                {
                    return StringResources.September;
                }
                if (Value == 10)
                {
                    return StringResources.October;
                }
                if (Value == 11)
                {
                    return StringResources.November;
                }
                if (Value == 12)
                {
                    return StringResources.December;
                }
                return null;
            }
        }

        public int CompareTo(object obj)
        {
            return obj == null ? 1 : value.CompareTo(((Month) obj).Value);
        }

        public static Month GetByMonth(int index)
        {
            return allMonths[index - 1];
        }


        public DayOfMonth GetLastDay(int year)
        {
            var firstDayThisMonth = new DateTime(year, value, 1);
            var firstDayOfNextMonth = firstDayThisMonth.AddMonths(1);
            var lastDayOfThisMonth = firstDayOfNextMonth.SubtractDays(1);
            return DayOfMonth.Day(lastDayOfThisMonth.Day);
        }

        public DayOfMonth GetByDayOfWeekWeekOfMonth(WeekOfMonth week, DayOfWeek day, int year)
        {
            var firstDayOfThisMonth = new DateTime(year, value, 1);
            var dayDiff = day - DayOfWeek.ConvertFromSystem(firstDayOfThisMonth.DayOfWeek);

            var firstDayOfWeekThisMonth = firstDayOfThisMonth.AddDays(dayDiff);
            var resultDay = firstDayOfWeekThisMonth;

            var count = week.Value - 1;
            while (resultDay.AddDays(7).Month == firstDayOfWeekThisMonth.Month && count > 0)
            {
                resultDay = resultDay.AddDays(7);
                count--;
            }
            return DayOfMonth.Day(resultDay.Day);
        }

        public Month GetNextMonthIn(List<Month> checkList)
        {
            checkList.Sort();
            Month result = null;
            Month previousMonth = null;
            foreach (var month in checkList)
            {
                if (previousMonth != null && previousMonth.Value == Value)
                {
                    result = month;
                    break;
                }

                if (month.Value == Value)
                {
                    previousMonth = this;
                }
            }

            if (previousMonth != null && result == null)
            {
                result = checkList[0];
            }

            return result;
        }

        public bool IsLastMonthIn(List<Month> checkList)
        {
            checkList.Sort();
            return checkList.Count > 0 && checkList[checkList.Count - 1].Value == Value;
        }

        public static int operator -(Month m1, Month m2)
        {
            var result = m1.value - m2.value;
            if (result < 0)
            {
                result += 12;
            }
            return result;
        }

        public static Month GetFirstMonthIn(List<Month> checkList)
        {
            checkList.Sort();
            return checkList.Count > 0 ? checkList[0] : null;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Month))
            {
                return false;
            }

            var month = (Month) obj;
            return month.value == value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}