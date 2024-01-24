using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class DocumentLinkService : IDocumentLinkService
    {
        private readonly IDocumentLinkDao dao;

        public DocumentLinkService()
        {
            dao = DaoRegistry.GetDao<IDocumentLinkDao>();
        }

        public void Remove(long id)
        {
            dao.RemoveRootPath(id);
        }

        public List<DocumentRootUncPath> QueryRootsBySiteId(long siteId)
        {
            return dao.QueryRootsBySiteId(siteId);
        }

        public List<DocumentRootUncPath> QueryRootsBySecondLevelFunctionalLocation(SectionOnlyFlocSet flocSet)
        {
            return dao.QueryRootsByFunctionalLocation(flocSet);
        }

        public void Insert(DocumentRootUncPath editObject)
        {
            dao.InsertRootPath(editObject);
        }

        public void Update(DocumentRootUncPath editObject)
        {
            dao.UpdateRootPath(editObject);
        }
    }
}