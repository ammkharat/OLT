using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TargetGapReason : SimpleDomainObject
    {
        public static readonly TargetGapReason Null = new TargetGapReason(-99, false);

        public static readonly TargetGapReason EquipmentFailure = new TargetGapReason(0, true);
        private static readonly TargetGapReason EquipmentLimitation = new TargetGapReason(1, true);
        private static readonly TargetGapReason UnplannedUnitShutdown = new TargetGapReason(2, true);
        private static readonly TargetGapReason UnplannedUnitSlowdown = new TargetGapReason(3, true);
        private static readonly TargetGapReason OtherMechanicalReason = new TargetGapReason(4, true);
        private static readonly TargetGapReason AdvancedProcessControlLimitation = new TargetGapReason(5, false);
        private static readonly TargetGapReason DesiredTargetReached = new TargetGapReason(6, false);
        private static readonly TargetGapReason PlannedEquipmentShutdown = new TargetGapReason(7, false);
        private static readonly TargetGapReason PlannedUnitShutdown = new TargetGapReason(8, false);
        private static readonly TargetGapReason PlannedUnitSlowdown = new TargetGapReason(9, false);
        private static readonly TargetGapReason FeedDietLimitation = new TargetGapReason(10, false);
        private static readonly TargetGapReason ProductSpecificationLimitation = new TargetGapReason(11, false);
        private static readonly TargetGapReason OtherOperationalReason = new TargetGapReason(12, false);

        private static readonly TargetGapReason[] all =
        {
            EquipmentFailure,
            EquipmentLimitation,
            UnplannedUnitShutdown,
            UnplannedUnitSlowdown,
            OtherMechanicalReason,
            AdvancedProcessControlLimitation,
            DesiredTargetReached,
            PlannedEquipmentShutdown,
            PlannedUnitShutdown,
            PlannedUnitSlowdown,
            FeedDietLimitation,
            ProductSpecificationLimitation,
            OtherOperationalReason
        };

        private readonly bool mechanical;

        private TargetGapReason(long id, bool mechanical)
            : base(id)
        {
            this.mechanical = mechanical;
        }

        public bool IsMechanical
        {
            get { return mechanical; }
        }

        public static TargetGapReason[] All
        {
            get { return all; }
        }

        public static TargetGapReason[] AllWithEmpty
        {
            get
            {
                var reasons = new TargetGapReason[all.Length + 1];
                reasons[0] = Null;
                Array.Copy(all, 0, reasons, 1, all.Length);
                return reasons;
            }
        }

        public override string GetName()
        {
            if (IdValue == -99)
            {
                return string.Empty;
            }
            if (IdValue == 0)
            {
                return StringResources.TargetGapReason_EquipmentFailure;
            }
            if (IdValue == 1)
            {
                return StringResources.TargetGapReason_EquipmentLimitation;
            }
            if (IdValue == 2)
            {
                return StringResources.TargetGapReason_UnplannedUnitShutdown;
            }
            if (IdValue == 3)
            {
                return StringResources.TargetGapReason_UnplannedUnitSlowdown;
            }
            if (IdValue == 4)
            {
                return StringResources.TargetGapReason_OtherMechanicalReason;
            }
            if (IdValue == 5)
            {
                return StringResources.TargetGapReason_AdvancedProcessControlLimitation;
            }
            if (IdValue == 6)
            {
                return StringResources.TargetGapReason_DesiredTargetReached;
            }
            if (IdValue == 7)
            {
                return StringResources.TargetGapReason_PlannedEquipmentShutdown;
            }
            if (IdValue == 8)
            {
                return StringResources.TargetGapReason_PlannedUnitShutdown;
            }
            if (IdValue == 9)
            {
                return StringResources.TargetGapReason_PlannedUnitSlowdown;
            }
            if (IdValue == 10)
            {
                return StringResources.TargetGapReason_FeedDietLimitation;
            }
            if (IdValue == 11)
            {
                return StringResources.TargetGapReason_ProductSpecificationLimitation;
            }
            if (IdValue == 12)
            {
                return StringResources.TargetGapReason_OtherOperationalReason;
            }
            return null;
        }

        public static TargetGapReason Get(long? id)
        {
            if (id.HasNoValue())
            {
                return Null;
            }

            return GetById(id, all) ?? Null;
        }
    }
}