using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.DTO
{
    [Serializable]
    public class FormEdmontonGN6DTO : FormEdmontonDTO
    {
        public FormEdmontonGN6DTO(long id, List<string> functionalLocations, EdmontonFormType formType,
            long createdByUserId, string createdByFullNameWithUserName, DateTime createdDateTime,
            long lastModifiedByUserId, DateTime validFrom, DateTime validTo,
            FormStatus formStatus, DateTime? approvedDateTime, DateTime? closedDateTime, List<string> remainingApprovals,
            string applicableSections, string jobDescription, DateTime lastModifiedDateTime)
            : base(
                id, functionalLocations, formType, createdByUserId, createdByFullNameWithUserName, createdDateTime,
                lastModifiedByUserId, validFrom, validTo, formStatus, approvedDateTime, closedDateTime,
                remainingApprovals)
        {
            ApplicableSections = applicableSections;
            JobDescription = jobDescription;
            LastModifiedDateTime = lastModifiedDateTime;
        }

        [IncludeInSearch]
        public string ApplicableSections { get; private set; }

        [IncludeInSearch]
        public string JobDescription { get; private set; }

        [IncludeInSearch]
        public DateTime LastModifiedDateTime { get; private set; }

        public static string GetApplicableSections(bool section1NotApplicable,
            bool section2NotApplicable, bool section3NotApplicable, bool section4NotApplicable,
            bool section5NotApplicable, bool section6NotApplicable)
        {
            var applicableSections = new List<string>();

            if (!section1NotApplicable)
            {
                applicableSections.Add("Section 1");
            }

            if (!section2NotApplicable)
            {
                applicableSections.Add("Section 2");
            }

            if (!section3NotApplicable)
            {
                applicableSections.Add("Section 3");
            }

            if (!section4NotApplicable)
            {
                applicableSections.Add("Section 4");
            }

            if (!section5NotApplicable)
            {
                applicableSections.Add("Section 5");
            }

            if (!section6NotApplicable)
            {
                applicableSections.Add("Section 6");
            }

            return applicableSections.BuildCommaSeparatedList();
        }
    }
}