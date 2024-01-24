using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IAddEditLogTemplateFormView : ILogTemplateValidationAction
    {
        string LogTemplateName { get; set; }
        string LogTemplateText { get; set; }
        string LogTemplateTextAsPlainText { get; }
        List<LogTemplateAssignmentGridDisplayAdapter> LogTemplateAssignmentGridDisplayAdapters { get; set; }
        Site Site { set; }
        bool AppliesToLogs { get; set; }
        bool AppliesToSummaryLogs { get; set; }
        bool AppliesToDirectives { get; set; }
        void CloseForm();
        void SaveSucceededMessage();

        void SetErrorForAtLeastOneApplicationAreaIsRequired();
        void SetErrorForAssignmentAlreadyHasAnAutoInsertedTemplate(string errorMessage);

        DialogResultAndOutput<IList<WorkAssignment>> ShowWorkAssignmentSelector(List<WorkAssignment> selectedAssignments);
    }
}
