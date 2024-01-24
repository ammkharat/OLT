using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IOnPremisePersonnelDtoDao : IDao
    {
        IList<OnPremisePersonnelSupervisorDTO> QuerySupervisorViewDtos(Range<DateTime> dateRange);
        IList<OnPremisePersonnelAuditDTO> QueryAuditViewDtos(Range<Date> dateRange);
        IList<OnPremisePersonnelShiftReportDetailDTO> QueryOnPremisePersonnelShiftReportDetailDtos(Range<DateTime> dateRange);
    }
}