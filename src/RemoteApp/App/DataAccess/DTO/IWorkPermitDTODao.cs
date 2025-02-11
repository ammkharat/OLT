using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitDTODao : IDao
    {
        List<WorkPermitDTO> QueryByFLOCsAndShiftForThisDate(IFlocSet rootFlocSet, List<WorkPermitStatus> statuses, ShiftPattern shiftPattern, DateTime dateTime);
        List<WorkPermitDTO> QueryByDateRangeAndStatuses(IFlocSet rootFlocSet, IList<WorkPermitStatus> statuses, DateTime startDate, DateTime? endDate, WorkAssignment workAssignment);
        List<WorkPermitDTO> QueryByDateRangeAndStatusesForTemplate(IFlocSet rootFlocSet, IList<WorkPermitStatus> statuses, DateTime startDate,
            DateTime? endDate, WorkAssignment workAssignment, bool template, string username);
        
    }
}