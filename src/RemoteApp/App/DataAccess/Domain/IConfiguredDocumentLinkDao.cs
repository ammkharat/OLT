using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IConfiguredDocumentLinkDao : IDao
    {
        List<ConfiguredDocumentLink> QueryByLocation(ConfiguredDocumentLinkLocation location);
        void Remove(ConfiguredDocumentLink link);
        ConfiguredDocumentLink Insert(ConfiguredDocumentLink link);
        void UpdateLinks(List<ConfiguredDocumentLink> documentLinks, List<ConfiguredDocumentLink> deletedLinks);
    }
}
