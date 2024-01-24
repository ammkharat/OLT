using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IMontrealCsdDTODao : IDao
    {
        List<MontrealCsdDTO> QueryFormMontrealCsd(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);
        List<MontrealCsdDTO> QueryFormMontrealCsdsThatAreApprovedDraftExpiredByFunctionalLocations(IFlocSet flocSet, DateTime now);
    }
}