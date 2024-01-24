using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class WeekOfMonth
    {
        public static readonly WeekOfMonth First = new WeekOfMonth(1);
        public static readonly WeekOfMonth Second = new WeekOfMonth(2);
        public static readonly WeekOfMonth Third = new WeekOfMonth(3);
        public static readonly WeekOfMonth Fourth = new WeekOfMonth(4);
        public static readonly WeekOfMonth Fifth = new WeekOfMonth(5);
        public static readonly WeekOfMonth Last = new WeekOfMonth(99);

        private static readonly WeekOfMonth[] allWeeks = {First, Second, Third, Fourth, Fifth, Last};
        private readonly int value;

        private WeekOfMonth(int value)
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
                    return StringResources.OrdinalFirst;
                }
                if (Value == 2)
                {
                    return StringResources.OrdinalSecond;
                }
                if (Value == 3)
                {
                    return StringResources.OrdinalThird;
                }
                if (Value == 4)
                {
                    return StringResources.OrdinalFourth;
                }
                if (Value == 5)
                {
                    return StringResources.OrdinalFifth;
                }
                if (Value == 99)
                {
                    return StringResources.Last;
                }
                return null;
            }
        }

        public static IList<WeekOfMonth> All
        {
            get { return allWeeks; }
        }

        public static WeekOfMonth Week(int weekIndex)
        {
            return allWeeks.Find(w => w.Value == weekIndex);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is WeekOfMonth))
            {
                return false;
            }

            var weekOfMonth = (WeekOfMonth) obj;
            return weekOfMonth.value == value;
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