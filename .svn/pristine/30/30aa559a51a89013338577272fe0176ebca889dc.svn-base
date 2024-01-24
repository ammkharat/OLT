using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PermitAttributeService : IPermitAttributeService
    {
        private readonly IPermitAttributeDao permitAttributeDao;

        public PermitAttributeService()
        {
            permitAttributeDao = DaoRegistry.GetDao<IPermitAttributeDao>();
        }

        public List<PermitAttribute> QueryBySite(long siteId)
        {
            return permitAttributeDao.QueryBySiteId(siteId);
        }
    }
}
