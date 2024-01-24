using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class HoneywellPhdConfigurationService : IHoneywellPhdConfigurationService
    {
        private readonly IScadaConfigurationDao dao;

        public HoneywellPhdConfigurationService()
        {
            dao = DaoRegistry.GetDao<IScadaConfigurationDao>();
        }

        public List<ScadaConnectionInfo> QueryBySiteId(long siteId)
        {
            return dao.QueryBySiteId(siteId);
        }
        public ScadaConnectionInfo QueryByScadaConnectionInfoId(long scadaConnectionInfoId)
        {
            return dao.QueryByScadaConnectionInfoId(scadaConnectionInfoId);
        }

        public List<ScadaConnectionInfo> QueryAll()
        {
            return dao.QueryAll();
        }

        public void Update(ScadaConnectionInfo connectionInfo)
        {
            dao.Update(connectionInfo);
        }
    }
}