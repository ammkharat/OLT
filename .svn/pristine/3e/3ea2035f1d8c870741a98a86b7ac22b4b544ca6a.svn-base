using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISiteConfigurationDefaultsDao : IDao
    {
        [CachedQueryById]
        SiteConfigurationDefaults QueryBySiteId(long siteId);
    }
}