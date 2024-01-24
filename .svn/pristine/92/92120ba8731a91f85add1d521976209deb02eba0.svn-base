using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public interface IDateRangeWithShiftAndWorkAssignmentAndFlocReportCriteriaFormView : IForm
    {
        event Action FormLoad;
        event Action FormClose;
        event Action RunReportButtonClick;
        event Action CancelButtonClick;

        List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments { set; }
        List<WorkAssignment> SelectedAssignments { get; }
        Date StartDate { get; set; }
        Date EndDate { get; set; }
        
        bool IncludeLogs { get; set; }
        bool IncludeDailyDirectives { get; set; }
        bool IncludeSummaryLogs { get; set; }

        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; set; }
        List<ShiftPattern> AvailableShiftPatterns { set; }
        string Title { set; }
        ShiftPattern StartShiftPattern { get; }
        ShiftPattern EndShiftPattern { get; }
        bool RunReportButtonEnabled { set; }

        void CloseForm();
        void SelectAllAssignments();

        void DisableIncludeLogsCapability();
        void DisableIncludeSummaryLogsCapability();
        void DisableIncludeDailyDirectivesCapability();

        void ClearErrors();
        void SetErrorForStartDate(string message);
        void SetErrorForEndDate(string message);
        void SetErrorForFunctionalLocationSelectionRequired();
        void SetErrorForWorkAssignmentSelectionRequired();
        void SetErrorForMoreThanOneWorkAssignmentSelection();
        void SetSelectReportError();
        void HideReportGroupBox();
        void SelectAllFunctionalLocations();
    }
}
