using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Utility.Cache;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardConfiguration : DomainObject, ICacheBySiteId
    {
        public const string DISPLAY_MEMBER = "Name";

        private readonly List<CokerCardConfigurationDrum> drums = new List<CokerCardConfigurationDrum>();
        private readonly List<CokerCardConfigurationCycleStep> steps = new List<CokerCardConfigurationCycleStep>();
        private readonly List<WorkAssignment> workAssignments = new List<WorkAssignment>();
        private FunctionalLocation functionalLocation;
        private string name;

        public CokerCardConfiguration(
            long? id,
            string name,
            FunctionalLocation functionalLocation)
        {
            this.id = id;
            this.name = name;
            this.functionalLocation = functionalLocation;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
            set { functionalLocation = value; }
        }

        public List<WorkAssignment> WorkAssignments
        {
            get { return workAssignments; }
        }

        public List<CokerCardConfigurationDrum> Drums
        {
            get { return drums; }
        }

        public List<CokerCardConfigurationCycleStep> Steps
        {
            get { return steps; }
        }

        [IgnoreToString]
        public long SiteId
        {
            get { return FunctionalLocation.Site.IdValue; }
        }
    }
}