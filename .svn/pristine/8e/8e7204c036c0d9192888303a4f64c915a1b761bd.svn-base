using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ILubesAlarmDisableFormDTODao : IDao
    {
        List<LubesAlarmDisableFormDTO> QueryFormAlarmDisable(IFlocSet flocSet, DateRange dateRange,
            List<FormStatus> formStatuses,
            bool includeAllDraftFormsRegardlessOfDateRange);

        List<LubesAlarmDisableFormDTO> QueryFormAlarmDisableThatAreApprovedDraftExpiredByFunctionalLocations(
            IFlocSet flocSet,
            DateTime now);

        List<LubesAlarmDisableFormDTO> QueryFormAlarmDisableThatAreApprovedAndActiveByFunctionalLocations(
            IFlocSet flocSet, DateTime now);
    }
}