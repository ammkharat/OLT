using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAssignmentConfigurationView : IBaseForm
    {
        List<WorkAssignment> Assignments { set; get; }
        WorkAssignment SelectedAssignment { get; set; }
        string SiteName { set; }
        DialogResult ShowEditAssignmentForm(WorkAssignment assignmentToEdit, List<WorkAssignment> assignments);
        DialogResult ShowCreateAssignmentForm(List<WorkAssignment> assignments);
        void CloseForm();
    }
}
