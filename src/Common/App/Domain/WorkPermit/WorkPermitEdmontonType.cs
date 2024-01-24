using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitEdmontonType : SortableSimpleDomainObject
    {
        public static WorkPermitEdmontonType ROUTINE_MAINTENANCE = new WorkPermitEdmontonType(1, 1,
            StringResources.WorkPermitRoutineMaintenance);

        public static WorkPermitEdmontonType COLD_WORK = new WorkPermitEdmontonType(2, 2,
            StringResources.WorkPermitColdWork);

        public static WorkPermitEdmontonType HOT_WORK = new WorkPermitEdmontonType(3, 3,
            StringResources.WorkPermitHotWork);

        public static WorkPermitEdmontonType HIGH_ENERGY_HOT_WORK = new WorkPermitEdmontonType(4, 4,
            StringResources.WorkPermitHighEnergyHotWork);

        public static WorkPermitEdmontonType[] All = {ROUTINE_MAINTENANCE, COLD_WORK, HOT_WORK, HIGH_ENERGY_HOT_WORK};
        public static WorkPermitEdmontonType NULL = new WorkPermitEdmontonType(0, 0, string.Empty);

        private readonly String name;

        private WorkPermitEdmontonType(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }

        public static WorkPermitEdmontonType Get(long index)
        {
            return GetById(index, All);
        }
    }
}