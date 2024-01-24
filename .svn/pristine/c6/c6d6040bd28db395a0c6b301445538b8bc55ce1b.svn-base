using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetDefinitionReadWriteTagConfigurationDao : IDao
    {
        [CachedQuery("ReadWriteTagConfigurationByTargetDefinitionId")]
        TargetDefinitionReadWriteTagConfiguration QueryByTargetDefinitionId(long targetDefinitionId);
        
        [CachedInsertOrUpdate(false, false)]
        void Insert(TargetDefinition targetDefinition);
        
        [CachedInsertOrUpdate(false, false)]
        void Update(TargetDefinitionReadWriteTagConfiguration readWriteTagConfiguration);
    }
}