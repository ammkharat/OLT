using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitMontrealType : SortableSimpleDomainObject
    {
        public static WorkPermitMontrealType COLD = new WorkPermitMontrealType(1, 1);
        public static WorkPermitMontrealType VEHICLE_ENTRY = new WorkPermitMontrealType(2, 2);
        public static WorkPermitMontrealType MODERATE_HOT = new WorkPermitMontrealType(3, 3);
        public static WorkPermitMontrealType ELEVATED_HOT = new WorkPermitMontrealType(4, 4);
        public static WorkPermitMontrealType FRESH_AIR_MASK = new WorkPermitMontrealType(5, 5);
        public static WorkPermitMontrealType DURATION_COLD = new WorkPermitMontrealType(6, 6);
        public static WorkPermitMontrealType DURATION_MODERATE_HOT = new WorkPermitMontrealType(7, 7);

        public static WorkPermitMontrealType[] All =
        {
            COLD, VEHICLE_ENTRY, MODERATE_HOT, ELEVATED_HOT, FRESH_AIR_MASK,
            DURATION_COLD, DURATION_MODERATE_HOT
        };

        public static WorkPermitMontrealType[] PERMIT_REQUEST_TYPES =
        {
            COLD, VEHICLE_ENTRY, MODERATE_HOT, ELEVATED_HOT,
            FRESH_AIR_MASK
        };

        public static WorkPermitMontrealType[] DURATION_PERMIT_TYPES = {DURATION_COLD, DURATION_MODERATE_HOT};

        public static WorkPermitMontrealType NULL = new WorkPermitMontrealType(0, 0);

        private WorkPermitMontrealType(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.WorkPermitCold;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitVehicleEntry;
            }
            if (IdValue == 3)
            {
                return StringResources.WorkPermitModerdateHot;
            }
            if (IdValue == 4)
            {
                return StringResources.WorkPermitElevatedHot;
            }
            if (IdValue == 5)
            {
                return StringResources.WorkPermitFreshAirMask;
            }
            if (IdValue == 6)
            {
                return StringResources.WorkPermitDurationCold;
            }
            if (IdValue == 7)
            {
                return StringResources.WorkPermitDurationModerateHot;
            }
            return string.Empty;
        }

        public static WorkPermitMontrealType Get(long index)
        {
            return GetById(index, All);
        }
    }
}