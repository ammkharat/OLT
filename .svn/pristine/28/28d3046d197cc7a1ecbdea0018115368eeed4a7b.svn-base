using System;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Common.Domain.LabAlert
{
    public class LabAlertCheckRangeCalculator
    {
        private readonly LabAlertDefinition definition;
        private readonly ILog logger = GenericLogManager.GetLogger<LabAlertCheckRangeCalculator>();

        private readonly ISchedule schedule;
        private readonly DateTime scheduleExecutionDateTime;
        private bool calculated;
        private DateTime fromDateTime;
        private DateTime toDateTime;

        public LabAlertCheckRangeCalculator(LabAlertDefinition definition, DateTime scheduleExecutionDateTime)
        {
            schedule = definition.Schedule;
            this.definition = definition;
            this.scheduleExecutionDateTime = scheduleExecutionDateTime;
        }

        public DateTime FromDateTime
        {
            get
            {
                Calculate();
                return fromDateTime;
            }
        }

        public DateTime ToDateTime
        {
            get
            {
                Calculate();
                return toDateTime;
            }
        }

        private void Calculate()
        {
            if (calculated)
            {
                return;
            }

            if (ScheduleType.Daily.Equals(schedule.Type))
            {
                CalculateDailyRange(scheduleExecutionDateTime);
            }
            else if (ScheduleType.Weekly.Equals(schedule.Type))
            {
                CalculateWeeklyRange((RecurringWeeklySchedule) schedule);
            }
            else if (ScheduleType.MonthlyDayOfMonth.Equals(schedule.Type))
            {
                CalculateMonthlyDayOfMonthRange();
            }
            else if (ScheduleType.MonthlyDayOfWeek.Equals(schedule.Type))
            {
                CalculateMonthlyDayOfWeekRange();
            }
            else
            {
                var message = string.Format(
                    "The provided schedule type ({0}) is not supported for Lab Alert definitions.", schedule.Type);
                throw new OLTException(message);
            }

            calculated = true;
        }

        private void CalculateMonthlyDayOfWeekRange()
        {
            var range = (LabAlertTagQueryMonthlyDayOfWeekRange) definition.LabAlertTagQueryRange;

            toDateTime = FindMostRecentDateForMonthlyDayOfWeek(
                scheduleExecutionDateTime, range.ToWeekOfMonth, range.ToDayOfWeek, range.ToTime);
            fromDateTime = FindMostRecentDateForMonthlyDayOfWeek(toDateTime, range.FromWeekOfMonth, range.FromDayOfWeek,
                range.FromTime);

            if (toDateTime.Equals(fromDateTime))
            {
                fromDateTime = FindDateTimeForMonthlyDayOfWeek(fromDateTime.AddMonths(-1), range.FromWeekOfMonth,
                    range.FromDayOfWeek, range.FromTime);
            }
        }

        private static DateTime FindMostRecentDateForMonthlyDayOfWeek(
            DateTime scheduleExecutionDateTime, WeekOfMonth rangeWeekOfMonth, DayOfWeek rangeDayOfWeek, Time rangeTime)
        {
            var potentialRangeToDateTime = FindDateTimeForMonthlyDayOfWeek(scheduleExecutionDateTime,
                rangeWeekOfMonth, rangeDayOfWeek,
                rangeTime);

            DateTime resultingDateTime;

            if (potentialRangeToDateTime <= scheduleExecutionDateTime)
            {
                resultingDateTime = potentialRangeToDateTime;
            }
            else
            {
                var adjustedDateTime = scheduleExecutionDateTime.AddMonths(-1);
                resultingDateTime =
                    FindDateTimeForMonthlyDayOfWeek(adjustedDateTime, rangeWeekOfMonth, rangeDayOfWeek, rangeTime);
            }

            return resultingDateTime;
        }

        private static DateTime FindDateTimeForMonthlyDayOfWeek(DateTime baseDateTime, WeekOfMonth weekOfMonth,
            DayOfWeek dayOfWeek, Time time)
        {
            var adjustedMonth = Month.GetByMonth(baseDateTime.Month);
            var adjustedCurrentDayOfMonth = adjustedMonth.GetByDayOfWeekWeekOfMonth(weekOfMonth, dayOfWeek,
                baseDateTime.Year);
            var adjustedDay = adjustedCurrentDayOfMonth.GetActualDayOfMonth(baseDateTime.Year, baseDateTime.Month);

            return new DateTime(baseDateTime.Year, baseDateTime.Month, adjustedDay,
                time.Hour, time.Minute, time.Second);
        }

        private void CalculateMonthlyDayOfMonthRange()
        {
            var range = (LabAlertTagQueryMonthlyDayOfMonthRange) definition.LabAlertTagQueryRange;

            toDateTime = FindMostRecentDateForDayOfMonth(range.ToDayOfMonth, range.ToTime, scheduleExecutionDateTime);
            fromDateTime = FindMostRecentDateForDayOfMonth(range.FromDayOfMonth, range.FromTime, toDateTime);

            if (toDateTime.Equals(fromDateTime))
            {
                fromDateTime = fromDateTime.AddMonths(-1);
            }
        }

        private static DateTime FindMostRecentDateForDayOfMonth(DayOfMonth dayOfMonth, Time toTime,
            DateTime scheduleExecutionDateTime)
        {
            var toRangeDay = dayOfMonth.GetActualDayOfMonth(scheduleExecutionDateTime.Year,
                scheduleExecutionDateTime.Month);

            var potentialRangeToDateTime =
                new DateTime(scheduleExecutionDateTime.Year, scheduleExecutionDateTime.Month, toRangeDay,
                    toTime.Hour, toTime.Minute, toTime.Second);

            DateTime resultingDateTime;

            if (potentialRangeToDateTime <= scheduleExecutionDateTime)
            {
                resultingDateTime = potentialRangeToDateTime;
            }
            else
            {
                potentialRangeToDateTime = potentialRangeToDateTime.AddMonths(-1);

                var daysInMonth = DateTime.DaysInMonth(potentialRangeToDateTime.Year, potentialRangeToDateTime.Month);

                var day = dayOfMonth.Value > daysInMonth ? daysInMonth : dayOfMonth.Value;

                resultingDateTime =
                    new DateTime(potentialRangeToDateTime.Year, potentialRangeToDateTime.Month,
                        day, potentialRangeToDateTime.Hour, potentialRangeToDateTime.Minute,
                        potentialRangeToDateTime.Second);
            }

            return resultingDateTime;
        }

        private void CalculateDailyRange(DateTime baselineScheduleExecutionTime)
        {
            var range = (LabAlertTagQueryDailyRange) definition.LabAlertTagQueryRange;

            toDateTime = baselineScheduleExecutionTime.RollBackward(range.ToTime);
            fromDateTime = toDateTime.RollBackward(range.FromTime, false);
        }

        private void CalculateWeeklyRange(RecurringWeeklySchedule weeklySchedule)
        {
            var weeklyRange = (LabAlertTagQueryWeeklyRange) definition.LabAlertTagQueryRange;

            if (weeklySchedule.DaysOfWeek.Count != 1)
            {
                var errorMessage =
                    "A weekly schedule was provided that does not contain 1 day. The range calculater expects 1 day.";
                logger.Error(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            var rightNowDayOfWeek = weeklySchedule.DaysOfWeek[0];
            var toRangeDayOfWeek = weeklyRange.ToDayOfWeek;

            var checkRangeToTime = weeklyRange.ToTime;

            toDateTime = FindMostRecentDateForDayOfWeek(
                rightNowDayOfWeek, toRangeDayOfWeek, weeklySchedule.StartTime, scheduleExecutionDateTime,
                checkRangeToTime);

            var fromRangeDayOfWeek = weeklyRange.FromDayOfWeek;

            fromDateTime = FindMostRecentDateForDayOfWeek(
                toRangeDayOfWeek, fromRangeDayOfWeek, new Time(toDateTime), toDateTime, weeklyRange.FromTime);

            if (toDateTime.Equals(fromDateTime))
            {
                fromDateTime = fromDateTime.AddDays(-7);
            }
        }

        private static DateTime FindMostRecentDateForDayOfWeek(DayOfWeek rightNowDayOfWeek, DayOfWeek toRangeDayOfWeek,
            Time scheduleTime, DateTime scheduleExecutionTime, Time checkRangeToTime)
        {
            DateTime resultingDateTime;

            if (rightNowDayOfWeek.Equals(toRangeDayOfWeek))
            {
                var potentialToDateTime = new DateTime(
                    scheduleExecutionTime.Year, scheduleExecutionTime.Month, scheduleExecutionTime.Day,
                    checkRangeToTime.Hour, checkRangeToTime.Minute, checkRangeToTime.Second);

                if (checkRangeToTime <= scheduleTime)
                {
                    resultingDateTime = potentialToDateTime;
                }
                else
                {
                    resultingDateTime = potentialToDateTime.AddDays(-7);
                }
            }
            else
            {
                var targetDayOfWeek = toRangeDayOfWeek;
                var counterDateTime = scheduleExecutionTime;
                var counterDayOfWeek = DayOfWeek.ConvertFromSystem(counterDateTime.DayOfWeek);

                while (!counterDayOfWeek.Equals(targetDayOfWeek))
                {
                    counterDateTime = counterDateTime.AddDays(-1);
                    counterDayOfWeek = DayOfWeek.ConvertFromSystem(counterDateTime.DayOfWeek);
                }

                resultingDateTime = new DateTime(counterDateTime.Year, counterDateTime.Month, counterDateTime.Day,
                    checkRangeToTime.Hour, checkRangeToTime.Minute, checkRangeToTime.Second);
            }

            return resultingDateTime;
        }
    }
}