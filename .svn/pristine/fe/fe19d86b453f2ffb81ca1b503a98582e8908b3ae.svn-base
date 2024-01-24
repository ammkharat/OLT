using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFunctionalLocationDTOService
    {
        [OperationContract]
        List<FunctionalLocationDTO> QueryBySearchTextInDescriptionOrFullHierarchy(string searchText, Site site,
            IList<FunctionalLocationType> allowedTypes);
    }
}