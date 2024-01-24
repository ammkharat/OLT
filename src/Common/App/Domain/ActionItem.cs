using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;


namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ActionItem : DomainObject, IFunctionalLocationRelevant, IDocumentLinksObject, IHasDefinition,
        IVisibilityGroupRelevant
    {
        public ActionItem(string name,
            string description,
            bool responseRequired,
            ActionItemStatus status,
            Priority priority,
            DataSource source,
            DateTime startDateTime,
            DateTime? endDateTime,
            DateTime? shiftAdjustedEndDateTime,
            ScheduleType createdByScheduleType,
            List<FunctionalLocation> functionalLocations,
            BusinessCategory category,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            List<DocumentLink> documentLinks,
            ActionItemStatusModification statusModification,
            ActionItemDefinition createdByActionItemDefinition,
            WorkAssignment assignment,
            long? associatedFormGn75BId, string visGroupsStartingWith,
            long definitionid, List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields,
            CustomFieldGroup customFieldGroup,
            string comment,
            List<ActionItemResponseTracker> trackers,             //ayman visibility groups             ayman action item definition       //ayman custom fields DMND0010030          
            bool reading)                                   //ayman action item reading
        {
            Name = name;
            Description = description;
            ResponseRequired = responseRequired;
            Status = status;
            Priority = priority;
            Source = source;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ShiftAdjustedEndDateTime = shiftAdjustedEndDateTime;
            CreatedByScheduleType = createdByScheduleType;
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            Category = category;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            DocumentLinks = documentLinks;
            StatusModification = statusModification;
            CreatedByActionItemDefinition = createdByActionItemDefinition;
            Assignment = assignment;
            AssociatedFormGn75BId = associatedFormGn75BId;
            VisGroupsStartingWith = visGroupsStartingWith;             //ayman visibility groups
            DefinitionID = definitionid;               //ayman action item definition
            CustomFieldGroup = customFieldGroup;         //ayman custom fields DMND0010030          
            Comment = comment;                          //ayman action item email
           
        }

        //mangesh: DMND0005327 - Request 15
        public ActionItem(string name,
            string description,
            bool responseRequired,
            ActionItemStatus status,
            Priority priority,
            DataSource source,
            DateTime startDateTime,       
            DateTime? endDateTime,
            DateTime? shiftAdjustedEndDateTime,
            ScheduleType createdByScheduleType,
            List<FunctionalLocation> functionalLocations,
            BusinessCategory category,
            User lastModifiedBy,
            DateTime lastModifiedDate,
            List<DocumentLink> documentLinks,
            ActionItemStatusModification statusModification,
            ActionItemDefinition createdByActionItemDefinition,
            WorkAssignment assignment,
            long? associatedFormGn75BId,
            long? associatedFormGn75BId1, long? associatedFormGn75BId2,string visGroupsStartingWith, long definitionid, List<CustomFieldEntry> customFieldEntries,
            List<CustomField> customFields,CustomFieldGroup customFieldGroup,string comment,List<ActionItemResponseTracker> trackers,bool reading)    //ayman visibility groups            ayman action item definition     ,List<CustomFieldEntry> customFieldEntries, List<CustomField> customFields
        {
            Name = name;
            Description = description;
            ResponseRequired = responseRequired;
            Status = status;
            Priority = priority;
            Source = source;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            ShiftAdjustedEndDateTime = shiftAdjustedEndDateTime;
            CreatedByScheduleType = createdByScheduleType;
            FunctionalLocations = functionalLocations ?? new List<FunctionalLocation>();
            Category = category;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            DocumentLinks = documentLinks;
            StatusModification = statusModification;
            CreatedByActionItemDefinition = createdByActionItemDefinition;
            Assignment = assignment;
            AssociatedFormGn75BId = associatedFormGn75BId;
            AssociatedFormGn75BId1 = associatedFormGn75BId1;
            AssociatedFormGn75BId2 = associatedFormGn75BId2;
            VisGroupsStartingWith = visGroupsStartingWith;                        //ayman visibility groups 
            DefinitionID = definitionid;
            CustomFieldEntries = customFieldEntries;                 //ayman custom fields DMND0010030          
            CustomFields = customFields;                      //ayman custom fields DMND0010030
            CustomFieldGroup = customFieldGroup;
            Comment = comment;                              //ayman action item email
            Trackers = trackers;
         
        }

        public long? AssociatedFormGn75BId { get; private set; }

        //mangesh: DMND0005327 - Request 15
        public long? AssociatedFormGn75BId1 { get; private set; }
        public long? AssociatedFormGn75BId2 { get; private set; }


        //ayman visibility group
        public string VisGroupsStartingWith { get; set; }

        //ayman action item definition
        public long DefinitionID { get; set; }

        public CustomFieldGroup CustomFieldGroup { get; set; }    //ayman custom fields DMND0010030          

        //ayman action item definition
        public List<CustomFieldEntry> CustomFieldEntries { get; set; }
        public List<CustomField> CustomFields { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }                   //ayman action item email
  
        public List<ActionItemResponseTracker> Trackers { get; set; }         //ayman action item reading

        /// <summary>
        ///     Whether this action item requires a response or not.
        ///     This means this action item instance will not expire.
        /// </summary>
        public bool ResponseRequired { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; private set; }

        public string FunctionalLocationsAsCommaSeparatedFullHierarchyList
        {
            get { return FunctionalLocations.FullHierarchyListToString(true, false); }
        }

        public Priority Priority { get; private set; }

        public ActionItemStatus Status { get; private set; }

        public BusinessCategory Category { get; private set; }

        [CachedRelationship]
        public WorkAssignment Assignment { get; set; }

        public string CategoryName
        {
            get { return Category != null ? Category.Name : null; }
        }

        /// <summary>
        ///     The description of what needs to be done, ie. the instruction of this action item
        /// </summary>
        public string Description { get; set; }

        public ScheduleType CreatedByScheduleType { get; private set; }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public DateTime? ShiftAdjustedEndDateTime { get; private set; }

        /// <summary>
        ///     Where this action item instance was generated (e.g. SAP, manual, etc)
        /// </summary>
        public DataSource Source { get; private set; }

        public ActionItemStatusModification StatusModification { get; private set; }

        [CachedRelationship]
        public ActionItemDefinition CreatedByActionItemDefinition { get; private set; }

        public List<WorkAssignmentVisibilityGroup> WritableWorkAssignmentVisibilityGroups
        {
            get
            {
                return Assignment == null
                    ? new List<WorkAssignmentVisibilityGroup>()
                    : new List<WorkAssignmentVisibilityGroup>(Assignment.WriteWorkAssignmentVisibilityGroups);
            }
        }

        /// <summary>
        ///     List of document links
        /// </summary>
        public List<DocumentLink> DocumentLinks { get; private set; }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFunctionalLocations, SiteConfiguration siteConfiguration)
        {
            foreach (var floc in FunctionalLocations)
            {
                var isRelevent = new ExactMatchRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                                 new WalkDownRelevance(floc).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
                if (isRelevent)
                    return true;
            }
            return false;
        }

        public long DefinitionId
        {
            get { return CreatedByActionItemDefinition.IdValue; }
        }

        //ayman action item reading
        public bool Reading
        {
            get { return CreatedByActionItemDefinition.Reading; }
        }


        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(Assignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public bool Is(ActionItemStatus statusToCheck)
        {
            return Status == statusToCheck;
        }

        public bool IsNot(ActionItemStatus statusToCheck)
        {
            return !Is(statusToCheck);
        }

        public void SetStatus(ActionItemStatus newStatus, User changeUser, DateTime changeDateTime)
        {
            if (newStatus.Equals(Status))
            {
                return;
            }

            StatusModification = new ActionItemStatusModification(Status, changeUser, changeDateTime);
            Status = newStatus;
        }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> Imagelist { get; set; }
        public List<LogImage> Imagelist_Response { get; set; }  // Added by Vibhor DMND0010736  : OLT - Adding Pictures on Action item Response
    }
}