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
    public class ConfinedSpaceMudsService : IConfinedSpaceMudsService
    {
        private readonly IConfinedSpaceMudsDao dao;
        private readonly IConfinedSpaceMudsDTODao dtoDao;
        private readonly IEditHistoryService editHistoryService;

        public ConfinedSpaceMudsService()
        {
            editHistoryService = new EditHistoryService();
            dao = DaoRegistry.GetDao<IConfinedSpaceMudsDao>();
            dtoDao = DaoRegistry.GetDao<IConfinedSpaceMudsDTODao>();
        }

        public ConfinedSpaceMuds QueryById(long id)
        {
            return dao.QueryById(id);
        }

        public List<ConfinedSpaceMudsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange)
        {
            return dtoDao.QueryByFlocUnitAndBelow(flocSet, dateRange);
        }

        public List<NotifiedEvent> Insert(ConfinedSpaceMuds confinedSpace)
        {
            ConfinedSpaceMuds confinedSpaceWithAnId = dao.Insert(confinedSpace);
            editHistoryService.TakeSnapshot(confinedSpaceWithAnId);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceMudsCreate, confinedSpaceWithAnId));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Update(ConfinedSpaceMuds confinedSpace)
        {
            dao.Update(confinedSpace);
            editHistoryService.TakeSnapshot(confinedSpace);

            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();
            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceMudsUpdate, confinedSpace));
            return notifiedEvents;
        }

        public List<NotifiedEvent> Remove(ConfinedSpaceMuds confinedSpace)
        {
            List<NotifiedEvent> notifiedEvents = new List<NotifiedEvent>();

            dao.Remove(confinedSpace);

            notifiedEvents.Add(ServiceUtility.PushEventIntoQueue(ApplicationEvent.ConfinedSpaceMudsRemove, confinedSpace));
            return notifiedEvents;

        }
        //Added by ppanigrahi
        public ConfinedSpaceMudSign GetConfinedSpaceSign(string ConfinedSpaceId, int SiteId)
        {
            return dao.GetConfinedSpaceMudSign(ConfinedSpaceId, SiteId);
        }



        public void InserUpdateConfinedSpaceSign(ConfinedSpaceMudSign confinedSpaceSign)
        {
            dao.InserUpdateConfinedSpaceMudSign(confinedSpaceSign);
        }
    }
}