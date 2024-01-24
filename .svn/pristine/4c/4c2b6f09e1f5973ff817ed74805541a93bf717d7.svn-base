using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public abstract class DomainObjectHistorySnapshot : DomainObject, IHistorySnapshot
    {
        protected DomainObjectHistorySnapshot(long id, User lastModifiedBy, DateTime lastModifiedDate) : base(id)
        {
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = lastModifiedDate;
        }

        public User LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}