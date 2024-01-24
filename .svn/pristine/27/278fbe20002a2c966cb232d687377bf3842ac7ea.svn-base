using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IFunctionalLocationInfoDao : IDao
    {
        [CachedQueryList("DivisionFlocsOfSite")]
        List<FunctionalLocationInfo> QueryFunctionalLocationDivisionInfosBySiteId(long siteId);

        // non-cached for admin floc edit screen
        List<FunctionalLocationInfo> QueryFunctionalLocationDivisionInfosBySiteIdForAdmin(long siteId);

        [CachedQueryList("ChildFlocsOf")]  
        List<FunctionalLocationInfo> QueryFunctionalLocationInfosByParentFunctionalLocation(long functionalLocationId);

        // non-cached for admin floc edit screen
        List<FunctionalLocationInfo> QueryFunctionalLocationInfosByParentFunctionalLocationForAdmin(long functionalLocationId);

        [CachedQueryList("UnitFlocsOfSite")]
        List<FunctionalLocationInfo> QueryFunctionalLocationUnitInfosBySiteId(long siteId);

        // non-cached for admin floc edit screen
        List<FunctionalLocationInfo> QueryFunctionalLocationUnitInfosBySiteIdForAdmin(long siteId);
    }
}