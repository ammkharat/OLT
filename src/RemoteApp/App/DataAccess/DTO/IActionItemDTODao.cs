using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IActionItemDTODao : IDao
    {
        List<ActionItemDTO> QueryByFunctionalLocationsAndStatusAndDateRange(IFlocSet flocSet, ActionItemStatus[] actionItemStatuses, DateTime dateRangeBegin, DateTime? dateRangeEnd, List<long> readableVisibilityGroupIds);
        List<ActionItemDTO> QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(
                IFlocSet flocSet, ActionItemStatus[] actionItemStatuses,
                    DateTime dateRangeBegin, DateTime? dateRangeEnd, WorkAssignment workAssignment, List<long> readableVisibilityGroupIds);
        List<ActionItemDTO> QueryByPriorityPageCriteria(
            IFlocSet flocSet,
            List<ActionItemStatus> actionItemStatuses,
            DateTime dateRangeBegin,
            DateTime dateRangeEnd,
            DateTime noEndDateFrom,
            bool includeWorkAssignmentInCondition,
            WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds);

        List<ActionItemDTO> QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(IFlocSet flocSet, DateTime dateRangeBegin, UserShift userShift, List<long> readableVisibilityGroupIds);
        List<ActionItemDTO> QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
            IFlocSet flocSet, DateTime dateRangeBegin, UserShift userShift, WorkAssignment workAssignment, List<long> readableVisibilityGroupIds);

        List<ActionItemDTO> QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(IFlocSet flocSet, WorkAssignment assignment, DateTime startDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds);
        List<ActionItemDTO> QueryByParentFunctionalLocationsAndDateRange(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds);


    }
}