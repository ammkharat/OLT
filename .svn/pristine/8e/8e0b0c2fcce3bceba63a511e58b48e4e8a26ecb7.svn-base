using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    public class FutureActionItemDTO : ActionItemDTO
    {
        public FutureActionItemDTO(long id, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime,
            long statusId, Priority priority, string categoryName, long sourceId,
            string description, string scheduleTypeName, List<string> functionalLocationNames,
            List<string> functionalLocationNamesWithDescription,
            bool responseRequired, long? lastModifiedUserId, string name, string workAssignmentName,
            long? workAssignmentId, List<string> visibilityGroupNames, bool requiresApproval, bool temporarilyInactive,
            string operationalMode, long actionItemDefinitionId,string visGroupsStartingWith,long createdbyactionitemdefinition,bool reading)                                   //ayman visibility group     ayman action item definition
            : base(
                id, startDate, startTime, endDate, endTime, statusId, priority, categoryName, sourceId, description,
                scheduleTypeName, functionalLocationNames, functionalLocationNamesWithDescription, responseRequired,
                lastModifiedUserId, categoryName, workAssignmentName, workAssignmentId, visibilityGroupNames,visGroupsStartingWith,createdbyactionitemdefinition,reading)          //ayman visibility group       ayman action item definition ayman action item reding
        {
            Name = name;
            RequiresApproval = requiresApproval;
            TemporarilyInactive = temporarilyInactive;
            OperationalMode = operationalMode;
            DefinitionId = actionItemDefinitionId;
        }
        public bool RequiresApproval { get; set; }

        public bool TemporarilyInactive { get; set; }

        [IncludeInSearch]
        public string TemporarilyInactiveYesNo
        {
            get
            {
                if (TemporarilyInactive) return StringResources.Yes;
                return string.Empty;
            }
        }
        
        [IncludeInSearch]
        public Date GroupByStartDate
        {
            get { return new Date(StartDate); }
        }

        [IncludeInSearch]
        public string RequiresApprovalYesNo
        {
            get
            {
                if (RequiresApproval) return StringResources.Yes;
                return string.Empty;
            }
        }

        [IncludeInSearch]
        public string OperationalMode { get; set; }

        public long DefinitionId { get; set; }
    }
}