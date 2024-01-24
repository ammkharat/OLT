using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitFortHillsType : SortableSimpleDomainObject
    {
        public static WorkPermitFortHillsType SPECIFIC_HOT = new WorkPermitFortHillsType(1, 1,
            StringResources.WorkPermitSpecificHot);

        public static WorkPermitFortHillsType BLANKET_HOT = new WorkPermitFortHillsType(2, 2,
            StringResources.WorkPermitBlanketHot);

        public static WorkPermitFortHillsType SPECIFIC_COLD = new WorkPermitFortHillsType(3, 3,
            StringResources.WorkPermitSpecificCold);

        public static WorkPermitFortHillsType BLANKET_COLD = new WorkPermitFortHillsType(4, 4,
            StringResources.WorkPermitBlanketCold);

        public static WorkPermitFortHillsType[] All = { SPECIFIC_HOT, BLANKET_HOT, SPECIFIC_COLD, BLANKET_COLD };
        public static WorkPermitFortHillsType NULL = new WorkPermitFortHillsType(0, 0, string.Empty);

        private readonly String name;

        private WorkPermitFortHillsType(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }

        public static WorkPermitFortHillsType Get(long index)
        {
            return GetById(index, All);
        }
    }
}