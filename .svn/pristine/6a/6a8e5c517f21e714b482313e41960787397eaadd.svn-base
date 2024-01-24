using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IGasTestElementDao : IDao
    {
        GasTestElement Insert(GasTestElement gasTestElement, long workPermitId);
        void Update(GasTestElement gasTestElement);
        List<GasTestElement> QueryAllGasTestElementByWorkPermitIdAndSiteId(long workPermitId,long siteid);

        /// <summary>
        /// Removes the given gas test element (element only, not element info).
        /// </summary>
        void Remove(GasTestElement element);

         GasTestElement InsertMuds(GasTestElement gasTestElement, long workPermitId);

         List<GasTestElement> QueryAllGasTestElementByWorkPermitIdMuds(long workPermitId, long siteid);


         void UpdateMuds(GasTestElement gasTestElement);
    }
}