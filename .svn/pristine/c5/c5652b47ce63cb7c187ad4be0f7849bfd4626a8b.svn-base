using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryDisplayAdapterForPreviousCardEntry : CycleStepEntryDisplayAdapter
    {
        private readonly UserShift currentCokerCardUserShift;

        public CycleStepEntryDisplayAdapterForPreviousCardEntry(UserShift currentCokerCardUserShift, CokerCardCycleStepEntry entry)
            : base(entry.Id, entry.DrumId, entry.CycleStepId, entry.StartEntry, entry.EndEntry)
        {
            this.currentCokerCardUserShift = currentCokerCardUserShift;
        }

        public CycleStepEntryDisplayAdapterForPreviousCardEntry(UserShift currentCokerCardUserShift, long drumId, long cycleStepId) 
            : base(null, drumId, cycleStepId, null, null)
        {
            this.currentCokerCardUserShift = currentCokerCardUserShift;
        }

        public override bool IsStartDateTimeReadOnly
        {
            get { return true; }
        }

        public override bool IsEndDateTimeReadOnly
        {
            get { return !CanEditEntry(currentCokerCardUserShift, entryId, originalEndEntry); }
        }

        private static bool CanEditEntry(UserShift userShift, long? entryId, TimeEntry timeEntry)
        {
            return entryId.HasValue &&
                   (timeEntry == null || timeEntry.IsSameShift(userShift));
        }

        public override CokerCardCycleStepEntry GetCycleStepEntry()
        {
            if (!IsEndDateTimeReadOnly)
            {
                TimeEntry endEntry = null;
                if (endDateTime.HasValue)
                {
                    endEntry = new TimeEntry(
                        new Time(endDateTime.Value), 
                        currentCokerCardUserShift.ShiftPatternId, 
                        currentCokerCardUserShift.StartDate);
                }

                return new CokerCardCycleStepEntry(
                    entryId, drumId, cycleStepId,
                    originalStartEntry,
                    endEntry);
            }
            else
            {
                return null;
            }
        }
    }
}
