using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public interface IDateRangeReportCriteriaFormView : IForm
    {
        event Action FormLoad;
        event Action FormClose;
        event Action RunReportButtonClick;
        event Action CancelButtonClick;

        Date StartDate { get; set; }
        Date EndDate { get; set; }

        List<ShiftPattern> AvailableShiftPatterns { set; }
        string Title { set; }
        ShiftPattern StartShiftPattern { get; }
        ShiftPattern EndShiftPattern { get; }
        bool RunReportButtonEnabled { set; }

        void CloseForm();
 
        void ClearErrors();
        void SetErrorForStartDate(string message);
        void SetErrorForEndDate(string message);
    }
}
