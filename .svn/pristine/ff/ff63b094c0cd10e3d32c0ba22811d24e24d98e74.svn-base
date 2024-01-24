using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class OilsandsWorkPermitType : SortableSimpleDomainObject
    {
        public static OilsandsWorkPermitType BlanketCold = new OilsandsWorkPermitType(1, 1);
        public static OilsandsWorkPermitType BlanketHot = new OilsandsWorkPermitType(2, 2);
        public static OilsandsWorkPermitType SpecificCold = new OilsandsWorkPermitType(3, 3);
        public static OilsandsWorkPermitType SpecificHot = new OilsandsWorkPermitType(4, 4);

        public static OilsandsWorkPermitType[] All = { BlanketCold, BlanketHot, SpecificCold, SpecificHot };
        public static OilsandsWorkPermitType NULL = new OilsandsWorkPermitType(0, 0);

        private OilsandsWorkPermitType(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.WorkPermitBlanketCold;
            }
            if (IdValue == 2)
            {
                return StringResources.WorkPermitBlanketHot;
            }
            if (IdValue == 3)
            {
                return StringResources.WorkPermitSpecificCold;
            }
            if (IdValue == 4)
            {
                return StringResources.WorkPermitSpecificHot;
            }
            return string.Empty;
        }

        public static OilsandsWorkPermitType Get(long index)
        {
            return GetById(index, All);
        }
    }
}