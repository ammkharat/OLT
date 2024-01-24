using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FunctionalLocationInfoService : IFunctionalLocationInfoService
    {
        private readonly IFunctionalLocationInfoDao dao;

        public FunctionalLocationInfoService() : this(DaoRegistry.GetDao<IFunctionalLocationInfoDao>())
        {
        }

        public FunctionalLocationInfoService(IFunctionalLocationInfoDao functionalLocationDtoDao)
        {
            dao = functionalLocationDtoDao;
        }

        public List<FunctionalLocationInfo> QueryDivisionsBySiteIdForAdmin(long siteId)
        {
            return dao.QueryFunctionalLocationDivisionInfosBySiteIdForAdmin(siteId);
        }

        public List<FunctionalLocationInfo> QueryByParentFunctionalLocationForAdmin(FunctionalLocation floc)
        {
            return dao.QueryFunctionalLocationInfosByParentFunctionalLocationForAdmin(floc.IdValue);
        }

        public List<FunctionalLocationInfo> QueryDivisionsBySiteId(long siteId)
        {
            return dao.QueryFunctionalLocationDivisionInfosBySiteId(siteId);
        }

        public List<FunctionalLocationInfo> QueryByParentFunctionalLocation(FunctionalLocation floc)
        {
            return dao.QueryFunctionalLocationInfosByParentFunctionalLocation(floc.IdValue);
        }

        public List<FunctionalLocationInfo> QueryUnitsBySiteId(long siteId)
        {
            return dao.QueryFunctionalLocationUnitInfosBySiteId(siteId);
        }

        public List<FunctionalLocationInfo> QueryUnitsBySiteIdForAdmin(long siteId)
        {
            return dao.QueryFunctionalLocationUnitInfosBySiteIdForAdmin(siteId);
        }

    }
}
