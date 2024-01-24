using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class TargetAlertDTO : DomainObject, IHasPriority, IHasStatus<TargetAlertStatus>
    {
        private readonly bool responseRequired;
        private readonly TargetValue targetValue;

        public TargetAlertDTO(TargetAlert targetAlert)
            : this(
                targetAlert.Id,
                targetAlert.TargetName,
                targetAlert.FunctionalLocation.FullHierarchy,
                targetAlert.Category.Name,
                targetAlert.Description,
                targetAlert.TargetValue,
                targetAlert.ActualValue,
                targetAlert.NeverToExceedMaximum,
                targetAlert.MaxValue,
                targetAlert.MinValue,
                targetAlert.NeverToExceedMinimum,
                targetAlert.GapUnitValue,
                targetAlert.CreatedDateTime,
                targetAlert.Status,
                targetAlert.Priority,
                targetAlert.Losses,
                targetAlert.RequiresResponse,
                targetAlert.AcknowledgedDateTime,
                targetAlert.LastModifiedBy.Id,
                targetAlert.LastViolatedDateTime,
                targetAlert.WorkAssignmentName
            )
        {
        }

        public TargetAlertDTO(long? id,
            string targetName,
            string functionalLocationName,
            string categoryName,
            string description,
            TargetValue targetValue,
            decimal? actualValue,
            decimal? neverToExceedMax,
            decimal? max,
            decimal? min,
            decimal? neverToExceedMin,
            decimal? gapUnitValue,
            DateTime createdDateTime,
            TargetAlertStatus status,
            Priority priority,
            decimal? losses,
            bool responseRequired,
            DateTime? acknowledgedDateTime,
            long? lastModifiedUserId,
            DateTime lastViolatedDateTime,
            string workAssignmentName)
        {
            this.id = id;
            TargetName = targetName;
            FunctionalLocationName = functionalLocationName;
            CategoryName = categoryName;
            Description = description;
            this.targetValue = targetValue;
            ActualValue = actualValue;
            NeverToExceedMax = neverToExceedMax;
            Max = max;
            Min = min;
            NeverToExceedMin = neverToExceedMin;
            GapUnitValue = gapUnitValue;
            CreatedDateTime = createdDateTime;
            Status = status;
            Priority = priority;
            Losses = losses;
            this.responseRequired = responseRequired;
            AcknowledgedDateTime = acknowledgedDateTime;
            LastModifiedUserId = lastModifiedUserId;
            LastViolatedDateTime = lastViolatedDateTime;
            WorkAssignmentName = workAssignmentName;
        }

        public string StatusName
        {
            get { return Status.Name; }
        }

        public bool ResponseRequiredAsBool
        {
            get { return responseRequired; }
        }

        public string ResponseRequired
        {
            get
            {
                var result = string.Empty;
                if (responseRequired)
                {
                    return StringResources.Yes;
                }
                return result;
            }
        }

        [IncludeInSearch]
        public DateTime CreatedDateTime { get; private set; }

        public DateTime? AcknowledgedDateTime { get; private set; }

        [IncludeInSearch]
        public string FunctionalLocationName { get; private set; }

        [IncludeInSearch]
        public string TargetName { get; private set; }

        [IncludeInSearch]
        public string CategoryName { get; private set; }

        [IncludeInSearch]
        public string TargetValue
        {
            get { return targetValue.Title; }
        }

        public TargetValue OriginalTargetValue
        {
            get { return targetValue; }
        }

        [IncludeInSearch]
        public decimal? ActualValue { get; private set; }

        public decimal? NeverToExceedMax { get; private set; }
        public decimal? Max { get; private set; }
        public decimal? Min { get; private set; }
        public decimal? NeverToExceedMin { get; private set; }
        public decimal? GapUnitValue { get; private set; }

        // GAP x GAP Unit Value if value otherwise blank      
        public decimal? Losses { get; private set; }

        [IncludeInSearch]
        public decimal? LossesRounded
        {
            get
            {
                if (Losses.HasValue)
                {
                    return Decimal.Round(Losses.Value);
                }

                return null;
            }
        }

        [IncludeInSearch]
        public string Description { get; private set; }

        public long? LastModifiedUserId { get; private set; }

        [IncludeInSearch]
        public DateTime LastViolatedDateTime { get; private set; }

        [IncludeInSearch]
        public string WorkAssignmentName { get; set; }

        [IncludeInSearch]
        public Priority Priority { get; private set; }

        [IncludeInSearch]
        public TargetAlertStatus Status { get; private set; }
    }
}