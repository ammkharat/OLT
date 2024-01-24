using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IOpmExcursionEventPriorityPageDTODao : IDao
    {
        List<ExcursionEventPriorityPageDTO> QueryUnrespondedExcursionEventPriorityPageDTOsThatAreOpenOrRecentlyClosed(
            DateTime dateTime, List<FunctionalLocation> flocs);

        List<ExcursionEventPriorityPageDTO>
            QueryRespondedExcursionEventPriorityPageDTOsThatAreStillExceedingOperatingLimits(
            DateTime dateTime, List<FunctionalLocation> flocs);
    }
}