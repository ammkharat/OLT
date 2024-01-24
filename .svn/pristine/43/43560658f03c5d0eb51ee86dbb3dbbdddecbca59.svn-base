using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormOP14Fixture
    {
        public static readonly long EXISTING_ID = 5;
        public static readonly long ANOTHER_EXISTING_ID = 6;
        public static readonly long siteid = 8;
        public static FormOP14 CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime, DateTime validToDateTime, FormStatus status)
        {
            User createdBy = UserFixture.CreateUserWithGivenId(1);
            DateTime createdDateTime = Clock.Now;

            FormOP14 form = new FormOP14(null, status, validFromDateTime, validToDateTime, createdBy, createdDateTime,siteid);

            form.Content = "content!";
            form.PlainTextContent = "content!";
            form.ApprovedDateTime = Clock.Now.AddDays(1);
            form.ClosedDateTime = Clock.Now.AddDays(2);
            form.FunctionalLocations = flocs;
            form.IsTheCSDForAPressureSafetyValve = false;
            form.CriticalSystemDefeated = "The big ol' pump.";
            form.Department = FormOP14Department.Maintenance;

            form.LastModifiedBy = createdBy;
            form.LastModifiedDateTime = Clock.Now;

            form.Approvals = new List<FormApproval> { new FormApproval(null, null, "Supervisor", null, null, null, 1), new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 2) };

            return form;
        }

        public static FormOP14 CreateFormWithExistingId()
        {
            return new FormOP14(EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1),siteid);  //ayman generic forms
        }

        public static FormOP14 CreateAnotherFormWithExistingId()
        {
            return new FormOP14(ANOTHER_EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1),siteid);
        }
    }
}
