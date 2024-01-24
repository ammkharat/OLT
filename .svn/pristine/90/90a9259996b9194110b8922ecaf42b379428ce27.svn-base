using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormGN59Fixture
    {
        public static readonly long EXISTING_ID = 2;
        public static readonly long ANOTHER_EXISTING_ID = 4;

        public static FormGN59 CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime, DateTime validToDateTime, FormStatus status)
        {
            User createdBy = UserFixture.CreateUserWithGivenId(1);
            DateTime createdDateTime = Clock.Now;

            FormGN59 form = new FormGN59(null, status, validFromDateTime, validToDateTime, createdBy, createdDateTime, 8);      //ayman generic forms

            form.Content = "content!";
            form.PlainTextContent = "content!";
            form.ApprovedDateTime = Clock.Now.AddDays(1);
            form.ClosedDateTime = Clock.Now.AddDays(2);
            form.FunctionalLocations = flocs;

            form.LastModifiedBy = createdBy;
            form.LastModifiedDateTime = Clock.Now;

            form.Approvals = new List<FormApproval> { new FormApproval(null, null, "Supervisor", null, null, null, 1), new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 2) };

            return form;
        }

        public static FormGN59 CreateFormWithExistingId()
        {
            return new FormGN59(EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1), 8);       //ayman generic forms
        }

        public static FormGN59 CreateAnotherFormWithExistingId()
        {
            return new FormGN59(ANOTHER_EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1), 8);     //ayman generic forms
        }
    }
}
