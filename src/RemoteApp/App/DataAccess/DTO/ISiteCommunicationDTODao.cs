using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ISiteCommunicationDTODao : IDao
    {
        List<SiteCommunicationDTO> QueryBySiteAndDateTime(long siteId, DateTime dateTime);
    }
}
