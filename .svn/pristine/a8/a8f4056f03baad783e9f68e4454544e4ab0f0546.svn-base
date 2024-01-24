using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.DTO.Reporting
{
    [Serializable]
    public class MarkedAsNotReadReportDirectiveDTO
    {
        private readonly DateTime activeFromDateTime;
        private readonly DateTime activeToDateTime;

        private readonly string content;

        private readonly List<string> functionalLocations;
        private readonly string lastModifiedByFullNameWithUserName;
        private readonly List<ItemNotReadBy> notreadByUsers = new List<ItemNotReadBy>();
        private readonly List<string> workAssignments;

        public MarkedAsNotReadReportDirectiveDTO(DateTime activeFromDateTime,
            DateTime activeToDateTime,
            List<string> functionalLocations,
            List<string> workAssignments,
            string lastModifiedByFullNameWithUserName,
            string content,
            List<ItemNotReadBy> notreadByUsers)
              {
                  this.activeFromDateTime = activeFromDateTime;
                  this.activeToDateTime = activeToDateTime;

                  this.lastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
                  this.content = content;

                  this.functionalLocations = functionalLocations ?? new List<string>();
                  this.workAssignments = workAssignments ?? new List<string>();
                  this.notreadByUsers = notreadByUsers ?? new List<ItemNotReadBy>();

              }

        public MarkedAsNotReadReportDirectiveDTO(List<ItemNotReadBy> notreadByUsers)
        {
            this.notreadByUsers = notreadByUsers ?? new List<ItemNotReadBy>();
            
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
        public List<ItemNotReadBy> NotReadByUsers
        {
            get { return notreadByUsers; }
        }
        public void AddNotNotReadByUser(ItemNotReadBy notreadByUser)
        {
            if (!notreadByUsers.Contains(notreadByUser))
            {
                notreadByUsers.Add(notreadByUser);
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
