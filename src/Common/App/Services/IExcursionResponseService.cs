using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.DTO.Excursions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IExcursionResponseService
    {
        [OperationContract]
        List<OpmExcursionResponseDTO> QueryDTOsByDateRangeAndFlocs(DateRange dateRange, List<FunctionalLocation> flocs);

        [OperationContract]
        OpmExcursion QueryById(long idValue);

        [OperationContract]
        OpmExcursionEditPackage CreateEditPackage(List<long> opmExcursionIds);

        [OperationContract]
        List<ExcursionEventPriorityPageDTO> QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(
            DateTime dateTime, List<FunctionalLocation> flocs);

        [OperationContract]
        List<ExcursionEventPriorityPageDTO>
        QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(DateTime dateTime,
            List<FunctionalLocation> flocs);

        [OperationContract]
        List<NotifiedEvent> UpdateEditPackageChanges(OpmExcursionEditPackage arg);

        [OperationContract]
        List<OpmExcursionResponseDTO> QueryDTOsByDateRangeAndFlocsForShiftHandover(DateTime startOfShift, DateTime endOfShift, List<FunctionalLocation> flocs);
    }
}