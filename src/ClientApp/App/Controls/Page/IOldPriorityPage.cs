using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.Details;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    public interface IOldPriorityPage
    {
        IMainForm MainParentForm { get; }

        ITargetAlertActions TargetAlertActions { get; }
        List<TargetAlertDTO> TargetList { set; }
        List<TargetAlertDTO> SelectedTargetAlertDTOs { get; }

        IDeviationAlertActions DeviationAlertActions { get; }
        List<DeviationAlertDTO> DeviationAlertList { set; }
        List<DeviationAlertDTO> SelectedDeviationAlertDTOs { get;}

        ILabAlertActions LabAlertActions { get; }
        List<LabAlertDTO> LabAlertList { set; }
        List<LabAlertDTO> SelectedLabAlertDTOs { get; }

        IActionItemActions ActionItemActions { get; }
        List<ActionItemDTO> ActionItemList { set; }
        List<ActionItemDTO> SelectedActionItemDTOs { get; }

        IWorkPermitActions WorkPermitActions { get; }
        List<WorkPermitDTO> WorkPermitList { set; }
        List<WorkPermitDTO> SelectedWorkPermitDTOs { get; }

        List<ShiftHandoverQuestionnaireDTO> ShiftHandoverQuestionnaireList { set; }
        
        void DisableActionItemContextMenu();
        void DisableActionItemListView();
        void DisableTargetContextMenu();
        void DisableTargetListView();
        void DisableDeviationAlertContextMenu();
        void DisableDeviationAlertListView();
        void DisableLabAlertContextMenu();
        void DisableLabAlertListView();
        void DisablePermitContextMenu();
        void DisablePermitListView();
        void DisableShiftHandoverQuestionnaireListView();

        bool InvokeRequired { get; }
        
        IAsyncResult BeginInvoke(Delegate deleg);

        void AddActionItem(ActionItemDTO dto);
        void UpdateActionItem(ActionItemDTO dto);
        void RemoveActionItem(ActionItemDTO dto);
        void AddTargetAlert(TargetAlertDTO dto);
        void UpdateTargetAlert(TargetAlertDTO dto);
        void RemoveTargetAlert(TargetAlertDTO dto);
        void AddDeviationAlert(DeviationAlertDTO dto);
        void UpdateDeviationAlert(DeviationAlertDTO dto);
        void AddLabAlert(LabAlertDTO dto);
        void UpdateLabAlert(LabAlertDTO dto);
        void RemoveLabAlert(LabAlertDTO dto);
        void AddWorkPermit(WorkPermitDTO dto);
        void UpdateWorkPermit(WorkPermitDTO dto);
        void RemoveWorkPermit(WorkPermitDTO dto);
        void AddShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto);
        void RemoveShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto);
        void UpdateShiftHandoverQuestionnaire(ShiftHandoverQuestionnaireDTO dto);

        bool ContainsWorkPermit(WorkPermit permit);

        object Invoke(Delegate deleg);        
        object Invoke(Delegate deleg, object[] dtos);

        void SetPanelVisibility();

        bool IsDisposed { get; }
    }
}