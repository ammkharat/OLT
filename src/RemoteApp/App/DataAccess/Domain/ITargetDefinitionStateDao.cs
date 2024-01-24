using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetDefinitionStateDao : IDao
    {
        [CachedQueryById]
        TargetDefinitionState QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        void Update(TargetDefinitionState targetDefinitionState);
        [CachedInsertOrUpdate(false, false)]
        void Insert(TargetDefinitionState targetDefinitionState);

        List<TargetDefinitionState> QueryAllTargetDefinitionStatesUnderAUnitId(long thirdLevelFlocId);
    }
}