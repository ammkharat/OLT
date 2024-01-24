using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IDetailedLogReportDTODao : IDao
    {
        List<DetailedLogReportDTO> QueryForLogs(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);

        List<DetailedLogReportDTO> QueryForSummaryLogs(
            UserShift startUserShift,
            UserShift endUserShift,
            IFlocSet flocSet,
            List<WorkAssignment> workAssignments,
            bool includeNullWorkAssignment);
    }
}
