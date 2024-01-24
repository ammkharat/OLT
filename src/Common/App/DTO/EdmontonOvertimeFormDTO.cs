using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class EdmontonOvertimeFormDTO : FormEdmontonDTO
    {
        public EdmontonOvertimeFormDTO(long id, List<string> functionalLocations, EdmontonFormType formType,
            long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? cancelledDateTime, string trade,
            decimal totalHours, string lastModifiedByFullNameWithUserName, string approvedByFullNameWithUserName)
            : base(
                id, functionalLocations, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime,
                lastModifiedByUserId, validFrom, validTo, formStatus,
                approvedDateTime, null, new List<string>(0))
        {
            Trade = trade;
            TotalHours = totalHours;
            ApprovedByFullNameWithUserName = approvedByFullNameWithUserName;
            LastModifiedByFullNameWithUserName = lastModifiedByFullNameWithUserName;
            CancelledDateTime = cancelledDateTime;
        }

        [IncludeInSearch]
        public string Trade { get; private set; }

        [IncludeInSearch]
        public decimal TotalHours { get; private set; }

        [IncludeInSearch]
        public string ApprovedByFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public string LastModifiedByFullNameWithUserName { get; private set; }

        [IncludeInSearch]
        public DateTime? CancelledDateTime { get; set; }
    }
}