using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule.Calculators;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [Serializable]
    public class RecurringDailySchedule : RecurringSchedule
    {
        private readonly int frequency;
        private readonly bool everyShift; // RITM0265710 - mangesh
        private readonly List<ShiftPattern> shifts;

        public RecurringDailySchedule(Date startDate, Date endDate, Time startTime, Time endTime, int frequency,
            Site site)
            : base(null, startDate, endDate, startTime, endTime, null, site)
        {
            this.frequency = frequency;
        }

        public RecurringDailySchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            int frequency, DateTime? lastInvokedDateTime, Site site)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            this.frequency = frequency;
        }

        //RITM0265710 - mangesh
        public RecurringDailySchedule(Date startDate, Date endDate, Time startTime, Time endTime, int frequency,
            Site site, bool everyShift)
            : base(null, startDate, endDate, startTime, endTime, null, site)
        {
            this.frequency = frequency;
            this.everyShift = everyShift;
        }
        public RecurringDailySchedule(long id, Date startDate, Date endDate, Time startTime, Time endTime,
            int frequency, DateTime? lastInvokedDateTime, Site site, bool everyShift, List<ShiftPattern> shifts)
            : base(id, startDate, endDate, startTime, endTime, lastInvokedDateTime, site)
        {
            this.frequency = frequency;
            this.everyShift = everyShift;
            this.shifts = shifts;
        }

        public override bool HasEndTime
        {
            get { return false; }
        }

        public override string BatchingKey
        {
            get
            {
                return EndDate != null
                    ? string.Format("{0} at {1}, Frequency {2} ending {3}", Type.Name, StartTime, Frequency, EndDate)
                    : string.Format("{0} at {1}, Frequency {2} and No End Date", Type.Name, StartTime, Frequency);
            }
        }

        public override int Frequency
        {
            get { return frequency; }
        }

        //RITM0265710 - mangesh
        public bool EveryShift
        {
            get { return everyShift; }
        }

        public override ScheduleType Type
        {
            get { return ScheduleType.Daily; }
        }

        public override string SimpleDescription
        {
            get
            {
                if (EndDate == null &&
                    Equals(StartTime, EndTime) &&
                    Frequency == 1)
                {
                    return
                        string.Format(
                            StringResources.RecurringDailySchedule_SimpleDescription_NoEndDate_Frequency_Once, StartTime);
                }

                return ToString();
            }
        }

        public override string RecurrencePatternString
        {
            get { return string.Format(StringResources.RecurringDailySchedule_RecurrencePatternString, frequency); }
        }

        public override List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            var scheduledOccurences = new List<Range<DateTime>>();
            var actionItemStartDateTimeToTest = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day,
                StartTime.Hour,
                StartTime.Minute, 0);

            while (actionItemStartDateTimeToTest <= EndDateTime)
            {
                var actionItemOccurence = new Range<DateTime>(actionItemStartDateTimeToTest,
                    new DateTime(actionItemStartDateTimeToTest.Year, actionItemStartDateTimeToTest.Month,
                        actionItemStartDateTimeToTest.Day, EndTime.Hour, EndTime.Minute, 0));
                if (DateRangeUtilities.OccurenceIsInWindow(actionItemOccurence, window))
                {
                    scheduledOccurences.Add(actionItemOccurence);
                }
                actionItemStartDateTimeToTest = actionItemStartDateTimeToTest.AddDays(frequency);
                if (actionItemStartDateTimeToTest > window.UpperBound) break;
            }
            return scheduledOccurences;
        }



        public override string ToString()
        {
            return ToString(HasEndTime);
        }

        public override string ToString(bool includeEndTime)
        {
            return includeEndTime
                ? string.Format(StringResources.RecurringDailySchedule_ToString_IncludeEndTime, frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime, EndTime)
                : string.Format(StringResources.RecurringDailySchedule_ToString_NotIncludeEndTime, frequency,
                    Date.ToDateString(StartDate),
                    Date.ToDateString(EndDate),
                    StartTime);
        }

        public override DateTime GetPreviousOccurrence(DateTime someDateTime)
        {
            return someDateTime.SubtractDays(frequency);
        }

        protected override DateTime GetNextInvokeDateTime(DateTime? lastInvokedDateTime)
        {
            //return
            //    new RecurringDailyScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
            //        frequency).GetNextInvokeDateTime();
            
            
            return
                new RecurringDailyScheduleCalculator(site.TimeZone, StartDateTime, EndDateTime, lastInvokedDateTime,
                    frequency, everyShift, shifts).GetNextInvokeDateTime();
        }
    }
}