using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IFormSarniaOP14DTODao : IDao
    {
        List<FormEdmontonOP14DTO> QueryFormOP14(IFlocSet flocSet, DateRange dateRange, List<FormStatus> formStatuses, bool includeAllDraftFormsRegardlessOfDateRange);
        List<FormEdmontonOP14DTO> QueryFormOP14sThatAreApprovedDraftExpiredByFunctionalLocations(IFlocSet flocSet, DateTime now);
    }
}