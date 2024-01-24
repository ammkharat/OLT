using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - this cold be cached, but it's only used by the SiteConfigurationDao. So, best to cache SiteConfiguration!
    public interface IActionItemDefinitionAutoReApprovalConfigurationDao : IDao
    {
        ActionItemDefinitionAutoReApprovalConfiguration QueryBySiteId(long siteId);
        void Update(ActionItemDefinitionAutoReApprovalConfiguration configToBeUpdated);
    }
}
