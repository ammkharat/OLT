using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Services
{
    public interface IFunctionalLocationLookup
    {
        List<FunctionalLocationInfo> GetChildrenFor(long siteId);
        List<FunctionalLocationInfo> GetChildrenFor(FunctionalLocation floc);
        List<FunctionalLocationInfo> GetUnitsFor(long siteId);
    }
}