using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class CardEntryStatus : SortableSimpleDomainObject
    {
        public static readonly CardEntryStatus OnSite = new CardEntryStatus(1, 0);
        public static readonly CardEntryStatus OffSite = new CardEntryStatus(2, 1);
        public static readonly CardEntryStatus UnKnown = new CardEntryStatus(3, 2);

        private CardEntryStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (id == OnSite.IdValue) return "OnSite";
            if (id == OffSite.IdValue) return "OffSite";
            if (id == UnKnown.IdValue) return "UnKnown";

            throw new NotImplementedException("Please implement GetName() for all ids in CardEntryStatus.");
        }
    }
}