using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.DTO;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FunctionalLocationDTOService : IFunctionalLocationDTOService
    {
        private readonly IFunctionalLocationDTODao dao;

        public FunctionalLocationDTOService() : this(DaoRegistry.GetDao<IFunctionalLocationDTODao>())
        {
        }

        public FunctionalLocationDTOService(IFunctionalLocationDTODao functionalLocationDao)
        {
            dao = functionalLocationDao;
        }

        public List<FunctionalLocationDTO> QueryBySearchTextInDescriptionOrFullHierarchy(string searchText, Site site, IList<FunctionalLocationType> allowedTypes)
        {
            return dao.QueryBySearchTextInDescriptionOrFullHierarchy(searchText, site, allowedTypes);
        }

    }
}
