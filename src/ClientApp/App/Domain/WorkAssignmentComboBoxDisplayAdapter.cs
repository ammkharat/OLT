using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Domain
{
    public class WorkAssignmentComboBoxDisplayAdapter
    {        
        public WorkAssignmentComboBoxDisplayAdapter(WorkAssignment workAssignment)
        {
            WorkAssignmentValue = workAssignment;
        }

        public string Name { get { return WorkAssignmentValue.Name; } }
        public string Category { get { return WorkAssignmentValue.Category; } }
        public WorkAssignment WorkAssignmentValue { get; private set; }

        protected bool Equals(WorkAssignmentComboBoxDisplayAdapter other)
        {
            return Equals(WorkAssignmentValue, other.WorkAssignmentValue);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorkAssignmentComboBoxDisplayAdapter) obj);
        }

        public override int GetHashCode()
        {
            return (WorkAssignmentValue != null ? WorkAssignmentValue.GetHashCode() : 0);
        }
    }
}
