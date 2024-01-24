using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ConfiguredDocumentLinkService : IConfiguredDocumentLinkService
    {
        private readonly IConfiguredDocumentLinkDao configuredDocumentLinkDao;

        public ConfiguredDocumentLinkService()
        {
            configuredDocumentLinkDao = DaoRegistry.GetDao<IConfiguredDocumentLinkDao>();
        }

        public List<ConfiguredDocumentLink> GetLinks(ConfiguredDocumentLinkLocation location)
        {
            return configuredDocumentLinkDao.QueryByLocation(location);
        }

        public void UpdateLinks(List<ConfiguredDocumentLink> documentLinks, List<ConfiguredDocumentLink> deletedLinks)
        {
            configuredDocumentLinkDao.UpdateLinks(documentLinks, deletedLinks);
        }
    }
}
