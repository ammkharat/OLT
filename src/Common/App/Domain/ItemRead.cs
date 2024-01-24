using System;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class ItemRead<T> : DomainObject where T : DomainObject, IReadable
    {
        private readonly long itemId;
        private readonly long readByUserId;
        private readonly DateTime time;

        public ItemRead(long itemId, long readByUserId, DateTime time)
        {
            this.itemId = itemId;
            this.readByUserId = readByUserId;
            this.time = time;
        }

        public ItemRead(T domainObject, User readByUser, DateTime time)
        {
            readByUserId = readByUser.IdValue;
            itemId = domainObject.IdValue;
            this.time = time;
        }

        public long ReadByUserId
        {
            get { return readByUserId; }
        }

        public long ItemId
        {
            get { return itemId; }
        }

        public DateTime Time
        {
            get { return time; }
        }
    }

    /// <summary>
    ///     Marker interace for anything that can be marked as read.
    /// </summary>
    public interface IReadable
    {
    }
}