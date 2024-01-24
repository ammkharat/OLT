using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ITargetDefinitionAutoReApprovalConfigurationDao : IDao
    {
        [CachedQueryById]
        TargetDefinitionAutoReApprovalConfiguration QueryById(long siteId);
        [CachedInsertOrUpdate(false, false)]
        void Update(TargetDefinitionAutoReApprovalConfiguration configToBeUpdated);
    }
}