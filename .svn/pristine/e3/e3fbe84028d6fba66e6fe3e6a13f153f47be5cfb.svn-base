using System;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{ 
    public class CokerCardRowWithCycleStepStart : CokerCardRow
    {
        public CokerCardRowWithCycleStepStart(long drumId, string drumName)
            : base(drumId, drumName)
        {
        }

        public override string EntryTypeDescription
        {
            get { return "Start"; }
        }

        public override bool AllowedToEnterLastCycleStep
        {
            get { return true; }
        }

        public override bool AllowedToEnterHoursIntoLastCycleStep
        {
            get { return true; }
        }

        public override bool AllowedToEnterComments
        {
            get { return true; }
        }

        protected override void SetDateTime(CycleStepEntryDisplayAdapter adapter, DateTime? stepDateTime)
        {
            adapter.StartDateTime = stepDateTime;
        }

        protected override DateTime? GetSetDateTime(CycleStepEntryDisplayAdapter adapter)
        {
            return adapter.StartDateTime;
        }

        protected override bool IsReadOnlyCycleStepEntry(CycleStepEntryDisplayAdapter adapter)
        {
            return adapter.IsStartDateTimeReadOnly;
        }
    }
}
