using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain.Target
{
    [Serializable]
    public class TagDirection : SortableSimpleDomainObject
    {
        public static readonly TagDirection None = new TagDirection(0, 0);
        public static readonly TagDirection Read = new TagDirection(1, 1);
        public static readonly TagDirection Write = new TagDirection(2, 2);

        public static readonly TagDirection[] All = {None, Read, Write};

        private TagDirection(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == 0)
            {
                return StringResources.TagDirection_None;
            }
            if (IdValue == 1)
            {
                return StringResources.TagDirection_Read;
            }
            if (IdValue == 2)
            {
                return StringResources.TagDirection_Write;
            }
            return null;
        }

        public static TagDirection Get(long id)
        {
            return GetById(id, All);
        }
    }
}