using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    interface IMarkedAsNotReadReportFormView
    {
        void CloseForm();

        Date StartDate { get; set; }
        Date EndDate { get; set; }
       // bool LogsChecked { get; set; }
      //  bool SummaryLogsChecked { get; set; }
        bool DirectivesChecked { get; set; }
        bool ShiftHandoverChecked { get; set; }
       
      //  bool FlexiShiftHandoverChecked { get; set; }
        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; }

        void ClearErrors();
        void SetErrorForStartDate(string errorMessage);
        void SetErrorForEndDate(string errorMessage);
        void SetSelectReportError(string errorMessage);
        void LaunchFunctionalLocationSelectionRequiredMessage();
    }
}
