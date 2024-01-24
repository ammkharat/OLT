using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Domain;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAssignmentAndFunctionalLocationsSelectionForm : IBaseForm
    {
        event Action AcceptClicked;
        event Action CancelClicked;
        event Action LoadPreviousFlocsClicked;
        event Action NoAssignmentCheckedChanged;
        event Action ClearFlocsClicked;
        event Action SelectedAssignmentCategoryChanged;
        event Action SelectedAssignmentChanged;
        event Action GroupGridUpdated;

        WorkAssignment SelectedAssignment { get; set; }
        IList<WorkAssignment> Assignments { set; }
        string SelectedAssignmentCategory { get; set; }
        List<string> AssignmentCategories { set; }
        IList<FunctionalLocation> UserCheckedFunctionalLocations { get; set; }
        List<FunctionalLocation> AllCheckedFunctionalLocations { get; }
        List<long> SelectedReadableVisibilityGroupIds { get; set; }
        bool NoAssignmentSelected { get; }
        List<VisibilityGroupLoginDisplayAdapter> VisibilityGroupList { get; set; }
        string WriteGroupList { set; }
        bool FormContentVisible { set; }
        void CloseForm(DialogResult dialogResult);
        void DisableAssignmentSelection();
        void EnableAssignmentSelection();
        void ClearSelectedAssignment();
        void SelectFirstAssignment();
        void LaunchFunctionalLocationSelectionRequiredMessage();
        void LaunchAtLeastOneReadableVisibilityGroupRequiredMessage();        
        DialogResult ShowNoAssignmentSelectedWarning();
        void DisableSelectAssignmentOption();
        void SetAtLeastOneMatchingReadAndWriteGroupRequiredError();
        void SetAtLeastOneReadableVisibilityGroupRequiredMessage();
        void ClearErrors();
        void HideVisibilityGroupArea();
    }
}
