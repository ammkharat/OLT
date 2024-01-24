using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISiteService
    {
        [OperationContract]
        List<Site> GetAll();

        [OperationContract]
        Site QueryById(long id);

        /// <summary>
        ///     Queries the site list to return the site associated with the given plant id
        /// </summary>
        /// <param name="plantId"></param>
        /// <returns></returns>
        [OperationContract]
        Site QueryByPlantId(string plantId);
    }
}