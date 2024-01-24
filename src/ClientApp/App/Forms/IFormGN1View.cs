using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormGN1View : IAddEditBaseFormView
    {
        event Action FormLoad;
        event Action ExpandPlanningWorksheetContentClicked;
        event Action ExpandRescuePlanContentClicked;
        event Action SaveAndEmailButtonClicked;
        event Action HistoryButtonClicked;
        event Action BrowseFunctionalLocationButtonClicked;        
        event Action AddTradeChecklistButtonClicked;
        event Action EditTradeChecklistButtonClicked;
        event Action RemoveTradeChecklistButtonClicked;
        event Action CloneTradeChecklistButtonClicked;
        event Action SelectedCSELevelChanged;
        event Action WaitingApprovalButtonClicked;

        event Action<FormApproval> PlanningWorksheetApprovalSelected;
        event Action<FormApproval> PlanningWorksheetApprovalUnselected;
        event Action<FormApproval> RescuePlanApprovalSelected;
        event Action<FormApproval> RescuePlanApprovalUnselected;

        event Action<TradeChecklist> TradeChecklistConstFieldMaintCoordApprovalSelected;
        event Action<TradeChecklist> TradeChecklistConstFieldMaintCoordApprovalUnselected;

        event Action<TradeChecklist> TradeChecklistOpsCoordApprovalSelected;
        event Action<TradeChecklist> TradeChecklistOpsCoordApprovalUnselected;

        event Action<TradeChecklist> TradeChecklistAreaManagerApprovalSelected;
        event Action<TradeChecklist> TradeChecklistAreaManagerApprovalUnselected;

        DateTime ValidTo { get; set; }
        DateTime ValidFrom { get; set; }
        string JobDescription { get; set; }
        string SelectedCSELevel { get; set; }
        List<string> CSELevelValues { set; } 
        string PlanningWorksheetContent { get; set; }
        string PlanningWorksheetPlainTextContent { get; }
        string RescuePlanContent { get; set; }
        string RescuePlanPlainTextContent { get; }
        List<FormApproval> PlanningWorksheetApprovals { set; get; }
        List<FormApproval> RescuePlanApprovals { set; get; }                
        List<DocumentLink> DocumentLinks { get; set; }
        User CreatedByUser { set; }
        DateTime CreatedDateTime { set; }
        User LastModifiedByUser { set; }
        DateTime LastModifiedDateTime { set; }

        TradeChecklist SelectedTradeChecklist { get; }
        List<TradeChecklist> TradeChecklists { get; set; }
        void ActivateFirstTradeChecklistRowAndEnableButtons();
        DialogResult ShowRemoveSelectedTradeChecklistMessage();

        FunctionalLocation SelectedFunctionalLocation { get; set; }
        string LocationText { get; set; }
        bool HistoryButtonEnabled { set; }        

        DialogResultAndOutput<FunctionalLocation> ShowFunctionalLocationSelector(FunctionalLocation functionalLocation);

        void DisplayExpandedPlanningWorksheetContentForm();
        void DisplayExpandedRescuePlanContentForm();
        
        DialogResult ShowFormWillNeedReapprovalQuestion();        

        void SetErrorForNoFunctionalLocationSelected();
        void SetErrorForValidFromMustBeBeforeValidTo();
        void SetErrorForNoCSELevelSelected();
        void SetErrorForNoJobDescription();
        void SetErrorForNoTradeChecklists();

        void CollapsePlanningWorksheetAndTradeChecklistSections();
        void ExpandPlanningWorksheetAndTradeChecklistSections();

        void HideTradeChecklistApprovalColumns();
        void ShowTradeChecklistApprovalColumns();
        void DisableCseLevelSelection();
        //ayman enable/disable waiting for approval button
        void EnableWaitingApprovalButton();
        void DisableWaitingApprovalButton();

    }
}