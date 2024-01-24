using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ITargetDefinitionDTODao : IDao
    {
        List<TargetDefinitionDTO> QueryByActionItemDefinitionId(long actionItemDefinitionId);
        List<TargetDefinitionDTO> QueryAssociatedTargets(long parentTargetId);

        List<TargetDefinitionDTO> QueryByFunctionalLocations(IFlocSet flocSet, DateRange dateRange);
    }
}