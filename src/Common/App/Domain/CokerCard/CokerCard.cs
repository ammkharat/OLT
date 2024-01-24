using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCard : DomainObject, ISiteRelevant, IHistoricalDomainObject
    {
        private readonly long configurationId;
        private readonly string configurationName;
        private readonly User createdBy;
        private readonly DateTime createdDateTime;
        private readonly List<CokerCardCycleStepEntry> cycleStepEntries = new List<CokerCardCycleStepEntry>();
        private readonly bool deleted;
        private readonly List<CokerCardDrumEntry> drumEntries = new List<CokerCardDrumEntry>();
        private readonly FunctionalLocation functionalLocation;

        private readonly ShiftPattern shift;
        private readonly Date shiftStartDate;
        private readonly WorkAssignment workAssignment;
        private User lastModifiedBy;
        private DateTime lastModifiedDate;

        public CokerCard(
            long? id,
            long configurationId,
            string configurationName,
            FunctionalLocation functionalLocation,
            WorkAssignment workAssignment,
            ShiftPattern shift,
            Date shiftStartDate,
            User createdBy,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            bool deleted)
        {
            this.id = id;
            this.configurationId = configurationId;
            this.configurationName = configurationName;
            this.functionalLocation = functionalLocation;
            this.workAssignment = workAssignment;
            this.shift = shift;
            this.shiftStartDate = shiftStartDate;
            this.createdBy = createdBy;
            this.createdDateTime = createdDateTime;
            this.lastModifiedBy = lastModifiedBy;
            this.lastModifiedDate = lastModifiedDate;
            this.deleted = deleted;
        }

        public List<CokerCardDrumEntry> DrumEntries
        {
            get { return drumEntries; }
        }

        public List<CokerCardCycleStepEntry> CycleStepEntries
        {
            get { return cycleStepEntries; }
        }

        public long ConfigurationId
        {
            get { return configurationId; }
        }

        public string ConfigurationName
        {
            get { return configurationName; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
        }

        public WorkAssignment WorkAssignment
        {
            get { return workAssignment; }
        }

        public ShiftPattern Shift
        {
            get { return shift; }
        }

        public Date ShiftStartDate
        {
            get { return shiftStartDate; }
        }

        public User CreatedBy
        {
            get { return createdBy; }
        }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public User LastModifiedBy
        {
            get { return lastModifiedBy; }
            set { lastModifiedBy = value; }
        }

        public DateTime LastModifiedDate
        {
            get { return lastModifiedDate; }
            set { lastModifiedDate = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
        }

        public bool IsRelevantTo(long siteId)
        {
            return functionalLocation.Site.IdValue == siteId;
        }

        public CokerCardHistory TakeSnapshot(CokerCardConfiguration configuration,
            List<CokerCardCycleStepEntry> previousEntries)
        {
            var cardHistory = new CokerCardHistory(configuration, this, previousEntries);
            return cardHistory;
        }

        public bool HasAtLeastOneEntryPerDrum(List<CokerCardConfigurationDrum> drums)
        {
            foreach (var drum in drums)
            {
                if (!cycleStepEntries.Exists(obj => obj.DrumId == drum.IdValue))
                {
                    return false;
                }
            }
            return true;
        }
    }
}