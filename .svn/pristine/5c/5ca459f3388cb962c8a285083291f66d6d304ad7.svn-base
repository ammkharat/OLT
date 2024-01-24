using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class ProcedureDeviationFixture
    {
        public static ProcedureDeviation CreateForInsert(List<FunctionalLocation> flocs, DateTime validFromDateTime,
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

            var causeDeterminationCauses = new List<CauseDeterminationWhyType>
            {
                CauseDeterminationWhyType.DocumentIncorrect,
                CauseDeterminationWhyType.EquipmentMalfunction
            };

            var form = new ProcedureDeviation(null,
                ProcedureDeviationType.Immediate,
                validFromDateTime,
                validToDateTime,
                status, createdBy,
                createdDateTime,
                lastModifiedBy, Clock.Now, 3)       //ayman generic forms
            {
                SiteId = 3,
                LastModifiedBy = lastModifiedBy,
                FunctionalLocations = flocs,
                LocationEquipmentNumber = "N3290",
                DocumentLinks = documentLinks,
                NumberOfExtensions = 2,
                ReasonsForExtension = reasonsForExtension,
                PermanentRevisionRequired = false,
                RevertedBackToOriginal = false,
                OperatingProcedureNumber = "P0034TR250",
                OperatingProcedureTitle = "Really important doc that needs updating",
                OperatingProcedureLevel = OperatingProcedureLevel.Level2,
                Description =
                    "Here are all the reasons this doc needs updating: 1) it's out of date, and 2) it's out of date.",
                CauseDeterminationCauses = causeDeterminationCauses,
                CauseDeterminationComments = "These are comments for the cause determination why1.",
                FixDocumentDurationType = CorrectiveActionFixDocumentDurationType.DeviationDurationOnly,
                AffectsToe = false,
                RiskAssessmentAttendee1Type = ProcedureDeviationAttendeeType.OperationsSME,
                RiskAssessmentAttendee2Type = ProcedureDeviationAttendeeType.TechnicalSME,
                RiskAssessmentAttendee3Type = ProcedureDeviationAttendeeType.ShiftSupervisor,
                RiskAssessmentAttendee4Type = ProcedureDeviationAttendeeType.Other,
                RiskAssessmentAnswer1 = false,
                RiskAssessmentAnswer2 = false,
                RiskAssessmentAnswer3 = false,
                RiskAssessmentAnswer4 = false,
                RiskAssessmentAnswer5 = false,
                ImmediateApprovalsApprover1Type = ProcedureDeviationApprovalType.OperationsSME,
                ImmediateApprovalsApprover2Type = ProcedureDeviationApprovalType.TechnicalSME,
                TemporaryApprovalsApprover1Type = ProcedureDeviationApprovalType.DocumentOwnerApprover,
                TemporaryApprovalsApprover2Type = ProcedureDeviationApprovalType.Other,
                ImmediateApprovalsApprover1ObtainedVia = ProcedureDeviationApprovalObtainedVia.Email,
                ImmediateApprovalsApprover2ObtainedVia = ProcedureDeviationApprovalObtainedVia.Radio,
                TemporaryApprovalsApprover1ObtainedVia = ProcedureDeviationApprovalObtainedVia.Phone,
                TemporaryApprovalsApprover2ObtainedVia = ProcedureDeviationApprovalObtainedVia.InPerson,
                CancelledBy = "",
                CancelledDateTime = null,
                CancelledReason = string.Empty
            };

            return form;
        }
    }
}