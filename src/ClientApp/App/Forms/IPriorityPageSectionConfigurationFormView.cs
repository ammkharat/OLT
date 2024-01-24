using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IPriorityPageSectionConfigurationFormView : IBaseForm
    {
        event Action SaveAndCloseClicked;
        event Action ClearPreferencesClicked;
        event Action CancelClicked;

        string FormTitle { set; }
        bool DefaultToExpanded { get; set; }
        void HideWorkAssignmentSection();
        void ShowWorkAssignmentSection();
        void SetWorkAssignments(List<WorkAssignment> allWorkAssignmentsForSite, List<WorkAssignment> selectedWorkAssignments);        
        List<WorkAssignment> SelectedWorkAssignments { get; }
        bool ClearPreferencesButtonEnabled { set; }
    }
}
