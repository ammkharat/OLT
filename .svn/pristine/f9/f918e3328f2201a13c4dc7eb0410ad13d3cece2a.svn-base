using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ISAPNotificationDTODao : IDao
    {
        List<SAPNotificationDTO> QueryByUnitLevelFunctionalLocationsAndDateRange(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime);
    }
}