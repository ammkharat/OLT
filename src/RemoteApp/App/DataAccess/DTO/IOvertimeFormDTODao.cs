using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IOvertimeFormDTODao : IDao
    {
        IList<EdmontonOvertimeFormDTO> QueryDTOs(DateRange dateRange);
        IList<EdmontonOvertimeFormDTO> QueryWaitingApprovalDTOs(DateRange dateRange);
    }
}