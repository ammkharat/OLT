using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitMontrealGroupFixture
    {
        public static WorkPermitMontrealGroup CreateWithExistingId()
        {
            return Create(1, "Group");
        }

        public static WorkPermitMontrealGroup CreateForInsert()
        {
            return Create(-1, "Group");
        }

        public static WorkPermitMontrealGroup Create(long id, string groupName)
        {
            WorkPermitMontrealGroup group = new WorkPermitMontrealGroup(groupName, 0);
            group.Id = id;

            return group;
        }
    }
}