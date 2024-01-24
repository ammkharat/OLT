using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public interface IDateRangeWithActionItemReadingReportCriteriaFormView : IForm
    {
        event Action FormLoad;
        event Action FormClose;
        event Action RunReportButtonClick;
        event Action CancelButtonClick;
        event Action GetDefinitionsButtonClick;                    //ayman action item reading 

        List<ActionItemDefinition> ActionitemDefinitions { set; }

        //List<ActionItemResponseTracker> SelectedAssignments { get; }
        Date StartDate { get; set; }
        Date EndDate { get; set; }

        long SelectedAId { get; }

        //bool IncludeLogs { get; set; }
        //bool IncludeDailyDirectives { get; set; }
        //bool IncludeSummaryLogs { get; set; }

        //        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; set; }
        //List<ShiftPattern> AvailableShiftPatterns { set; }
        string Title { set; }
        //ShiftPattern StartShiftPattern { get; }
        //ShiftPattern EndShiftPattern { get; }
        bool RunReportButtonEnabled { set; }

        void CloseForm();
//        void SelectAllAssignments();

        //void DisableIncludeLogsCapability();
        //void DisableIncludeSummaryLogsCapability();
        //void DisableIncludeDailyDirectivesCapability();

        void ClearErrors();
        void SetErrorForStartDate(string message);
        void SetErrorForEndDate(string message);
        //void SetErrorForFunctionalLocationSelectionRequired();
        //void SetErrorForWorkAssignmentSelectionRequired();
        //void SetErrorForMoreThanOneWorkAssignmentSelection();
        //void SetSelectReportError();
        //void HideReportGroupBox();
        //void SelectAllFunctionalLocations();
         string RptType{get;}
         string ActionItemName{ get; }
         DevExpress.XtraCharts.ViewType graphtype { get;}
        
    }
}
