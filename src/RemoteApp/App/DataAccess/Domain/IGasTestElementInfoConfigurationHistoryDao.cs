using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IGasTestElementInfoConfigurationHistoryDao : IDao
    {
        List<GasTestElementInfoConfigurationHistory> QueryAllBySiteId(long siteId);
        GasTestElementInfoConfigurationHistory Insert(GasTestElementInfoConfigurationHistory gasTestElementInfoConfigurationHistory, long siteId);
    }
}
