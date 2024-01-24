using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [Serializable]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class LabAlertDefinitionService : ILabAlertDefinitionService
    {
        private readonly ILabAlertDefinitionDao dao;
        private readonly ILabAlertDefinitionDTODao dtoDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly IUserService userService;
        private readonly ITimeService timeService;

        public LabAlertDefinitionService()
        {
            dao = DaoRegistry.GetDao<ILabAlertDefinitionDao>();
            dtoDao = DaoRegistry.GetDao<ILabAlertDefinitionDTODao>();
            editHistoryService = new EditHistoryService();
            userService = new UserService();
            timeService = new TimeService();
        }
       
        public LabAlertDefinition QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public LabAlertDefinition QueryByScheduleId(long scheduleId)
        {
            return dao.QueryByScheduleId(scheduleId);
        }

        public List<LabAlertDefinitionDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(IFlocSet flocSet, Range<Date> dateRange)
        {
            return dtoDao.QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(flocSet, new DateRange(dateRange));
        }

        public SchedulingList<LabAlertDefinition, OLTException> QueryAllAvailableForScheduling()
        {
            return dao.QueryAllAvailableForScheduling();
        }

        public List<NotifiedEvent> Insert(LabAlertDefinition definition)
        {
            dao.Insert(definition);
            editHistoryService.TakeSnapshot(definition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertDefinitionCreate, definition));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(LabAlertDefinition definition)
        {
            return DoFullUpdate(definition);
        }

        private List<NotifiedEvent> DoFullUpdate(LabAlertDefinition definition)
        {
            dao.Update(definition);
            editHistoryService.TakeSnapshot(definition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertDefinitionUpdate, definition));
            return notifiedEvents;
        }
       
        public List<NotifiedEvent> Remove(LabAlertDefinition definition)
        {
            dao.Remove(definition);
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.LabAlertDefinitionRemove, definition));
            return notifiedEvents;
        }

        public void UpdateStatusForValidTag(TagInfo tag, Site site)
        {
            List<LabAlertDefinition> definitionsWithTag = dao.QueryLabAlertDefinitionsWithInvalidTag(tag);
            if (definitionsWithTag.Count > 0)
            {
                User systemUser = userService.GetRemoteAppUser();
                DateTime timeAtSite = timeService.GetTime(site.TimeZone);

                foreach (LabAlertDefinition definition in definitionsWithTag)
                {
                    definition.HasValidTag(systemUser, timeAtSite);
                    DoFullUpdate(definition);
                }
            }
        }

        public void UpdateStatusForInvalidTag(TagInfo tag, Site site)
        {
            List<LabAlertDefinition> definitionsWithTag = dao.QueryLabAlertDefinitionsWithValidTag(tag);
            if (definitionsWithTag.Count > 0)
            {
                User systemUser = userService.GetRemoteAppUser();
                DateTime timeAtSite = timeService.GetTime(site.TimeZone);

                foreach (LabAlertDefinition definition in definitionsWithTag)
                {
                    definition.HasInvalidTag(systemUser, timeAtSite);
                    DoFullUpdate(definition);
                }
            }
        }

        public Error IsValidName(string name, Site site, LabAlertDefinition definition)
        {
            long siteId = site.IdValue;

            List<LabAlertDefinition> definitionsWithSameName = dao.QueryByName(siteId, name);
            if (definitionsWithSameName.Exists(obj => !obj.IsSame(definition)))
            {
                return new Error(String.Format(StringResources.LabAlertDefinitionSameNameAlreadyExists, name));
            }
            else
            {
                return Error.HasNoError;       
            }
        }
    }
}
