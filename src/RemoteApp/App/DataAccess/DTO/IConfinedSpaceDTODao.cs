using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IConfinedSpaceDTODao : IDao
    {
        List<ConfinedSpaceDTO> QueryByFlocUnitAndBelow(
            IFlocSet flocSet, DateRange dateRange);
    }
}