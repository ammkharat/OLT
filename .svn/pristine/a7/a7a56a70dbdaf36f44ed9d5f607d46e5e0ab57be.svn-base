using System;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class ShiftHandoverConfigurationDTO : DomainObject
    {
        public ShiftHandoverConfigurationDTO(long id, string assignmentListString, string name)
        {
            this.id = id;
            AssignmentListString = assignmentListString;
            Name = name;
        }

        public string AssignmentListString { get; private set; }
        public string Name { get; private set; }
    }
}