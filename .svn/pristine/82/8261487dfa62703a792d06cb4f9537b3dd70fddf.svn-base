using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class ConfinedSpaceStatusMuds : SortableSimpleDomainObject
    {
        public static ConfinedSpaceStatusMuds Pending = new ConfinedSpaceStatusMuds(1, 1);
        public static ConfinedSpaceStatusMuds Issued = new ConfinedSpaceStatusMuds(2, 2);

        private static readonly ConfinedSpaceStatusMuds[] all = {Pending, Issued};

        private ConfinedSpaceStatusMuds(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.ConfinedSpaceStatus_Pending;
            }
            if (IdValue == 2)
            {
                return StringResources.ConfinedSpaceStatus_Issued;
            }

            return null;
        }

        public static ConfinedSpaceStatusMuds Get(long index)
        {
            return GetById(index, all);
        }
    }
}