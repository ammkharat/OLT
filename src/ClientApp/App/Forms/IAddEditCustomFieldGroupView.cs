using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditCustomFieldGroupView : IBaseForm
    {
        string GroupName { get; set; }
        bool AppliesToLogs { get; set; }
        bool AppliesToSummaryLogs { get; set; }
        bool AppliesToDailyDirectives { get; set; }
        bool AppliesToActionItems { get; set; }             //ayman custom field
        List<WorkAssignment> WorkAssignments { get; set; }
        List<CustomField> CustomFields { get; set; }
        
        DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments);

        void AddField(CustomField field);
        void RemoveField(CustomField field);
        void RefreshFields();

        CustomField SelectedField { get; }
        bool ShouldShowPhTagIndicators { set; }
        CustomField ShowAddEditFieldForm(CustomField editObject);
        void SetDialogResultOk();
        void HideDirectiveLogsOption();

        void ClearAllErrors();
        void SetErrorForNoAssociatedWorkAssignments();
        void SetErrorForNoNameProvided();
        void SetErrorForDuplicateName();
        void SetErrorForDuplicateFieldName();
        void SetErrorForAtLeastOneFieldIsRequired();
        void SetErrorForAtLeastOneApplicationAreaIsRequired();
        void DisableMovingAndSuggestSaving();
    }
}
