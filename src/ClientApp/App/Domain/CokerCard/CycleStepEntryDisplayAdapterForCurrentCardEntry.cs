using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryDisplayAdapterForCurrentCardEntry : CycleStepEntryDisplayAdapter
    {
        private readonly UserShift currentCokerCardUserShift;

        public CycleStepEntryDisplayAdapterForCurrentCardEntry(UserShift currentCokerCardUserShift, CokerCardCycleStepEntry entry)
            : base(entry.Id, entry.DrumId, entry.CycleStepId, entry.StartEntry, entry.EndEntry)
        {
            this.currentCokerCardUserShift = currentCokerCardUserShift;
        }

        public CycleStepEntryDisplayAdapterForCurrentCardEntry(UserShift currentCokerCardUserShift, long drumId, long cycleStepId) 
            : base(null, drumId, cycleStepId, null, null)
        {
            this.currentCokerCardUserShift = currentCokerCardUserShift;
        }

        public override bool IsStartDateTimeReadOnly
        {
            get { return false; }
        }

        public override bool IsEndDateTimeReadOnly
        {
            get { return EndEntryIsForADifferentShift; }
        }

        private bool EndEntryIsForADifferentShift
        {
            get { return !CanEditEntry(currentCokerCardUserShift, originalEndEntry); }
        }

        private static bool CanEditEntry(UserShift userShift, TimeEntry timeEntry)
        {
            return timeEntry == null || timeEntry.IsSameShift(userShift);
        }

        public override CokerCardCycleStepEntry GetCycleStepEntry()
        {
            if (startDateTime.HasValue)
            {
                TimeEntry startEntry = new TimeEntry(
                    new Time(startDateTime.Value),
                    currentCokerCardUserShift.ShiftPatternId,
                    currentCokerCardUserShift.StartDate);

                TimeEntry endEntry = null;
                if (endDateTime.HasValue)
                {
                    if (EndEntryIsForADifferentShift)
                    {
                        endEntry = new TimeEntry(
                            new Time(endDateTime.Value),
                            originalEndEntry.ShiftId,
                            originalEndEntry.ShiftStartDate);
                    }
                    else
                    {
                        endEntry = new TimeEntry(
                            new Time(endDateTime.Value),
                            currentCokerCardUserShift.ShiftPatternId,
                            currentCokerCardUserShift.StartDate);
                    }
                }

                return new CokerCardCycleStepEntry(entryId, drumId, cycleStepId, startEntry, endEntry);
            }
            else
            {
                return null;
            }
        }
    }
}
