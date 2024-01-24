using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class PermitAssessmentDTO : FormEdmontonDTO
    {
        public PermitAssessmentDTO(long id,
            List<string> functionalLocations,
            long createdByUserId,
            string createdByFullNameWithUserName,
            DateTime createdDateTime,
            long lastModifiedByUserId,
            DateTime permitStartDateTime,
            DateTime permitExpiredDateTime,
            FormStatus formStatus,
            string lastModifiedBy,
            OilsandsWorkPermitType workPermitType,
            string permitNumber,
            decimal totalScore,
            string jobDescription,
            string overallFeedback,
            DateTime lastModifiedOn,
            bool? isIlpRecommended,
            long creationUserShiftPatternId)
            : base(
                id,
                functionalLocations,
                EdmontonFormType.OilsandsPermitAssessment,
                createdByUserId,
                createdByFullNameWithUserName,
                createdDateTime,
                lastModifiedByUserId,
                permitStartDateTime,
                permitExpiredDateTime,
                formStatus,
                null,
                null,
                null)
        {
            CreationUserShiftPatternId = creationUserShiftPatternId;
            LastModifiedBy = lastModifiedBy;
            WorkPermitType = workPermitType;
            PermitNumber = permitNumber;
            TotalScore = totalScore.ToPercent(100);
            JobDescription = jobDescription;
            OverallFeedback = overallFeedback;
            LastModified = lastModifiedOn;
            IsIlpRecommended = isIlpRecommended;
        }

        public long CreationUserShiftPatternId { get; set; }

        [IncludeInSearch]
        public bool? IsIlpRecommended { get; set; }

        [IncludeInSearch]
        public string LastModifiedBy { get; set; }

        [IncludeInSearch]
        public OilsandsWorkPermitType WorkPermitType { get; set; }

        [IncludeInSearch]
        public string PermitNumber { get; set; }

        [IncludeInSearch]
        public int TotalScore { get; set; }

        [IncludeInSearch]
        public string JobDescription { get; set; }

        [IncludeInSearch]
        public string OverallFeedback { get; set; }

        [IncludeInSearch]
        public DateTime LastModified { get; set; }

        public bool HasYesAnswer
        {
            get
            {
                return
                    IsIlpRecommended.HasValue && IsIlpRecommended.Value;
            }
        }
    }
}