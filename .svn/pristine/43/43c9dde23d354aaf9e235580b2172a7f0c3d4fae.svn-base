using System;
using Com.Suncor.Olt.Client.Controls.Reporting;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    public class DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator
    {
        private readonly IDateRangeShiftRoleAndWorkAssignmentReportParametersControl control;
        private string errorMessage = string.Empty;

        public DateRangeShiftRoleAndWorkAssignmentReportParametersControlValidator(IDateRangeShiftRoleAndWorkAssignmentReportParametersControl control)
        {
            this.control = control;
        }

        public bool IsValid
        {
            get
            {
                errorMessage = string.Empty;
               
                if (!DatesAreInCorrectOrder() || !ShiftsAreInCorrectOrder())
                {
                    errorMessage = StringResources.FromShiftBeforeToShift;
                    return false;
                }

                if (control.SelectedWorkAssignments.Count == 0 &&
                    !control.IncludeDataWithNoWorkAssignment)
                {
                    errorMessage = StringResources.AtLeastOneWorkAssignmentMustBeSelected;
                    return false;
                }

                if (control.SelectedFunctionalLocations.Count == 0)
                {
                    errorMessage = StringResources.AtLeastOneFlocMustBeSelected;
                    return false;
                }

                return true;
            }
        }

        private bool DatesAreInCorrectOrder()
        {
            DateTime startDate = 
                new DateTime(control.SelectedStartDate.Year, control.SelectedStartDate.Month, control.SelectedStartDate.Day );
            DateTime endDate = 
                new DateTime(control.SelectedEndDate.Year, control.SelectedEndDate.Month, control.SelectedEndDate.Day );

            return startDate <= endDate;
        }

        private bool ShiftsAreInCorrectOrder()
        {            
            ShiftPattern startShift = control.SelectedStartShiftPattern;
            ShiftPattern endShift = control.SelectedEndShiftPattern;
           
            Date startDate = control.SelectedStartDate;
            Date endDate = control.SelectedEndDate;

            UserShift startUserShift = new UserShift(startShift, startDate);
            UserShift endUserShift = new UserShift(endShift, endDate);

            return startUserShift.StartDateTime <= endUserShift.EndDateTime;
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}
