using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ILabAlertDTODao : IDao
    {
        List<LabAlertDTO> QueryByFlocReturnMatchesInTheSameFlocTreeAboveOrBelowSearchFlocs(IFlocSet flocSet, DateRange dateRange, List<LabAlertStatus> statuses);
    }
}
