using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetDefinition :
        DomainObject, ICommentable, IDocumentLinksObject, IFunctionalLocationRelevant, IHistoricalDomainObject
    {
        public static readonly Priority[] Priorities = {Priority.Normal, Priority.Elevated, Priority.High};
        private List<DocumentLink> documentLinks = new List<DocumentLink>();

        public TargetDefinition(string name, string description, TargetCategory category,
            TargetDefinitionStatus status, TagInfo tagInfo, ISchedule schedule,
            decimal? neverToExceedMinimum, decimal? neverToExceedMaximum,
            decimal? preApprovedNeverToExceedMinimum, decimal? preApprovedNeverToExceedMaximum,
            int? neverToExceedMinimumFrequency, int? neverToExceedMaximumFrequency, decimal? maxValue,
            decimal? minValue, decimal? preApprovedMinValue, decimal? preApprovedMaxValue,
            int? maxValueFrequency, int? minValueFrequency,
            TargetValue targetValue, decimal? gapUnitValue, FunctionalLocation functionalLocation,
            bool generateActionItem, bool isAlertRequired, bool requiresApproval,
            bool requiresResponseWhenAlerted,
            List<TargetDefinitionDTO> associatedTargetDtOs, User lastModifiedBy,
            DateTime lastModifiedDate, bool isActive, OperationalMode operationalMode,
            TargetDefinitionReadWriteTagConfiguration readWriteTagsConfiguration, WorkAssignment assignment)
            : this(
                name,
                description,
                category,
                status,
                tagInfo,
                schedule,
                neverToExceedMinimum,
                neverToExceedMaximum,
                preApprovedNeverToExceedMinimum,
                preApprovedNeverToExceedMaximum,
                neverToExceedMinimumFrequency,
                neverToExceedMaximumFrequency,
                maxValue,
                minValue,
                preApprovedMinValue,
                preApprovedMaxValue,
                maxValueFrequency,
                minValueFrequency,
                targetValue,
                gapUnitValue,
                functionalLocation,
                generateActionItem,
                isAlertRequired,
                requiresApproval,
                requiresResponseWhenAlerted,
                associatedTargetDtOs,
                lastModifiedBy,
                lastModifiedDate,
                isActive,
                operationalMode,
                readWriteTagsConfiguration,
                new List<DocumentLink>(),
                assignment)
        {
        }

        public TargetDefinition(string name, string description, TargetCategory category,
            TargetDefinitionStatus status, TagInfo tagInfo, ISchedule schedule,
            decimal? neverToExceedMinimum, decimal? neverToExceedMaximum,
            decimal? preApprovedNeverToExceedMinimum, decimal? preApprovedNeverToExceedMaximum,
            int? neverToExceedMinimumFrequency, int? neverToExceedMaximumFrequency,
            decimal? maxValue, decimal? minValue, decimal? preApprovedMinValue, decimal? preApprovedMaxValue,
            int? maxValueFrequency, int? minValueFrequency,
            TargetValue targetValue, decimal? gapUnitValue, FunctionalLocation functionalLocation,
            bool generateActionItem, bool isAlertRequired, bool requiresApproval,
            bool requiresResponseWhenAlerted,
            List<TargetDefinitionDTO> associatedTargetDtOs, User lastModifiedBy,
            DateTime lastModifiedDate, bool isActive, OperationalMode operationalMode,
            TargetDefinitionReadWriteTagConfiguration readWriteTagsConfiguration, List<DocumentLink> documentLinks,
            WorkAssignment assignment)
        {
            Comments = new List<Comment>();
            Priority = Priority.Normal;
            Name = name;
            Description = description;
            Category = category;
            Status = status;
            TagInfo = tagInfo;
            Schedule = schedule;
            NeverToExceedMinimum = neverToExceedMinimum;
            NeverToExceedMaximum = neverToExceedMaximum;
            PreApprovedNeverToExceedMinimum = preApprovedNeverToExceedMinimum;
            PreApprovedNeverToExceedMaximum = preApprovedNeverToExceedMaximum;
            NeverToExceedMaxFrequency = neverToExceedMaximumFrequency;
            NeverToExceedMinFrequency = neverToExceedMinimumFrequency;
            MaxValue = maxValue;
            MinValue = minValue;
            PreApprovedMinValue = preApprovedMinValue;
            PreApprovedMaxValue = preApprovedMaxValue;
            MaxValueFrequency = maxValueFrequency;
            MinValueFrequency = minValueFrequency;
            TargetValue = targetValue;
            GapUnitValue = gapUnitValue;
            FunctionalLocation = functionalLocation;
            GenerateActionItem = generateActionItem;
            IsAlertRequired = isAlertRequired;
            RequiresApproval = requiresApproval;
            RequiresResponseWhenAlerted = requiresResponseWhenAlerted;
            AssociatedTargetDTOs = associatedTargetDtOs;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
            IsActive = isActive;
            OperationalMode = operationalMode;
            ReadWriteTagsConfiguration = readWriteTagsConfiguration;
            this.documentLinks = documentLinks;
            Assignment = assignment;
        }

        public OperationalMode OperationalMode { get; set; }

        public bool RequiresApproval { get; set; }

        public List<Comment> Comments { get; set; }

        public string Name { get; set; }

        public ISchedule Schedule { get; set; }

        /// <summary>
        ///     Whether an alert is required if this target is in gap.
        ///     The Target should still be evaulated, but there is no need to generate an Alert?
        /// </summary>
        public bool IsAlertRequired { get; set; }

        public int SamplesRequired
        {
            get { return GetThresholds().SamplesRequiredToEvaluate; }
        }

        /// <summary>
        ///     Never to Exceed Minimum Value
        /// </summary>
        public decimal? NeverToExceedMinimum { get; set; }

        /// <summary>
        ///     Never to Exceed Maximum Value
        /// </summary>
        public decimal? NeverToExceedMaximum { get; set; }

        /// <summary>
        ///     Maximum Value to check for
        /// </summary>
        public decimal? MaxValue { get; set; }

        /// <summary>
        ///     Minimum Value
        /// </summary>
        public decimal? MinValue { get; set; }

        /// <summary>
        ///     Pre-approved range for never-to-exceed minimum values
        /// </summary>
        public decimal? PreApprovedNeverToExceedMinimum { get; set; }

        /// <summary>
        ///     Pre-approved range for never-to-exceed maximum values
        /// </summary>
        public decimal? PreApprovedNeverToExceedMaximum { get; set; }

        /// <summary>
        ///     Pre-approved range for maximum values
        /// </summary>
        public decimal? PreApprovedMaxValue { get; set; }

        /// <summary>
        ///     Pre-approved range for minimum values
        /// </summary>
        public decimal? PreApprovedMinValue { get; set; }

        public TargetValue TargetValue { get; set; }

        /// <summary>
        ///     Frequency to hit maximum value before alert
        /// </summary>
        public int? MaxValueFrequency { get; set; }

        /// <summary>
        ///     Frequency to check the Minimum value
        /// </summary>
        public int? MinValueFrequency { get; set; }

        /// <summary>
        ///     Never to exceed Minimum value Frequency
        /// </summary>
        public int? NeverToExceedMinFrequency { get; set; }

        /// <summary>
        ///     Never To Exceed Maximum Frequency
        /// </summary>
        public int? NeverToExceedMaxFrequency { get; set; }

        /// <summary>
        ///     Value for Gap Unit
        /// </summary>
        public decimal? GapUnitValue { get; set; }

        public string Description { get; set; }

        public bool GenerateActionItem { get; set; }

        /// <summary>
        ///     Whether the Target is IsActive (Generate Action)
        /// </summary>
        public bool IsActive { get; set; }

        public TargetDefinitionStatus Status { get; set; }

        public Priority Priority { get; set; }

        public TargetCategory Category { get; set; }

        [CachedRelationship]
        public TagInfo TagInfo { get; set; }

        [CachedRelationship]
        public WorkAssignment Assignment { get; set; }

        public string AssignmentName
        {
            get { return Assignment != null ? Assignment.Name : null; }
        }

        public bool RequiresResponseWhenAlerted { get; set; }

        public FunctionalLocation FunctionalLocation { get; set; }

        public List<TargetDefinitionDTO> AssociatedTargetDTOs { get; set; }

        public bool Deleted { get; set; }

        public TargetDefinitionReadWriteTagConfiguration ReadWriteTagsConfiguration { get; set; }

        public bool AutoGenerateActionItemDefinitionRequired
        {
            get { return RequiresApproval == false && GenerateActionItem; }
        }

        /// <summary>
        ///     This centralizes all the business logic of what needs to be checked on a Target Definition to make sure it's in the
        ///     correct state
        ///     to generate an Alert.  This doesn't take into consideration things like the Functional Location Mode being the same
        ///     as the Target Definition's
        /// </summary>
        public bool IsInStateForGeneratingAlerts
        {
            get { return IsActive && !Deleted && IsApproved; }
        }

        private bool IsApproved
        {
            get { return Status.Equals(TargetDefinitionStatus.Approved); }
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinks; }
            set { documentLinks = value; }
        }

        public bool IsRelevantTo(long siteIdOfClient, List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        private RecurringSchedule GetRecurringSchedule()
        {
            return (RecurringSchedule) Schedule;
        }

        /// <summary>
        ///     Returns the times at which we need to read tag values to evaluate this target.
        ///     The times will be ordered chronologically.
        /// </summary>
        public List<DateTime> GetReadTimesToEvaluateTarget(DateTime currentTimeAtSite)
        {
            var samplesRequired = GetThresholds().SamplesRequiredToEvaluate;
            return GetRecurringSchedule().GetReadTimes(currentTimeAtSite, samplesRequired);
        }

        /// <summary>
        ///     Tell this target definition to evaluate the new readings (actual values)
        ///     against the threshold values (<see cref="TargetThresholds" />).
        /// </summary>
        public TargetThresholdEvaluation EvaluateNewReadings(List<decimal?> actualValues)
        {
            var evaluation = GetThresholds().Evaluate(actualValues);
            return evaluation;
        }

        private TargetThresholds GetThresholds()
        {
            return
                new TargetThresholds(
                    MinThreshold.Create(NeverToExceedMinimum, NeverToExceedMinFrequency, PreApprovedNeverToExceedMinimum),
                    MinThreshold.Create(MinValue, MinValueFrequency, PreApprovedMinValue),
                    MaxThreshold.Create(MaxValue, MaxValueFrequency, PreApprovedMaxValue),
                    MaxThreshold.Create(NeverToExceedMaximum, NeverToExceedMaxFrequency, PreApprovedNeverToExceedMaximum));
        }

        public TargetAlert CreateTargetAlert(TargetThresholdEvaluation evaluation, DateTime currentTimeAtSite,
            User createdByUser)
        {
            if (evaluation.AnyLimitExceeded == false)
            {
                throw new ApplicationException("Should not create alert when no thresholds are broken.");
            }

            var targetAlertStatus = evaluation.NeverToExceedLimitExceeded
                ? TargetAlertStatus.NeverToExceedAlert
                : TargetAlertStatus.StandardAlert;
            var targetAlert = new TargetAlert(this,
                FunctionalLocation,
                TagInfo,
                Name,
                Description,
                currentTimeAtSite,
                createdByUser,
                currentTimeAtSite,
                null,
                null,
                NeverToExceedMaximum,
                NeverToExceedMinimum,
                MaxValue,
                MinValue,
                NeverToExceedMaxFrequency,
                NeverToExceedMinFrequency,
                MaxValueFrequency,
                MinValueFrequency,
                TargetValue,
                GapUnitValue,
                evaluation.ActualValueUsed,
                Schedule.Type,
                targetAlertStatus,
                Priority,
                Category,
                true,
                RequiresResponseWhenAlerted,
                targetAlertStatus,
                currentTimeAtSite,
                MaxValue,
                MinValue,
                NeverToExceedMaximum,
                NeverToExceedMinimum,
                evaluation.ActualValueUsed,
                CloneDocumentLinksForDBInsert());
            return targetAlert;
        }

        public bool Is(TargetDefinitionStatus someStatus)
        {
            return Status == someStatus;
        }

        private bool IsNot(TargetDefinitionStatus someStatus)
        {
            return !Is(someStatus);
        }

        public TargetDefinitionHistory TakeSnapshot()
        {
            return new TargetDefinitionHistory(IdValue,
                Name,
                NeverToExceedMinimum,
                NeverToExceedMaximum,
                PreApprovedNeverToExceedMinimum,
                PreApprovedNeverToExceedMaximum,
                NeverToExceedMinFrequency,
                NeverToExceedMaxFrequency,
                MaxValue,
                MinValue,
                PreApprovedMinValue,
                PreApprovedMaxValue,
                MaxValueFrequency,
                MinValueFrequency,
                TargetValue.ToString(),
                GapUnitValue,
                Description,
                Category,
                TagInfo,
                GenerateActionItem,
                IsAlertRequired,
                RequiresResponseWhenAlerted,
                IsActive,
                RequiresApproval,
                FunctionalLocation,
                Status,
                LastModifiedBy,
                LastModifiedDate,
                OperationalMode,
                Priority,
                Schedule.ToString(),
                AssociatedTargetDTOs.AsString(tdDto => tdDto.Name),
                documentLinks.AsString(link => link.TitleWithUrl),
                ReadWriteTagsConfiguration.ToString(),
                AssignmentName);
        }

        public void Approve(User approver, DateTime approvedDateTime)
        {
            if (IsNot(TargetDefinitionStatus.Pending))
            {
                throw new NotSupportedException("Only pending target definitions can be approved.");
            }
            if (IsActive)
            {
                throw new NotSupportedException("Only inactive target definitions can be approved.");
            }
            if (!RequiresApproval)
            {
                throw new NotSupportedException("Only target definitions requiring approval can be approved.");
            }

            Approve(true);

            LastModifiedBy = approver;
            LastModifiedDate = approvedDateTime;
        }

        private void Approve(bool active)
        {
            Status = TargetDefinitionStatus.Approved;
            IsActive = active;
            RequiresApproval = false;
        }

        public void Reject(User rejector, DateTime rejectedDateTime)
        {
            Status = TargetDefinitionStatus.Rejected;
            LastModifiedBy = rejector;
            LastModifiedDate = rejectedDateTime;
        }

        public void HasInvalidTag(User modifiedByUser, DateTime detectedInvalidTagDateTime)
        {
            Status = TargetDefinitionStatus.InvalidTag;
            IsActive = false;
            LastModifiedBy = modifiedByUser;
            LastModifiedDate = detectedInvalidTagDateTime;
        }

        public void HasValidTag(User modifiedByUser, DateTime detectedValidDateTime)
        {
            Status = TargetDefinitionStatus.Pending;
            LastModifiedBy = modifiedByUser;
            LastModifiedDate = detectedValidDateTime;
        }

        public void UpdateStatusAfterChange(bool authorizedToReApprove,
            TargetDefinition targetDefBeforeChanges,
            TargetDefinitionAutoReApprovalConfiguration autoReApprovalConfig)
        {
            if (ShouldWaitForApproval(authorizedToReApprove, targetDefBeforeChanges, autoReApprovalConfig))
            {
                WaitForApproval();
            }
            else
            {
                Approve(IsActive);
            }
        }

        private bool ShouldWaitForApproval(bool authorizedToReApprove, TargetDefinition beforeChanges,
            TargetDefinitionAutoReApprovalConfiguration autoReApprovalConfig)
        {
            if (RequiresApproval)
            {
                return true;
            }

            return authorizedToReApprove == false &&
                   (
                       autoReApprovalConfig.RequrieReApproval(beforeChanges, this) ||
                       GetThresholds().AreWithinPreApprovedLimits() == false
                       );
        }

        public List<DocumentLink> CloneDocumentLinksForDBInsert()
        {
            var documentLinksWithoutIds = new List<DocumentLink>();

            foreach (var documentLink in documentLinks)
            {
                documentLinksWithoutIds.Add(documentLink.CloneWithoutId());
            }
            return documentLinksWithoutIds;
        }

        public void WaitForApproval()
        {
            Status = TargetDefinitionStatus.Pending;
            IsActive = false;
            RequiresApproval = true;
        }

        public bool HasSameIdAs(TargetDefinition otherTarget)
        {
            return otherTarget != null && Id == otherTarget.Id;
        }

        public bool HasOperationalMode(OperationalMode anOperationalMode)
        {
            return Equals(OperationalMode, anOperationalMode);
        }

        public List<TagReadRequest> CreateRequestsForTarget(DateTime currentTimeAtSite)
        {
            var requests = new List<TagReadRequest>();

            var readTimes = GetReadTimesToEvaluateTarget(currentTimeAtSite);
            readTimes.ForEach(readTime => requests.Add(new TagReadRequest(TagInfo.Name, readTime)));

            // need to get all the tags that need to be read once for the TargetDefinition Read/Write tags.
            var readTags = ReadWriteTagsConfiguration.ReadTags;
            readTags.ForEach(readTag => requests.Add(new TagReadRequest(readTag.Name, readTimes.Last())));

            return requests;
        }
    }

    [Serializable]
    public class TagChangedState
    {
        public bool TagHasChanged { get; set; }
        public bool ReadWriteTagConfigurationHasChanged { private get; set; }

        public bool HasChanged
        {
            get { return TagHasChanged || ReadWriteTagConfigurationHasChanged; }
        }
    }
}