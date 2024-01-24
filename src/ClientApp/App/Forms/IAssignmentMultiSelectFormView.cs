using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAssignmentMultiSelectFormView : IBaseForm
    {
        List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments { set; get; }
        List<WorkAssignment> SelectedAssignments { get; }
        string SiteName { set; }
        void ShowMultiSelectDialog(List<WorkAssignment> selectedWorkAssignments);
        void CloseForm();
        void SetDialogResult(DialogResult dialogResult);
        DialogResult DialogResult { get; }
    }
}
