using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IPermitRequestLubesDTODao : IDao
    {
        List<PermitRequestLubesDTO> QueryByDateRangeAndFlocs(IFlocSet flocSet, DateRange dateRange);
        List<PermitRequestLubesDTO> QueryByCompletenessAndGroupAndDateWithinRange(List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date);
    }
}
