using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class SiteService : ISiteService
    {
        private readonly ISiteDao siteDao;

        public SiteService()
        {
            siteDao = DaoRegistry.GetDao<ISiteDao>();
        }

        public List<Site> GetAll()
        {
            return siteDao.QueryAll();
        }

        public Site QueryById(long id)
        {
            return siteDao.QueryById(id);
        }

        public Site QueryByPlantId(string plantId)
        {
            return siteDao.QueryByPlantId(plantId);
        }
    }
}