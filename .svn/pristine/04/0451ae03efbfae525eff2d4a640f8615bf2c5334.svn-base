using System;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class OnPremisePersonnelAuditDTO : DomainObject
    {
        public OnPremisePersonnelAuditDTO(long id,
            long formId,
            string company,
            string trade,
            string personnelName,
            DateTime startDateTime,
            DateTime endDateTime,
            string primaryLocation,
            decimal expectedHours,
            string description,
            string workOrderNumber,
            FormStatus formStatus,
            string approvedBy)
            : base(id)
        {
            this.id = id;
            FormId = formId;
            Company = company;
            Trade = trade;
            PersonnelName = personnelName;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PrimaryLocation = primaryLocation;
            ExpectedHours = expectedHours;
            Description = description;
            WorkOrderNumber = workOrderNumber;
            OvertimeFormStatus = formStatus.Name;
            ApprovedByFullName = approvedBy;
        }

        [IncludeInSearch]
        public long FormId { get; set; }

        [IncludeInSearch]
        public string Company { get; private set; }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public string PersonnelName { get; private set; }

        [IncludeInSearch]
        public DateTime StartDateTime { get; private set; }

        [IncludeInSearch]
        public DateTime EndDateTime { get; private set; }

        [IncludeInSearch]
        public string PrimaryLocation { get; private set; }

        [IncludeInSearch]
        public decimal ExpectedHours { get; private set; }

        [IncludeInSearch]
        public string Description { get; private set; }

        [IncludeInSearch]
        public string WorkOrderNumber { get; private set; }

        [IncludeInSearch]
        public string OvertimeFormStatus { get; private set; }

        [IncludeInSearch]
        public string ApprovedByFullName { get; private set; }
    }
}