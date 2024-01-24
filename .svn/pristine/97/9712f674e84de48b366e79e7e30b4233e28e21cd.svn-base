using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitEdmontonGroupFixture
    {
        public static WorkPermitEdmontonGroup CreateForInsert()
        {
            return CreateForInsert(-1, "Group");
        }

        public static WorkPermitEdmontonGroup CreateForInsert(long id, string groupName)
        {
            return new WorkPermitEdmontonGroup(id, groupName, new List<long> { 0 }, 0, false);
        }

        public static WorkPermitEdmontonGroup CreateP1()
        {
            return new WorkPermitEdmontonGroup(-1, "Some Group", new List<long> { WorkOrderPriority.P1.IdValue }, 0, false);
        }

        public static WorkPermitEdmontonGroup CreateP4()
        {
            return new WorkPermitEdmontonGroup(-1, "Some Group", new List<long> { WorkOrderPriority.P4.IdValue }, 0, false);
        }
    }
}