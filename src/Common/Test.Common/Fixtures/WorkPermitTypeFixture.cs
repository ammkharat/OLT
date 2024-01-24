using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public class WorkPermitTypeFixture
    {
        public static WorkPermitType CreateWorkPermitTypeHot()
        {
            WorkPermitType workPermitType = WorkPermitType.HOT;

            return workPermitType;
        }

        public static WorkPermitType CreateWorkPermitTypeCold()
        {
            WorkPermitType workPermitType = WorkPermitType.COLD;

            return workPermitType;
        }
    }
}