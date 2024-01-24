using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitLubesType : SortableSimpleDomainObject
    {
        public static WorkPermitLubesType HAZARDOUS_COLD_WORK = new WorkPermitLubesType(1, 1,
            StringResources.WorkPermitLubesHazardousColdWork);

        public static WorkPermitLubesType HOT_WORK = new WorkPermitLubesType(2, 2,
            StringResources.WorkPermitLubesHotWork);

        public static WorkPermitLubesType[] All = {HAZARDOUS_COLD_WORK, HOT_WORK};

        private readonly String name;

        private WorkPermitLubesType(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }

        public static WorkPermitLubesType Get(long index)
        {
            return GetById(index, All);
        }

        public static string GetPermitTypeLabel(WorkPermitLubesType permitType, bool isVehicleEntry)
        {
            if (HAZARDOUS_COLD_WORK.Equals(permitType))
            {
                return HAZARDOUS_COLD_WORK.ToString();
            }

            var hotString = HOT_WORK.ToString();

            if (isVehicleEntry)
            {
                hotString += string.Format(" ({0})", StringResources.WorkPermitLubesVehicleEntry);
            }

            return hotString;
        }
    }
}