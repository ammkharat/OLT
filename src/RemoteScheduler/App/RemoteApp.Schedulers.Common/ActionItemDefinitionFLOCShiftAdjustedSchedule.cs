using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    public class ActionItemDefinitionFLOCShiftAdjustedSchedule : DomainObject, ISchedule,
        IActionItemDefinitionFLOCShiftAdjustedSchedule
    {
        private readonly long actionItemDefinitionId;
        private readonly FunctionalLocation floc;
        private readonly ISchedule schedule;
        private readonly IShiftPatternService shiftPatternService;

        public ActionItemDefinitionFLOCShiftAdjustedSchedule(
            ISchedule schedule,
            FunctionalLocation functionalLocation,
            long actionItemDefinitionId) : this(
                schedule,
                functionalLocation,
                actionItemDefinitionId,
                SchedulerServiceRegistry.Instance.GetService<IShiftPatternService>())
        {
        }

        public ActionItemDefinitionFLOCShiftAdjustedSchedule(
            ISchedule schedule,
            FunctionalLocation functionalLocation,
            long actionItemDefinitionId,
            IShiftPatternService shiftPatternService)
        {
            this.schedule = schedule;
            floc = functionalLocation;
            this.actionItemDefinitionId = actionItemDefinitionId;
            this.shiftPatternService = shiftPatternService;
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return floc; }
        }

        public long? FunctionalLocationId
        {
            get { return floc.Id; }
        }

        public long ActionItemDefinitionId
        {
            get { return actionItemDefinitionId; }
        }

        public ISchedule InternalSchedule
        {
            get { return schedule; }
        }

        public bool HasEndTime { get { return schedule.HasEndTime; } }

        public int Frequency
        {
            get
            {
                if (schedule.IsRecurring)
                {
                    var recurringSchedule = schedule as RecurringSchedule;
                    if (recurringSchedule != null)
                        return recurringSchedule.Frequency;
                    throw new InvalidCastException(
                        "Was not able to cast schedule to RecurringSchedule.  The schedule has Recurring set to true, but is not actually a recurring schedule.");
                }
                return 0; // There is no Frequency for non-recurring Schedules.
            }
        }

        public Site Site
        {
            get { return schedule.Site; }
        }

        public long? Id
        {
            get { return schedule.Id; }
            set { schedule.Id = value; }
        }

        public DateTime NextInvokeDateTime
        {
            get
            {
                var nextInvokeDateTime = schedule.NextInvokeDateTime;

                var shiftAdjustedNextInvokeDateTime = AdjustDateTimeToBeginningOfShift(nextInvokeDateTime);

                shiftAdjustedNextInvokeDateTime = RollShiftAdjustedNextInvokeDateTime(nextInvokeDateTime,
                    shiftAdjustedNextInvokeDateTime);

                return shiftAdjustedNextInvokeDateTime;
            }
        }

        /*  This method is here for situations where the NextInvokeDateTime comes back as a datetime earlier than the last invoked date time.
         *  An example of this is that the next invoke date time is shift adjusted to 10am, but it's currently 2pm.  So, the LastInvokedDateTime becomes 2pm.
         *  Then, the next invoke datetime is shift adjusted to 10am again.  The Shift Adjusted Next Invoke Date Time never gets pushed to the next one.
         *  See test ActionItemDefinitionFLOCShiftAdjustedScheduleTest.ShouldFireDailyScheduleOnceEachDay() for an example of a test that uses this code.
         *
         */

        public DateTime? LastInvokedDateTime
        {
            get { return schedule.LastInvokedDateTime; }
            set { schedule.LastInvokedDateTime = value; }
        }

        public Date StartDate
        {
            get { return schedule.StartDate; }
            set { schedule.StartDate = value; }
        }

        public Date EndDate
        {
            get { return schedule.EndDate; }
            set { schedule.EndDate = value; }
        }

        public DateTime StartDateTime
        {
            get { return schedule.StartDateTime; }
        }

        public DateTime EndDateTime
        {
            get { return schedule.EndDateTime; }
        }

        public bool HasEndDate
        {
            get { return schedule.HasEndDate; }
        }

        public bool IsNextScheduledTimeValid
        {
            get { return schedule.IsNextScheduledTimeValid; }
        }

        public ScheduleType Type
        {
            get { return schedule.Type; }
        }

        public string RecurrencePatternString
        {
            get { return schedule.RecurrencePatternString; }
        }

        public List<Range<DateTime>> ScheduledOccurencesWithin(Range<DateTime> window)
        {
            return schedule.ScheduledOccurencesWithin(window);
        }

        public string ToString(bool includeEndTime)
        {
            return schedule.ToString(includeEndTime);
        }

        public override string ToString()
        {
            return schedule.ToString();
        }

        public string SimpleDescription
        {
            get { return schedule.SimpleDescription; }
        }

        public Time StartTime
        {
            get { return schedule.StartTime; }
            set { schedule.StartTime = value; }
        }

        public Time EndTime
        {
            get { return schedule.EndTime; }
            set { schedule.EndTime = value; }
        }

        public new long IdValue
        {
            get { return schedule.IdValue; }
        }

        public bool CrossesDayBoundary
        {
            get { return schedule.CrossesDayBoundary; }
        }

        public bool IsRecurring
        {
            get { return schedule.IsRecurring; }
        }

        public bool Deleted
        {
            get { return schedule.Deleted; }
            set { schedule.Deleted = value; }
        }

        public bool Overlaps(ISchedule otherSchedule)
        {
            throw new NotImplementedException(
                "Overlaps is not implemented in class ActionItemDefinitionFLOCShiftAdjustedSchedule");
        }

        public List<DateTime> NextInvokeDateTimes(DateTime endDateTime)
        {
            return schedule.NextInvokeDateTimes(endDateTime);
        }

        public string BatchingKey
        {
            get { return schedule.BatchingKey; }
        }

        public bool IsAffectedByUnit(FunctionalLocation unit)
        {
            return floc.IsPartOfUnit(unit);
        }

        private DateTime RollShiftAdjustedNextInvokeDateTime(DateTime nextInvokeDateTime,
            DateTime shiftAdjustedNextInvokeDateTime)
        {
            if (IsValidActionItemDefinitionSchedule() && schedule.LastInvokedDateTime.HasValue &&
                shiftAdjustedNextInvokeDateTime < schedule.LastInvokedDateTime)
            {
                var lastInvokedDateTime = schedule.LastInvokedDateTime.Value;

                var realLastInvokeDateTime = lastInvokedDateTime;

                schedule.LastInvokedDateTime = nextInvokeDateTime;

                nextInvokeDateTime = schedule.NextInvokeDateTime;

                schedule.LastInvokedDateTime = realLastInvokeDateTime;

                shiftAdjustedNextInvokeDateTime = AdjustDateTimeToBeginningOfShift(nextInvokeDateTime);
            }
            return shiftAdjustedNextInvokeDateTime;
        }

        /* This method checks if the Schedule being passed is a valid Schedule for Action Item Definitions.  
           Action Items should never be recurring Hourly or recurring Minute because the Action Item Instances 
           would all fire at the beginning on the shift, thus creating multiple instances.
        */

        private bool IsValidActionItemDefinitionSchedule()
        {
            return schedule is SingleSchedule ||
                   schedule is ContinuousSchedule ||
                   schedule is RecurringDailySchedule ||
                   schedule is RecurringWeeklySchedule ||
                   schedule is RecurringMonthlyDayOfMonthSchedule ||
                   schedule is RecurringMonthlyDayOfWeekSchedule;
        }

        private DateTime AdjustDateTimeToBeginningOfShift(DateTime dateTime)
        {
            if (dateTime == Constants.PAST_END_TIME || dateTime == DateTime.MaxValue)
                return dateTime;

            var correspondingShiftPatternForFLOC =
                shiftPatternService.GetShiftBySiteAndDateTime(FunctionalLocation.Site, dateTime);

            var userShift = new UserShift(correspondingShiftPatternForFLOC, dateTime);

            return userShift.StartDateTimeWithPadding;
        }

        public ISchedule CreateCopy()
        {
            return new ActionItemDefinitionFLOCShiftAdjustedSchedule(schedule, floc, actionItemDefinitionId);
        }
    }
}