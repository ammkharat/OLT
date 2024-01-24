using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface ILogDefinitionDTODao : IDao
    {
        List<LogDefinitionDTO> QueryByFunctionalLocationsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibilityGroupIds);
        List<LogDefinitionDTO> QueryByUserRootFlocsAndLogType(IFlocSet flocSet, LogType logType, List<long> readableVisibilityGroupIds);
    }
}