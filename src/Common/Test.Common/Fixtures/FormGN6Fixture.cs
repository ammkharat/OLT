using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class FormGN6Fixture
    {
        public static readonly long EXISTING_ID = 9;
        public static readonly long ANOTHER_EXISTING_ID = 10;

        public static FormGN6 CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime, DateTime validToDateTime, FormStatus status)
        {
            User createdBy = UserFixture.CreateUserWithGivenId(1);
            DateTime createdDateTime = Clock.Now;

            FormGN6 form = new FormGN6(null, status, validFromDateTime, validToDateTime, createdBy, createdDateTime, 8);    //ayman generic forms

            form.JobDescription = "job desc!";
            form.ReasonForCriticalLift = "reason!";

            form.Section1Content = "sec1";
            form.Section1PlainTextContent = "sec1pt";
            form.Section1NotApplicableToJob = false;

            form.Section2Content = "sec2";
            form.Section2PlainTextContent = "sec2pt";
            form.Section2NotApplicableToJob = false;

            form.Section3Content = "sec3";
            form.Section3PlainTextContent = "sec3pt";
            form.Section3NotApplicableToJob = false;

            form.Section4Content = "sec4";
            form.Section4PlainTextContent = "sec4pt";
            form.Section4NotApplicableToJob = false;

            form.Section5Content = "sec5";
            form.Section5PlainTextContent = "sec5pt";
            form.Section5NotApplicableToJob = false;

            form.Section6Content = "sec6";
            form.Section6PlainTextContent = "sec6pt";
            form.Section6NotApplicableToJob = false;
            
            form.ApprovedDateTime = Clock.Now.AddDays(1);
            form.ClosedDateTime = Clock.Now.AddDays(2);
            form.FunctionalLocations = flocs;

            form.PreJobMeetingSignatures = "pre job meeting sigs";
            form.PlainTextPreJobMeetingSignatures = "pre job meeting sigs!";

            form.LastModifiedBy = createdBy;
            form.LastModifiedDateTime = Clock.Now;

            return form;
        }

        public static FormGN6 CreateFormWithExistingId()
        {
            return new FormGN6(EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1), 8);   //ayman generic forms
        }

        public static FormGN6 CreateAnotherFormWithExistingId()
        {
            return new FormGN6(ANOTHER_EXISTING_ID, FormStatus.Draft, Clock.Now.AddDays(-1), Clock.Now.AddDays(1), UserFixture.CreateUserWithGivenId(1), Clock.Now.AddDays(-1), 8);   //ayman generic forms
        }

    }
}
