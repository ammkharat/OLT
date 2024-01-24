using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ActionItemService : IActionItemService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<ActionItemService>();
        private readonly IActionItemDefinitionDao actionItemDefinitionDao;
        private readonly IActionItemDao dao;
        private readonly IActionItemDTODao dtoDao;
        private readonly ILogService logService;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ITimeService timeService;
        private readonly IUserService userService;
        private readonly ICustomFieldDropDownValueDao customFieldDropDownValueDao;

        public ActionItemService() : this(
            new LogService(),
            new TimeService(),
            new UserService())
        {
        }

        public ActionItemService(
            ILogService logService,
            ITimeService timeService,
            IUserService userService)
        {
            dao = DaoRegistry.GetDao<IActionItemDao>();
            customFieldDropDownValueDao = DaoRegistry.GetDao<ICustomFieldDropDownValueDao>();           //ayman action item reading
            dtoDao = DaoRegistry.GetDao<IActionItemDTODao>();
            actionItemDefinitionDao = DaoRegistry.GetDao<IActionItemDefinitionDao>();
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            this.logService = logService;
            this.timeService = timeService;
            this.userService = userService;
        }


        // Used By Old Priority Page Presenter
        public List<ActionItemDTO> QueryDTOByFunctionalLocationsForCurrentShiftOrIfResponseRequiredWithDisplayLimits(
            IFlocSet flocSet, ShiftPattern shiftPattern, List<long> readableVisibilityGroupIds)
        {
            var siteConfiguration = siteConfigurationDao.QueryBySiteId(shiftPattern.Site.IdValue);
            var daysToDisplayActionItems = siteConfiguration.DaysToDisplayActionItems;

            var currentTimeAtSite = timeService.GetTime(shiftPattern.Site.TimeZone);
            var startDateRangeBegin = new Date(currentTimeAtSite.SubtractDays(daysToDisplayActionItems));
            var userShift = new UserShift(shiftPattern, currentTimeAtSite);
            return dtoDao.QueryByFunctionalLocationForShiftOrResponseRequiredAndDisplayLimits(flocSet,
                startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, readableVisibilityGroupIds);
        }



        // Used By Old Priority Page Presenter
        public List<ActionItemDTO>
            QueryDTOByFunctionalLocationsAndWorkAssignmentForCurrentShiftOrIfResponseRequiredWithDisplayLimits(
            IFlocSet flocSet, ShiftPattern shiftPattern, WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds)
        {
            var siteConfiguration = siteConfigurationDao.QueryBySiteId(shiftPattern.Site.IdValue);
            var daysToDisplayActionItems = siteConfiguration.DaysToDisplayActionItems;

            var currentTimeAtSite = timeService.GetTime(shiftPattern.Site.TimeZone);
            var startDateRangeBegin = new Date(currentTimeAtSite.SubtractDays(daysToDisplayActionItems));
            var userShift = new UserShift(shiftPattern, currentTimeAtSite);
            return dtoDao.QueryByFunctionalLocationAndWorkAssignmentForShiftOrResponseRequiredAndDisplayLimits(
                flocSet, startDateRangeBegin.CreateDateTime(Time.START_OF_DAY), userShift, workAssignment,
                readableVisibilityGroupIds);
        }


        public List<ActionItemDTO> QueryDTOByPriorityPageCriteria(
            IFlocSet flocSet,
            List<ActionItemStatus> actionItemStatuses,
            DateTime dateRangeBegin,
            DateTime dateRangeEnd,
            bool queryByWorkAssignment,
            WorkAssignment workAssignment,
            List<long> readableVisibilityGroupIds)
        {
            if (flocSet.FunctionalLocations.Count == 0)
            {
                return new List<ActionItemDTO>(0);
            }

            var site = flocSet.FunctionalLocations[0].Site;
            var startDateTimeFromDisplayLimits = GetStartDate(site);

            var dtos = dtoDao.QueryByPriorityPageCriteria(
                flocSet,
                actionItemStatuses,
                dateRangeBegin,
                dateRangeEnd,
                startDateTimeFromDisplayLimits,
                queryByWorkAssignment,
                workAssignment,
                readableVisibilityGroupIds);

            dtos = dtos.OrderByDescending(dto => dto.StartDateTime).ThenBy(dto => dto.FunctionalLocationNames).ToList();

            return dtos;
        }

        public List<ActionItemDTO> QueryDTOByFunctionalLocationsAndDisplayLimitsAndWorkAssignment(IFlocSet flocSet,
            ActionItemStatus[] actionItemStatuses, WorkAssignment assignment, Range<Date> dateRange,
            List<long> readableVisibilityGroupIds)
        {
            if (flocSet.FunctionalLocations.Count == 0)
            {
                return new List<ActionItemDTO>(0);
            }

            DateTime startDateTime;
            DateTime? endDateTime = null;

            if (dateRange == null)
            {
                var site = flocSet.FunctionalLocations[0].Site;
                startDateTime = GetStartDate(site);
            }
            else
            {
                var range = new DateRange(dateRange);
                startDateTime = range.SqlFriendlyStart;
                endDateTime = range.SqlFriendlyEnd;
            }

            var actionItemDtos =
                dtoDao.QueryByFunctionalLocationsAndStatusAndDateRangeAndWorkAssignment(flocSet, actionItemStatuses,
                    startDateTime, endDateTime, assignment, readableVisibilityGroupIds);

            return actionItemDtos;
        }

        public List<ActionItemDTO> QueryDTOsByFunctionalLocationsAndDateRange(IFlocSet flocSet,
            ActionItemStatus[] actionItemStatuses, Range<Date> range, List<long> readableVisibilityGroupIds)
        {
            var dateRange = new DateRange(range);

            var actionItemDtos = dtoDao.QueryByFunctionalLocationsAndStatusAndDateRange(
                flocSet, actionItemStatuses, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd,
                readableVisibilityGroupIds);

            return actionItemDtos;
        }

        public List<ActionItemDTO> QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange(IFlocSet flocSet,
            WorkAssignment assignment, DateTime startDateTime, DateTime endDateTime,
            List<long> readableVisibilityGroupIds)
        {
            return dtoDao.QueryByParentFunctionalLocationsAndWorkAssignmentAndDateRange(flocSet, assignment,
                startDateTime, endDateTime, readableVisibilityGroupIds);
        }

        public List<ActionItemDTO> QueryDTOsByParentFunctionalLocationsAndDateRange(IFlocSet flocSet,
            DateTime startDateTime, DateTime endDateTime, List<long> readableVisibilityGroupIds)
        {
            return dtoDao.QueryByParentFunctionalLocationsAndDateRange(flocSet, startDateTime, endDateTime,
                readableVisibilityGroupIds);
        }

        public List<ActionItemDefinition> QueryFutureActionItemDefinitions(RootFlocSet rootFlocSet, DateTime addDays, DateTime upperBound,
            List<long> readableVisibilityGroupIds)
        {
            return actionItemDefinitionDao.QueryFutureActionItemDefinitions(rootFlocSet, addDays, upperBound, readableVisibilityGroupIds);
        }

        public ActionItem QueryById(long actionItemId)
        {
            return dao.QueryById(actionItemId);
        }

        //ayman action item reading
        public List<TrackerReport> GetTrackersByAidId(long aididDateTime,DateTime startDate, DateTime Enddate)
        {
            return dao.QueryTrackersByAidId(aididDateTime ,startDate,  Enddate);
        }

        public List<CustomFieldDropDownValue> QueryCustomFieldDropDownValues(long customfieldid)
        {
          return customFieldDropDownValueDao.QueryByCustomFieldId(customfieldid);
        }

        //ayman action item reading
        public ActionItem QueryReadingBySite(long siteId)
        {
            return dao.QueryById(siteId);
        }

        public bool QueryReadingByAIDId(long actionItemDefinitionId)
        {
            return dao.QueryReadingByAIDId(actionItemDefinitionId);
        }

        //ayman action item reading
        public ActionItemDefinition QueryActionItemDefinitionByActionItemCreatedByActionItemDefId(long createdbyactionitemdefId)
        {
            return actionItemDefinitionDao.QueryById(createdbyactionitemdefId);
        }


        public ActionItem Insert(ActionItem actionItem)
        {
            dao.Insert(actionItem);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemCreate, actionItem);
            return actionItem;
        }

        public List<NotifiedEvent> Update(ActionItem actionItem)
        {
            return UpdateFromWithinService(actionItem);
        }

        public List<NotifiedEvent> Update(ActionItem actionItem, string logComment, ShiftPattern shiftPattern,
            bool isOperatingEngineerLog, WorkAssignment workAssignment, Role createdByRole)
        {
            dao.Update(actionItem);

            var site = actionItem.FunctionalLocations[0].Site;
            var now = timeService.GetTime(site.TimeZone);

            var actionItemLog = new Log(null,
                null,
                null,
                DataSource.ACTION_ITEM,
                actionItem.FunctionalLocations,
                false,
                false,
                false,
                false,
                false,
                false,
                logComment,
                logComment,
                now,
                shiftPattern,
                actionItem.LastModifiedBy,
                actionItem.LastModifiedBy,
                now,
                now,
                false,
                isOperatingEngineerLog,
                createdByRole,
                null,
                LogType.Standard,
                false,
                workAssignment,actionItem.CustomFieldEntries,actionItem.CustomFields);              //ayman custom fields DMND0010030

            var notifiedEvents = new List<NotifiedEvent>();

            notifiedEvents.AddRange(logService.InsertForActionItem(actionItemLog, actionItem));

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemUpdate, actionItem));

            return notifiedEvents;
        }

        public void UpdateAllResponseNotRequiredActionItemsToCompleteWhenShiftEndHasPassed(Site site)
        {
            var siteDateTime = timeService.GetTime(site.TimeZone);

            dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus.Complete, site,
                siteDateTime,
                userService.GetRemoteAppUser());

            logger.InfoFormat("End of Shift. Updating unresponded action items for site: {0}", site.Name);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemRefresh, site);
            
            //ayman generic forms (just added this comment to include this file in the release)
            ////ayman action item new status
            //// we need to deal with new status IefSubmitted as complete
            //dao.UpdateAllResponseNotRequiredActionItemsWhenShiftEndHasPassed(ActionItemStatus.IefSubmitted, site,
            //    siteDateTime,
            //    userService.GetRemoteAppUser());
            //logger.InfoFormat("End of Shift. Updating unresponded action items for site: {0}", site.Name);
            //ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemRefresh, site);
        }

        public void ClearActionItemsAtOrBelowFlocs(List<FunctionalLocation> flocList)
        {
            if (flocList.Count == 0)
                return;

            var systemUser = userService.GetRemoteAppUser();

            var actionItems = dao.QueryAllActionItemsNeedingAttention(flocList);
            foreach (var actionItem in actionItems)
            {
                if (actionItem.IsNot(ActionItemStatus.Cleared))
                {
                    actionItem.LastModifiedBy = systemUser;
                    actionItem.SetStatus(ActionItemStatus.Cleared, systemUser,
                        timeService.GetTime(flocList[0].Site.TimeZone));
                    UpdateFromWithinService(actionItem);
                }
            }
        }

        public List<NotifiedEvent> RemoveCurrentActionItemsForActionItemDefinition(
            ActionItemDefinition actionItemDefinition, DateTime currentTimeAtSite)
        {
            var actionItems = QueryCurrentActionItemsForActionItemDefinition(actionItemDefinition, currentTimeAtSite);
            return RemoveActionItems(actionItems, actionItemDefinition.LastModifiedBy,
                actionItemDefinition.LastModifiedDate);
        }

        public List<NotifiedEvent> RemoveAllUnrespondedToActionItemsForActionItemDefinition(
            ActionItemDefinition definition)
        {
            var actionItems = dao.QueryUnrespondedToActionItemsByDefinitionId(definition.IdValue);
            return RemoveActionItems(actionItems, definition.LastModifiedBy, definition.LastModifiedDate);
        }

        public bool CurrentActionItemsExistForActionItemDefinition(ActionItemDefinition actionItemDefinition,
            DateTime currentTimeAtSite)
        {
            var actionItems = QueryCurrentActionItemsForActionItemDefinition(actionItemDefinition, currentTimeAtSite);
            return actionItems.Count > 0;
        }


        private DateTime GetStartDate(Site site)
        {
            var siteConfiguration = siteConfigurationDao.QueryBySiteId(site.IdValue);
            var range = DateRangeUtilities.GetDefaultDateRangeForActionItems(site, siteConfiguration, timeService);
            return range.LowerBound.CreateDateTime(Time.START_OF_DAY);
        }

        private List<NotifiedEvent> UpdateFromWithinService(ActionItem actionItem)
        {
            dao.Update(actionItem);

            var notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemUpdate, actionItem));
            return notifiedEvents;
        }

        private List<NotifiedEvent> RemoveActionItems(List<ActionItem> actionItems, User lastModifiedBy,
            DateTime lastModifiedDate)
        {
            var notifiedEvents = new List<NotifiedEvent>();

            foreach (var actionItem in actionItems)
            {
                actionItem.LastModifiedBy = lastModifiedBy;
                actionItem.LastModifiedDate = lastModifiedDate;
                dao.Remove(actionItem);
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemDelete, actionItem));
            }

            return notifiedEvents;
        }

        private List<ActionItem> QueryCurrentActionItemsForActionItemDefinition(
            ActionItemDefinition actionItemDefinition, DateTime currentTimeAtSite)
        {
            return dao.QueryCurrentActionItemsForActionItemDefinition(actionItemDefinition, currentTimeAtSite);
        }
    }
}