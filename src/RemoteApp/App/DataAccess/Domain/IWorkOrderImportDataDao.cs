using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkOrderImportDataDao : IDao
    {
        void Insert(WorkOrderImportData permitRequest);
        void Delete(long batchId);
        long GetBatchId();
        List<WorkOrderImportData> QueryByBatchId(long batchId);
    }
}
