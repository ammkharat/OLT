using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IDropdownValueService
    {
        [OperationContract]
        List<DropdownValue> QueryAll(long siteId);

        [OperationContract]
        List<DropdownValue> QueryByKey(long siteId, string key);

        [OperationContract]
        void UpdateValues(List<DropdownValue> values, List<DropdownValue> deletedValues);
    }
}