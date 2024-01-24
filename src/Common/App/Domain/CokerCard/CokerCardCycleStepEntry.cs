using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardCycleStepEntry : DomainObject
    {
        private readonly long cycleStepId;
        private readonly long drumId;
        private TimeEntry endEntry;
        private TimeEntry startEntry;

        public CokerCardCycleStepEntry(
            long? id,
            long drumId,
            long cycleStepId,
            TimeEntry startEntry,
            TimeEntry endEntry)
        {
            this.id = id;
            this.drumId = drumId;
            this.cycleStepId = cycleStepId;
            this.startEntry = startEntry;
            this.endEntry = endEntry;
        }

        public long DrumId
        {
            get { return drumId; }
        }

        public long CycleStepId
        {
            get { return cycleStepId; }
        }

        public TimeEntry StartEntry
        {
            get { return startEntry; }
            set { startEntry = value; }
        }

        public TimeEntry EndEntry
        {
            get { return endEntry; }
            set { endEntry = value; }
        }
    }
}