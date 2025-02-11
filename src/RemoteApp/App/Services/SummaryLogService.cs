﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
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
    public class SummaryLogService : ISummaryLogService
    {
        private readonly ITimeService timeService;
        private readonly IEditHistoryService editHistoryService;
        private readonly IPlantHistorianService plantHistorianService;

        private readonly ISiteConfigurationDao siteConfigurationDao;

        private readonly ISummaryLogReadDao summaryLogReadDao;
        private readonly ISummaryLogDao summaryLogDao;
        private readonly ISummaryLogDTODao dtoDao;
        private readonly ISummaryLogCustomFieldEntryDao customFieldEntryDao;
        private readonly IShiftHandoverQuestionnaireAssociationDao shiftHandoverAssociationDao;

        public SummaryLogService() : 
            this(new TimeService(), new EditHistoryService(), GenericServiceRegistry.Instance.GetService<IPlantHistorianService>())
        {
        }

        public SummaryLogService(
            ITimeService timeService,
            IEditHistoryService editHistoryService, IPlantHistorianService plantHistorianService)
        {
            this.timeService = timeService;
            this.editHistoryService = editHistoryService;
            this.plantHistorianService = plantHistorianService;

            siteConfigurationDao = DaoRegistry.GetDao<ISiteConfigurationDao>();
            
            summaryLogReadDao = DaoRegistry.GetDao<ISummaryLogReadDao>();
            dtoDao = DaoRegistry.GetDao<ISummaryLogDTODao>();
            summaryLogDao = DaoRegistry.GetDao<ISummaryLogDao>();

            customFieldEntryDao = DaoRegistry.GetDao<ISummaryLogCustomFieldEntryDao>();

            shiftHandoverAssociationDao = DaoRegistry.GetDao<IShiftHandoverQuestionnaireAssociationDao>();
        }

        public List<SummaryLogDTO> QuerySummaryLogDTOsByParentFloc(IFlocSet flocSet, List<long> clientReadableVisibilityGroupIds)
        {
            if (flocSet == null || flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
                return new List<SummaryLogDTO>(0);

            Date fromDate = SharedServiceUtilities.GetFromDateForLogs(flocSet.FunctionalLocations[0].Site, siteConfigurationDao, timeService);

            return dtoDao.QueryDTOsByParentFlocList(fromDate.CreateDateTime(Time.START_OF_DAY), null, flocSet, clientReadableVisibilityGroupIds);
        }

        public List<SummaryLogDTO> QueryShiftSummaryDTOsByParentFlocAndDateRange(IFlocSet flocSet, Range<Date> range, List<long> clientReadableVisibilityGroupIds)
        {
            DateRange dateRange = new DateRange(range);
            return dtoDao.QueryDTOsByParentFlocList(dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, clientReadableVisibilityGroupIds);
        }
        //Added to View based on rolepermission
        public List<SummaryLogDTO> QueryShiftSummaryDTOsByParentFlocAndDateRange(IFlocSet flocSet, Range<Date> range, List<long> clientReadableVisibilityGroupIds,long? RoleId)
        {
            DateRange dateRange = new DateRange(range);
            return dtoDao.QueryDTOsByParentFlocList(dateRange.SqlFriendlyStart, dateRange.SqlFriendlyEnd, flocSet, clientReadableVisibilityGroupIds,RoleId);
        }

        public List<SummaryLog> QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment(DateTime @from, DateTime to, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId)
        {
            return summaryLogDao.QueryByFlocListDateRangeShiftAndWorkAssignment(@from, to, flocSet, shiftId, workAssignmentId, userId);
        }
        // amit shukla Flexi shift handover RITM0185797
        public List<SummaryLog> QueryShiftSummaryLogsByFunctionalLocationDateRangeShiftAndWorkAssignment(DateTime @from, DateTime to, IFlocSet flocSet, long shiftId, long? workAssignmentId, long userId, bool isFlexible)
        {
            return summaryLogDao.QueryByFlocListDateRangeShiftAndWorkAssignment(@from, to, flocSet, shiftId, workAssignmentId, userId, isFlexible);
        }

        public SummaryLog QueryById(long id)
        {
            return summaryLogDao.QueryById(id);           
        }

        public List<NotifiedEvent> Insert(SummaryLog summaryLog)
        {
            summaryLogDao.Insert(summaryLog);
            editHistoryService.TakeSnapshot(summaryLog);
            if (summaryLog.WorkAssignment != null)
            {
                shiftHandoverAssociationDao.InsertSummaryLogAssocications(summaryLog);
            }

            WriteCustomFieldsOnOneWayServiceCall(summaryLog);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            if (summaryLog.Id.HasValue)
            {
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SummaryLogCreate, summaryLog));
            }

            if (summaryLog.ReplyToLogId.HasValue)
            {
                SummaryLog parentLog = summaryLogDao.QueryById(summaryLog.ReplyToLogId.Value);
                if (!parentLog.HasChildren)
                {
                    parentLog.HasChildren = true;
                    summaryLogDao.Update(parentLog);
                    notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SummaryLogUpdate, parentLog));
                }
            }
            return notifiedEvents;
        }

        private void WriteCustomFieldsOnOneWayServiceCall(SummaryLog log)
        {
            if (!log.HasCustomFields)
                return;

            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.WriteCustomFieldsToPhd(log);
        }


        public List<NotifiedEvent> Update(SummaryLog log)
        {
            SummaryLog previousVersionForWorkAssignment = null;
            if (log.WorkAssignment != null)
            {
                previousVersionForWorkAssignment = summaryLogDao.QueryById(log.IdValue);    
            }

            SummaryLog previousSummaryLogCustomFieldEntries = null;
            if (log.HasCustomFields)
            {
                previousSummaryLogCustomFieldEntries = previousVersionForWorkAssignment ?? summaryLogDao.QueryById(log.IdValue);
            }

            log.LastModifiedDate = timeService.GetTime(log.SiteDerivedFromFunctionalLocations.TimeZone);
            summaryLogDao.Update(log);
            editHistoryService.TakeSnapshot(log);

            if (log.WorkAssignment != null && previousVersionForWorkAssignment != null && !previousVersionForWorkAssignment.FunctionalLocations.EqualsById(log.FunctionalLocations))
            {
                shiftHandoverAssociationDao.UpdateSummaryLogAssociations(log);
            }

            UpdateCustomFieldsOnOneWayServiceCall(previousSummaryLogCustomFieldEntries, log);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SummaryLogUpdate, log));
            return notifiedEvents;
        }

        private void UpdateCustomFieldsOnOneWayServiceCall(SummaryLog oldLog, SummaryLog newLog)
        {
            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.UpdateCustomFieldsToPhd(oldLog, newLog);
        }

        public List<NotifiedEvent> Remove(SummaryLog summaryLog)
        {
            RemoveCustomFieldsOnOneWayServiceCall(summaryLog);

            summaryLogDao.Remove(summaryLog);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SummaryLogRemove, summaryLog));

            if (summaryLog.ReplyToLogId.HasValue)
            {
                SummaryLog parentLog = summaryLogDao.QueryById(summaryLog.ReplyToLogId.Value);
                parentLog.HasChildren = summaryLogDao.HasChildren(parentLog);
                if (!parentLog.HasChildren)
                {
                    // Before this log was deleted, this log was the only child of parentLog. So, now we need to update this parent log
                    summaryLogDao.Update(parentLog);
                    notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.SummaryLogUpdate, parentLog));                    
                }
            }

            return notifiedEvents;
        }

        private void RemoveCustomFieldsOnOneWayServiceCall(SummaryLog log)
        {
            if (!log.HasCustomFields)
                return;

            // this is a one-way WCF service call. So, we don't receive any exceptions back.
            plantHistorianService.RemoveCustomFieldsFromPhd(log);
        }

        public SummaryLog GetLatestSummaryLogForUser(long userId)
        {
            return summaryLogDao.QueryLatestSummaryLogForUser(userId);
        }

        public List<ItemReadBy> UsersThatMarkedLogAsRead(long summaryLogId)
        {
            return summaryLogReadDao.UsersThatMarkedSummaryLogAsRead(summaryLogId);            
        }

        public bool UserMarkedSummaryLogAsRead(long summaryLogId, long userId)
        {
            SummaryLogRead logRead = summaryLogReadDao.UserMarkedSummaryLogAsRead(summaryLogId, userId);
            return (logRead != null);
        }

        public void MarkAsRead(long summaryLogId, long userId, DateTime readDateTime)
        {
            if (summaryLogReadDao.UserMarkedSummaryLogAsRead(summaryLogId, userId) == null)
            {
                summaryLogReadDao.Insert(new SummaryLogRead(summaryLogId, userId, readDateTime));
            }            
        }

        public bool LogIsMarkedAsRead(long summaryLogId)
        {
            List<ItemReadBy> usersThatMarkedLogAsRead = UsersThatMarkedLogAsRead(summaryLogId);
            return usersThatMarkedLogAsRead.Count > 0;
        }

        public List<NumericCustomFieldEntryDTO> QueryNumericCustomFieldEntries(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            return customFieldEntryDao.QueryNumericCustomFieldEntriesForLogs(customFieldId, workAssignmentId, site, dateRange);
        }

        public List<NonnumericCustomFieldEntryDTO> QueryNonnumericCustomFieldEntries(long customFieldId, long workAssignmentId, Site site, DateRange dateRange)
        {
            return customFieldEntryDao.QueryNonnumericCustomFieldEntriesForLogs(customFieldId, workAssignmentId, site, dateRange);
        }
    }
}
