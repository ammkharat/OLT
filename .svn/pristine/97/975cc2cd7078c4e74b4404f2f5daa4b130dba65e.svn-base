using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - make HoneywellConnectionInfo a domain object, and Id should be the siteid.  Then QueryBySiteId becomes QueryById and caching can be done!
    public interface IScadaConfigurationDao : IDao
    {
        List<ScadaConnectionInfo> QueryBySiteId(long siteId);
        List<ScadaConnectionInfo> QueryAll();
        void Update(ScadaConnectionInfo connectionInfo);
        ScadaConnectionInfo QueryByScadaConnectionInfoId(long scadaConnectionInfoId);
    }
}