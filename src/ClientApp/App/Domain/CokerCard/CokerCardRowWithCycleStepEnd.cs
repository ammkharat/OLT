using System;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{ 
    public class CokerCardRowWithCycleStepEnd : CokerCardRow
    {
        public CokerCardRowWithCycleStepEnd(long drumId, string drumName)
            : base(drumId, drumName)
        {
        }

        public override string EntryTypeDescription
        {
            get { return "End"; }
        }

        public override bool AllowedToEnterLastCycleStep
        {
            get { return false; }
        }

        public override bool AllowedToEnterHoursIntoLastCycleStep
        {
            get { return false; }
        }

        public override bool AllowedToEnterComments
        {
            get { return false; }
        }

        protected override void SetDateTime(CycleStepEntryDisplayAdapter adapter, DateTime? stepDateTime)
        {
            adapter.EndDateTime = stepDateTime;
        }

        protected override DateTime? GetSetDateTime(CycleStepEntryDisplayAdapter adapter)
        {
            return adapter.EndDateTime;
        }

        protected override bool IsReadOnlyCycleStepEntry(CycleStepEntryDisplayAdapter adapter)
        {
            return adapter.IsEndDateTimeReadOnly;
        }
    }
}
