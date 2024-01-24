using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    // This isn't really a DomainObject, in that it never gets persisted and there is no matching table. It's a DomainObject in the code
    // because it will work better with the Grid this way.
    public class AssignmentFlocConfiguration : DomainObject
    {
        public AssignmentFlocConfiguration(
            long workAssignmentId, string name, string role, string description,
            string category, List<FunctionalLocation> functionalLocations)
        {
            Id = workAssignmentId;
            WorkAssignmentId = workAssignmentId;
            Name = name;
            RoleName = role;
            Description = description;
            Category = category;
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
        }

        public long WorkAssignmentId { get; private set; }
        public string Name { get; private set; }
        public string RoleName { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }
        public List<FunctionalLocation> FunctionalLocations { get; private set; }

        public override string ToString()
        {
            var descriptionString = string.IsNullOrEmpty(Description) ? "" : string.Format(" ({0})", Description);
            return string.Format("{0}{1}", Name, descriptionString);
        }
    }
}