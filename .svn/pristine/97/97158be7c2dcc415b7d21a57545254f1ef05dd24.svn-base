using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IConfiguredDocumentLinkService
    {
        [OperationContract]
        List<ConfiguredDocumentLink> GetLinks(ConfiguredDocumentLinkLocation location);

        [OperationContract]
        void UpdateLinks(List<ConfiguredDocumentLink> documentLinks, List<ConfiguredDocumentLink> deletedLinks);
    }
}