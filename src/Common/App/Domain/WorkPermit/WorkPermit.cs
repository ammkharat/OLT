using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public interface IWorkPermit
    {
    }

    [Serializable]
    public class WorkPermit : DomainObject, IFunctionalLocationRelevant, IDocumentLinksObject,
        IHistoricalDomainObject, IWorkPermit
    {
        private const string formatString = "{0}: {1}";

        public static readonly WorkPermitStatus[] EditableStatuses =
        {
            WorkPermitStatus.Pending,
            WorkPermitStatus.Rejected
        };

        private User approvedBy;
        private string coauthorizationDescription;
        private User createdBy;
        private List<DocumentLink> documentLinks = new List<DocumentLink>();

        private string permitNumber;

        private string specialPrecautionsOrConsiderations;
        private WorkPermitSpecifics specifics;
        private Version version;
        private WorkPermitStatus workPermitStatus;
        private WorkPermitType workPermitType;

        public WorkPermit(Site site)
        {
            Version = Constants.CURRENT_VERSION;
            Attributes = new WorkPermitAttributes();
            AdditionItemsRequired = new WorkPermitAdditionalItemsRequired();
            specifics = new WorkPermitSpecifics(SiteSpecificHandlerFactory.GetDateTimeHandler(site));
            Tools = new WorkPermitTools();
            EquipmentPreparationCondition =
                new WorkPermitEquipmentPreparationCondition(SiteSpecificHandlerFactory.GetDateTimeHandler(site));
            JobWorksitePreparation = new WorkPermitJobWorksitePreparation();
            RadiationInformation = new WorkPermitRadiationInformation();
            Asbestos = new WorkPermitAsbestos();
            GasTests = new WorkPermitGasTests();
            FireConfinedSpaceRequirements = new WorkPermitFireConfinedSpaceRequirements();
            RespiratoryProtectionRequirements = new WorkPermitRespiratoryProtectionRequirements();
            SpecialProtectionRequirements = new WorkPermitSpecialPPERequirements();
            Source = DataSource.MANUAL;
            ExtensionEnable = false;
            RevalidationEnable = false;
            //ExtensionTimeIssuer= new Time(0);
            // ExtensionTimeNonIssuer = new Time(0);
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public WorkPermit(string templatename, string categories)
        {
            _templateName = templatename;
            _categories = categories;
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit] // mangesh uspipeline to selc
        public string SpecialPrecautionsOrConsiderations
        {
            get { return specialPrecautionsOrConsiderations; }
            set { specialPrecautionsOrConsiderations = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public bool? IsCoauthorizationRequired { get; set; }

        [SarniaWorkPermit]
        public bool? IsControlRoomContacted { get; set; }       // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia

          // Added by Vibhor : DMND0011077 - Work Permit Clone History
        public string ClonedFormDetailSarnia { get; set; }
          
        public string ClonedFormDetailDenver { get; set; }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActiveTemplate { get; set; }

        public string TemplateCreatedBy { get; set; }
        public string Categories { get; set; }
        public bool Global { get; set; }
        public bool Individual { get; set; }

        public string _templateName { get; set; }
        public string _categories { get; set; }


public long TemplateId { get; set; }




        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string CoauthorizationDescription
        {
            get { return coauthorizationDescription; }
            set { coauthorizationDescription = value.EmptyToNull(); }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public WorkPermitType WorkPermitType
        {
            get { return workPermitType; }
            set { workPermitType = value; }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public string PermitNumber
        {
            get { return permitNumber; }
            set { permitNumber = value; }
        }

        [DenverWorkPermit(Constants.VERSION_4_9_STRING, null)]
        [USPipelineWorkPermit(Constants.VERSION_4_9_STRING, null)]                       //ayman USPipeline workpermit
        [SELCWorkPermit(Constants.VERSION_4_9_STRING, null)]                            // mangesh uspipeline to selc
        public WorkPermitTypeClassification WorkPermitTypeClassification { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitSpecifics Specifics
        {
            get { return specifics; }
            set { specifics = value; }
        }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitAttributes Attributes { get; set; }

        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitTools Tools { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitEquipmentPreparationCondition EquipmentPreparationCondition { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitJobWorksitePreparation JobWorksitePreparation { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitRadiationInformation RadiationInformation { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitAsbestos Asbestos { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitFireConfinedSpaceRequirements FireConfinedSpaceRequirements { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitRespiratoryProtectionRequirements RespiratoryProtectionRequirements { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitAdditionalItemsRequired AdditionItemsRequired { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitGasTests GasTests { get; set; }

        [SarniaWorkPermit(WorkPermitAttribute.Classification.Group)]
        [DenverWorkPermit(WorkPermitAttribute.Classification.Group)]
        [USPipelineWorkPermit(WorkPermitAttribute.Classification.Group)]
        [SELCWorkPermit(WorkPermitAttribute.Classification.Group)]
        public WorkPermitSpecialPPERequirements SpecialProtectionRequirements { get; set; }

        // There is no WorkPermitAttribute here as it is marked up in WorkPermitSpecifics
        public WorkPermitCommunication CommunicationMethod
        {
            get { return specifics.Communication; }
            set { specifics.Communication = value; }
        }

        public string CraftOrTradeName
        {
            get { return Specifics.CraftOrTradeName; }
            set { Specifics.CraftOrTradeName = value; }
        }

        public string WorkOrderNumber
        {
            get { return Specifics.WorkOrderNumber; }
            set { Specifics.WorkOrderNumber = value; }
        }

        public DateTime StartDateTime
        {
            get { return Specifics.StartDateTime; }
        }

        public Date StartDate
        {
            get { return Specifics.StartDate; }
        }

        public DateTime? EndDateTime
        {
            get { return Specifics.EndDateTime; }
        }

        public DataSource Source { get; set; }

        public bool StartAndOrEndTimesFinalized
        {
            get { return Specifics.StartAndOrEndTimesFinalized; }
            set { Specifics.StartAndOrEndTimesFinalized = value; }
        }

        public DateTime? PermitValidDateTime { get; set; }

        public WorkPermitStatus WorkPermitStatus
        {
            get { return workPermitStatus; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return Specifics.FunctionalLocation; }
            set { Specifics.FunctionalLocation = value; }
        }

        public WorkAssignment WorkAssignment
        {
            get { return Specifics.WorkAssignment; }
        }

        public string FunctionalLocationName
        {
            get { return Specifics.FunctionalLocationName; }
            set { Specifics.FunctionalLocationName = value; }
        }

        public string WorkOrderDescription
        {
            get { return Specifics.WorkOrderDescription; }
            set { Specifics.WorkOrderDescription = value; }
        }

        public long? SapOperationId { get; set; }

        public Version Version
        {
            get { return version; }
            set { version = value; }
        }

        public User CreatedBy
        {
            get { return createdBy; }
        }

        /// <summary>
        ///     Tests whether this is an operations permit (versus a non-operations permit).
        /// </summary>
        public bool IsOperations { get; private set; }

        public User LastModifiedBy { get; set; }

        public bool Deleted { get; set; }

        public User ApprovedBy
        {
            get { return approvedBy; }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]              //ayman USPipeline workpermit // mangesh uspipeline to selc
        public DateTime LastModifiedDate { get; set; }

        public bool IsAtLeastApproved
        {
            get
            {
                return Is(WorkPermitStatus.Approved)
                       || Is(WorkPermitStatus.Issued)
                       || Is(WorkPermitStatus.Complete)
                       || Is(WorkPermitStatus.Archived);
            }
        }

        [SarniaWorkPermit, DenverWorkPermit, USPipelineWorkPermit, SELCWorkPermit]
        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinks; }
            set { documentLinks = value; }
        }

        public bool IsRelevantTo(long siteIdOfClient,  List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public bool StartsInUserShift(UserShift userShift)
        {
            return (Specifics.StartDateTime >= userShift.StartDateTimeWithPadding)
                   && (Specifics.StartDateTime <= userShift.EndDateTimeWithPadding);
        }

        public bool IsEffectiveInUserShift(UserShift userShift)
        {
            return StartsInUserShift(userShift) || ShiftIsWithinWorkPermitTimeSpan(userShift);
        }

        private bool ShiftIsWithinWorkPermitTimeSpan(UserShift userShift)
        {
            return (StartDateTime <= userShift.StartDateTime && EndDateTime >= userShift.EndDateTime);
        }

        public void ChangeToIssuedPermit(User issuer, DateTime lastModifiedDateTime)
        {
            workPermitStatus = WorkPermitStatus.Issued;
            LastModifiedBy = issuer;
            LastModifiedDate = lastModifiedDateTime;
        }

        public void SetWorkPermitStatusAndApprover(WorkPermitStatus newStatus, User approver)
        {
            workPermitStatus = newStatus;

            approvedBy = Is(WorkPermitStatus.Rejected) || Is(WorkPermitStatus.Pending) ? null : approver;
        }

        public void SetWorkPermitStatus(WorkPermitStatus newStatus)
        {
            SetWorkPermitStatusAndApprover(newStatus, approvedBy);
        }

        public bool Is(WorkPermitStatus status)
        {
            return WorkPermitStatus == status;
        }

        public bool IsNot(WorkPermitStatus status)
        {
            return Is(status) == false;
        }

        public bool HasEditableStatus()
        {
            return Array.Exists(EditableStatuses,
                Is);
        }

        public void SetCreatedBy(User user, bool isOperations)
        {
            // NOTE: Set created by position AFTER created by user because setting the user sets
            //       the corresponding position, which might have changed.
            createdBy = user;
            IsOperations = isOperations;
        }

        /// <summary>
        ///     Tests whether this is a non-operations permit. Just convenience for <see cref="IsOperations" />
        /// </summary>
        public bool IsNonOperations()
        {
            return IsOperations == false;
        }

        /// <summary>
        ///     Tests if the 'special precautions or considerations' section of the work permit has data (has been "filled out").
        /// </summary>
        public bool SpecialPrecautionsOrConsiderationsHasData()
        {
            return SpecialPrecautionsOrConsiderations.HasValue();
        }

        /// <summary>
        ///     Copies notification and authorization fields to another permit.
        /// </summary>
        public void CopyNotificationAuthorizationTo(WorkPermit another)
        {
            another.IsCoauthorizationRequired = IsCoauthorizationRequired;
            another.CoauthorizationDescription = CoauthorizationDescription;
            another.IsControlRoomContacted = IsControlRoomContacted; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
        }

        /// <summary>
        ///     Tests if the 'notification and authorization' section of the work permit has data (has been "filled out").
        /// </summary>
        public bool NotificationAuthorizationHasData()
        {
            return CoauthorizationDescription.HasValue();
        }

        /// <summary>
        ///     Tests if any of the sections of this work permit has data (has been "filled out").
        /// </summary>
        public bool HasData()
        {
            return Tools.HasData()
                   || EquipmentPreparationCondition.HasData()
                   || JobWorksitePreparation.HasData()
                   || RadiationInformation.HasData()
                   || Asbestos.HasData()
                   || FireConfinedSpaceRequirements.HasData()
                   || RespiratoryProtectionRequirements.HasData()
                   || SpecialProtectionRequirements.HasData()
                   || SpecialPrecautionsOrConsiderationsHasData()
                   || GasTests.HasData()
                   || NotificationAuthorizationHasData();
        }

        /// <summary>
        ///     Initialize this work permit with 'safe' defaults.
        /// </summary>
        public void InitializeWithSensibleDefaults(
            ICraftOrTrade defaultCraftOrTrade,
            User createdUser,
            bool isOperations,
            DateTime currentTimeAtSite,
            SiteConfiguration siteConfiguration,
            UserShift currentShift,
            ISiteSpecificDateTimeHandler handler)
        {
            SetCreatedBy(createdUser, isOperations);
            LastModifiedDate = currentTimeAtSite;
            SetOptionDefaults(siteConfiguration);
            Tools.InitializeWithSensibleDefaults();
            EquipmentPreparationCondition = new WorkPermitEquipmentPreparationCondition(siteConfiguration, handler);
            JobWorksitePreparation.InitializeWithSensibleDefaults(siteConfiguration);
            RadiationInformation.InitializeWithSensibleDefaults(siteConfiguration);
            FireConfinedSpaceRequirements.InitializeWithSensibleDefaults(siteConfiguration);
            Specifics = new WorkPermitSpecifics(defaultCraftOrTrade, createdUser.WorkPermitDefaultTimePreferences,
                siteConfiguration, currentShift, handler, currentTimeAtSite);
            GasTests.InitializeWithSensibleDefaults();
            RespiratoryProtectionRequirements.InitializeWithSensibleDefaults(siteConfiguration);
            SpecialProtectionRequirements.InitializeWithSensibleDefaults(siteConfiguration);
            Asbestos.InitializeWithSensibleDefaults(siteConfiguration);
        }

        private void SetOptionDefaults(SiteConfiguration siteConfiguration)
        {
            if (siteConfiguration.WorkPermitOptionAutoSelected)
            {
                WorkPermitType = WorkPermitType.COLD;
                WorkPermitTypeClassification = WorkPermitTypeClassification.SPECIFIC;
                IsCoauthorizationRequired = false;
                IsControlRoomContacted = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }
            else
            {
                WorkPermitType = null;
                WorkPermitTypeClassification = null;
                IsCoauthorizationRequired = null;
                IsControlRoomContacted = true; // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia
            }
        }

        public override string ToString()
        {
            return this.ReflectionToString();
        }

        public string Description()
        {
            using (var writer = new StringWriter())
            {
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_PermitNumberLabel, permitNumber);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_PermitTypeLabel,
                    workPermitType.Name);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_WorkOrderNumberLabel,
                    specifics.WorkOrderNumber);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_FunctionalLocationLabel,
                    specifics.FunctionalLocationName);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_CraftTradeLabel,
                    specifics.CraftOrTradeName);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_WorkOrderDescriptionLabel,
                    specifics.WorkOrderDescription);
                writer.WriteLine(formatString, StringResources.WorkPermitDescription_JobStepDescriptionLabel,
                    specifics.JobStepDescription);

                return writer.ToString();
            }
        }

        public List<DocumentLink> CloneDocumentLinksWithoutIds()
        {
            var documentLinksWithoutIds = new List<DocumentLink>();

            foreach (var documentLink in documentLinks)
            {
                documentLinksWithoutIds.Add(documentLink.CloneWithoutId());
            }
            return documentLinksWithoutIds;
        }

        public static bool IsOldVersionForDenver(Version version)
        {
            return (version <= Constants.VERSION_4_9);
        }

        //ayman USPipeline workpermit
        public static bool IsOldVersionForUSPipeline(Version version)
        {
            return (version <= Constants.VERSION_4_9);
        }
        //Added by ppanigrahi
        public DateTime? RevalidationDateTime { get; set; }

        public DateTime? ExtensionDateTime { get; set; }

        public bool ExtensionEnable { get; set; }
        public bool RevalidationEnable { get; set; }

        public DateTime? ExtensionRevalidationDateTime { get; set; }

        public int? Revalidation { get; set; }

        public int? Extension { get; set; }

        public User IssuedByUser { get; set; }

        public DateTime? ExtensionTimeIssuer { get; set; }

        public DateTime? BeforeExtensionDateTime { get; set; }

        public DateTime? ExtensionTimeNonIssuer { get; set; }

        public DateTime? MidExtensionvalueIssuer { get; set; }

        public DateTime? MidExtensionvaluenonIssuer { get; set; }

        public string ISSUER_SOURCEXTENSION { get; set; }

      

        public string ExtensionReasonPartJ { get; set; }
        public User ExtendedByUser { get; set; }
    }
}