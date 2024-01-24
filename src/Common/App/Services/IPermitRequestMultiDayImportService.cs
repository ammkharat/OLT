using System;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IPermitRequestMultiDayImportService
    {
        [OperationContract]
        long GetNewBatchId();

        [OperationContract]
        WorkOrderDataImportResult Import(User user, Date from, long batchId, Site site);

        [OperationContract]
        PermitRequestPostFinalizeResult FinalizeImport(Date @from, Date to, long batchId, User currentUser, Site site);

        [OperationContract]
        DateTime? GetLastImportDateTime(Site site);
    }
}