using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LogDefinitionService : ILogDefinitionService
    {
        private readonly ILogDefinitionDTODao logDefinitionDTODao;
        private readonly ILogDefinitionDao logDefinitionDao;
        private readonly ILogDefinitionCustomFieldEntryDao customFieldEntryDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly IScheduleService scheduleService;

        public LogDefinitionService() : this(DaoRegistry.GetDao<ILogDefinitionDao>(),
                                             DaoRegistry.GetDao<ILogDefinitionDTODao>(), 
                                            DaoRegistry.GetDao<ILogDefinitionCustomFieldEntryDao>(),
                                             new EditHistoryService(),
                                             new ScheduleService())
        {
        }

        public LogDefinitionService(ILogDefinitionDao logDefinitionDao, ILogDefinitionDTODao logDefinitionDTODao, ILogDefinitionCustomFieldEntryDao customFieldEntryDao, IEditHistoryService editHistoryService, IScheduleService scheduleService)
        {
            this.logDefinitionDao = logDefinitionDao;
            this.logDefinitionDTODao = logDefinitionDTODao;
            this.customFieldEntryDao = customFieldEntryDao;
            this.editHistoryService = editHistoryService;
            this.scheduleService = scheduleService;
        }

        public LogDefinition QueryById(long id)
        {
            return logDefinitionDao.QueryById(id);
        }

        public List<LogDefinition> QueryAllForScheduling()
        {
            return logDefinitionDao.QueryAllForScheduling();
        }

        public List<LogDefinitionDTO> QueryDtoByFunctionalLocationsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibiltiyGroupIds)
        {
            if (flocSet.FunctionalLocations == null || flocSet.FunctionalLocations.Count == 0)
            {
                throw new ApplicationException("No Functional Locations found.");
            }
            return logDefinitionDTODao.QueryByFunctionalLocationsAndLogType(flocSet, logType, readableVisibiltiyGroupIds);
        }

        public List<LogDefinitionDTO> QueryDtoByUserRootFlocsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibiltiyGroupIds)
        {
            return logDefinitionDTODao.QueryByUserRootFlocsAndLogType(flocSet, logType, readableVisibiltiyGroupIds);
        }

        public LogDefinition QueryByScheduleId(long scheduleId)
        {
            return logDefinitionDao.QueryByScheduleId(scheduleId);
        }

        public List<NotifiedEvent> Insert(LogDefinition logDefinition)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            logDefinition = logDefinitionDao.Insert(logDefinition);
            bool result = logDefinition.Id.HasValue && logDefinition.Schedule.Id.HasValue;
            if (result)
            {
                editHistoryService.TakeSnapshot(logDefinition);
                notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogDefinitionCreate, logDefinition));
            }

            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(LogDefinition logDefinition)
        {
            logDefinitionDao.Update(logDefinition);
            editHistoryService.TakeSnapshot(logDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LogDefinitionUpdate, logDefinition));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Cancel(LogDefinition logDefinition, DateTime endDateTime)
        {
            logDefinition.Schedule.EndDate = endDateTime.ToDate();
            logDefinition.Schedule.EndTime = new Time(endDateTime);
            scheduleService.Update(logDefinition.Schedule);
            logDefinitionDao.Remove(logDefinition);
            
            editHistoryService.TakeSnapshot(logDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue( ApplicationEvent.LogDefinitionCancelRecurring, logDefinition));
            return notifiedEvents;
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
