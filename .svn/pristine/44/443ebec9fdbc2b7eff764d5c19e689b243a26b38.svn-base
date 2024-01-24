using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormLubesCsdFixture
    {
        public static readonly long EXISTING_ID = 5;
        public static readonly long ANOTHER_EXISTING_ID = 6;

        public static LubesCsdForm CreateForInsert(FunctionalLocation floc, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var form = new LubesCsdForm(null, status, validFromDateTime, validToDateTime, createdBy, createdDateTime)        //ayman generic forms
            {
                Content = "content!",
                PlainTextContent = "content!",
                ApprovedDateTime = Clock.Now.AddDays(1),
                ClosedDateTime = Clock.Now.AddDays(2),
                FunctionalLocation = floc,
                Location = "Location Text",
                IsTheCSDForAPressureSafetyValve = false,
                CriticalSystemDefeated = "The big ol' pump.",
                LastModifiedBy = createdBy,
                LastModifiedDateTime = Clock.Now,
                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, null, "Supervisor", null, null, null, 1),
                    new FormApproval(null, null, "Some Other Guy", createdBy, Clock.Now, null, 2)
                }
            };

            return form;
        }

        public static LubesCsdForm CreateFormWithExistingId()
        {
            return new LubesCsdForm(EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1));         //ayman generic forms
        }

        public static LubesCsdForm CreateAnotherFormWithExistingId()
        {
            return new LubesCsdForm(ANOTHER_EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1));  //ayman generic forms
        }
    }
}