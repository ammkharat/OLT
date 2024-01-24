using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ITargetAlertDTODao : IDao
    {
        List<TargetAlertDTO> QueryByFunctionalLocationsAndStatuses(IFlocSet flocSet, List<TargetAlertStatus> statuses, DateRange dateRange);
        List<TargetAlertExcelReportDTO> QueryForExcelReport(IFlocSet flocSet, List<TargetAlertStatus> statuses, DateRange dateRange);
    }
}
