using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardDrumEntry : DomainObject
    {
        private readonly long drumId;
        private string comments;
        private decimal? hoursIntoLastCycle;
        private long? lastCycleStepId;

        public CokerCardDrumEntry(long? id, long drumId, long? lastCycleStepId, decimal? hoursIntoLastCycle,
            string comments)
        {
            this.id = id;
            this.drumId = drumId;

            this.lastCycleStepId = lastCycleStepId;
            this.hoursIntoLastCycle = hoursIntoLastCycle;
            this.comments = comments;
        }

        public long DrumId
        {
            get { return drumId; }
        }

        public long? LastCycleStepId
        {
            get { return lastCycleStepId; }
            set { lastCycleStepId = value; }
        }

        public decimal? HoursIntoLastCycle
        {
            get { return hoursIntoLastCycle; }
            set { hoursIntoLastCycle = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
    }
}