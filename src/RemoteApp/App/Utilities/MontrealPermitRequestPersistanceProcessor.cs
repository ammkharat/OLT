using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class MontrealPermitRequestPersistanceProcessor : AbstractPermitRequestPersistanceProcessor<PermitRequestMontreal>
    {
        public MontrealPermitRequestPersistanceProcessor(Date importFromDate, Date importToDate, IPermitRequestDao<PermitRequestMontreal> permitRequestDao, List<PermitRequestMontreal> incomingPermitRequests, List<WorkOrderImportData> completeIncomingWorkOrderList)
                : base(importFromDate, importToDate, permitRequestDao, incomingPermitRequests, completeIncomingWorkOrderList)
        {
        }

        protected override List<PermitRequestMontreal> QueryExistingPermitRequests(PermitRequestMontreal permitRequest)
        {            
            List<PermitRequestMontreal> results = 
                permitRequestDao.QueryByWorkOrderNumberAndOperationAndSource(
                    permitRequest.WorkOrderNumber, permitRequest.OperationNumber, permitRequest.SubOperationNumber, permitRequest.DataSource);

            return results;
        }

        protected override void PerformPostProcessStep()
        {
            List<PermitRequestMontreal> existingPermitRequestsForDateRange = permitRequestDao.QueryByDateRangeAndDataSource(importFromDate, importToDate, DataSource.SAP);
            deleteList.AddRange(BuildImportRemovalList(existingPermitRequestsForDateRange));
        }
    }
}
