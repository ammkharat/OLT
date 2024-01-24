using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class DocumentSuggestionFixture
    {
        public static DocumentSuggestion CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status, User lastModifiedBy)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var comment1User = UserFixture.CreateUserWithGivenId(2);
            var comment1DateTime = Clock.Now;

            var comment2User = UserFixture.CreateUserWithGivenId(3);
            var comment2DateTime = Clock.Now;

            var documentLinks = new List<DocumentLink>
            {
                new DocumentLink("www.google.ca", "GOOG"),
                new DocumentLink("www.microsoft.com", "MSFT")
            };

            var reasonsForExtension = new List<Comment>
            {
                new Comment(comment1User, comment1DateTime, "1. It's not done yet"),
                new Comment(comment2User, comment2DateTime, "2. Still not done yet")
            };

            var form = new DocumentSuggestion(null, validFromDateTime, validToDateTime, status, createdBy,
                createdDateTime,
                lastModifiedBy, Clock.Now, 8)       //ayman generic forms
            {
                SiteId = 3,
                LastModifiedBy = lastModifiedBy,
                FunctionalLocations = flocs,
                LocationEquipmentNumber = "N3290",
                DocumentLinks = documentLinks,
                ScheduledCompletionDateTime = validToDateTime.AddDays(30),
                NumberOfExtensions = 2,
                ReasonsForExtension = reasonsForExtension,
                IsExistingDocument = true,
                DocumentOwner = "Joe in Accounting",
                DocumentNumber = "P0034TR250",
                DocumentTitle = "Really important doc that needs updating",
                OriginalMarkedUp = true,
                HardCopySubmittedTo = "That lady Joe reports to",
                RecommendedToBeArchived = false,
                Description =
                    "Here are all the reasons this doc needs updating: 1) it's out of date, and 2) it's out of date.",
                InitialReviewApprovedBy = "",
                InitialReviewApprovedDateTime = null,
                OwnerReviewApprovedBy = "",
                OwnerReviewApprovedDateTime = null,
                DocumentIssuedApprovedBy = "",
                DocumentIssuedApprovedDateTime = null,
                DocumentArchivedApprovedBy = "",
                DocumentArchivedApprovedDateTime = null,
                NotApprovedBy = "",
                NotApprovedDateTime = null,
            };

            return form;
        }
    }
}