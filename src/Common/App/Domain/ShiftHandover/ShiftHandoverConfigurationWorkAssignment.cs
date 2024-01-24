namespace Com.Suncor.Olt.Common.Domain.ShiftHandover
{
    public class ShiftHandoverConfigurationWorkAssignment : DomainObject
    {
        private readonly long shiftHandoverConfigurationId;
        private readonly WorkAssignment workAssignment;

        public ShiftHandoverConfigurationWorkAssignment(long shiftHandoverConfigurationId, WorkAssignment workAssignment)
        {
            this.shiftHandoverConfigurationId = shiftHandoverConfigurationId;
            this.workAssignment = workAssignment;
        }

        public long ShiftHandoverConfigurationId
        {
            get { return shiftHandoverConfigurationId; }
        }

        public WorkAssignment WorkAssignment
        {
            get { return workAssignment; }
        }
    }
}