﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitEdmontonDTODao : IDao
    {
        List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet);
        List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsAndPriorityIds(Range<Date> dateRange, IFlocSet flocSet, List<long> priorityIds, bool excludeTheGivenPriorityIds);
        List<WorkPermitEdmontonDTO> QueryByFormGN59Id(long formGN59Id);
        List<WorkPermitEdmontonDTO> QueryByFormGN7Id(long formGN7Id);
        List<WorkPermitEdmontonDTO> QueryByFormGN24Id(long formGN24Id);
        List<WorkPermitEdmontonDTO> QueryByFormGN6Id(long formGN6Id);
        List<WorkPermitEdmontonDTO> QueryByFormGN75AId(long formGN6Id);
        List<WorkPermitEdmontonDTO> QueryByFormGN1Id(long formGN1Id);

        List<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRange, IFlocSet flocSet, string username);
    }
}
