using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISiteDao : IDao
    {
        [CachedQueryById]
        Site QueryById(long id);

        List<Site> QueryAll();

        [CachedQuery("SiteByPlantId")]
        Site QueryByPlantId(string plantId);
        
        [CachedQuery("SiteByADKey")]
        Site QueryByActiveDirectoryKey(string siteKey);
    }
}