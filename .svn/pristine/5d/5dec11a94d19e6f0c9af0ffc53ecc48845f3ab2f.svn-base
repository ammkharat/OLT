using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface ISpecialWorkService
    {
        [OperationContract]
        List<SpecialWork> QueryBySite(Site site);

        [OperationContract]
        void UpdateContractors(Site site, IList<SpecialWork> contractors);
    }
}