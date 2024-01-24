using System;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DateRangeReportParametersControlValidator
    {
        private readonly IDateRangeReportParametersControl control;
        private string errorMessage = string.Empty;

        public DateRangeReportParametersControlValidator(IDateRangeReportParametersControl control)
        {
            this.control = control;
        }

        public bool IsValid
        {
            get
            {
                errorMessage = string.Empty;
                if (!DatesAreInCorrectOrder())
                {
                    errorMessage = StringResources.StartDateBeforeEndDate;
                    return false;
                }
                return true;
            }
        }

        private bool DatesAreInCorrectOrder()
        {
            DateTime startDate =
                new DateTime(control.SelectedStartDate.Year, control.SelectedStartDate.Month,
                    control.SelectedStartDate.Day);
            DateTime endDate =
                new DateTime(control.SelectedEndDate.Year, control.SelectedEndDate.Month, control.SelectedEndDate.Day);

            return startDate <= endDate;
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}