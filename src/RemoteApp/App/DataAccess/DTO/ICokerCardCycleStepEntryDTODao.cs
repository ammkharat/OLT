using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ICokerCardCycleStepEntryDTODao : IDao
    {
        List<CokerCardCycleStepEntryDTO> QueryByConfigurationIdsAndDateRange(List<long> configurationIds, Date startOfRange, Date endOfRange);
    }
}
