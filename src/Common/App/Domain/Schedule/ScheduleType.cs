using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class ScheduleType : SimpleDomainObject
    {
        public static ScheduleType Single = new ScheduleType(1);
        public static ScheduleType Continuous = new ScheduleType(2);
        public static ScheduleType Daily = new ScheduleType(3);
        public static ScheduleType Weekly = new ScheduleType(4);
        public static ScheduleType MonthlyDayOfMonth = new ScheduleType(5);
        public static ScheduleType MonthlyDayOfWeek = new ScheduleType(6);
        public static ScheduleType Hourly = new ScheduleType(7);
        public static ScheduleType ByMinute = new ScheduleType(8);
        public static ScheduleType RoundTheClock = new ScheduleType(9);

        private static readonly ScheduleType[] All =
        {
            Single, Continuous, Daily, Weekly, MonthlyDayOfMonth, MonthlyDayOfWeek,
            Hourly, ByMinute, RoundTheClock
        };

        private ScheduleType(long id) : base(id)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.SingleScheduleType;
            }
            if (IdValue == 2)
            {
                return StringResources.ContinuousScheduleType;
            }
            if (IdValue == 3)
            {
                return StringResources.RecurringDailyScheduleType;
            }
            if (IdValue == 4)
            {
                return StringResources.RecurringWeeklyScheduleType;
            }
            if (IdValue == 5)
            {
                return StringResources.RecurringMonthlyDayOfMonthScheduleType;
            }
            if (IdValue == 6)
            {
                return StringResources.RecurringMonthlyDayOfWeekScheduleType;
            }
            if (IdValue == 7)
            {
                return StringResources.RecurringHourlyScheduleType;
            }
            if (IdValue == 8)
            {
                return StringResources.RecurringMinuteScheduleType;
            }
            if (IdValue == 9)
            {
                return StringResources.RoundTheClockScheduleType;
            }
            return null;
        }

        public static ScheduleType GetById(int id)
        {
            return GetById(id, All);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ((ScheduleType) obj).id == id;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public static bool operator ==(ScheduleType x, ScheduleType y)
        {
            return x.AreEqualOperator(y);
        }

        public static bool operator !=(ScheduleType x, ScheduleType y)
        {
            return x.AreNotEqualOperator(y);
        }
    }
}