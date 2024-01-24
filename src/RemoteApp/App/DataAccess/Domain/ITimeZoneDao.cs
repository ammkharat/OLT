using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITimeZoneDao : IDao
    {
        [CachedQuery("TZ")]
        OltTimeZoneInfo QueryByName(string timeZoneName);
    }
}