using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO.Reporting;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ICustomFieldTrendReportDTODao : IDao
    {

        List<CustomFieldTrendReportDTO> QueryCustomFieldTrendReportDataForSummaryLogs(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<WorkAssignment> workAssignments, bool includeNullAssignment);

        List<CustomFieldTrendReportDTO> QueryCustomFieldTrendReportDataForLogs(IFlocSet flocSet, DateTime startDateTime, DateTime endDateTime, List<WorkAssignment> workAssignments, bool includeNullAssignment, LogType logType);
    }
}
