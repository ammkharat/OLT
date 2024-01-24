using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class ConfinedSpaceStatus : SortableSimpleDomainObject
    {
        public static ConfinedSpaceStatus Pending = new ConfinedSpaceStatus(1, 1);
        public static ConfinedSpaceStatus Issued = new ConfinedSpaceStatus(2, 2);

        private static readonly ConfinedSpaceStatus[] all = {Pending, Issued};

        private ConfinedSpaceStatus(long id, int sortOrder) : base(id, sortOrder)
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

        public static ConfinedSpaceStatus Get(long index)
        {
            return GetById(index, all);
        }
    }
}