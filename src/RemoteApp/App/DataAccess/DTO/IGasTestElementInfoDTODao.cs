using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IGasTestElementInfoDTODao : IDao
    {
        List<GasTestElementInfoDTO> QueryStandardInfoDTOsBySiteId(long siteId);
        void Update(GasTestElementInfoDTO dtoToBeUpdated);
    }
}
