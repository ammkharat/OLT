using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class PriorityPageSectionConfiguration : DomainObject
    {
        public PriorityPageSectionConfiguration()
        {
            WorkAssignments = new List<WorkAssignment>();
        }

        public PriorityPageSectionConfiguration(PriorityPageSectionKey sectionKey, User user,
            bool sectionExpandedByDefault, List<WorkAssignment> workAssignments, DateTime lastModifiedDateTime)
        {
            SectionKey = sectionKey;
            User = user;
            SectionExpandedByDefault = sectionExpandedByDefault;
            WorkAssignments = workAssignments;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        public PriorityPageSectionKey SectionKey { get; set; }
        public User User { get; set; }
        public bool SectionExpandedByDefault { get; set; }

        public List<WorkAssignment> WorkAssignments { get; private set; }

        public DateTime LastModifiedDateTime { get; set; }

        public List<T> FilterDTOsByWorkAssignment<T>(List<T> dtos, WorkAssignment usersCurrentAssignment)
            where T : IHasWorkAssignment
        {
            if (WorkAssignments.Count == 0) // No configured work assignments means no filtering.
            {
                return dtos;
            }

            var configuredFilterList = new List<WorkAssignment>(WorkAssignments);

            if (usersCurrentAssignment != null)
            {
                configuredFilterList.Add(usersCurrentAssignment);
            }

            var filteredList =
                dtos.FindAll(
                    dto =>
                        dto.WorkAssignmentId == null ||
                        configuredFilterList.Exists(wa => wa.IdValue == dto.WorkAssignmentId));

            return filteredList;
        }
    }
}