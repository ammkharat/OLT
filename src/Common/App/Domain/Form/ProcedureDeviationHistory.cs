using System;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    [Serializable]
    public class ProcedureDeviationHistory : BaseFormHistory
    {
        public ProcedureDeviationHistory(long? id,
            DateTime fromDateTime,
            DateTime toDateTime,
            FormStatus formStatus,
            User lastModifiedBy,
            DateTime lastModifiedDateTime,
            ProcedureDeviationType type,
            bool permanentRevisionRequired,
            bool revertedBackToOriginal,
            string flocListString,
            string locationEquipmentNumber,
            string documentLinks,
            int numberOfExtensions,
            string reasonsForExtension,
            string operatingProcedureNumber,
            string operatingProcedureTitle,
            OperatingProcedureLevel operatingProcedureLevel,
            string description,
            string causeDeterminationCauses,
            string causeDeterminationCategory,
            string causeDeterminationComments,
            CorrectiveActionFixDocumentDurationType fixDocumentDurationType,
            string correctiveActionIlpNumber,
            string correctiveActionWorkRequestNumber,
            string correctiveActionOtherComments,
            bool affectsToe,
            ProcedureDeviationAttendeeType riskAssessmentAttendee1Type,
            string riskAssessmentAttendee1Name,
            ProcedureDeviationAttendeeType riskAssessmentAttendee2Type,
            string riskAssessmentAttendee2Name,
            ProcedureDeviationAttendeeType riskAssessmentAttendee3Type,
            string riskAssessmentAttendee3Name,
            ProcedureDeviationAttendeeType riskAssessmentAttendee4Type,
            string riskAssessmentAttendee4Name,
            bool riskAssessmentAnswer1,
            bool riskAssessmentAnswer2,
            bool riskAssessmentAnswer3,
            bool riskAssessmentAnswer4,
            bool riskAssessmentAnswer5,
            string riskAssessmentComments,
            ProcedureDeviationApprovalType immediateApprovalsApprover1Type,
            string immediateApprovalsApprover1Title,
            string immediateApprovalsApprover1Name,
            ProcedureDeviationApprovalObtainedVia immediateApprovalsApprover1ObtainedVia,
            DateTime? immediateApprovalsApprover1ApprovedDateTime,
            ProcedureDeviationApprovalType immediateApprovalsApprover2Type,
            string immediateApprovalsApprover2Title,
            string immediateApprovalsApprover2Name,
            ProcedureDeviationApprovalObtainedVia immediateApprovalsApprover2ObtainedVia,
            DateTime? immediateApprovalsApprover2ApprovedDateTime,
            ProcedureDeviationApprovalType temporaryApprovalsApprover1Type,
            string temporaryApprovalsApprover1Title,
            string temporaryApprovalsApprover1Name,
            ProcedureDeviationApprovalObtainedVia temporaryApprovalsApprover1ObtainedVia,
            DateTime? temporaryApprovalsApprover1ApprovedDateTime,
            ProcedureDeviationApprovalType temporaryApprovalsApprover2Type,
            string temporaryApprovalsApprover2Title,
            string temporaryApprovalsApprover2Name,
            ProcedureDeviationApprovalObtainedVia temporaryApprovalsApprover2ObtainedVia,
            DateTime? temporaryApprovalsApprover2ApprovedDateTime,
            string cancelledBy,
            DateTime? cancelledDateTime,
            string cancelledReason)
            : base(id.Value, formStatus, fromDateTime, toDateTime, lastModifiedBy, lastModifiedDateTime)
        {
            Type = type;
            PermanentRevisionRequired = permanentRevisionRequired;
            RevertedBackToOriginal = revertedBackToOriginal;
            FunctionalLocations = flocListString;
            LocationEquipmentNumber = locationEquipmentNumber;
            DocumentLinks = documentLinks;
            NumberOfExtensions = numberOfExtensions;
            ReasonsForExtension = reasonsForExtension;
            OperatingProcedureNumber = operatingProcedureNumber;
            OperatingProcedureTitle = operatingProcedureTitle;
            OperatingProcedureLevel = operatingProcedureLevel;
            Description = description;
            CauseDeterminationCauses = causeDeterminationCauses;
            CauseDeterminationCategory = causeDeterminationCategory;
            CauseDeterminationComments = causeDeterminationComments;
            FixDocumentDurationType = fixDocumentDurationType;
            CorrectiveActionIlpNumber = correctiveActionIlpNumber;
            CorrectiveActionWorkRequestNumber = correctiveActionWorkRequestNumber;
            CorrectiveActionOtherComments = correctiveActionOtherComments;
            AffectsToe = affectsToe;
            RiskAssessmentAttendee1Type = riskAssessmentAttendee1Type;
            RiskAssessmentAttendee1Name = riskAssessmentAttendee1Name;
            RiskAssessmentAttendee2Type = riskAssessmentAttendee2Type;
            RiskAssessmentAttendee2Name = riskAssessmentAttendee2Name;
            RiskAssessmentAttendee3Type = riskAssessmentAttendee3Type;
            RiskAssessmentAttendee3Name = riskAssessmentAttendee3Name;
            RiskAssessmentAttendee4Type = riskAssessmentAttendee4Type;
            RiskAssessmentAttendee4Name = riskAssessmentAttendee4Name;
            RiskAssessmentAnswer1 = riskAssessmentAnswer1;
            RiskAssessmentAnswer2 = riskAssessmentAnswer2;
            RiskAssessmentAnswer3 = riskAssessmentAnswer3;
            RiskAssessmentAnswer4 = riskAssessmentAnswer4;
            RiskAssessmentAnswer5 = riskAssessmentAnswer5;
            RiskAssessmentComments = riskAssessmentComments;
            ImmediateApprovalsApprover1Type = immediateApprovalsApprover1Type;
            ImmediateApprovalsApprover1Title = immediateApprovalsApprover1Title;
            ImmediateApprovalsApprover1Name = immediateApprovalsApprover1Name;
            ImmediateApprovalsApprover1ObtainedVia = immediateApprovalsApprover1ObtainedVia;
            ImmediateApprovalsApprover1ApprovedDateTime = immediateApprovalsApprover1ApprovedDateTime;
            ImmediateApprovalsApprover2Type = immediateApprovalsApprover2Type;
            ImmediateApprovalsApprover2Title = immediateApprovalsApprover2Title;
            ImmediateApprovalsApprover2Name = immediateApprovalsApprover2Name;
            ImmediateApprovalsApprover2ObtainedVia = immediateApprovalsApprover2ObtainedVia;
            ImmediateApprovalsApprover2ApprovedDateTime = immediateApprovalsApprover2ApprovedDateTime;
            TemporaryApprovalsApprover1Type = temporaryApprovalsApprover1Type;
            TemporaryApprovalsApprover1Title = temporaryApprovalsApprover1Title;
            TemporaryApprovalsApprover1Name = temporaryApprovalsApprover1Name;
            TemporaryApprovalsApprover1ObtainedVia = temporaryApprovalsApprover1ObtainedVia;
            TemporaryApprovalsApprover1ApprovedDateTime = temporaryApprovalsApprover1ApprovedDateTime;
            TemporaryApprovalsApprover2Type = temporaryApprovalsApprover2Type;
            TemporaryApprovalsApprover2Title = temporaryApprovalsApprover2Title;
            TemporaryApprovalsApprover2Name = temporaryApprovalsApprover2Name;
            TemporaryApprovalsApprover2ObtainedVia = temporaryApprovalsApprover2ObtainedVia;
            TemporaryApprovalsApprover2ApprovedDateTime = temporaryApprovalsApprover2ApprovedDateTime;
            CancelledBy = cancelledBy;
            CancelledDateTime = cancelledDateTime;
            CancelledReason = cancelledReason;
        }

        public ProcedureDeviationType Type { get; set; }

        public bool PermanentRevisionRequired { get; set; }

        public bool RevertedBackToOriginal { get; set; }

        public string FunctionalLocations { get; private set; }

        public string DocumentLinks { get; private set; }

        public string LocationEquipmentNumber { get; set; }

        public int NumberOfExtensions { get; set; }

        public string ReasonsForExtension { get; set; }

        public string OperatingProcedureNumber { get; set; }

        public string OperatingProcedureTitle { get; set; }

        public OperatingProcedureLevel OperatingProcedureLevel { get; set; }

        public string Description { get; set; }

        public string CauseDeterminationCauses { get; set; }

        public string CauseDeterminationCategory { get; set; }

        public string CauseDeterminationComments { get; set; }

        public CorrectiveActionFixDocumentDurationType FixDocumentDurationType { get; set; }

        public string CorrectiveActionIlpNumber { get; set; }

        public string CorrectiveActionWorkRequestNumber { get; set; }

        public string CorrectiveActionOtherComments { get; set; }

        public bool AffectsToe { get; set; }

        public ProcedureDeviationAttendeeType RiskAssessmentAttendee1Type { get; set; }
        public string RiskAssessmentAttendee1Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee2Type { get; set; }
        public string RiskAssessmentAttendee2Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee3Type { get; set; }
        public string RiskAssessmentAttendee3Name { get; set; }
        public ProcedureDeviationAttendeeType RiskAssessmentAttendee4Type { get; set; }
        public string RiskAssessmentAttendee4Name { get; set; }

        public bool RiskAssessmentAnswer1 { get; set; }
        public bool RiskAssessmentAnswer2 { get; set; }
        public bool RiskAssessmentAnswer3 { get; set; }
        public bool RiskAssessmentAnswer4 { get; set; }
        public bool RiskAssessmentAnswer5 { get; set; }
        public string RiskAssessmentComments { get; set; }

        public ProcedureDeviationApprovalType ImmediateApprovalsApprover1Type { get; set; }
        public string ImmediateApprovalsApprover1Title { get; set; }
        public string ImmediateApprovalsApprover1Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia ImmediateApprovalsApprover1ObtainedVia { get; set; }
        public DateTime? ImmediateApprovalsApprover1ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType ImmediateApprovalsApprover2Type { get; set; }
        public string ImmediateApprovalsApprover2Title { get; set; }
        public string ImmediateApprovalsApprover2Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia ImmediateApprovalsApprover2ObtainedVia { get; set; }
        public DateTime? ImmediateApprovalsApprover2ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType TemporaryApprovalsApprover1Type { get; set; }
        public string TemporaryApprovalsApprover1Title { get; set; }
        public string TemporaryApprovalsApprover1Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia TemporaryApprovalsApprover1ObtainedVia { get; set; }
        public DateTime? TemporaryApprovalsApprover1ApprovedDateTime { get; set; }

        public ProcedureDeviationApprovalType TemporaryApprovalsApprover2Type { get; set; }
        public string TemporaryApprovalsApprover2Title { get; set; }
        public string TemporaryApprovalsApprover2Name { get; set; }
        public ProcedureDeviationApprovalObtainedVia TemporaryApprovalsApprover2ObtainedVia { get; set; }
        public DateTime? TemporaryApprovalsApprover2ApprovedDateTime { get; set; }

        public string CancelledBy { get; set; }
        public DateTime? CancelledDateTime { get; set; }
        public string CancelledReason { get; set; }
    }
}