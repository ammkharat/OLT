using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IDeviationAlertReportDTODao : IDao
    {
        List<DeviationAlertReportDTO> QueryByDateRangeAndParentFunctionalLocation(
            Date startDate, Date endDate, IFlocSet flocSet);
    }
}
