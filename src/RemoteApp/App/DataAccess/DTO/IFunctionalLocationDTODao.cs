using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Remote.DataAccess.DTO
{
    public interface IFunctionalLocationDTODao : IDao
    {
        List<FunctionalLocationDTO> QueryBySearchTextInDescriptionOrFullHierarchy(string searchText, Site site, IList<FunctionalLocationType> allowedTypes);
    }
}