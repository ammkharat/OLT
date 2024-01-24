using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitRequestFortHillsSAPImportDataDao : IDao
    {
        PermitRequestFortHillsSAPImportData Insert(PermitRequestFortHillsSAPImportData permitRequest);
        PermitRequestFortHillsSAPImportData QueryByWorkOrderInformation(string workOrderNumber, string operationNumber, string subOperationNumber);
        void Delete(long batchId);
        long GetBatchId();
        List<PermitRequestFortHillsSAPImportData> QueryByBatchId(long batchId);
    }
}
