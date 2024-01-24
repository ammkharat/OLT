using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ConfinedSpaceService : IConfinedSpaceService
    {
        private readonly IConfinedSpaceDao dao;
        private readonly IConfinedSpaceDTODao dtoDao;
        private readonly IEditHistoryService editHistoryService;

        public ConfinedSpaceService()
        {
            editHistoryService = new EditHistoryService();
            dao = DaoRegistry.GetDao<IConfinedSpaceDao>();
            dtoDao = DaoRegistry.GetDao<IConfinedSpaceDTODao>();
        }

        public ConfinedSpace QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<ConfinedSpaceDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            return dtoDao.QueryByFlocUnitAndBelow(flocSet, dateRange);
        }

        public List<NotifiedEvent> Insert(ConfinedSpace confinedSpace)
        {
            ConfinedSpace confinedSpaceWithAnId = dao.Insert(confinedSpace);
            editHistoryService.TakeSnapshot(confinedSpaceWithAnId);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceCreate, confinedSpaceWithAnId));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(ConfinedSpace confinedSpace)
        {
            dao.Update(confinedSpace);
            editHistoryService.TakeSnapshot(confinedSpace);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceUpdate, confinedSpace));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(ConfinedSpace confinedSpace)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            dao.Remove(confinedSpace);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceRemove, confinedSpace));
            return notifiedEvents;

        }
    }
}