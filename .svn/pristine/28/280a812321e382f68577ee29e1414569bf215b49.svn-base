using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormGN7Fixture
    {
        public static readonly long EXISTING_ID = 1;
        public static readonly long ANOTHER_EXISTING_ID = 3;

        public static FormGN7 CreateForInsert(List<FunctionalLocation> flocs,
            DateTime validFromDateTime,
            DateTime validToDateTime,
            FormStatus status)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var formGn7 = new FormGN7(null, status, validFromDateTime, validToDateTime, createdBy, createdDateTime, 8);         //ayman generic forms

            formGn7.Content = "content!";
            formGn7.PlainTextContent = "content!";
            formGn7.ApprovedDateTime = Clock.Now.AddDays(1);
            formGn7.ClosedDateTime = Clock.Now.AddDays(2);
            formGn7.FunctionalLocations = flocs;
            formGn7.DocumentLinks = new List<DocumentLink> {DocumentLinkFixture.CreateNewDocumentLink()};

            formGn7.LastModifiedBy = createdBy;
            formGn7.LastModifiedDateTime = Clock.Now;

            formGn7.Approvals = new List<FormApproval>
            {
                new FormApproval(null, null, "Supervisor", null, null, null, 1),
                new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 2)
            };

            return formGn7;
        }

        public static FormGN7 CreateFormWithExistingId()
        {
            return new FormGN7(EXISTING_ID,
                FormStatus.Draft,
                Clock.Now.AddDays(-1),
                Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1),
                Clock.Now.AddDays(-1), 8);    //ayman generic forms
        }

        public static FormGN7 CreateAnotherFormWithExistingId()
        {
            return new FormGN7(ANOTHER_EXISTING_ID,
                FormStatus.Draft,
                Clock.Now.AddDays(-1),
                Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1),
                Clock.Now.AddDays(-1), 8);    //ayman generic forms
        }
    }
}