using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ICokerCardDao : IDao
    {
        CokerCard QueryById(long id);
        CokerCard QueryByConfigurationAndShift(long configurationId, UserShift shift);

        CokerCard Insert(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries);
        void Update(CokerCard cokerCard, List<CokerCardCycleStepEntry> previousEntries);
        void Remove(CokerCard cokerCard);

        List<CokerCardDrumEntryDTO> QueryCokerCardSummaries(Date shiftStartDate, long shiftId, long workAssignmentId, List<long> cokerCardConfigurationIds);
    }
}