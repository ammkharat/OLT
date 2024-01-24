using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IProcedureDeviationFormView : IFormView
    {
        event Action HistoryClicked;
        event Action CompleteButtonClicked;
        event Action CompleteAndRevertButtonClicked;
        event Action CompleteAndPermanentRevisionButtonClicked;
        event Action CancelDeviationButtonClicked;
        event Action SaveAndEmailButtonClicked;
        event Action ExpandClicked;
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action DeviationTypeChanged;
        event Action ConvertDeviationButtonClicked;

        event Action<ProcedureDeviationFormApproval> ImmediateApprovalSelected;
        event Action<ProcedureDeviationFormApproval> ImmediateApprovalUnselected;
        event Action<ProcedureDeviationFormApproval> TemporaryApprovalSelected;
        event Action<ProcedureDeviationFormApproval> TemporaryApprovalUnselected;

        ProcedureDeviation ProcedureDeviation { set; }

        string LocationEquipmentNumber { get; set; }

        string FormStatus { set; }

        int NumberOfExtensions { set; }
        List<Comment> ReasonForExtensions { set; }

        ProcedureDeviationType ProcedureDeviationType { get; set; }
        bool PermanentRevisionRequired { get; set; }
        bool RevertedBackToOriginal { get; set; }

        string OperatingProcedureNumber { get; set; }
        string OperatingProcedureTitle { get; set; }
        OperatingProcedureLevel OperatingProcedureLevel { get; set; }
        List<OperatingProcedureLevel> OperatingProcedureLevels { set; }

        bool EnableDeviationType { set; }

        bool EnableCompleteButton { set; }
        bool EnableCancelDeviationButton { set; }
        bool EnableSaveAndEmailButton { set; }
        string SaveAndEmailButtonText { set; }
        bool EnableSaveAndCloseButton { set; }

        bool EnableConvertDeviationButton { set; }

        List<CauseDeterminationWhyType> CauseDeterminationCauses { get; set; }
        string CauseDeterminationComments { get; set; }

        CorrectiveActionFixDocumentDurationType FixDocumentDurationType { get; set; }
        bool HasCorrectiveActionIlpNumber { get; set; }
        string CorrectiveActionIlpNumber { get; set; }
        bool HasCorrectiveActionWorkRequestNumber { get; set; }
        string CorrectiveActionWorkRequestNumber { get; set; }
        bool HasCorrectiveActionOtherComments { get; set; }
        string CorrectiveActionOtherComments { get; set; }

        bool CauseDeterminationCauseSelected { get; }
        bool FixDocumentDurationTypeSelected { get; }

        List<ProcedureDeviationFormApproval> ImmediateApprovals { set; get; }
        List<ProcedureDeviationFormApproval> TemporaryApprovals { set; get; }
        
        List<string> ImmediateApprovalsObtainedViaList { set; }

        bool AffectsToe { get; set; }
        List<ProcedureDeviationFormAttendee> RiskAssessmentAttendees { get; set; }
        bool RiskAssessmentAnswer1 { get; set; }
        bool RiskAssessmentAnswer2 { get; set; }
        bool RiskAssessmentAnswer3 { get; set; }
        bool RiskAssessmentAnswer4 { get; set; }
        bool RiskAssessmentAnswer5 { get; set; }
        string RiskAssessmentComments { get; set; }

        bool HasAtLeastOneRiskAssessmentYesAnswer { get; }
        bool RiskAssessmentAnswer1NotSet { get; }
        bool RiskAssessmentAnswer2NotSet { get; }
        bool RiskAssessmentAnswer3NotSet { get; }
        bool RiskAssessmentAnswer4NotSet { get; }
        bool RiskAssessmentAnswer5NotSet { get; }

        void SetErrorForTechnicalSMERequired();

        void SetErrorForRiskAssessmentCommentsNotSet();

        void ResetRiskAssessmentAnswers();

        void SetErrorForValidFromIsBeforeCreatedDateTime();
        void SetErrorForValidFromIsInThePast();
        void SetErrorForValidToIsBeforeCreatedDateTime();
        void SetErrorForValidToIsInThePast();
        void SetErrorForValidFromMustBeBeforeValidTo();

        void SetErrorForLocationEquipmentNumberNotSet();
        void SetErrorForOperatingProcedureNumberNotSet();
        void SetErrorForOperatingProcedureTitleNotSet();
        void SetErrorForOperatingProcedureLevelNotSet();
        void SetErrorForDescriptionNotSet();

        void SetErrorWhy1ReasonNotSet();
        void SetErrorCauseDeterminationCommentsNotSet();

        void SetErrorCorrectiveActionNotSet();
        void SetErrorCorrectiveActionIlpNumberNotSet();
        void SetErrorCorrectiveActionWorkRequestNumberNotSet();
        void SetErrorCorrectiveActionOtherCommentsNotSet();
        void SetErrorForRiskAssessmentAnswer1NotSet();
        void SetErrorForRiskAssessmentAnswer2NotSet();
        void SetErrorForRiskAssessmentAnswer3NotSet();
        void SetErrorForRiskAssessmentAnswer4NotSet();
        void SetErrorForRiskAssessmentAnswer5NotSet();
    }
}