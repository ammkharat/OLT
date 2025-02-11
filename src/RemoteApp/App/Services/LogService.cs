using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.PriorityPage;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;
using log4net;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LogService : ILogService
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<LogService>();

        private readonly ILogDao dao;        
        private readonly ILogDTODao dtoDao;
        private readonly ISiteConfigurationDao siteConfigurationDao;
        private readonly ILogReadDao logReadDao;
        private readonly ILogGuidelineDao logGuidelineDao;
        private readonly IFunctionalLocationDao functionalLocationDao;
        private readonly ILogCustomFieldEntryDao customFieldEntryDao;
        private readonly IShiftHandoverQuestionnaireAssociationDao shiftHandoverAssociationDao;

        private readonly ITimeService timeService;
        private readonly IEditHistoryService editHistoryService;
        private readonly IPlantHistorianService plantHistorianService;

        public LogService()
            : this(new TimeService(), new EditHistoryService(), GenericServiceRegistry.Instance.GetService<IPlantHistorianService>())
        {
        }

        public LogService(
            ITimeService timeService,
            IEditHistoryService editHistoryService, IPlantHistorianService plantHistorianService)
        {
            dao = DaoRegistry.GetDao<ILogDao>();
            dtoDao = DaoRegistry.GetDao<ILogDTODao>();
            logReadDao = DaoRegistry.GetDao<ILogReadDao>();
            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            logGuidelineDao = DaoRegistry.GetDao<ILogGuidelineDao>();
            functionalLocationDao = DaoRegistry.GetDao<IFunctionalLocationDao>();
            customFieldEntryDao = DaoRegistry.GetDao<ILogCustomFieldEntryDao>();
            shiftHandoverAssociationDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireAssociationDao>();

            this.timeService = timeService;
            this.editHistoryService = editHistoryService;
            this.plantHistorianService = plantHistorianService;
        }

        public Log QueryById(long id)
        {
            Log log = dao.QueryById(id);
            return log;
        }
      
        public List<LogDTO> QueryDTOById(List<long> ids)
        {
            return dtoDao.QueryById(ids);
        }

        public int CountOfLogsAssociatedToActionItem(long actionItemId)
        {
            return dao.QueryCountOfLogsAssociatedToActionItem(actionItemId);
        }

        public List<LogDTO> QueryDTOsByActionItemDefinition(long actionItemDefinitionId)
        {
            return dtoDao.QueryByActionItemDefinition(actionItemDefinitionId);
        }

        public List<LogDTO> QueryDTOsByWorkPermitEdmonton(long workPermitEdmontonId)
        {
            return dtoDao.QueryByWorkPermitEdmonton(workPermitEdmontonId);
        }

        public int CountOfLogsAssociatedToWorkPermitEdmonton(long workPermitEdmontonId)
        {
            return dao.QueryCountOfLogsAssociatedToWorkPermitEdmonton(workPermitEdmontonId);
        }

        public List<LogDTO> QueryDTOsByWorkPermitLubes(long workPermitLubesId)
        {
            return dtoDao.QueryByWorkPermitLubes(workPermitLubesId);
        }
        
        public List<LogDTO> QueryDTOsByWorkPermitMontreal(long workPermitMontrealId)
        {
            return dtoDao.QueryByWorkPermitMontreal(workPermitMontrealId);
        }

        //RITM0301321 Start mangesh
        public List<LogDTO> QueryDTOsByWorkPermitMuds(long workPermitMudsId)
        {
            return dtoDao.QueryByWorkPermitMuds(workPermitMudsId);
        }
        public int CountOfLogsAssociatedToWorkPermitMuds(long workPermitMudsId)
        {
            return dao.QueryCountOfLogsAssociatedToWorkPermitMuds(workPermitMudsId);
        }
        //RITM0301321 End

        public int CountOfLogsAssociatedToWorkPermitMontreal(long workPermitMontrealId)
        {
            return dao.QueryCountOfLogsAssociatedToWorkPermitMontreal(workPermitMontrealId);
        }

        public int CountOfLogsAssociatedToWorkPermitLubes(long workPermitLubesId)
        {
            return dao.QueryCountOfLogsAssociatedToWorkPermitLubes(workPermitLubesId);
        }

        public List<LogDTO> QueryDTOsByTargetAlert(long targetAlertId)
        {
            return dtoDao.QueryByTargetAlert(targetAlertId);
        }

        public int CountOfLogsAssociatedToTargetAlert(long targetAlertId)
        {
            return dao.QueryCountOfLogsAssociatedToTargetAlert(targetAlertId);
        }

        public List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntries(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            return customFieldEntryDao.QueryNumericCustomFieldEntriesForLogs(customFieldId, workAssignmentId, site, dateRange);
        }

        public List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntries(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            return customFieldEntryDao.QueryNonnumericCustomFieldEntriesForLogs(customFieldId, workAssignmentId, site, dateRange);
        }

        public int CountOfLogsAssociatedToActionItemDefinition(long actionItemDefinitionId)
        {
            return dao.QueryCountOfLogsAssociatedToActionItemDefinition(actionItemDefinitionId);
        }

        public List<LogDTO> QueryDTOsByActionItem(long actionItemId)
        {
            return dtoDao.QueryByActionItem(actionItemId);
        }

        public List<LogDTO> GetDailyDirectivesForDisplayByUserRootFlocs(Site site, IFlocSet flocSet, User readByUser, List<long> readableVisibilityGroupIds)
        {
            DateTime fromDate = SharedServiceUtilities.GetFromDateTimeForLogs(site, siteConfigurationDao, timeService);
            
            List<LogDTO> logDtos = dtoDao. QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
                LogType.DailyDirective, fromDate, null, flocSet, readByUser, readableVisibilityGroupIds);

            return logDtos;
        }

        public List<LogDTO> GetDailyDirectivesForDisplayByUserRootFlocsAndDateRange(IFlocSet flocSet, Range<Date> range, User readByUser, List<long> readableVisibilityGroupIds)
        {
            DateRange dateRange = new DateRange(range);

            List<LogDTO> logDtos = dtoDao.QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
                LogType.DailyDirective, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, readByUser, readableVisibilityGroupIds);

            return logDtos;
        }

        public List<LogDTO> GetOperatingEngineerLogsForDisplay(Site site, IFlocSet flocSet, List<long> readableVisibilityGroupIds)
        {
            // Is this really neccessary?
            if (flocSet == null || flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
            {
                throw new ApplicationException("No Functional Locations found.");
            }

            DateTime fromDate = SharedServiceUtilities.GetFromDateTimeForLogs(site, siteConfigurationDao, timeService);
            List<LogDTO> logDtos = dtoDao.QueryOpEngineerLogsByFunctionalLocation(flocSet, fromDate, readableVisibilityGroupIds);
            return logDtos;            
        }

        public List<LogDTO> GetLogsForDisplay(IFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds)
        {
            if (flocSet == null || flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
            {
                throw new ApplicationException("No Functional Locations found.");
            }

            List<LogDTO> logDtos = dtoDao.QueryByFunctionalLocations(flocSet, dateRange, readableVisibilityGroupIds);
            
            return logDtos;
        }

        //Added for view based on role permisiion
         public List<LogDTO> GetLogsForDisplay(IFlocSet flocSet, DateRange dateRange, List<long> readableVisibilityGroupIds,long? RoleId)
        {
            if (flocSet == null || flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
            {
                throw new ApplicationException("No Functional Locations found.");
            }

            List<LogDTO> logDtos = dtoDao.QueryByFunctionalLocations(flocSet, dateRange, readableVisibilityGroupIds, RoleId);
            
            return logDtos;
        }
        //End

        public List<LogDTO> GetCrossShiftLogsForDisplay(IFlocSet flocSet, WorkAssignment assignment, DateRange dateRange, List<long> readableVisibilityGroupIds)
        {
            if (flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
            {
                throw new ApplicationException("No Functional Locations found.");
            }

            List<LogDTO> logDtos = dtoDao.QueryByFunctionalLocations(flocSet, dateRange.SqlFriendlyStart, null, assignment, readableVisibilityGroupIds);
            return logDtos;
        }

        public List<LogDTO> QueryStandardLogsByFlocAndCurrentShift(IFlocSet flocSet, UserShift userShift, List<long> readableVisibilityGroupIds)
        {
            return dtoDao.GetLogsWhereLoggedDateOrActualLoggedDateMatchRange(flocSet, userShift, readableVisibilityGroupIds);
        }

        public List<HasCommentsDTO> QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(DateTime @from, DateTime to, IFlocSet flocSet, long shiftPatternId, long? workAssignmentId, long userId)
        {
            return dtoDao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(@from, to, flocSet, shiftPatternId, workAssignmentId, userId);
        }

        // Flexi shift handover  amit shukla RITM0185797
        public List<HasCommentsDTO> QueryLogsByParentFunctionalLocationDateRangeShiftAndWorkAssignmentAndCurrentShift(DateTime @from, DateTime to, IFlocSet flocSet, long shiftPatternId, long? workAssignmentId, long userId, bool isFlexibleshiftHandover)
        {
            return dtoDao.QueryByParentFlocListDateRangeShiftAndWorkAssignment(@from, to, flocSet, shiftPatternId, workAssignmentId, userId, isFlexibleshiftHandover);
        }

        public List<LogDTO> QueryOperatingEngineerDTOsByFunctionalLocationsAndDateRange(IFlocSet flocSet, Range<Date> range, List<long> readableVisibilityGroupIds)
        {
            DateRange dateRange = new DateRange(range);
            return dtoDao.QueryOpEngLogsByFunctionalLocations(flocSet, dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, readableVisibilityGroupIds);
        }

        public List<LogPriorityPageDTO> QueryDirectivesForPriorityPageDTOs(IFlocSet flocSet, Range<Date> range, User user, List<long> readableVisibilityGroupIds)
        {
            List<LogDTO> logDtos = dtoDao.QueryByRootFLOCsWithMatchingFLOCAncestorsAndDescendants(
                LogType.DailyDirective,
                range.LowerBound.CreateDateTime(Time.START_OF_DAY),
                range.UpperBound.CreateDateTime(Time.END_OF_DAY),
                flocSet,
                user,
                readableVisibilityGroupIds);

            List<LogPriorityPageDTO> results = new List<LogPriorityPageDTO>();
            foreach (LogDTO logDto in logDtos)
            {
                results.Add(new LogPriorityPageDTO(logDto, logDto.IsReadByCurrentUser.GetValueOrDefault(false)));
            }
            return results;
        }
       
        public List<NotifiedEvent> Insert(Log log)
        {
            List<NotifiedEvent> withLogInsertEventHandling = WithLogInsertEventHandling(log, () => dao.Insert(log));
            AddHandoverAssociation(log);

            WriteCustomFieldsOnOneWayServiceCall(log);            

            return withLogInsertEventHandling;
        }

        private void UpdateCustomFieldsOnOneWayServiceCall(Log oldLog, Log newLog)
        {
            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.UpdateCustomFieldsToPhd(oldLog, newLog);
        }

        private void RemoveCustomFieldsOnOneWayServiceCall(Log log)
        {
            if (!log.HasCustomFields)
                return;

            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.RemoveCustomFieldsFromPhd(log);
        }

        private void WriteCustomFieldsOnOneWayServiceCall(Log log)
        {
            if (!log.HasCustomFields)
                return;

            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.WriteCustomFieldsToPhd(log);
        }

        private void AddHandoverAssociation(Log log)
        {
            if (log.WorkAssignment != null)
            {
                shiftHandoverAssociationDao.InsertLogAssocications(log);
            }
        }

        public List<NotifiedEvent> InsertForActionItem(Log log, ActionItem associatedAction)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            notifiedEvents.AddRange(WithLogInsertEventHandling(log, () => dao.Insert(log, associatedAction)));

            // if log is being created via 'comment only' mechanism on action item response screen, the action item itself will not be 
            // updated but the 'view associated logs' button needs to be refreshed, so we push this event here
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ActionItemUpdate, associatedAction));

            AddHandoverAssociation(log);
            //Added by Mukesh to Fix custom field Write problem
            WriteCustomFieldsOnOneWayServiceCall(log); 
            //End

            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertActionItemDefinition(Log log, ActionItemDefinition associatedActionItemDefinition)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedActionItemDefinition));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertForWorkPermitEdmonton(Log log, WorkPermitEdmonton associatedWorkPermit)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedWorkPermit));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertForWorkPermitLubes(Log log, WorkPermitLubes associatedWorkPermit)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedWorkPermit));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }


        public List<NotifiedEvent> InsertForWorkPermitMontreal(Log log, WorkPermitMontreal associatedWorkPermit)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedWorkPermit));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }

        //RITM0301321 mangesh
        public List<NotifiedEvent> InsertForWorkPermitMuds(Log log, WorkPermitMuds associatedWorkPermit)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedWorkPermit));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }

        public List<NotifiedEvent> InsertForTargetAlert(Log log, TargetAlert associatedTargetAlert)
        {
            List<NotifiedEvent> notifiedEvents = WithLogInsertEventHandling(log, () => dao.Insert(log, associatedTargetAlert));
            AddHandoverAssociation(log);
            return notifiedEvents;
        }

        private List<NotifiedEvent> WithLogInsertEventHandling(Log log, Func<Log> insertLog)
        {
            IfLogIsNullThrowException(log);

            Log savedLog;

            try
            {
                savedLog = insertLog.Invoke();
            }
            catch (ShiftOutOfBoundsException soobe)
            {
                string userMessage = string.Format("There was a shift exception for user: {0}",
                                                   log.CreationUser != null ? log.CreationUser.FullName : "No user provided");

                string errorMessage = string.Format("{0}, LogComments: {1}", userMessage, log.PlainTextComments);

                logger.Error(errorMessage, soobe);

                throw;
            }

            editHistoryService.TakeSnapshot(log);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (log.Id.HasValue)
            {
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogCreate, savedLog));
            }

            if (log.ReplyToLogId.HasValue)
            {
                Log parentLog = dao.QueryById(log.ReplyToLogId.Value);
                if (!parentLog.HasChildren)
                {
                    parentLog.HasChildren = true;
                    dao.Update(parentLog);
                    notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogUpdate, parentLog));
                }
            }

            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(Log log)
        {
            Log prevLogWithCustomFields = null;
            if (log.HasCustomFields)
            {
                prevLogWithCustomFields = QueryById(log.IdValue);
            }

            log.LastModifiedDate = timeService.GetTime(log.FunctionalLocations[0].Site.TimeZone);
            dao.Update(log);

            UpdateCustomFieldsOnOneWayServiceCall(prevLogWithCustomFields, log);

            editHistoryService.TakeSnapshot(log);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>
                                                     {
                                                         ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogUpdate,
                                                                                           log)
                                                     };
            return notifiedEvents;
        }

        private static void IfLogIsNullThrowException(Log log)
        {
            if (log == null)
            {
                logger.Error("Cannont Insert null object into log");
                throw new OLTException("Cannot Insert null object into log");
            }
        }

        public List<NotifiedEvent> Remove(Log log)
        {
            RemoveCustomFieldsOnOneWayServiceCall(log);

            dao.Remove(log);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogRemove, log));

            if (log.ReplyToLogId.HasValue)
            {
                Log replyLog = dao.QueryById(log.ReplyToLogId.Value);
                replyLog.HasChildren = dao.HasChildren(replyLog);
                if (!replyLog.HasChildren)
                {
                    // Before this log was deleted, this log was the only child of replyLog. So, now we need to update this parent log
                    dao.Update(replyLog);
                    notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogUpdate, replyLog));    
                }
            }

            return notifiedEvents;
        }

        public LogRead MarkAsRead(long logId, long userId, DateTime readDateTime)
        {
            // As there is no notification event for marking a log as read, it is possible that the log may be marked
            //   as read courtesy of an imposter user during the time that this user was about to mark the log as read.
            //   It should never happen unless users are logged into multiple machines as the same user.
            LogRead logRead = logReadDao.UserMarkedLogAsRead(logId, userId) ??
                              logReadDao.Insert(new LogRead(logId, userId, readDateTime));
            return logRead;
        }

        public List<ItemReadBy> UsersThatMarkedLogAsRead(long logId)
        {
            return logReadDao.UsersThatMarkedLogAsRead(logId);
        }

        public bool LogIsMarkedAsRead(long logId)
        {
            List<ItemReadBy> usersThatMarkedLogAsRead = logReadDao.UsersThatMarkedLogAsRead(logId);
            return usersThatMarkedLogAsRead != null && usersThatMarkedLogAsRead.Count > 0;
        }

        public bool UserMarkedLogAsRead(long logId, long userId)
        {
            LogRead logRead = logReadDao.UserMarkedLogAsRead(logId, userId);
            return (logRead != null);            
        }

        public bool HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(LogDefinition logDefinition, DateTime dateTimeToCheck, ExactFlocSet flocSet)
        {
            return dao.HasLogForDefinitionSameDayAndAtLeastOneOfTheQueriedFlocs(logDefinition, dateTimeToCheck, flocSet);
        }

        public void SaveLogGuideline(string guidelineText, FunctionalLocation functionalLocation)
        {
            LogGuideline guideline = logGuidelineDao.QueryByDivision(functionalLocation);

            if (guideline == null)
            {
                logGuidelineDao.Insert(new LogGuideline(functionalLocation, guidelineText));
            }
            else
            {
                guideline.Text = guidelineText;
                logGuidelineDao.Update(guideline);
            }
        }

        public LogGuideline QueryLogGuidelineByDivision(FunctionalLocation functionalLocation)
        {
            if (!functionalLocation.IsDivision)
            {
                throw new ArgumentException("Functional location must be a division", "functionalLocation");
            }

            return logGuidelineDao.QueryByDivision(functionalLocation);
        }

        public List<LogGuideline> QueryLogGuidelinesByDivisions(List<string> divisions, long siteId)
        {
            List<LogGuideline> guidelines = new List<LogGuideline>();

            foreach (string divisionString in divisions)
            {
                FunctionalLocation division = functionalLocationDao.QueryByFullHierarchy(divisionString, siteId);
                LogGuideline guideline = QueryLogGuidelineByDivision(division);                
                guidelines.AddIfNotNull(guideline);                                
            }

            return guidelines;
        }

    }
}