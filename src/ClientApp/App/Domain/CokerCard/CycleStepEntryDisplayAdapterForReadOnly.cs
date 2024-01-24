using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public class CycleStepEntryDisplayAdapterForReadOnly : CycleStepEntryDisplayAdapter
    {
        public CycleStepEntryDisplayAdapterForReadOnly(CokerCardCycleStepEntry entry)
            : base(entry.Id, entry.DrumId, entry.CycleStepId, entry.StartEntry, entry.EndEntry)
        {
            
        }
        public CycleStepEntryDisplayAdapterForReadOnly(long drumId, long cycleStepId) 
            : base(null, drumId, cycleStepId, null, null)
        {
        }

        public override bool IsStartDateTimeReadOnly
        {
            get { return true; }
        }

        public override bool IsEndDateTimeReadOnly
        {
            get { return true; }
        }

        public override CokerCardCycleStepEntry GetCycleStepEntry()
        {
            return null;
        }
    }
}
