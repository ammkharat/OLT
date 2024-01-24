using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class LubesPermitRequestPersistanceProcessor : AbstractPermitRequestPersistanceProcessor<PermitRequestLubes>
    {
        public LubesPermitRequestPersistanceProcessor(Date importFromDate, Date importToDate, IPermitRequestDao<PermitRequestLubes> permitRequestDao, List<PermitRequestLubes> incomingPermitRequests, List<WorkOrderImportData> completeIncomingWorkOrderList)
            : base(importFromDate, importToDate, permitRequestDao, incomingPermitRequests, completeIncomingWorkOrderList)
        {
        }

        protected override List<PermitRequestLubes> QueryExistingPermitRequests(PermitRequestLubes permitRequest)
        {
            List<PermitRequestLubes> results =
                permitRequestDao.QueryByWorkOrderNumberAndOperationAndSource(permitRequest.WorkOrderNumber, permitRequest.OperationNumber, permitRequest.SubOperationNumber, permitRequest.DataSource);

            return results;
        }

        protected override void PerformPostProcessStep()
        {
            List<PermitRequestLubes> existingPermitRequestsForDateRange = permitRequestDao.QueryByDateRangeAndDataSource(importFromDate, importToDate, DataSource.SAP);
            deleteList.AddRange(BuildImportRemovalList(existingPermitRequestsForDateRange));
        }
    }
}