using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN24View : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action ExpandContentClicked;
        event Action ExpandPreJobMeetingSignaturesClicked;
        event Action SaveAndEmailButtonClicked;
        event Action HistoryButtonClicked;
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;
        event Action IsTheSafeWorkPlanForWorkInTheAlkylationUnitChanged;
        event Action IsTheSafeWorkPlanForPSVRemovalOrInstallationChanged;
        event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        List<FunctionalLocation> FunctionalLocations { set; get; }
        DateTime ValidTo { get; set; }
        DateTime ValidFrom { get; set; }
        bool IsTheSafeWorkPlanForPSVRemovalOrInstallation { get; set; }
        bool IsTheSafeWorkPlanForWorkInTheAlkylationUnit { get; set; }
        FormGN24AlkylationClass AlkylationClass { get; set; }
        string Content { get; set; }
        string PlainTextContent { get; }
        List<FormApproval> Approvals { set; get; }
        List<DocumentLink> DocumentLinks { get; set; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }

        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FormGN24AlkylationClass> AlkylationClasses { set; }
        bool AlkylationClassSelectionEnabled { set; }
        bool HistoryButtonEnabled { set; }
        string PreJobMeetingSignatures { get; set; }
        string PlainTextPreJobMeetingSignatures { get; }
        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections);
        void DisplayExpandedContentForm();
        void DisplayExpandedPreJobMeetingSignaturesForm();
        DialogResult ShowFormWillNeedReapprovalQuestion();

        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForValidFromMustBeBeforeValidTo();
        void SetErrorForNoAlkylationClassSelected();

        //ayman enable/disable waiting for approval button
        void EnableWaitingForApprovalButton();
        void DisableWaitingForApprovalButton();
    }
}
