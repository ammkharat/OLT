using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RestrictionDefinitionService : IRestrictionDefinitionService
    {
        private readonly IRestrictionDefinitionDao dao;
        private readonly IRestrictionDefinitionDTODao dtoDao;
        private readonly IEditHistoryService editHistoryService;
        private readonly IUserService userService;
        private readonly ITimeService timeService;

        public RestrictionDefinitionService()
        {
            dao = DaoRegistry.GetDao<IRestrictionDefinitionDao>();
            dtoDao = DaoRegistry.GetDao<IRestrictionDefinitionDTODao>();
            editHistoryService = new EditHistoryService();
            userService = new UserService();
            timeService = new TimeService();
        }
       
        public RestrictionDefinition QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<RestrictionDefinitionDTO> QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(
            IFlocSet flocSet, Range<Date> dateRange)
        {
            return dtoDao.QueryByFunctionalLocationsAndTheirChildrenFunctionalLocations(flocSet, new DateRange(dateRange));
        }

        public SchedulingList<RestrictionDefinition, OLTException> QueryAllAvailableForScheduling()
        {
            return dao.QueryAllAvailableForScheduling();
        }

        public List<NotifiedEvent> Insert(RestrictionDefinition restrictionDefinition)
        {
            dao.Insert(restrictionDefinition);
            editHistoryService.TakeSnapshot(restrictionDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.RestrictionDefinitionCreate, restrictionDefinition));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(RestrictionDefinition restrictionDefinition)
        {
            return DoFullUpdate(restrictionDefinition);
        }

        private List<NotifiedEvent> DoFullUpdate(RestrictionDefinition restrictionDefinition)
        {
            dao.Update(restrictionDefinition);
            editHistoryService.TakeSnapshot(restrictionDefinition);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.RestrictionDefinitionUpdate, restrictionDefinition));
            return notifiedEvents;
        }

        public void UpdateLastInvokedDateTime(RestrictionDefinition restrictionDefinition)
        {
            dao.UpdateLastInvokedDateTime(restrictionDefinition);
            ServiceUtility.PushEventIntoQueue(ApplicationEvent.RestrictionDefinitionUpdate, restrictionDefinition);
        }

        public List<NotifiedEvent> Remove(RestrictionDefinition restrictionDefinition)
        {
            dao.Remove(restrictionDefinition);
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.RestrictionDefinitionRemove, restrictionDefinition));
            return notifiedEvents;
        }

        public void UpdateStatusForValidTag(TagInfo tag, Site site)
        {
            List<RestrictionDefinition> definitionsWithTag = dao.QueryRestrictionDefinitionsWithInvalidTag(tag);
            if (definitionsWithTag.Count > 0)
            {
                User systemUser = userService.GetRemoteAppUser();
                DateTime timeAtSite = timeService.GetTime(site.TimeZone);

                foreach (RestrictionDefinition definition in definitionsWithTag)
                {
                    definition.HasValidTag(systemUser, timeAtSite);
                    DoFullUpdate(definition);
                }
            }
        }

        public void UpdateStatusForInvalidTag(TagInfo tag, Site site)
        {
            List<RestrictionDefinition> definitionsWithTag = dao.QueryRestrictionDefinitionsWithValidTag(tag);
            if (definitionsWithTag.Count > 0)
            {
                User systemUser = userService.GetRemoteAppUser();
                DateTime timeAtSite = timeService.GetTime(site.TimeZone);

                foreach (RestrictionDefinition definition in definitionsWithTag)
                {
                    definition.HasInvalidTag(systemUser, timeAtSite);
                    DoFullUpdate(definition);
                }
            }
        }

        public Error IsValidName(string name, Site site, RestrictionDefinition restrictionDefinition)
        {
            long siteId = site.Id.Value;

            List<RestrictionDefinition> definitionsWithSameName = dao.QueryByName(siteId, name);
            if (definitionsWithSameName.Exists(obj => !obj.IsSame(restrictionDefinition)))
            {
                return new Error(String.Format("A restriction definition with the same name ({0}) already exists.", name));
            }
            else
            {
                return Error.HasNoError;       
            }
        }
    }
}