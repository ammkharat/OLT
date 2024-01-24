using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormEdmontonGN1DTO : FormEdmontonDTO
    {
        public FormEdmontonGN1DTO(long id, string functionalLocationName, string tradeChecklistNames,
            EdmontonFormType formType, long createdByUserId, string createdByFullNameWithUserName,
            DateTime createdDateTime, long lastModifiedByUserId, DateTime lastModifiedDateTime, DateTime fromDateTime,
            DateTime toDateTime, FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime,
            List<string> remainingApprovals)
            : base(
                id, new List<string> {functionalLocationName}, formType, createdByUserId, createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId, fromDateTime, toDateTime, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            TradeChecklistNames = tradeChecklistNames;
            FunctionalLocationName = functionalLocationName;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        [IncludeInSearch]
        public string TradeChecklistNames { get; private set; }

        public string FunctionalLocationName { private set; get; }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { private set; get; }

        [IncludeInSearch]
        public DateTime FromDateTime
        {
            get { return ValidFrom; }
        }

        [IncludeInSearch]
        public DateTime ToDateTime
        {
            get { return ValidTo; }
        }
    }
}