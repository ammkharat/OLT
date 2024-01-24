using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ILubesCsdFormDTODao : IDao
    {
        List<LubesCsdFormDTO> QueryFormCsd(IFlocSet flocSet, DateRange dateRange, IEnumerable<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        List<LubesCsdFormDTO> QueryFormCsdsThatAreApprovedDraftExpiredByFunctionalLocations(IFlocSet flocSet,
            DateTime now);

        List<LubesCsdFormDTO> QueryFormCsdsThatAreExpiredOrApprovedAndActiveByFunctionalLocations(IFlocSet flocSet, DateTime now);
    }
}