using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetAlert : DomainObject, IFunctionalLocationRelevant, IDocumentLinksObject, IHasDefinition
    {
        private readonly List<DocumentLink> documentLinks = new List<DocumentLink>();
        private readonly decimal? originalExceedingValue;
        private DateTime? acknowledgedDateTime;
        private User acknowledgedUser;
        private decimal? actualValue;
        private bool exceedingBoundaries;
        private FunctionalLocation functionalLocation;
        private Priority priority = Priority.Normal;
        private TargetAlertStatus status;
        private TargetValue targetValue = TargetValue.CreateEmptyTarget();

        public TargetAlert(TargetDefinition targetDefinition,
            FunctionalLocation functionalLocation,
            TagInfo tagInfo,
            string targetName,
            string description,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            User acknowledgedUser,
            DateTime? acknowledgedDateTime,
            decimal? neverToExceedMaximum,
            decimal? neverToExceedMinimum,
            decimal? maxValue,
            decimal? minValue,
            int? neverToExceedMaxFrequency,
            int? neverToExceedMinFrequency,
            int? maxValueFrequency,
            int? minValueFrequency,
            TargetValue targetValue,
            decimal? gapUnitValue,
            decimal? actualValue,
            ScheduleType createdByScheduleType,
            TargetAlertStatus targetAlertStatus,
            Priority priority,
            TargetCategory targetCategory,
            bool exceedingBoundaries,
            bool requiresResponse,
            TargetAlertStatus typeOfViolationStatus,
            DateTime lastViolatedDateTime,
            decimal? maxAtEvaluation,
            decimal? minAtEvaluation,
            decimal? nteMaxAtEvaluation,
            decimal? nteMinAtEvaluation,
            decimal? actualValueAtEvaluation,
            List<DocumentLink> documentLinks)
            : this(targetDefinition,
                functionalLocation,
                tagInfo,
                targetName,
                description,
                createdDateTime,
                lastModifiedBy,
                lastModifiedDateTime,
                acknowledgedUser,
                acknowledgedDateTime,
                neverToExceedMaximum,
                neverToExceedMinimum,
                maxValue,
                minValue,
                neverToExceedMaxFrequency,
                neverToExceedMinFrequency,
                maxValueFrequency,
                minValueFrequency,
                targetValue,
                gapUnitValue,
                actualValue,
                actualValue, // If OriginalExceeding Value is not supplied, use Actual Value.
                createdByScheduleType,
                targetAlertStatus,
                priority,
                targetCategory,
                exceedingBoundaries,
                requiresResponse,
                typeOfViolationStatus,
                lastViolatedDateTime,
                maxAtEvaluation,
                minAtEvaluation,
                nteMaxAtEvaluation,
                nteMinAtEvaluation,
                actualValueAtEvaluation,
                documentLinks)
        {
        }

        //
        //  Not not be used other than DAO. Update: Why? What would happen if it were used other than in the dao?
        //
        public TargetAlert(
            TargetDefinition targetDefinition,
            FunctionalLocation functionalLocation,
            TagInfo tagInfo,
            string targetName,
            string description,
            DateTime createdDateTime,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            User acknowledgedUser,
            DateTime? acknowledgedDateTime,
            decimal? neverToExceedMaximum,
            decimal? neverToExceedMinimum,
            decimal? maxValue,
            decimal? minValue,
            int? neverToExceedMaxFrequency,
            int? neverToExceedMinFrequency,
            int? maxValueFrequency,
            int? minValueFrequency,
            TargetValue targetValue,
            decimal? gapUnitValue,
            decimal? actualValue,
            decimal? originalExceedingValue,
            ScheduleType createdByScheduleType,
            TargetAlertStatus targetAlertStatus,
            Priority priority,
            TargetCategory targetCategory,
            bool exceedingBoundaries,
            bool requiresResponse,
            TargetAlertStatus typeOfViolationStatus,
            DateTime lastViolatedDateTime,
            decimal? maxAtEvaluation,
            decimal? minAtEvaluation,
            decimal? nteMaxAtEvaluation,
            decimal? nteMinAtEvaluation,
            decimal? actualValueAtEvaluation,
            List<DocumentLink> documentLinks)
        {
            TargetDefinition = targetDefinition;
            this.functionalLocation = functionalLocation;
            Tag = tagInfo;
            TargetName = targetName;
            Description = description;
            NeverToExceedMaximum = neverToExceedMaximum;
            NeverToExceedMinimum = neverToExceedMinimum;
            MaxValue = maxValue;
            MinValue = minValue;
            NeverToExceedMaxFrequency = neverToExceedMaxFrequency;
            NeverToExceedMinFrequency = neverToExceedMinFrequency;
            MaxValueFrequency = maxValueFrequency;
            MinValueFrequency = minValueFrequency;
            this.targetValue = targetValue;
            GapUnitValue = gapUnitValue;
            this.actualValue = actualValue;
            this.originalExceedingValue = originalExceedingValue;
            RequiresResponse = requiresResponse;
            Category = targetCategory;
            CreatedByScheduleType = createdByScheduleType;
            status = targetAlertStatus;
            this.priority = priority;
            this.exceedingBoundaries = exceedingBoundaries;
            CreatedDateTime = createdDateTime;
            LastModifiedBy = lastModifiedBy;
            LastModifiedDateTime = lastModifiedDateTime;
            this.acknowledgedUser = acknowledgedUser;
            this.acknowledgedDateTime = acknowledgedDateTime;

            TypeOfViolationStatus = typeOfViolationStatus;
            LastViolatedDateTime = lastViolatedDateTime;
            MaxAtEvaluation = maxAtEvaluation;
            MinAtEvaluation = minAtEvaluation;
            NTEMaxAtEvaluation = nteMaxAtEvaluation;
            NTEMinAtEvaluation = nteMinAtEvaluation;
            ActualValueAtEvaluation = actualValueAtEvaluation;

            this.documentLinks = documentLinks;
        }

        public TargetAlertStatus TypeOfViolationStatus { get; set; }
        public DateTime LastViolatedDateTime { get; set; }
        public decimal? MaxAtEvaluation { get; set; }
        public decimal? MinAtEvaluation { get; set; }
        public decimal? NTEMaxAtEvaluation { get; set; }
        public decimal? NTEMinAtEvaluation { get; set; }
        public decimal? ActualValueAtEvaluation { get; set; }

        /// <summary>
        ///     Describes whether the target is exceeding the boundaries of its definition;
        ///     same as "if target is in gap".
        /// </summary>
        public bool ExceedingBoundaries
        {
            get { return exceedingBoundaries; }
            set { exceedingBoundaries = value; }
        }

        public string TargetName { get; set; }

        public TargetCategory Category { get; set; }

        public ScheduleType CreatedByScheduleType { get; set; }

        public DateTime CreatedDateTime { get; set; }

        /// <summary>
        ///     Value that minimum value should never be lower than.
        /// </summary>
        public decimal? NeverToExceedMinimum { get; set; }

        /// <summary>
        ///     Value that maximum value should never exceed.
        /// </summary>
        public decimal? NeverToExceedMaximum { get; set; }

        /// <summary>
        ///     Upper threshold limit.
        /// </summary>
        public decimal? MaxValue { get; set; }

        /// <summary>
        ///     Lower threshold limit.
        /// </summary>
        public decimal? MinValue { get; set; }

        /// <summary>
        ///     The ideal ActualValue under normal operations; (options are close to Max or close to Min)
        /// </summary>
        public TargetValue TargetValue
        {
            get { return targetValue; }
            set { targetValue = value; }
        }

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
        ///     The dollar cost for each unit in gap (aka out of range)
        /// </summary>
        public decimal? GapUnitValue { get; set; }

        public string Description { get; set; }

        public TargetAlertStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public Priority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public bool RequiresResponse { get; set; }

        public TagInfo Tag { get; set; }

        [CachedRelationship]
        public TargetDefinition TargetDefinition { get; set; }

        public string WorkAssignmentName 
        {
            get { return TargetDefinition != null ? TargetDefinition.AssignmentName : null; }
        }

        public ISchedule Schedule
        {
            get { return (TargetDefinition == null) ? null : TargetDefinition.Schedule; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocation; }
            set { functionalLocation = value; }
        }

        public User LastModifiedBy { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public User AcknowledgedUser
        {
            get { return acknowledgedUser; }
            set { acknowledgedUser = value; }
        }

        public DateTime? AcknowledgedDateTime
        {
            get { return acknowledgedDateTime; }
            set { acknowledgedDateTime = value; }
        }

        /// <summary>
        ///     Store the most recent reading of the threshold value.  It may
        ///     be in/out of the gap as a new value is assigned according to its
        ///     TargetDefinition scheduled reading.
        /// </summary>
        public decimal? ActualValue
        {
            get { return actualValue; }
            //
            // Use constructor instead.
            //
            set { actualValue = value; }
        }

        /// <summary>
        ///     Store the original (aka first) reading of the threshold value that
        ///     triggered the Target Alert.  Thus, it has the same value as ActualValue
        ///     the first time the Alert is triggerred.
        /// </summary>
        public decimal? OriginalExceedingValue
        {
            get { return originalExceedingValue; }
        }

        /// <summary>
        ///     Dollar amount lost due to the threshold value going outside the range
        ///     (aka not in the gap).  It is calculated based on the most recent threshold
        ///     value (ActualValue) reading.
        /// </summary>
        public decimal? Losses
        {
            get
            {
                if (GapUnitValue.HasNoValue())
                {
                    return null;
                }

                var evaluation = CreateThresholdEvaluation(actualValue);
                return (evaluation == null) ? new decimal?() : evaluation.CalculateLosses(GapUnitValue.Value);
            }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinks; }
        }

        public bool IsRelevantTo(long siteIdOfClient,List<string> clientFullHierarchies, List<string> workPermitEdmontonFullHierarchies, List<string> restrictionFullHierarchies,SiteConfiguration siteConfiguration)
        {
            return new ExactMatchRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies) ||
                   new WalkDownRelevance(FunctionalLocation).IsRelevantTo(siteIdOfClient, clientFullHierarchies);
        }

        public long DefinitionId
        {
            get { return TargetDefinition.IdValue; }
        }

        /// <summary>
        ///     Be aware that the status could change based on whether we go into gap,
        ///     or come out of gap.
        /// </summary>
        public void UpdateWithNewEvaluation(TargetThresholdEvaluation evaluation, TargetDefinition definition,
            DateTime currentTime)
        {
            var nowExceedingBoundaries = evaluation.AnyLimitExceeded;
            var noLongerExceedingBoundaries = (ExceedingBoundaries && nowExceedingBoundaries == false);

            exceedingBoundaries = nowExceedingBoundaries;
            actualValue = evaluation.ActualValueUsed;

            if (status == TargetAlertStatus.Acknowledged)
            {
                if (noLongerExceedingBoundaries)
                {
                    status = TargetAlertStatus.Closed;
                }
            }
            else
            {
                // Current status is one of the alerts.

                if (noLongerExceedingBoundaries && RequiresResponse == false)
                {
                    status = TargetAlertStatus.Closed;
                }
                else
                {
                    status = evaluation.NeverToExceedLimitExceeded
                        ? TargetAlertStatus.NeverToExceedAlert
                        : TargetAlertStatus.StandardAlert;
                }
            }

            if (nowExceedingBoundaries)
            {
                TypeOfViolationStatus = status;
                LastViolatedDateTime = currentTime;
                MaxAtEvaluation = definition.MaxValue;
                MinAtEvaluation = definition.MinValue;
                NTEMaxAtEvaluation = definition.NeverToExceedMaximum;
                NTEMinAtEvaluation = definition.NeverToExceedMinimum;
                ActualValueAtEvaluation = actualValue;
            }
        }

        public void UpdateStatusWithNewTargetDefinitionOpMode(OperationalMode beforeOpMode, OperationalMode afterOpMode)
        {
            if (status != TargetAlertStatus.Closed && beforeOpMode.Equals(afterOpMode) == false)
                status = TargetAlertStatus.Cleared;
        }

        public void UpdateStatusWithTargetDefinitionIsActive(bool isActive)
        {
            if (isActive == false)
            {
                status = TargetAlertStatus.Cleared;
            }
        }

        /// <summary>
        ///     Indicate that someone has acknowledged this alert.
        ///     Be aware that the status will change depending on whether the target is still in gap.
        /// </summary>
        public void Acknowledge(User user, DateTime dateTime)
        {
            var firstAcknowledgement = IsNot(TargetAlertStatus.Acknowledged) && IsNot(TargetAlertStatus.Closed);

            Status = ExceedingBoundaries ? TargetAlertStatus.Acknowledged : TargetAlertStatus.Closed;

            if (firstAcknowledgement)
            {
                acknowledgedUser = user;
                acknowledgedDateTime = dateTime;
            }
        }

        private bool IsNot(SimpleDomainObject otherStatus)
        {
            return Is(otherStatus) == false;
        }

        private bool Is(SimpleDomainObject otherStatus)
        {
            return Status == otherStatus;
        }

        public TargetThresholdEvaluation GetTargetThresholdEvaluationForOriginalExceedingValue()
        {
            return CreateThresholdEvaluation(originalExceedingValue);
        }

        private TargetThresholdEvaluation CreateThresholdEvaluation(decimal? valueToEvaluate)
        {
            if (valueToEvaluate.HasNoValue())
            {
                return null;
            }

            var thresholds =
                TargetThresholds.CreateForEvaluatingSingleActualValue(NeverToExceedMinimum, MinValue,
                    MaxValue, NeverToExceedMaximum);
            if (thresholds == null)
            {
                return null;
            }

            return thresholds.Evaluate(valueToEvaluate.Value);
        }

        /// <summary>
        ///     Creates a new response for this alert.
        /// </summary>
        public TargetAlertResponse CreateResponse(User currentUser, string responseText,
            DateTime timeOfCreation, ShiftPattern shiftPattern)
        {
            return new TargetAlertResponse(this, responseText, currentUser, timeOfCreation, shiftPattern);
        }

        /// <summary>
        ///     Gap = Difference between ActualValue and the threshold that was exceeded
        ///     Losses =  Gap * GapUnitValue
        ///     If not All required data is available OR Losses equals zero, then Losses is UNDEFINED.
        /// </summary>
        public static decimal? CalculateLosses(decimal? actualValue,
            decimal? neverToExceedMax, decimal? maxValue,
            decimal? minValue, decimal? neverToExceedMin,
            decimal? gapUnitValue)
        {
            if (actualValue == null || gapUnitValue == null) return null;

            var thresholds =
                TargetThresholds.CreateForEvaluatingSingleActualValue(neverToExceedMin, minValue, maxValue,
                    neverToExceedMax);
            if (thresholds == null)
            {
                return null;
            }

            var evaluation = thresholds.Evaluate(actualValue.Value);

            return evaluation.AnyLimitExceeded ? (decimal?) evaluation.CalculateLosses(gapUnitValue.Value) : null;
        }
    }
}