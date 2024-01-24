using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormView : IAddEditBaseFormView
    {
        event Action AddFunctionalLocationButtonClicked;
        event Action RemoveFunctionalLocationButtonClicked;
        event Action FormLoad;
        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;
        event Action ExpandClicked;
        event Action SaveAndEmailButtonClicked;        
        event Action ValidityDatesChanged;
        event Action WaitingApprovalButtonClicked; // Swapnil Patki For DMND0005325 Point Number 7
        List<DocumentLink> DocumentLinks { set; get; }
        List<FunctionalLocation> FunctionalLocations { set; get; }
        DateTime ValidTo { get; set; }
        DateTime ValidFrom { get; set; }
        string Content { get; set; }
        string PlainTextContent { get; }

        FunctionalLocation SelectedFunctionalLocation { get; }
        List<FormApproval> Approvals { set; get; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }
        DialogResultAndOutput<List<FunctionalLocation>> ShowFunctionalLocationSelector(List<FunctionalLocation> initialUserFLOCSelections);
        void DisplayExpandedLogCommentForm();
        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForValidFromMustBeBeforeValidTo();
        DialogResult ShowFormWillNeedReapprovalQuestion();


        //ayman enable/disable waiting for approval button
        void EnableWaitingForApprovalButton();
        void DisableWaitingForApprovalButton();
    }
}
