using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormOvertimeView : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action SaveAndEmailButtonClicked;
        event Action HistoryButtonClicked;
        
        event Action AddButtonClicked;
        event Action CloneButtonClicked;
        event Action RemoveButtonClicked;

        event Action StartDateChanged;
        event Action EndDateChanged;

        event Action<FormApproval> ApprovalSelected;
        event Action<FormApproval> ApprovalUnselected;

        List<CraftOrTrade> AllCraftOrTrades { set; }
        List<Contractor> Contractors { set; }
        bool RemoveButtonEnabled { set; }
        List<OvertimeContractorDisplayAdapter> OnPremiseContractors { get; set;  }
        List<string> PrimaryLocations { set; }
        List<EdmontonPerson> PersonnelList { set; }
        string Trade { get; set; }
        List<FormApproval> Approvals { set; get; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }
        DateTime OvertimeStart { set; get; }
        DateTime OvertimeEnd { set; get; }
        OvertimeContractorDisplayAdapter SelectedPersonnel { get; }
        List<DocumentLink> DocumentLinks { get; set; }
        void AddOnPremiseContractor(OvertimeContractorDisplayAdapter overtimeContractorDisplayAdapter);
        void SetErrorForNoTrade();
        void SetErrorForOvertimePersonnel();
        void MakeOvertimePersonGridValidationIconsShowOrDisappear();
        void RemoveSelectedOnPremiseContractor();
        DialogResult ShowFormWillNeedReapprovalQuestion();
        void DisableApprovals();
        void ChangeButtonText();    // Minlge Story #4003, Change By : Swapnil, Changed On : 29 Mar 2016
    }
}