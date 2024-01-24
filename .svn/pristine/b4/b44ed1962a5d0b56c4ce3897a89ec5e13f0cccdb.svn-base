using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN75AView : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action ExpandContentClicked;        
        event Action SaveAndEmailButtonClicked;
        event Action HistoryButtonClicked;
        event Action BrowseFunctionalLocationButtonClicked;
        event Action AssociateFormGN75BButtonClicked;
        event Action RemoveFormGN75BButtonClicked;
        event Action ViewFormGN75BButtonClicked;
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;
        event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7

        DateTime ValidTo { get; set; }
        DateTime ValidFrom { get; set; }
        string Content { get; set; }
        string PlainTextContent { get; }
        List<FormApproval> Approvals { set; get; }
        List<DocumentLink> DocumentLinks { get; set; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }

        FunctionalLocation SelectedFunctionalLocation { get; set; }
        bool HistoryButtonEnabled { set; }
        long? FormGN75BId { get; set; }
        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(FunctionalLocation functionalLocation);
        void DisplayExpandedContentForm();
        
        DialogResult ShowFormWillNeedReapprovalQuestion();
        DialogResult DisplayNoAssociatedGN75BFormDialog();

        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForValidFromMustBeBeforeValidTo();

        void EnableOrDisableGN75BButtonsDependingOnWhetherThereIsAGN75BFormSet();        
    
    //ayman enable/disable waiting for approval button 
        void EnableWaitingForApprovalButton();
        void DisableWaitingForApprovalButton();


    }
}
