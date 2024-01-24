using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormGN75AFixture
    {
        public static readonly long EXISTING_ID = 7;
        public static readonly long ANOTHER_EXISTING_ID = 8;

        public static FormGN75A CreateForInsert(FunctionalLocation floc, DateTime fromDateTime, DateTime toDateTime, FormStatus status)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var form = new FormGN75A(null, status, fromDateTime, toDateTime, createdBy, createdDateTime, 8); //ayman generic forms

            form.Content = "content!";
            form.PlainTextContent = "content! (Plain text)";
            form.ApprovedDateTime = Clock.Now.AddDays(1);
            form.ClosedDateTime = Clock.Now.AddDays(2);
            form.FunctionalLocation = floc;

            form.LastModifiedBy = createdBy;
            form.LastModifiedDateTime = Clock.Now;

            form.Approvals = new List<FormApproval>
            {
                new FormApproval(null, null, "Supervisor", null, null, null, 1),
                new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 2)
            };

            form.DocumentLinks = DocumentLinkFixture.CreateDocumentListOfTwo();

            return form;
        }
    }
}