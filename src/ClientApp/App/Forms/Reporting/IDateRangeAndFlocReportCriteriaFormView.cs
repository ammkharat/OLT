using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms.Reporting
{
    public interface IDateRangeAndFlocReportCriteriaFormView : IForm
    {
        event Action FormLoad;
        event Action RunReportButtonClick;
        event Action CancelButtonClick;

        void CloseForm();

        Date StartDate { get; set; }
        Date EndDate { get; set; }
        IList<FunctionalLocation> UserSelectedFunctionalLocations { get; }
        string Title { set; }

        void ClearErrors();
        void SetErrorForStartDate(string errorMessage);
        void SetErrorForEndDate(string errorMessage);
        void LaunchFunctionalLocationSelectionRequiredMessage();
    }
}
