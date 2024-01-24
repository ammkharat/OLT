using System;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class WorkPermitTestDao
    {
        public static void DeleteWorkPermits(params WorkPermit[] permits)
        {
            Array.ForEach(permits, DeleteWorkPermit);
        }

        public static void DeleteWorkPermit(WorkPermit permit)
        {
            TestDataAccessUtil.ExecuteExpression("DELETE FROM WorkPermitGasTestElementInfo WHERE WorkPermitId = {0}",
                permit.Id);
            TestDataAccessUtil.ExecuteExpression("DELETE FROM WorkPermit WHERE Id = {0}",
                permit.Id);

            if (permit.SapOperationId.HasValue)
            {
                TestDataAccessUtil.ExecuteExpression("DELETE FROM SapWorkOrderOperation WHERE Id = {0}",
                    permit.SapOperationId);
            }
        }

    }
}
