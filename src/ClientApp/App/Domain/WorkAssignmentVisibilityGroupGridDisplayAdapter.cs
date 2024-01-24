using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Domain
{
    public class WorkAssignmentVisibilityGroupGridDisplayAdapter : DomainObject
    {
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }

        public VisibilityGroup VisibilityGroup { get; private set; }

        public WorkAssignmentVisibilityGroupGridDisplayAdapter(VisibilityGroup group, bool canRead, bool canWrite)
        {
            Id = group.Id;
            CanRead = canRead;
            CanWrite = canWrite;
            VisibilityGroup = group;
        }

        public string GroupName
        {
            get
            {
                return VisibilityGroup != null ? VisibilityGroup.Name : null;
            }
        }
    }
}