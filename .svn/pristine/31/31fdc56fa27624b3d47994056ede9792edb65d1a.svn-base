using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardDrumEntryHistory : DomainObject
    {
        private readonly List<CokerCardCycleStepHistory> cycleStepHistory = new List<CokerCardCycleStepHistory>();

        public CokerCardDrumEntryHistory(CokerCardConfigurationDrum drumConfiguration)
        {
            DrumConfigurationId = drumConfiguration.IdValue;
            Name = drumConfiguration.Name;
        }

        public CokerCardDrumEntryHistory(long id, long drumConfiguerationId, string drumName, string lastCycleStep,
            decimal? hoursIntoLastCycle, string comment)
        {
            Id = id;
            DrumConfigurationId = drumConfiguerationId;
            Name = drumName;
            LastCycleStep = lastCycleStep;
            HoursIntoLastCycle = hoursIntoLastCycle;
            Comments = comment;
        }

        public List<CokerCardCycleStepHistory> CycleStepHistory
        {
            get { return cycleStepHistory; }
        }

        [DifferenceLabel]
        public string Name { get; private set; }

        [IgnoreDifference]
        [IgnoreToString]
        public long DrumConfigurationId { get; private set; }

        public string LastCycleStep { get; set; }
        public decimal? HoursIntoLastCycle { get; set; }
        public string Comments { get; set; }
    }
}