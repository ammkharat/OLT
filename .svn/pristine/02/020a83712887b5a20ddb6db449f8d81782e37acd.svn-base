using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsReadReportDirectiveDTO
    {
        private readonly DateTime activeFromDateTime;
        private readonly DateTime activeToDateTime;

        private readonly string content;

        private readonly List<string> functionalLocations;
        private readonly string lastModifiedByFullNameWithUserName;
        private readonly List<ItemReadBy> readByUsers = new List<ItemReadBy>();
        private readonly List<string> workAssignments;

        public MarkedAsReadReportDirectiveDTO(
            DateTime activeFromDateTime,
            DateTime activeToDateTime,
            List<string> functionalLocations,
            List<string> workAssignments,
            string lastModifiedByFullNameWithUserName,
            string content,
            List<ItemReadBy> readByUsers)
        {
            this.activeFromDateTime = activeFromDateTime;
            this.activeToDateTime = activeToDateTime;

            this.lastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
            this.content = content;

            this.functionalLocations = functionalLocations ?? new List<string>();
            this.workAssignments = workAssignments ?? new List<string>();
            this.readByUsers = readByUsers ?? new List<ItemReadBy>();
        }

        public DateTime ActiveFromDateTime
        {
            get { return activeFromDateTime; }
        }

        public DateTime ActiveToDateTime
        {
            get { return activeToDateTime; }
        }

        public string FunctionalLocations
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        public string WorkAssignments
        {
            get { return workAssignments.BuildCommaSeparatedList(); }
        }

        public string LastModifiedByFullNameWithUserName
        {
            get { return lastModifiedByFullNameWithUserName; }
        }

        public string Content
        {
            get { return content; }
        }

        public List<ItemReadBy> ReadByUsers
        {
            get { return readByUsers; }
        }

        public void AddReadByUser(ItemReadBy readByUser)
        {
            if (!readByUsers.Contains(readByUser))
            {
                readByUsers.Add(readByUser);
            }
        }

        public void AddFunctionalLocation(string floc)
        {
            functionalLocations.AddAndSort(floc);
        }

        public void AddWorkAssignment(string workAssignment)
        {
            workAssignments.AddAndSort(workAssignment);
        }
    }
}