using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Restriction
{
    [Serializable]
    public class RestrictionDefinitionStatus : SortableSimpleDomainObject
    {
        public static RestrictionDefinitionStatus Valid = new RestrictionDefinitionStatus(1, 1);
        public static RestrictionDefinitionStatus InvalidTag = new RestrictionDefinitionStatus(2, 2);

        private static readonly RestrictionDefinitionStatus[] all = {Valid, InvalidTag};

        private RestrictionDefinitionStatus(long id, int sortOrder)
            : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 1)
            {
                return StringResources.RestrictionDefinitionStatus_Valid;
            }
            if (IdValue == 2)
            {
                return StringResources.RestrictionDefinitionStatus_InvalidTag;
            }
            return null;
        }

        public static RestrictionDefinitionStatus Get(long index)
        {
            return GetById(index, all);
        }
    }
}