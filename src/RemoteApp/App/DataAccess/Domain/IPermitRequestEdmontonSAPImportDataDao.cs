using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestEdmontonSAPImportDataDao : IDao
    {
        PermitRequestEdmontonSAPImportData Insert(PermitRequestEdmontonSAPImportData permitRequest);
        PermitRequestEdmontonSAPImportData QueryByWorkOrderInformation(string workOrderNumber, string operationNumber, string subOperationNumber);
        void Delete(long batchId);
        long GetBatchId();
        List<PermitRequestEdmontonSAPImportData> QueryByBatchId(long batchId);
    }
}
