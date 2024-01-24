using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class FortHillsPermitRequestPersistanceProcessor : AbstractPermitRequestPersistanceProcessor<PermitRequestFortHills>
    {
        public FortHillsPermitRequestPersistanceProcessor(IPermitRequestFortHillsDao permitRequestDao, List<PermitRequestFortHills> incomingPermitRequests)
            : base(null, null, permitRequestDao, incomingPermitRequests, null)
        {
        }

       protected override List<PermitRequestFortHills> QueryExistingPermitRequests(PermitRequestFortHills permitRequest)
        {
            List<PermitRequestWorkOrderSource> sources = permitRequest.WorkOrderSourceList;

            if (sources.Count != 1)
            {
                throw new InvalidOperationException("The Permit Request must have exactly 1 work order source to use this method");
            }

            PermitRequestWorkOrderSource source = sources[0];

            List<PermitRequestFortHills> results = permitRequestDao.QueryByWorkOrderNumberAndOperationAndSource(source.WorkOrderNumber, source.OperationNumber, source.SubOperationNumber, permitRequest.DataSource);
            return results;
        }
    }
}
