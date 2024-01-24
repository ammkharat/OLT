using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO.Reporting;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetAlertResponseDao : IDao
    {
        TargetAlertResponse Insert(TargetAlertResponse response);
        List<TargetAlertResponse> QueryByTargetAlert(TargetAlert targetAlert);
        List<ShiftGapReasonReportDTO> QueryGapReasonsByShiftAndDateRange(IFlocSet flocSet, 
                                                                                   ShiftPattern shiftPattern, 
                                                                                   DateTime fromDateTime, 
                                                                                   DateTime toDateTime);
    }
}