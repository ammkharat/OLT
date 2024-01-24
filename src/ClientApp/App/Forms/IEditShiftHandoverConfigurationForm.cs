using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditShiftHandoverConfigurationForm : IBaseForm
    {
        void ClearWorkAssignmentListBox();
        string ShiftHandoverType { get; set; }
        List<WorkAssignment> WorkAssignments { get; set; }
        void ClearErrors();
        void SetShiftHandoverTypeMissingError();
        void SetAtLeastOneWorkAssignmentNotSelectedError();
        List<ShiftHandoverQuestion> ShiftHandoverQuestions { set; }
        ShiftHandoverQuestion SelectedQuestion { get; set; }
        ShiftHandoverQuestion LaunchAddEditQuestionForm(ShiftHandoverQuestion question);
        void SetAtLeastOneQuestionRequiredError();
        void SelectFirstQuestion();
        bool UserIsSure();
        DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> workAssignments);
    }
}