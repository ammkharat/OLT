using System;

namespace Com.Suncor.Olt.Common.Domain.Excursions
{
    [Serializable]
    public class ToeType : SortableSimpleDomainObject
    {
        public static ToeType InvalidToeType = new ToeType(0, 0, "INVALID TOE TYPE");
        public static ToeType HighSol = new ToeType(1, 1, "SOL HIGH");
        public static ToeType LowSol = new ToeType(2, 2, "SOL LOW");
        public static ToeType HighSl = new ToeType(3, 3, "SL HIGH");
        public static ToeType LowSl = new ToeType(4, 4, "SL LOW");
        public static ToeType HighTarget = new ToeType(5, 5, "TARGET HIGH");
        public static ToeType LowTarget = new ToeType(6, 6, "TARGET LOW");

        private static readonly ToeType[] all =
        {
            HighSol, LowSol, HighSl, LowSl, HighTarget, LowTarget
        };

        private readonly string name;

        private ToeType(long id, int sortOrder, string name)
            : base(id, sortOrder)
        {
            this.name = name;
        }

        public static ToeType[] All
        {
            get { return all; }
        }

        public override string GetName()
        {
            return name;
        }

        public static ToeType Get(long index)
        {
            return GetById(index, all);
        }

        // Used during import to retain actual value when invalid
        public string TagValue { get; set; }
    }
}