using System;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class AcidClothingType : SimpleDomainObject
    {
        public static AcidClothingType A_ACIDCLOTHINGTYPE = new AcidClothingType(0, "A");
        public static AcidClothingType B_ACIDCLOTHINGTYPE = new AcidClothingType(1, "B");
        public static AcidClothingType C_ACIDCLOTHINGTYPE = new AcidClothingType(2, "C");
        public static AcidClothingType DPLUSJACKET_ACIDCLOTHINGTYPE = new AcidClothingType(4, "D + Jacket");
        public static AcidClothingType D_ACIDCLOTHINGTYPE = new AcidClothingType(3, "D");

        private static readonly AcidClothingType[] all =
        {
            A_ACIDCLOTHINGTYPE, B_ACIDCLOTHINGTYPE, C_ACIDCLOTHINGTYPE,
            DPLUSJACKET_ACIDCLOTHINGTYPE, D_ACIDCLOTHINGTYPE
        };

        private readonly string name;

        private AcidClothingType(long id, string name) : base(id)
        {
            this.name = name;
        }

        public static AcidClothingType[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            return name;
        }

        public static AcidClothingType Get(long index)
        {
            return GetById(index, all);
        }
    }
}