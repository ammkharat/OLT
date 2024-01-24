using System;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Domain.CokerCard
{
    public abstract class CycleStepEntryDisplayAdapter
    {
        protected readonly long? entryId;
        protected readonly long drumId;
        protected readonly long cycleStepId;
        protected readonly TimeEntry originalStartEntry;
        protected readonly TimeEntry originalEndEntry;

        protected DateTime? startDateTime;
        protected DateTime? endDateTime;

        protected CycleStepEntryDisplayAdapter(
            long? entryId, 
            long drumId, 
            long cycleStepId,
            TimeEntry originalStartEntry, 
            TimeEntry originalEndEntry)
        {
            this.entryId = entryId;
            this.drumId = drumId;
            this.cycleStepId = cycleStepId;
            this.originalStartEntry = originalStartEntry;
            this.originalEndEntry = originalEndEntry;

            startDateTime = originalStartEntry == null ? (DateTime?)null : originalStartEntry.Time.ToDateTime();
            endDateTime = originalEndEntry == null ? (DateTime?)null : originalEndEntry.Time.ToDateTime();                
        }

        public abstract bool IsStartDateTimeReadOnly { get; }
        public abstract bool IsEndDateTimeReadOnly { get; }
        public abstract CokerCardCycleStepEntry GetCycleStepEntry();

        public DateTime? StartDateTime
        {
            get { return startDateTime; }
            set
            {
                if (!IsStartDateTimeReadOnly)
                {
                    startDateTime = value;
                }
            }
        }

        public DateTime? EndDateTime
        {
            get { return endDateTime; }
            set
            {
                if (!IsEndDateTimeReadOnly)
                {
                    endDateTime = value;
                }
            }
        }

        public TimeEntry OriginalEndEntry
        {
            get { return originalEndEntry; }
        }
    }
}
