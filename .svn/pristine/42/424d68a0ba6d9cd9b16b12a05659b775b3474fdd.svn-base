using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls.Reporting
{
    public interface IDateRangeShiftRoleAndWorkAssignmentReportParametersControl : IReportParametersControl
    {
        ShiftPattern SelectedStartShiftPattern { get; set; }
        ShiftPattern SelectedEndShiftPattern { get; set; }
        Date SelectedStartDate { get; set; }
        Date SelectedEndDate { get; set; }
        List<ShiftPattern> AvailableShiftPatterns { set; }

        IList<FunctionalLocation> SelectedRootFunctionalLocations { get; set; }
        List<FunctionalLocation> SelectedFunctionalLocations { get; }

        List<WorkAssignment> SelectedWorkAssignments { get; }
        bool IncludeDataWithNoWorkAssignment { get; }
        string IncludeDataWithNoWorkAssignmentText { set; }
        void SetAvailableWorkAssignments(List<WorkAssignment> assignments);

        List<Role> SelectedRoles { get; }
        List<string> SelectedCategories { get; }
        void SelectRolesCategoriesAndWorkAssignments(
            List<long> selectedRoleIds, 
            List<string> selectedCategories,
            List<long> selectedWorkAssignmentIds,
            bool includeDataWithNoWorkAssignment);

        List<AssignmentSectionUnitReportGroupBy> GroupByItems { set; }
        AssignmentSectionUnitReportGroupBy SelectedGroupBy { get; set; }

        /* amit shukla Flexible shift handover RITM0185797*/
        bool ShowFlexibleShiftHandoverData { get; }
    
        /**/
    }
}
