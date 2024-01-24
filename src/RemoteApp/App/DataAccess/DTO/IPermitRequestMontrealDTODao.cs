using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IPermitRequestMontrealDTODao : IDao
    {
        List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        List<PermitRequestMontrealDTO> QueryByFlocUnitAndBelowForTemplate(IFlocSet flocSet, DateRange dateRange, string username);
    }
}
