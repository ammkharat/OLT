using System;
using System.Collections.Generic;
using System.Diagnostics;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain
{
    /// <summary>
    ///     Action Item Domain Object
    /// </summary>
    [Serializable]
    public class ActionItemDefinition :
        DomainObject, ICommentable, IFunctionalLocationRelevant, IDocumentLinksObject, IHistoricalDomainObject,
        IVisibilityGroupRelevant
    {
        public static readonly Priority[] Priorities = {Priority.Normal, Priority.Elevated, Priority.High};

        public ActionItemDefinition(string name, BusinessCategory businessCategory,
            ActionItemDefinitionStatus actionItemDefinitionStatus, ISchedule schedule, string description,
            DataSource source, bool requiresApproval, bool active, bool responseRequired, User lastModifiedBy,
            DateTime lastModifiedDate, User createdBy, DateTime createdDateTime,
            List<FunctionalLocation> functionalLocations,
            List<TargetDefinitionDTO> targetDefinitionDtos, List<DocumentLink> documentLinks,
            OperationalMode operationalMode, WorkAssignment assignment, bool createAnActionItemForEachFunctionalLocation,
            long? associatedFormGn75BId, string visGroupsStartingWith , CustomFieldGroup customFieldGroup,bool sendEmail,bool autopopulate,bool reading, List<string> sendEmailTo)          //ayman visibility groups      //ayman custom fields DMND0010030
        {
            Priority = Priority.Normal;
            Comments = new List<Comment>();
            Name = name;
            Category = businessCategory;
            Description = description;
            Status = actionItemDefinitionStatus;
            Schedule = schedule;
            Source = source;
            Active = active;
            ResponseRequired = responseRequired;
            RequiresApproval = requiresApproval;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            FunctionalLocations = functionalLocations;
            TargetDefinitionDTOs = targetDefinitionDtos;
            DocumentLinks = documentLinks;
            OperationalMode = operationalMode;
            Assignment = assignment;
            CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;
            AssociatedFormGN75BId = associatedFormGn75BId;

            //ayman visibility groups
            VisGroupsStartingWith = visGroupsStartingWith;
            Customfieldgroup = customFieldGroup;          //ayman custom fields DMND0010030
            SendEmailTo = sendEmailTo;                        //ayman custom fields DMND0010030
            SendEmail = sendEmail;                        //ayman action item email
            AutoPopulate = autopopulate;                  //ayman action item reading
            Debug.Assert
                (
                    (requiresApproval && active == false &&
                     actionItemDefinitionStatus != ActionItemDefinitionStatus.Approved) ||
                    (!requiresApproval && actionItemDefinitionStatus == ActionItemDefinitionStatus.Approved)
                );
        }

        //mangesh- Request 15 - DMND0005327
        public ActionItemDefinition(string name, BusinessCategory businessCategory,
            ActionItemDefinitionStatus actionItemDefinitionStatus, ISchedule schedule, string description,
            DataSource source, bool requiresApproval, bool active, bool copyresponseToLog, bool responseRequired, User lastModifiedBy,
            DateTime lastModifiedDate, User createdBy, DateTime createdDateTime,
            List<FunctionalLocation> functionalLocations,
            List<TargetDefinitionDTO> targetDefinitionDtos, List<DocumentLink> documentLinks,
            OperationalMode operationalMode, WorkAssignment assignment, bool createAnActionItemForEachFunctionalLocation,

            long? associatedFormGn75BId, long? associatedFormGn75BId1, long? associatedFormGn75BId2, string visGroupsStartingWith, CustomFieldGroup customFieldGroup,
            bool sendEmail,bool autopopulate,bool reading, List<string> sendEmailTo, bool everyShift)              //ayman visibility groups   
        {            
            Priority = Priority.Normal;
            Comments = new List<Comment>();
            Name = name;
            Category = businessCategory;
            Description = description;
            Status = actionItemDefinitionStatus;
            Schedule = schedule;
            Source = source;
            Active = active;
            CopyResponseToLog = copyresponseToLog; //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
            ResponseRequired = responseRequired;
            RequiresApproval = requiresApproval;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            FunctionalLocations = functionalLocations;
            TargetDefinitionDTOs = targetDefinitionDtos;
            DocumentLinks = documentLinks;
            OperationalMode = operationalMode;
            Assignment = assignment;
            CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;
            AssociatedFormGN75BId = associatedFormGn75BId;
            
            AssociatedFormGN75BId1 = associatedFormGn75BId1;
            AssociatedFormGN75BId2 = associatedFormGn75BId2;

            //ayman visibility groups
            VisGroupsStartingWith = visGroupsStartingWith;
            Customfieldgroup = customFieldGroup;                      //ayman custom fields DMND0010030
            SendEmailTo = sendEmailTo;                                   //ayman custom fields DMND0010030
            SendEmail = sendEmail;                                    //ayman action item email
            AutoPopulate = autopopulate;
            Reading = reading;
            //RITM0265710 mangesh
            EveryShift = everyShift;    //commented by Ayman ro resolve code overlap 

            Debug.Assert
                (
                    (requiresApproval && active == false &&
                     actionItemDefinitionStatus != ActionItemDefinitionStatus.Approved) ||
                    (!requiresApproval && actionItemDefinitionStatus == ActionItemDefinitionStatus.Approved)
                );
        }

        //Added  by ppanigrahi for adding workpermit Id

        public ActionItemDefinition(string name, BusinessCategory businessCategory,
           ActionItemDefinitionStatus actionItemDefinitionStatus, ISchedule schedule, string description,
           DataSource source, bool requiresApproval, bool active,bool copyresponseToLog, bool responseRequired, User lastModifiedBy,
           DateTime lastModifiedDate, User createdBy, DateTime createdDateTime,
           List<FunctionalLocation> functionalLocations,
           List<TargetDefinitionDTO> targetDefinitionDtos, List<DocumentLink> documentLinks,
           OperationalMode operationalMode, WorkAssignment assignment, bool createAnActionItemForEachFunctionalLocation,
           long? associatedFormGn75BId, string visGroupsStartingWith, CustomFieldGroup customFieldGroup, bool sendEmail, bool autopopulate, bool reading, List<string> sendEmailTo,long? workPermitID)          //ayman visibility groups      //ayman custom fields DMND0010030
        {
            Priority = Priority.Normal;
            Comments = new List<Comment>();
            Name = name;
            Category = businessCategory;
            Description = description;
            Status = actionItemDefinitionStatus;
            Schedule = schedule;
            Source = source;
            Active = active;
            CopyResponseToLog = copyresponseToLog;
            ResponseRequired = responseRequired;
            RequiresApproval = requiresApproval;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            CreatedBy = createdBy;
            CreatedDateTime = createdDateTime;
            FunctionalLocations = functionalLocations;
            TargetDefinitionDTOs = targetDefinitionDtos;
            DocumentLinks = documentLinks;
            OperationalMode = operationalMode;
            Assignment = assignment;
            CreateAnActionItemForEachFunctionalLocation = createAnActionItemForEachFunctionalLocation;
            AssociatedFormGN75BId = associatedFormGn75BId;

            //ayman visibility groups
            VisGroupsStartingWith = visGroupsStartingWith;
            Customfieldgroup = customFieldGroup;          //ayman custom fields DMND0010030
            SendEmailTo = sendEmailTo;                        //ayman custom fields DMND0010030
            SendEmail = sendEmail;                        //ayman action item email
            AutoPopulate = autopopulate;                  //ayman action item reading
            this.workpermitId = workPermitID;
            Debug.Assert
                (
                    (requiresApproval && active == false &&
                     actionItemDefinitionStatus != ActionItemDefinitionStatus.Approved) ||
                    (!requiresApproval && actionItemDefinitionStatus == ActionItemDefinitionStatus.Approved)
                );

            
        }

        //RITM0265710 mangesh
         public bool EveryShift { get; set; }  //commented by Ayman ro resolve code overlap 

        //mangesh - DMND0005327 - Request 15
        public long? AssociatedFormGN75BId1 { get; set; }
        public long? AssociatedFormGN75BId2 { get; set; }

        //ayman visibility groups
        public string VisGroupsStartingWith { get; set; }

        public long? AssociatedFormGN75BId { get; set; }

        public OperationalMode OperationalMode { get; set; }

        public CustomFieldGroup Customfieldgroup { get; set; }               //ayman custom fields DMND0010030

        public List<string> SendEmailTo { get; set; }                                  //ayman custom fields DMND0010030

        public bool AutoPopulate { get; set; }                                         //ayman action item reading

        public bool Reading { get; set; }                                         //ayman action item reading

        public bool SendEmail { get; set; }                                  //ayman custom fields DMND0010030

        public List<CustomFieldEntry> CustomFieldEntries { get; private set; }       //ayman custom fields DMND0010030

        public List<CustomField> CustomFields { get; private set; }                  //ayman custom fields DMND0010030

        public DateTime LogDateTime
        {
            get { return LastModifiedDate; }
        }

        public List<Comment> Comments { get; set; }

        public string Name { get; set; }

        public DataSource Source { get; set; }

        public long? SapOperationId { get; set; }

        public bool RequiresApproval { get; set; }

        public bool Active { get; set; }

        public bool CopyResponseToLog { get; set; } //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades

        public bool ResponseRequired { get; set; }

        public ISchedule Schedule { get; set; }

        public ActionItemDefinitionStatus Status { get; set; }

        public string Description { get; set; }

        public List<FunctionalLocation> FunctionalLocations { get; set; }

        public BusinessCategory Category { get; set; }

        [CachedRelationship]
        public WorkAssignment Assignment { get; set; }

        public Priority Priority { get; set; }

        public bool Deleted { get; set; }

        public User CreatedBy { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public List<TargetDefinitionDTO> TargetDefinitionDTOs { get; set; }

        public bool CreateAnActionItemForEachFunctionalLocation { get; set; }

        public String ApprovedText
        {
            get { return Status.IsApproved.BooleanToYesNoString(); }
        }

        public bool IsApproved
        {
            get { return Status.IsApproved; }
        }

        public List<WorkAssignmentVisibilityGroup> WritableWorkAssignmentVisibilityGroups
        {
            get
            {
                if (Assignment == null)
                {
                    return new List<WorkAssignmentVisibilityGroup>();
                }
                return new List<WorkAssignmentVisibilityGroup>(Assignment.WriteWorkAssignmentVisibilityGroups);
            }
        }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public List<DocumentLink> DocumentLinks { get; set; }


        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionsFullHierarchies, SiteConfiguration siteConfiguration)
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

        public bool IsRelevantTo(List<long> clientReadableVisibilityGroupIds)
        {
            return new StandardVisibilityGroupRelevance(Assignment).IsRelevantTo(clientReadableVisibilityGroupIds);
        }

        public ActionItemDefinitionHistory TakeSnapshot()
        {
            return new ActionItemDefinitionHistory(IdValue,
                Name,
                Category,
                Status,
                Schedule.ToString(),
                Description,
                CopyResponseToLog,  //Added By Vibhor : DMND0011091 OLT - Sarnia  Site upgrades
                Source,
                RequiresApproval,
                Active,
                ResponseRequired,
                LastModifiedBy,
                LastModifiedDate,
                FunctionalLocations.FullHierarchyListToString(false, false),
                TargetDefinitionDTOs.AsString(tdDto => tdDto.Name),
                DocumentLinks.AsString(link => link.TitleWithUrl),
                OperationalMode,
                Priority,
                Assignment != null ? Assignment.Name : null,
                CreateAnActionItemForEachFunctionalLocation,
                AssociatedFormGN75BId,
                AssociatedFormGN75BId1,// mangesh - DMND0005327 - Request 15
                AssociatedFormGN75BId2);
        }

        public bool Is(ActionItemDefinitionStatus statusToCompare)
        {
            return Status == statusToCompare;
        }

        public bool IsNot(ActionItemDefinitionStatus statusToCompare)
        {
            return !Is(statusToCompare);
        }

        public void UpdateStatusAfterChanges(bool authorizedToReApprove,
            ActionItemDefinitionAutoReApprovalConfiguration autoReApprovalConfig,
            ActionItemDefinition beforeChanges)
        {
            if (ShouldWaitForApproval(authorizedToReApprove, autoReApprovalConfig, beforeChanges))
            {
                WaitForApproval();
            }
            else
            {
                Approve(Active);
            }
        }

        private bool ShouldWaitForApproval(bool authorizedToReApprove,
            ActionItemDefinitionAutoReApprovalConfiguration autoReApprovalConfig,
            ActionItemDefinition beforeChanges)
        {
            if (RequiresApproval)
            {
                return true;
            }

            if (authorizedToReApprove == false &&
                autoReApprovalConfig.RequireReApproval(beforeChanges, this))
            {
                return true;
            }

            return false;
        }

        private void Approve(bool isActive)
        {
            Status = ActionItemDefinitionStatus.Approved;
            Active = isActive;
            RequiresApproval = false;
        }

        public void Approve(User approver, DateTime approvedDateTime)
        {
            Approve(true);
            LastModifiedBy = approver;
            LastModifiedDate = approvedDateTime;
        }

        public void Reject(User rejector, DateTime rejectedDateTime)
        {
            Status = ActionItemDefinitionStatus.Rejected;
            Active = false;
            RequiresApproval = true;
            LastModifiedBy = rejector;
            LastModifiedDate = rejectedDateTime;
        }

        public void WaitForApproval()
        {
            Status = ActionItemDefinitionStatus.Pending;
            Active = false;
            RequiresApproval = true;
        }

        public List<ActionItemDefinition> BuildActionItemDefinitionForEachFunctionalLocation()
        {
            var list = new List<ActionItemDefinition>();

            foreach (var floc in FunctionalLocations)
            {
                var flocList = new List<FunctionalLocation> {floc};
                var flattenedActionItemDefintion = (ActionItemDefinition) Clone();
                flattenedActionItemDefintion.FunctionalLocations = flocList;
                list.Add(flattenedActionItemDefintion);
            }

            return list;
        }

        //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public List<ImageUploader> Imagelist { get; set; }   

        //Adding by ppanigrahi
        public long? workpermitId;

// Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions

        public bool Isclone { get; set; }

    }
}