using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IShiftPatternService
    {
        [OperationContract]
        List<ShiftPattern> QueryAll();

        [OperationContract]
        ShiftPattern GetShiftBySiteAndDateTime(Site site, DateTime dateTimeDuringShift);

        [OperationContract]
        ShiftPattern GetShiftBySiteAndDateTimeFavourEarlierShift(Site site, DateTime dateTimeDuringShift);

        [OperationContract]
        List<ShiftPattern> QueryBySite(Site site);

        [OperationContract]
        List<ShiftPattern> GetFunctionalLocationsGroupedByShiftDeterminedWithShiftPadding
            (Site site, Time timeDuringShift);
    }
}