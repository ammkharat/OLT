using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IWorkPermitEdmontonHazardDTODao : IDao
    {
        List<WorkPermitEdmontonHazardDTO> QueryByFlocsAndStatus(IFlocSet flocSet, List<PermitRequestBasedWorkPermitStatus> statuses);
    }
}
