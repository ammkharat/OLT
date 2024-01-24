using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IProcedureDeviationDTODao : IDao
    {
        List<ProcedureDeviationDTO> QueryProcedureDeviationDtos(IFlocSet flocSet, DateRange dateRange, long userId);

        List<ProcedureDeviationDTO> QueryProcedureDeviationDtosThatAreNonDraftByFunctionalLocations(IFlocSet flocSet,
            DateTime now, long userId);
    }
}