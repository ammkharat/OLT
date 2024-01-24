using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public abstract class SortableSimpleDomainObject : SimpleDomainObject
    {
        protected SortableSimpleDomainObject(long id, int sortOrder) : base(id)
        {
            SortOrder = sortOrder;
        }

        public int SortOrder { get; private set; }

        public override int CompareTo(object obj)
        {
            var otherStatus = obj as SortableSimpleDomainObject;

            return otherStatus == null ? 1 : SortOrder.CompareTo(otherStatus.SortOrder);
        }
    }
}