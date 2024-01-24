using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IStreamingRequestRoleService
    {
        [OperationContract(Name = "GenerateRoleChangesForAllSites")]
        List<RoleElementChange> GenerateRoleChanges(Stream excelStream);
    }
}