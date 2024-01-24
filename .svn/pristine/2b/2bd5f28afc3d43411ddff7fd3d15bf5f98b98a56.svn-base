using System;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardCycleStepHistory : DomainObject
    {
        public CokerCardCycleStepHistory(long? id, long cycleStepConfigurationId, string cycleStepName, string drumName,
            Time startTime, Time endTime)
        {
            Id = id;
            CycleStepConfigurationId = cycleStepConfigurationId;
            CycleStepName = cycleStepName;
            DrumName = drumName;
            StartTime = startTime;
            EndTime = endTime;
        }

        public CokerCardCycleStepHistory(CokerCardConfigurationCycleStep cycleStepConfiguration, string drumName)
        {
            CycleStepConfigurationId = cycleStepConfiguration.IdValue;
            CycleStepName = cycleStepConfiguration.Name;
            DrumName = drumName;
        }

        [DifferenceLabel]
        [IgnoreToString]
        public string Name
        {
            get { return DrumName + " - " + CycleStepName; }
        }

        [IgnoreDifference]
        private string DrumName { get; set; }

        [IgnoreDifference]
        public string CycleStepName { get; private set; }

        [IgnoreDifference]
        [IgnoreToString]
        public long CycleStepConfigurationId { get; private set; }

        public Time StartTime { get; private set; }
        public Time EndTime { get; private set; }

        public void SetTimes(TimeEntry startEntry, TimeEntry endEntry)
        {
            StartTime = startEntry != null ? startEntry.Time : null;
            EndTime = endEntry != null ? EndTime = endEntry.Time : null;
        }
    }
}