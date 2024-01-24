using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmExcursionResponseDTODao : IDao
    {
        List<OpmExcursionResponseDTO> QueryByDateRangeAndFlocs(DateRange dateRange, List<FunctionalLocation> flocs);
        List<OpmExcursionResponseDTO> QueryByDateRangeAndFlocsForShiftHandover(DateTime startOfShift, DateTime endOfShift, List<FunctionalLocation> flocs);
    }
}