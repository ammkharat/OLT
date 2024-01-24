using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN6View : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action ExpandSection1Clicked;        
        event Action ExpandSection2Clicked;
        event Action ExpandSection3Clicked;        
        event Action ExpandSection4Clicked;
        event Action ExpandSection5Clicked;
        event Action ExpandSection6Clicked;
        event Action Section1NotApplicableToJobCheckedChanged;
        event Action Section2NotApplicableToJobCheckedChanged;
        event Action Section3NotApplicableToJobCheckedChanged;
        event Action Section4NotApplicableToJobCheckedChanged;
        event Action Section5NotApplicableToJobCheckedChanged;
        event Action Section6NotApplicableToJobCheckedChanged;
        event Action ExpandPreJobMeetingSignaturesClicked;
        event Action SaveAndEmailButtonClicked;
        event Action HistoryButtonClicked;
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;
        event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        List<FunctionalLocation> FunctionalLocations { set; get; }
        DateTime ValidTo { get; set; }
        DateTime ValidFrom { get; set; }

        string JobDescription { get; set; }
        string ReasonForCriticalLift { get; set; }

        string Section1Content { get; set; }
        string Section1PlainTextContent { get; }
        bool Section1NotApplicableToJob { get; set; }

        string Section2Content { get; set; }
        string Section2PlainTextContent { get; }
        bool Section2NotApplicableToJob { get; set; }

        string Section3Content { get; set; }
        string Section3PlainTextContent { get; }
        bool Section3NotApplicableToJob { get; set; }

        string Section4Content { get; set; }
        string Section4PlainTextContent { get; }
        bool Section4NotApplicableToJob { get; set; }

        string Section5Content { get; set; }
        string Section5PlainTextContent { get; }
        bool Section5NotApplicableToJob { get; set; }

        string Section6Content { get; set; }
        string Section6PlainTextContent { get; }
        bool Section6NotApplicableToJob { get; set; }

        string PreJobMeetingSignatures { get; set; }
        string PlainTextPreJobMeetingSignatures { get; }

        List<FormApproval> Approvals { set; get; }
        List<DocumentLink> DocumentLinks { get; set; }

        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }

        FunctionalLocation SelectedFunctionalLocation { get; }
        bool HistoryButtonEnabled { set; }
        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections);
        
        string DisplayExpandedContentForm(string text);
        
        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForValidFromMustBeBeforeValidTo();
        void SetErrorForJobDescriptionRequired();
        void SetErrorForReasonForCriticalLiftRequired();
        
        DialogResult ShowFormWillNeedReapprovalQuestion();
        DialogResult ShowFormWillNeedElectricalReapprovalQuestion();

        //ayman enable/disable waiting for approval button
        void EnableWaitingApprovalButton();
        void DisableWaitingApprovalButton();
    }
}
