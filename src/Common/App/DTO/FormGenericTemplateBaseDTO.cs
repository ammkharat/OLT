using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormGenericTemplateBaseDTO : DomainObject, IHasStatus<FormStatus>, IFormGenericTemplateBaseDTO
    {
        private readonly List<string> functionalLocations = new List<string>();

        public FormGenericTemplateBaseDTO(long id, List<string> functionalLocations, EdmontonFormType formType,
            long createdByUserId, string createdByFullNameWithUserName, DateTime createdDateTime,
            long lastModifiedByUserId, DateTime validFrom, DateTime validTo, FormStatus formStatus,
            DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals)
        {
            Id = id;
            functionalLocations.ForEach(AddFunctionalLocation);
            FormType = formType;
            CreatedByUserId = createdByUserId;
            CreatedByFullNameWithUserName = createdByFullNameWithUserName;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Status = formStatus;
            ApprovedDateTime = approvedDateTime;
            ClosedDateTime = closedDateTime;
            CreatedDateTime = createdDateTime;
            LastModifiedByUserId = lastModifiedByUserId;
            RemainingApprovals = remainingApprovals;

            if (RemainingApprovals == null)
            {
                RemainingApprovals = new List<string>();
            }
        }

        [IncludeInSearch]
        public string CreatedByFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public DateTime ValidFrom { get; private set; }

        [IncludeInSearch]
        public DateTime ValidTo { get; private set; }

        [IncludeInSearch]
        public DateTime? ApprovedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime? ClosedDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime CreatedDateTime { get; private set; }

        public List<string> RemainingApprovals { get; private set; }

        [IncludeInSearch]
        public string RemainingApprovalsString
        {
            get { return RemainingApprovals.BuildCommaSeparatedList(); }
        }

        [IncludeInSearch]
        public string FunctionalLocationNames
        {
            get { return functionalLocations.BuildCommaSeparatedList(); }
        }

        public EdmontonFormType FormType { get; private set; }

        [IncludeInSearch]
        public long FormNumber
        {
            get { return IdValue; }
        }

        public long CreatedByUserId { get; set; }
        public long LastModifiedByUserId { get; set; }

        public bool IsPermitRequestDatesWithinFormDates(Range<Date> workPermitDateRange)
        {
            var formRange = new Range<Date>(ValidFrom.ToDate(), ValidTo.ToDate());
            return formRange.ContainsInclusive(workPermitDateRange);
        }

        public bool IsWorkPermitDateTimesWithinFormDateTimes(Range<DateTime> workPermitDateRange)
        {
            var formRange = new Range<DateTime>(ValidFrom, ValidTo);
            return formRange.ContainsInclusive(workPermitDateRange);
        }

        [IncludeInSearch]
        public virtual FormStatus Status { get; private set; }

        public void AddFunctionalLocation(string functionalLocationName)
        {
            functionalLocations.AddAndSort(functionalLocationName);
        }

        public void AddRemainingApproval(string approval)
        {
            if (!string.IsNullOrEmpty(approval) && RemainingApprovals.DoesNotContain(approval))
            {
                RemainingApprovals.Add(approval);
            }
        }
    }
}