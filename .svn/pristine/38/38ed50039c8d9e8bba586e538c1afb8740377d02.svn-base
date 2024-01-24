using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class LubesAlarmDisableFormFixture
    {
        public static readonly long EXISTING_ID = 5;
        public static readonly long ANOTHER_EXISTING_ID = 6;

        public static LubesAlarmDisableForm CreateForInsert(FunctionalLocation floc, DateTime validFromDateTime,
            DateTime validToDateTime, FormStatus status)
        {
            var createdBy = UserFixture.CreateUserWithGivenId(1);
            var createdDateTime = Clock.Now;

            var form = new LubesAlarmDisableForm(null, status, validFromDateTime, validToDateTime, createdBy,
                createdDateTime)                                   //ayman generic forms
            {
                Content = "content!",
                PlainTextContent = "content!",
                ApprovedDateTime = Clock.Now.AddDays(1),
                ClosedDateTime = Clock.Now.AddDays(2),
                FunctionalLocation = floc,
                Location = floc.Description,
                LastModifiedBy = createdBy,
                LastModifiedDateTime = Clock.Now,
                Criticality = "1 - High",
                Alarm = "Test alarm",
                SapNotification = "Test SAP notification",
                DocumentLinks = new List<DocumentLink>(),
                Approvals = new List<FormApproval>
                {
                    new FormApproval(null, null, "Lead Tech", null, null, null, 1),
                    new FormApproval(null, null, "Supervisor", createdBy, Clock.Now, null, 2)
                }
            };

            return form;
        }

        public static LubesAlarmDisableForm CreateFormWithExistingId()
        {
            var floc1 = FunctionalLocationFixture.GetReal_ED1_A001_U007();
            var form = new LubesAlarmDisableForm(EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1),
                Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1))     //ayman generic forms
            {
                FunctionalLocation = floc1,
                Criticality = "2 - Medium"
            };
            
            return form;
        }

        public static LubesAlarmDisableForm CreateAnotherFormWithExistingId()
        {
            return new LubesAlarmDisableForm(ANOTHER_EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1),
                Clock.Now.AddDays(1),
                UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1));               //ayman generic forms
        }
    }
}