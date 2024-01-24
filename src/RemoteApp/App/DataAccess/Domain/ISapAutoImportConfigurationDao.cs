using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface ISapAutoImportConfigurationDao : IDao
    {
        SapAutoImportConfiguration QueryBySiteId(long siteId);        
        void Update(SapAutoImportConfiguration configuration);
        void Disable(SapAutoImportConfiguration schedule);        
    }
}
