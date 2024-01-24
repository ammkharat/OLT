using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IStreamingRoleService
    {
        [OperationContract]
        Stream QueryRoleMatrix(Site currentSite);
    }
}