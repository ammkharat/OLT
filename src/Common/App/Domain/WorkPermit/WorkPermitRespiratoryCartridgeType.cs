using System;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkPermitRespiratoryCartridgeType : SimpleDomainObject
    {
        public static WorkPermitRespiratoryCartridgeType OV_AG_HEPA = new WorkPermitRespiratoryCartridgeType(1,
            "OV/AG/HEPA");

        public static WorkPermitRespiratoryCartridgeType OV_AG = new WorkPermitRespiratoryCartridgeType(2, "OV/AG");
        public static WorkPermitRespiratoryCartridgeType HEPA = new WorkPermitRespiratoryCartridgeType(3, "HEPA");
        public static WorkPermitRespiratoryCartridgeType AMMONIA = new WorkPermitRespiratoryCartridgeType(4, "Ammonia");

        private static readonly WorkPermitRespiratoryCartridgeType[] All = {OV_AG_HEPA, OV_AG, HEPA, AMMONIA};
        private readonly string name;

        private WorkPermitRespiratoryCartridgeType(long id, string name)
            : base(id)
        {
            this.name = name;
        }

        public override string GetName()
        {
            return name;
        }

        public static WorkPermitRespiratoryCartridgeType Get(long index)
        {
            return All.FindById(index);
        }
    }
}