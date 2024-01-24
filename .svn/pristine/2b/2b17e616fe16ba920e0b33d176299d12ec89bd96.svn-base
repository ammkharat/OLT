using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IDeviationAlertDTODao : IDao
    {
        List<DeviationAlertDTO> QueryByFunctionalLocationsAndTimePeriod(
            IFlocSet flocSet, DateTime? fromDateTime, DateTime? toDateTime);

        List<DeviationAlertDTO> QueryByFunctionalLocationsAndOverlapInDateRange(
            IFlocSet flocSet, DateTime fromDateTime, DateTime toDateTime);
    }
}
