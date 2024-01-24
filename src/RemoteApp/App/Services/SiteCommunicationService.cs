using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SiteCommunicationService : ISiteCommunicationService
    {
        private readonly ISiteCommunicationDao dao;
        private readonly ISiteCommunicationDTODao dtoDao;

        public SiteCommunicationService()
        {
            dao = DaoRegistry.GetDao<ISiteCommunicationDao>();
            dtoDao = DaoRegistry.GetDao<ISiteCommunicationDTODao>();
        }

        public List<SiteCommunicationDTO> QueryBySiteAndDateTime(long siteId, DateTime dateTime)
        {
            return dtoDao.QueryBySiteAndDateTime(siteId, dateTime);
        }

        //ayman site communication
        public List<SiteCommunication> QueryAll()
        {
            return dao.QueryAll();
        }

        public List<SiteCommunication> QueryBySiteId(long siteId)
        {
            return dao.QueryBySite(siteId);
        }

        public void Update(SiteCommunication siteCommunication)
        {
            dao.Update(siteCommunication);
        }

        //ayman site communication
        public List<SiteCommunication> InsertAllSites(SiteCommunication siteCommunication)
        {
           return dao.InsertAllSites(siteCommunication);
        }
        
        public SiteCommunication Insert(SiteCommunication siteCommunication)
        {
            return dao.Insert(siteCommunication);
        }

        public void Remove(SiteCommunication siteCommunication)
        {
            dao.Remove(siteCommunication);
        }
    }
}
