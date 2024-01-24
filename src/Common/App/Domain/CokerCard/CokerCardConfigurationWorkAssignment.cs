using System;

namespace Com.Suncor.Olt.Common.Domain.CokerCard
{
    [Serializable]
    public class CokerCardConfigurationWorkAssignment : DomainObject
    {
        private readonly long cokerCardConfigurationId;
        private readonly WorkAssignment workAssignment;

        public CokerCardConfigurationWorkAssignment(long cokerCardConfigurationId, WorkAssignment workAssignment)
        {
            this.cokerCardConfigurationId = cokerCardConfigurationId;
            this.workAssignment = workAssignment;
        }

        public long CokerCardConfigurationId
        {
            get { return cokerCardConfigurationId; }
        }

        public WorkAssignment WorkAssignment
        {
            get { return workAssignment; }
        }
    }
}