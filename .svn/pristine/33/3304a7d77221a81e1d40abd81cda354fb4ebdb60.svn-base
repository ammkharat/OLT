using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IDocumentLinkService
    {
        [OperationContract]
        void Remove(long id);

        [OperationContract]
        List<DocumentRootUncPath> QueryRootsBySiteId(long siteId);

        [OperationContract]
        List<DocumentRootUncPath> QueryRootsBySecondLevelFunctionalLocation(SectionOnlyFlocSet flocSet);

        [OperationContract]
        void Insert(DocumentRootUncPath editObject);

        [OperationContract]
        void Update(DocumentRootUncPath editObject);
    }
}