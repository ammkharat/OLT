using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IActionItemDefinitionDTODao : IDao
    {
        List<ActionItemDefinitionDTO> QueryByFunctionalLocations(
            IFlocSet flocSet, DateTime? startDate, DateTime? endDate, List<long> readableVisibilityGroupIds);
        List<ActionItemDefinitionDTO> QueryByTargetDefinitionId(long? targetId);

        //ayman action item definition
        List<ActionItemDefinitionDTO> QueryByActionItemDefinitions(List<long> aidSet,
            List<long> readableVisibilityGroupIds);
    }
}