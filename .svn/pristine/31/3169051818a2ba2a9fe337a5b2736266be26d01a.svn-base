using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class AvailabilityReason : SortableSimpleDomainObject
    {
        public static readonly AvailabilityReason None = new AvailabilityReason(0, 0);
        public static readonly AvailabilityReason Turnaround = new AvailabilityReason(1, 1);
        public static readonly AvailabilityReason RoutineMaintenance = new AvailabilityReason(2, 2);
        public static readonly AvailabilityReason RegulativeProcessing = new AvailabilityReason(3, 3);
        public static readonly AvailabilityReason Other = new AvailabilityReason(4, 4);

        public static readonly AvailabilityReason[] ALL =
        {
            None, Turnaround, RoutineMaintenance, RegulativeProcessing,
            Other
        };

        private AvailabilityReason(int id, int displayPriority) : base(id, displayPriority)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.FunctionalLocationOperationalModeAvailabilityReason_None;
            }
            if (IdValue == 1)
            {
                return StringResources.FunctionalLocationOperationalModeAvailabilityReason_Turnaround;
            }
            if (IdValue == 2)
            {
                return StringResources.FunctionalLocationOperationalModeAvailabilityReason_RoutineMaintenance;
            }
            if (IdValue == 3)
            {
                return StringResources.FunctionalLocationOperationalModeAvailabilityReason_RegulativeProcessing;
            }
            if (IdValue == 4)
            {
                return StringResources.FunctionalLocationOperationalModeAvailabilityReason_Other;
            }
            return null;
        }

        public static AvailabilityReason GetById(long id)
        {
            return GetById(id, ALL);
        }
    }
}