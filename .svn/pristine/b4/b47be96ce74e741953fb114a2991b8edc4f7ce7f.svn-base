using System;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ReadStatus : SortableSimpleDomainObject
    {
        public static readonly ReadStatus Unread = new ReadStatus(0, 0);
        public static readonly ReadStatus Read = new ReadStatus(1, 1);

        private ReadStatus(long id, int sortOrder) : base(id, sortOrder)
        {
        }

        public override string GetName()
        {
            if (IdValue == Unread.IdValue)
            {
                return StringResources.ReadStatus_Unread;
            }
            if (IdValue == Read.IdValue)
            {
                return StringResources.ReadStatus_Read;
            }
            return null;
        }
    }
}