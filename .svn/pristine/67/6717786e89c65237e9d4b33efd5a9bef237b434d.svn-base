using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IActionItemService
    {
        /// <summary>
        ///     Get actionItem by actionItem Id
        /// </summary>
        /// <param name="actionItemId">actionItem Id</param>
        /// <returns></returns>
        [OperationContract]
        ActionItem QueryById(long actionItemId);

        [OperationContract]
        ActionItem QueryReadingBySite(long siteId);

        [OperationContract]
        List<TrackerReport> GetTrackersByAidId(long aidid,DateTime startDate, DateTime Enddate);      //ayman action item reading

        /// <summary>
        ///     Adds an Action Item to the database, return true if save successed, otherwise false
        /// </summary>
        /// <param name="actionItem"></param>
        /// <returns></returns>
        [OperationContract]
        ActionItem Insert(ActionItem actionItem);

        [OperationContract]
        List<ActionItemDTO> QueryDTOByFunctionalLocationsAndDisplayLimitsAndWorkAssignment(IFlocSet flocSet,
            ActionItemStatus[] actionItemStatuses, WorkAssignment assignment, Range<Date> dateRange,
            List<long> readableVisibilityGroupIds);

        /// <summary>
        ///     Gets All the dto for a list of functional locations that are within the display limits
        /// </summary>
        [OperationContract]
        List<ActionItemDTO> QueryDTOsByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            ActionItemStatus[] actionItemStatuses, Range<Date> range, List<long> readableVisibilityGroupIds);

        [OperationContract(Name = "UpdateActionItem")]
        List<NotifiedEvent> Update(ActionItem respondTo);

        [OperationContract(Name = "UpdateActionItemAndComment")]
        List<NotifiedEvent> Update(ActionItem respondTo, string logComment, ShiftPattern shiftPattern,
            bool isOperatingEngineerLog, WorkAssignment workAssignment, Role createdByRole);

        /// <summary>
        ///     Updates the status of All the action item that doesn't require respond to complete
        /// </summary>
        [OperationContract]
        void UpdateAllResponseNotRequiredActionItemsToCompleteWhenShiftEndHasPassed(Site site);

        [OperationContract]
        void ClearActionItemsAtOrBelowFlocs(List<FunctionalLocation> flocList);

        [OperationContract]
        List<ActionItemDTO> QueryDTOByFunctionalLocationsForCurrentShiftOrIfResponseRequiredWithDisplayLimits(
            IFlocSet flocSet, ShiftPattern shiftPattern, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ActionItemDTO>
        QueryDTOByFunctionalLocationsAndWorkAssignmentForCurrentShiftOrIfResponseRequiredWithDisplayLimits(
            IFlocSet flocSet, ShiftPattern shiftPattern, WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ActionItemDTO> QueryDTOByPriorityPageCriteria(
            IFlocSet flocSet,
            List<ActionItemStatus> actionItemStatuses,
            DateTime dateRangeBegin,
            DateTime dateRangeEnd,
            bool queryByWorkAssignment,
            WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<NotifiedEvent> RemoveCurrentActionItemsForActionItemDefinition(ActionItemDefinition actionItemDefinition,
            DateTime currentTimeAtSite);

        [OperationContract]
        List<NotifiedEvent> RemoveAllUnrespondedToActionItemsForActionItemDefinition(ActionItemDefinition definition);

        [OperationContract]
        bool CurrentActionItemsExistForActionItemDefinition(ActionItemDefinition actionItemDefinition,
            DateTime currentTimeAtSite);

        [OperationContract]
        List<ActionItemDTO> QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange(IFlocSet flocSet,
            WorkAssignment assignment, DateTime startDateTime, DateTime endDateTime,
            List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ActionItemDTO> QueryDTOsByParentFunctionalLocationsAndDateRange(IFlocSet flocSet, DateTime startDateTime,
            DateTime endDateTime, List<long> readableVisibilityGroupIds);

        [OperationContract]
        List<ActionItemDefinition> QueryFutureActionItemDefinitions(RootFlocSet rootFlocSet, DateTime addDays, DateTime upperBound, List<long> readableVisibilityGroupIds);

        //ayman action item reading
        [OperationContract]
        ActionItemDefinition QueryActionItemDefinitionByActionItemCreatedByActionItemDefId(long actionItemDefinitionId);

        [OperationContract]
        List<CustomFieldDropDownValue> QueryCustomFieldDropDownValues(long customfieldid);
    }
}