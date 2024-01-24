using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPermitAttributeService
    {
        [OperationContract]
        List<PermitAttribute> QueryBySite(long siteId);
    }
}