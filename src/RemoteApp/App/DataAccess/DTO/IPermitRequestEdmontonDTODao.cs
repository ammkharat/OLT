﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IPermitRequestEdmontonDTODao : IDao
    {
        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange);
        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange, List<long> priorityIds, bool excludeTheGivenPriorityIds);
        List<PermitRequestEdmontonDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date queryDate);

        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(IFlocSet flocSet, DateRange dateRange, List<long> priorityIds, bool excludeTheGivenPriorityIds, string username);

    }
}
