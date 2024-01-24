using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class EdmontonPermitRequestPersistanceProcessor : AbstractPermitRequestPersistanceProcessor<PermitRequestEdmonton>
    {
        public EdmontonPermitRequestPersistanceProcessor(IPermitRequestEdmontonDao permitRequestDao, List<PermitRequestEdmonton> incomingPermitRequests)
            : base(null, null, permitRequestDao, incomingPermitRequests, null)
        {
        }

        protected override List<PermitRequestEdmonton> QueryExistingPermitRequests(PermitRequestEdmonton permitRequest)
        {
            List<PermitRequestWorkOrderSource> sources = permitRequest.WorkOrderSourceList;

            if (sources.Count != 1)
            {
                throw new InvalidOperationException("The Permit Request must have exactly 1 work order source to use this method");
            }

            PermitRequestWorkOrderSource source = sources[0];

            List<PermitRequestEdmonton> results = permitRequestDao.QueryByWorkOrderNumberAndOperationAndSource(source.WorkOrderNumber, source.OperationNumber, source.SubOperationNumber, permitRequest.DataSource);
            return results;
        }
    }
}
