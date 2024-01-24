using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IGenericCsdDTODao : IDao
    {
        List<GenericCsdDTO> QueryFormGenericCsd(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);
        List<GenericCsdDTO> QueryFormGenericCsdsThatAreApprovedDraftExpiredByFunctionalLocations(IFlocSet flocSet, DateTime now);
    }
}