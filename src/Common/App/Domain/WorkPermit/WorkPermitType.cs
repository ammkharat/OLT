using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitType : SortableSimpleDomainObject
    {
        public static WorkPermitType HOT = new WorkPermitType(1, 2);
        public static WorkPermitType COLD = new WorkPermitType(2, 1);

        public static WorkPermitType[] All = {HOT, COLD};
        public static WorkPermitType NULL = new WorkPermitType(0, 0);

        private WorkPermitType(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.WorkPermitHot;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitCold;
            }
            return string.Empty;
        }

        public static WorkPermitType Get(long index)
        {
            return GetById(index, All);
        }
    }
}