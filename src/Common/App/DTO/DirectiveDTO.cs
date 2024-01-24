using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class DirectiveDTO : DomainObject, IHasReadByCurrentUserInfo, ICreatedByARole, IShiftBased
    {
        public const long CreatedByMigrationRoleID = 0;

        private readonly DateTime activeFromDateTime;
        private readonly DateTime activeToDateTime;
        private readonly string content;
        private readonly string createdByFullNameWithUsername;
        
        private readonly long createdByRoleId;
        private readonly long createdByUserId;
        private readonly string createdByWorkAssignmentName;
        private readonly DateTime createdDateTime;
        private readonly List<string> functionalLocations;
        private readonly string lastModifiedByFullName;
        private readonly string lastModifiedByFullNameWithUsername;
        private readonly long lastModifiedByUserId;
        private readonly List<string> workAssignments;

        public DirectiveDTO(long? id, List<string> workAssignments, List<string> functionalLocations,                   
            DateTime activeFromDateTime, DateTime activeToDateTime, long createdByUserId, long createdByRoleId,
            DateTime createdDateTime, long lastModifiedByUserId,
            string content, string createdByFullNameWithUsername, string lastModifiedByFullName,
            string lastModifiedByFullNameWithUsername, string createdByWorkAssignmentName)
        {
            this.id = id;

            this.workAssignments = workAssignments;
            this.functionalLocations = functionalLocations;

            this.activeToDateTime = activeToDateTime;
            this.activeFromDateTime = activeFromDateTime;
            this.createdByUserId = createdByUserId;
            this.lastModifiedByUserId = lastModifiedByUserId;
            this.createdByWorkAssignmentName = createdByWorkAssignmentName;

            this.createdByRoleId = createdByRoleId;
            this.createdDateTime = createdDateTime;

            this.content = content;

            this.createdByFullNameWithUsername = createdByFullNameWithUsername;
            this.lastModifiedByFullName = lastModifiedByFullName;
            this.lastModifiedByFullNameWithUsername = lastModifiedByFullNameWithUsername;
        }

        public DirectiveDTO(Directive directive)
            : this(
           directive.Id,
                directive.WorkAssignments.ConvertAll(WorkAssignmentString),
                directive.FunctionalLocations.FullHierarchyList(true),
                directive.ActiveFromDateTime,
                directive.ActiveToDateTime,
                directive.CreatedBy.IdValue,
                directive.CreatedByRole != null ? directive.CreatedByRole.IdValue : CreatedByMigrationRoleID,
                directive.CreatedDateTime,
                directive.LastModifiedBy.IdValue,
                directive.PlainTextContent,
                directive.CreatedBy.FullNameWithUserName,
                directive.LastModifiedBy.FullName,
                directive.LastModifiedBy.FullNameWithUserName,
                directive.CreatedByWorkAssignmentName)
        {
        }

        [IncludeInSearch]
        public string WorkAssignments
        {
            get { return workAssignments.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string FunctionalLocations
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public DateTime ActiveFromDateTime
        {
            get { return activeFromDateTime; }
        }

        
        [IncludeInSearch]
        public DateTime ActiveToDateTime
        {
            get { return activeToDateTime; }
        }

        [IncludeInSearch]
        public string Content
        {
            get { return content; }
        }

        [IncludeInSearch]
        public string CreatedByWorkAssignmentName
        {
            get { return createdByWorkAssignmentName; }
        }

        [IncludeInSearch]
        public string CreatedByFullNameWithUsername
        {
            get { return createdByFullNameWithUsername; }
        }

        [IncludeInSearch]
        public string LastModifiedByFullName
        {
            get { return lastModifiedByFullName; }
        }

        [IncludeInSearch]
        public string LastModifiedByFullNameWithUsername
        {
            get { return lastModifiedByFullNameWithUsername; }
        }

        public long LastModifiedByUserId
        {
            get { return lastModifiedByUserId; }
        }

        public long CreatedByRoleId
        {
            get { return createdByRoleId; }
        }

        public long CreatedByUserId
        {
            get { return createdByUserId; }
        }

        public bool? IsReadByCurrentUser { get; set; }

        public DateTime CreatedDateTime
        {
            get { return createdDateTime; }
        }

        public static string WorkAssignmentString(WorkAssignment wa)
        {
            return wa.Name;
        }

        public void AddFunctionalLocation(string floc)
        {
            functionalLocations.AddAndSort(floc);
        }

        public void AddWorkAssignment(string assignment)
        {
            workAssignments.AddAndSort(assignment);
        }

        public bool IsInFuture(DateTime now)
        {
            return ActiveFromDateTime > now;
        }


        public bool IsExpired(DateTime now)
        {
            return now > ActiveToDateTime;
        }

        public bool IsActive(DateTime now)
        {
            return !IsInFuture(now) && !IsExpired(now);
        }

        public bool IsRelevantToAssignment(WorkAssignment assignment)
        {
            if (assignment == null || workAssignments.IsEmpty())
            {
                return true;
            }

            return workAssignments.Contains(WorkAssignmentString(assignment));
        }

        # region Unused but required by DirectiveAuthorization

        public long CreatedShiftPatternId { get; private set; }
        public Date CreatedShiftEndDate { get; private set; }

        #endregion
    }
}